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

        public int GetEnemyQuantityByIndex(string levelName, int challengeIndex, int waveIndex, int enemyIndex) {
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
        public int GetWaveCountOf(string levelName, int challengeIndex) {
            return Levels[levelName].challenges[challengeIndex].waves.Count;
        }
        public int GetChallengeCountOf(string levelName) {
            return Levels[levelName].challenges.Count;
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
    }
}
