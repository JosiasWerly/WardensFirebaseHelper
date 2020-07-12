using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System;

using WardensFirebaseHelper.Structures;
using WardensFirebaseHelper.Files;

namespace WardensFirebaseHelper.Forms {
    public partial class Editor : Form {
        FirebaseInterface dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");
        Worker dbWorker;
        public Editor() {
            dbWorker = new Worker(dataBaseInterface.dbData);
            InitializeComponent();

            foreach (var mapName in dbWorker.GetLevelNames()) {
                mapComboBox.Items.Add(mapName);
            }

            //Structures.Levels.Root levels = dataBaseInterface.dbData.ToObject<Structures.Levels.Root>();
            //Structures.Enemies.Root enemies = dataBaseInterface.dbData.ToObject<Structures.Enemies.Root>();

            Console.WriteLine("FUN");

        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}

