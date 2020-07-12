using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using LevelData;

namespace WardensFirebaseHelper.Files {
    public class Disposer {
        const string MAP_KEY = "Levels";
        const string CHALLANGE_KEY = "challenges";

        JObject database;

        public Disposer(JObject database) => this.database = database;

        public List<string> GetWaves() {
            List<string> waves = new List<string>();

            foreach(var item in database[MAP_KEYS][CHALLANGE_KEY]["0"]["waves"]) {
                //waves.Add(JsonConvert.DeserializeObject<Wave>(json))
            }
        }

    }
}