using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace WardensFirebaseHelper.Files {
    public class Disposer {
        const string MAP_KEY = "Levels";
        const string CHALLANGE_KEY = "challenges";

        JObject database;

        public Disposer(JObject database) => this.database = database;

    }
}