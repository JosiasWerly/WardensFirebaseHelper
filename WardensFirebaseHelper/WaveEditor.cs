using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Schema;
using WardensFirebaseHelper.Files;

namespace WardensFirebaseHelper {
    public class DataBaseInterface {
        string dbLocalPath = Application.StartupPath + "\\dbLocal.json";
        FirebaseConnector fb = new FirebaseConnector("https://bigmoxiwardens.firebaseio.com/", "AIzaSyDDiV0BvrE0TUA3t7BzwVkz2pH5Ybs8Fgs");
        JObject dbData;
        
        public DataBaseInterface() {
        }
        public void downloadDB() {            
            dbData = fb.downloadJson("");
            saveToLocal();
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
    public partial class WaveEditor : Form {
        DataBaseInterface dataBaseInterface = new DataBaseInterface();
        public WaveEditor() {
            InitializeComponent();
            //dataBaseInterface.updateLocalFile();
        }
    }
}
