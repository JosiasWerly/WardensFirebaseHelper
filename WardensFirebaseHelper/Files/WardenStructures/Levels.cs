using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace WardensFirebaseHelper.Structures.Levels {

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root {
        public Levels Levels { get; set; }
    }

    public class Level {
        public List<Challenge> challenges { get; set; }
        public InfoData info_data { get; set; }
        public List<string> levels_unlock { get; set; }
        public List<string> region_unlock { get; set; }
    }

    public class Challenge {
        public InfoData Info_data { get; set; }
        public List<string> missions { get; set; }
        public int victoryPoints { get; set; }
        public List<Wave> waves { get; set; }
    }

    public class Wave {
        public List<Group> groups { get; set; }
        public int time_limit { get; set; }
        public string wave_name { get; set; }

        public Wave() {
            groups = new List<Group>();
        }
    }

    public class Group {
        public List<EnemySpawn> enemy_spawn { get; set; }
        public string spawn_location { get; set; }
        public int spawn_time { get; set; }

        public Group() {
            enemy_spawn = new List<EnemySpawn>();
        }
    }

    public class EnemySpawn {
        public string enemy_class { get; set; }
        public int quantity { get; set; }
    }

    public class InfoData {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }



    public class Canopycircuit : Level { }

    public class Crimsoncanyon : Level { }

    public class Cryodome : Level { }

    public class Riptideretreat : Level { }

    public class Snaketails : Level { }

    public class Splitriver : Level { }

    public class Test : Level { }

    public class Woodlandrun : Level { }

    public class Levels : Dictionary<string, Level> { }
}
