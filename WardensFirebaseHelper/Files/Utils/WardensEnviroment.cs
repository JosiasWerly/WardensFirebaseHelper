using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace WardensFirebaseHelper {
    public static class WardensEnviroment {
        public static IEnumerable<string> AvailableEnemies { get; set; }
        public static Dictionary<string, int> HPByEnemyClass { get; set; }
    }
}
