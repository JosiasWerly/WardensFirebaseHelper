using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardensFirebaseHelper.Files {
    namespace LevelData {
        public struct sInfo {
            public string displayName, shortDescription, longDescription;
        }
        public class Level {
            public sInfo info;
            public string name = "noName";
            public int victoryPoints = 0;
            public List<Challenge> challenges = new List<Challenge>();
        }
        public class Challenge {
            public List<Wave> waves = new List<Wave>();
        }
        public class Wave {
            public float time_limit;
            public string wave_name;
            public List<Group> groups = new List<Group>();
        }
        public class Group {
            public float spawn_time;
            public string spawn_location;
            public Dictionary<string, int> enemies;
        }
        
        public class FakeLevel : Level {
            Random rnd = new Random();
            string getRndList(ref List<string> ls) {
                return ls[rnd.Next(0, ls.Count)];
            }
            public Dictionary<string, int> generateEnemies() {
                List<string> EnemiesNames = new List<string>{
                    "goblin_bomber",
                    "goblin_crossbow",
                    "goblin_gunner"
                };
                Dictionary<string, int> outData = new Dictionary<string, int>();
                for (int i = 0; i < 10; i++) {
                    outData[getRndList(ref EnemiesNames)] = rnd.Next(2, 10);
                }
                return outData;
            }
            public List<Group> generateGroups() {
                List<string> portalNames = new List<string>{
                    "portal0",
                    "portal1",
                    "portal2"
                };
                List<Group> outData = new List<Group>();
                for (int i = 0; i < rnd.Next(5); i++) {
                    Group g = new Group();
                    g.spawn_location = getRndList(ref portalNames);
                    g.spawn_time = i * 20;
                    g.enemies = generateEnemies();
                    outData.Add(g);
                }
                return outData;
            }
            public List<Wave> generateWaves() {
                List<Wave> dataOut = new List<Wave>();
                for (int i = 0; i < rnd.Next(5); i++) {
                    Wave w = new Wave();
                    w.groups = generateGroups();
                    dataOut.Add(w);
                }
                return dataOut;
            }
            public List<Challenge> generateChallenges() {
                List<Challenge> dataOut = new List<Challenge>();
                for (int i = 0; i < rnd.Next(2, 4); i++) {
                    Challenge c = new Challenge();
                    c.waves = generateWaves();
                    dataOut.Add(c);
                }
                return dataOut;
            }
            public FakeLevel() {
                name = "funmap";
                victoryPoints = 25;
                info.displayName = "fake";
                info.longDescription = "fakeShortDescription";
                info.shortDescription = "fakeLongDescription";
                this.challenges = generateChallenges();
            }
        }
        
    }
}
