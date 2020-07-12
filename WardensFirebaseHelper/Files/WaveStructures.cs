using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardensFirebaseHelper.Files {
    namespace LevelData {
        //https://json2csharp.com/
        public class InfoData {
            public string DisplayName { get; set; }
            public string LargeDescription { get; set; }
            public string ShortDescription { get; set; }

        }

        public class EnemySpawn {
            public string enemy_class { get; set; }
            public int quantity { get; set; }

        }

        public class Group {
            public List<EnemySpawn> enemy_spawn { get; set; }
            public string spawn_location { get; set; }
            public int spawn_time { get; set; }

        }

        public class Wave {
            public List<Group> groups { get; set; }
            public int time_limit { get; set; }
            public string wave_name { get; set; }

        }

        public class Challenge {
            public InfoData Info_data { get; set; }
            public List<string> missions { get; set; }
            public int victoryPoints { get; set; }
            public List<Wave> waves { get; set; }

        }

        public class InfoData2 {
            public string DisplayName { get; set; }
            public string LargeDescription { get; set; }
            public string ShortDescription { get; set; }

        }

        public class Canopycircuit {
            public List<Challenge> challenges { get; set; }
            public InfoData2 info_data { get; set; }
            public List<string> levels_unlock { get; set; }
            public List<string> region_unlock { get; set; }

        }

        public class Root {
            public Canopycircuit canopycircuit { get; set; }

        }
        
    }
}
