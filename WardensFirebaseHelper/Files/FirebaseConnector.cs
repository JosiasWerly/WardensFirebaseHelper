using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WardensFirebaseHelper.Files {
    public class AAA {
        public string A { get;  }
    }

    public class FirebaseConnector {
        string dbURL, dbPassword;
        public FirebaseConnector() { }
        public FirebaseConnector(string url, string password) {
            init(url, password);
        }
        public void init(string url, string password) {
            dbURL = url;
            dbPassword = "?api_key=" + password;
        }
        public Type downloadData<Type>(string key) {
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api_key=", dbPassword);
            HttpResponseMessage response = client.GetAsync(dbPassword).Result;
            Type outData = default(Type);
            if (response.IsSuccessStatusCode) {
                outData = response.Content.ReadAsAsync<Type>().Result;
            }
            client.Dispose();
            return outData;
        }
        public void uploadData<Type>(string key, Type type) {
            string outJson = JsonConvert.SerializeObject(type);
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Authorization = null;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api_key=", dbPassword);
            //HttpResponseMessage response = client.PostAsync("?api_key="+dbPassword, new StringContent(outJson, UnicodeEncoding.UTF8, "application/json")).Result;

            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Put,
                //RequestUri = new Uri(dbPassword,UriKind.Absolute),
                Content = new StringContent(outJson, UnicodeEncoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            client.Dispose();
        }


        public JObject downloadJson(string key) {
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(dbPassword).Result;
            JObject outData = null;
            if (response.IsSuccessStatusCode) {
                outData = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            }
            client.Dispose();
            return outData;
        }
        public void uploadJson(string key, JObject data) {
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Authorization = null;
            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(data), UnicodeEncoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            client.Dispose();
        }

    }
    public class FirebaseInterface {
        string dbLocalPath = "";
        FirebaseConnector fb = new FirebaseConnector("https://bigmoxiwardens.firebaseio.com/", "AIzaSyDDiV0BvrE0TUA3t7BzwVkz2pH5Ybs8Fgs");
        public JObject dbData;

        public FirebaseInterface(string filePath){
            if(filePath == "")
                throw new System.InvalidOperationException("db local instance needs a path");
            dbLocalPath = filePath;            
            try {
                loadFromLocal();
            }
            catch (Exception) {
                downloadDB();
            }
        }
        public void downloadDB() {
            dbData = fb.downloadJson("");
            saveToLocal();
        }
        public void uploadDB() {
            if (dbData == null)
                throw new System.InvalidOperationException("dbLocalNotFound");
            fb.uploadJson("", dbData);
        }

        public void loadFromLocal() {
            if (File.Exists(dbLocalPath))
                dbData = JObject.Parse(File.ReadAllText(dbLocalPath));
            else
                throw new System.InvalidOperationException("dbLocalNotFound");
        }
        public void saveToLocal() {
            File.WriteAllText(dbLocalPath, JsonConvert.SerializeObject(dbData));
        }
    }
}
