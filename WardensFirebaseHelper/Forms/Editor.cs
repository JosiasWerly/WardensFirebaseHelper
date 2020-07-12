using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WardensFirebaseHelper.Files;
using WardensFirebaseHelper.Files.LevelData;

namespace WardensFirebaseHelper.Forms {
    public partial class Editor : Form {
        FirebaseInterface dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");
        
        public Editor() {            
            InitializeComponent();
            FakeLevel f = new FakeLevel();
            var d = dataBaseInterface.dbData;
            
        }
    }
}

