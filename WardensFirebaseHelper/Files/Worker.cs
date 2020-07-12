using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

using WardensFirebaseHelper.Structures.Enemies;
using WardensFirebaseHelper.Structures.Levels;

namespace WardensFirebaseHelper.Files {
    public class Worker {
        const string ENEMIES_KEY = "Enemies";
        const string LEVELS_KEY = "Levels";

        JObject database;
        Levels Levels { get; set; }
        Enemies Enemies { get; set; }

        public Worker(JObject database) {
            this.database = database;

            Levels = this.database[LEVELS_KEY].ToObject<Levels>();
            Enemies = this.database[ENEMIES_KEY].ToObject<Enemies>();
        }

        public IEnumerable<Level> GetLevelObjects() {
            return from map
                   in Levels.Values
                   select map;
        }
        public IEnumerable<string> GetLevelNames() {
            return from map
                   in Levels.Keys
                   select map;
        }
    }
}
