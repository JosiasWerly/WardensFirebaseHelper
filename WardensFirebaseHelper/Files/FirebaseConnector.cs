using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WardensFirebaseHelper.Files {
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


        public Type downloadJson(string key) {
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(dbPassword).Result;
            Type outData = default(Type);
            if (response.IsSuccessStatusCode) {
                outData = response.Content.ReadAsAsync<Type>().Result;
            }
            client.Dispose();
            return outData;
        }
        public void uploadJson(string key, Type type) {
            string outJson = JsonConvert.SerializeObject(type);
            string URL = dbURL + key + "/.json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Authorization = null;
            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Put,
                Content = new StringContent(outJson, UnicodeEncoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            client.Dispose();
        }
    }
}
