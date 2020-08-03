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

    public delegate void JsonExceptionDelegate(JsonReaderException e);

    public class Worker {
        const string ENEMIES_KEY = "Enemies";
        const string LEVELS_KEY = "Levels";

        public JObject DataBase => database;

        Enemies Enemies { get; set; }
        Levels Levels { get; set; }
        JObject database;

        public Worker(JObject database, JsonExceptionDelegate onException = null)
        {
            try {
                this.database = database;
                Levels = this.database[LEVELS_KEY].ToObject<Levels>();
                Enemies = this.database[ENEMIES_KEY].ToObject<Enemies>();
            }
            catch (JsonReaderException e) {
                throw e;
            }
        }

        public IEnumerable<Group>  GetGroups(string levelName, int challegeIndex, int waveIndex) {
            return Levels[levelName].challenges[challegeIndex].waves[waveIndex].groups;
        }
        public IEnumerable<Wave> GetWavesOf(string levelName, int challengeIndex) {
            return from wave
                   in Levels[levelName].challenges[challengeIndex].waves
                   select wave;
        }
        public IEnumerable<Challenge> GetChallengesOf(string levelName) {
            return from cLevel
                   in Levels[levelName].challenges
                   select cLevel;
        }

        public IEnumerable<Level> GetLevelObjects() {
            return from map
                   in Levels.Values
                   select map;
        }

        public IEnumerable<string> GetEnemyNames() {
            return from enemy
                   in Enemies.Keys
                   select enemy;
        }
        public IEnumerable<string> GetLevelNames() {
            return from map
                   in Levels.Keys
                   select map;
        }

        public int GetSpawnQuantityOf(string levelName, int challengeIndex, int waveIndex, int groupIndex, int enemyIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex].enemy_spawn[enemyIndex].quantity;
        }
        public string GetEnemyByIndex(string levelName, int challengeIndex, int waveIndex, int groupIndex, int enemyIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex].enemy_spawn[enemyIndex].enemy_class;
        }
        public string GetEnemyByIndex(string levelName, int challengeIndex, int waveIndex, int enemyIndex) {
            //return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[]
            int count = 0;
            for (int i = 0; i < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups.Count; i++) {
                for (int j = 0; j < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[i].enemy_spawn.Count; j++) {
                    if(enemyIndex.Equals(count)) {
                        return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[i].enemy_spawn[j].enemy_class;
                    }

                    count++;
                }
            }

            return string.Empty;
        }
        public string GetSpawnLocationOf(string levelName, int challengeIndex, int waveIndex, int groupIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex].spawn_location;
        }

        public int GetEnemySpawnQuantityByIndex(string levelName, int challengeIndex, int waveIndex, int enemyIndex) {
            int count = 0;
            for (int i = 0; i < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups.Count; i++) {
                for (int j = 0; j < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[i].enemy_spawn.Count; j++) {
                    if (enemyIndex.Equals(count)) {
                        return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[i].enemy_spawn[j].quantity;
                    }

                    count++;

                }
            }

            return 0;
        }
        public int GetSpawnTimeOf(string levelName, int challengeIndex, int waveIndex, int groupIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex].spawn_time;
        }
        public int GetGroupCountOf(string levelName, int challengeIndex, int waveIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups.Count;
        }
        public int GetWaveCountOf(string levelName, int challengeIndex) {
            return Levels[levelName].challenges[challengeIndex].waves.Count;
        }
        public int GetChallengeCountOf(string levelName) {
            return Levels[levelName].challenges.Count;
        }


        public int GetEnemyCountOf(string levelName, int challengeIndex, int waveIndex, int groupIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex].enemy_spawn.Count;
        }
        public int GetEnemyCountOf(string levelName, int challengeIndex, int waveIndex) {
            int count = 0;
            for (int i = 0; i < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups.Count; i++) {
                for (int j = 0; j < Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[i].enemy_spawn.Count; j++) {
                    count++;
                }
            }

            return count;
        }

        public Group GetGroup(string levelName, int challengeIndex, int waveIndex, int groupIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex].groups[groupIndex];
        }
        public Wave GetWave(string levelName, int challengeIndex, int waveIndex) {
            return Levels[levelName].challenges[challengeIndex].waves[waveIndex];
        }

        public Challenge GetChallenge (string levelName, int challengeIndex) {
            return Levels[levelName].challenges[challengeIndex];
        }

        public void ApplyLevelChanges() => database[LEVELS_KEY] = JToken.FromObject(Levels);
        public void ApplyEnemyChanges() => database[ENEMIES_KEY] = JToken.FromObject(Enemies);


        public void ReplaceLevel(string name, string newName) {
            if (!string.IsNullOrEmpty(newName) && newName != name) {
                if (Levels.ContainsKey(name)) {
                    Level level = Levels[name];
                    Levels.Remove(name);

                    Levels.Add(newName, level);
                }
            }
        }
        public void Delete(string currentLevel, int challengeIndex, Wave wave)
        {
            Levels[currentLevel].challenges[challengeIndex].waves.Remove(wave);
        }
        public Level CreateLevel() {
            string mapName = "new level";
            if (Levels.ContainsKey(mapName)) {
                int tries = 0;
                mapName += $" {tries}";

                while (Levels.ContainsKey(mapName)) {
                    tries++;
                    var pieces = mapName.Split();
                    mapName = $"{pieces[0]} {pieces[1]} {tries}";
                }
            }

            Levels.Add(mapName, new Level(true));
            return Levels[mapName];
        }

    }
}