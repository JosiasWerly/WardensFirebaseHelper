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
            public Dictionary<string, int> generateEnemies() {
                List<string> EnemiesNames = new List<string>{
                    "goblin_bomber",
                    "goblin_crossbow",
                    "goblin_gunner"
                };
                Random rnd = new Random();
                Dictionary<string, int> outData = new Dictionary<string, int>();
                for (int i = 0; i < 10; i++) {
                    //rnd enemyname, rnd enemyQuantity
                    outData[EnemiesNames[rnd.Next(0, EnemiesNames.Count)]] = rnd.Next(2, 10);
                }
                return outData;
            }
            public Group generateGroup() {
                Group g = new Group();
                g.enemies = generateEnemies();
                for (int i = 0; i < 10; i++) {
                    //g.
                }
                return g;
            }
            public FakeLevel() {
                
                info.displayName = "fake";
                info.longDescription = "fakeShortDescription";
                info.shortDescription = "fakeLongDescription";

                challenges = new List<Challenge>(2);
                challenges[0].waves = new List<Wave>(3);
                challenges[0].waves[0].time_limit = 10;
                challenges[0].waves[0].wave_name = "";
                challenges[0].waves[0].groups



            }
        }
    }
}
