using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using WardensFirebaseHelper.Structures.Levels;

namespace WardensFirebaseHelper {
    public delegate Wave WaveGetAction(Group group);

    public static class WardensEnviroment {
        public static IEnumerable<string> AvailableEnemies { get; set; }
        public static Dictionary<string, int> HPByEnemyClass { get; set; }

        public static WaveGetAction GetWaveFor { get; set; }
    }
}
