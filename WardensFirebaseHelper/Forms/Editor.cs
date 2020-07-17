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

using WardensFirebaseHelper.Files;
using WardensFirebaseHelper.Files.FormHelpers;

using WardensFirebaseHelper.Structures.Levels;
using Group = WardensFirebaseHelper.Structures.Levels.Group;

namespace WardensFirebaseHelper.Forms {
    public partial class Editor : Form {
        public const int TABS_WIDTH = 750;
        public const int TABS_HEIGHT = 500;

        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;

        public GroupPage CurrentGroupPage => CurrentWavePage != null ? CurrentWavePage.CurrentGroup : null;
        public int CurrentGroupIndex => (waveTabs.TabPages[CurrentWaveIndex] as WavePage).CurrentGroupIndex;

        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public WavePage CurrentWavePage {
            get {
                return (CurrentWaveIndex >= 0 && CurrentWaveIndex <= waveTabs.TabPages.Count) ?
                    waveTabs.TabPages[CurrentWaveIndex] as WavePage :
                    null;
            }
        }

        public string CurrentLevelName => mapComboBox.Text;

        public bool SelectedChallengeIsValid => challengesComboBox.SelectedItem != null;
        public bool SelectedMapIsValid => mapComboBox.SelectedItem != null;


        FirebaseInterface dataBaseInterface;
        Worker dbWorker;

        public Editor() {
            dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");

            // Some cached keys can be invalid and require the db to be download again
            try { dbWorker = new Worker(dataBaseInterface.dbData); }
            catch (SystemException) {
                dataBaseInterface.downloadDB();
                dbWorker = new Worker(dataBaseInterface.dbData);
            }
            
            InitializeComponent();
            SetVisibilityForHideableContent(false);

            foreach (var mapName in dbWorker.GetLevelNames())
                mapComboBox.Items.Add(mapName);

            WardensEnviroment.AvailableEnemies = dbWorker.GetEnemyNames();
        }

        private void SetVisibilityForHideableContent(bool visible) {
            splitContainer.Visible = visible;
            c_buttonsContainer.Visible = visible;
        }


        private bool SaveData() {
            try {
                dbWorker.ApplyLevelChanges();
                dataBaseInterface.saveToLocal();
                return true;
            }
            catch(Exception e) {
                return false;
            }
        }

        private bool UploadData() {
            try {
                dbWorker.ApplyLevelChanges();
                dataBaseInterface.uploadDB();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        private void ReloadWavesTab() {
            waveTabs.TabPages.Clear();

            int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
            for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetWave(CurrentLevelName, CurrentChallenge, waveIndex));
                waveTabs.TabPages.Add(wavePage);
            }
        }

        private void SimpleReloadAction() {
            if (CurrentWavePage != null) {
                CurrentWavePage.GroupControl.SelectedIndex = 0;
                waveTabs.SelectedIndex = 0;
            }

            mapComboBox.Text = challengesComboBox.Text= string.Empty;
            SetVisibilityForHideableContent(false);
        }

        private bool HardReload() {
            if(CurrentWavePage != null) {
                ReloadWavesTab();
                return true;
            }

            return false;
        }


        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            // Display a MsgBox asking the user to save changes or abort.
            var option = MessageBox.Show("Do you want to save changes your changes?", "Wave editor", MessageBoxButtons.YesNoCancel);

            if      (option == DialogResult.Yes)    b_Save_Click(null, null);
            else if (option == DialogResult.Cancel) e.Cancel = true;
        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(mapComboBox.SelectedItem != null) {
                challengesComboBox.Items.Clear();

                for (int i = 0; i < dbWorker.GetChallengeCountOf(CurrentLevelName); i++) {
                    challengesComboBox.Items.Add(i);
                }

                challengesComboBox.Text = string.Empty;
                challengesComboBox.SelectedItem = null;
                SetVisibilityForHideableContent(false);
            }
        }

        private void challengesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(challengesComboBox.SelectedItem != null && mapComboBox.SelectedItem != null) {
                ReloadWavesTab();

                SetVisibilityForHideableContent(true);
            }
        }


        private void b_Save_Click(object sender, EventArgs e) {
            if (SaveData()) {
                MessageBox.Show("Save successful!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Save failed!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_Reload_Click(object sender, EventArgs e) {
            dataBaseInterface.loadFromLocal();
            dbWorker = new Worker(dataBaseInterface.dbData);

            SimpleReloadAction();
        }

        private void b_CreateEnemy_Click(object sender, EventArgs e) {
            if(SelectedMapIsValid && SelectedChallengeIsValid) {
                EnemySpawn enemySpawn = new EnemySpawn();

                if(CurrentGroupPage != null && CurrentGroupPage.Group != null) {
                    CurrentGroupPage.Group.enemy_spawn.Add(enemySpawn);
                    CurrentGroupPage.Reload();
                }
                else {
                    Task.Run(() => {
                        MessageBox.Show("Please. You must create a group firts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }

        private void b_CreateGroup_Click(object sender, EventArgs e) {
            if(SelectedMapIsValid && SelectedChallengeIsValid) {

                Task.Run(() => {
                    var dialogBox = MessageBox.Show("Wait while the page is reloading...", "Warning", MessageBoxButtons.OK);
                });

                CurrentWavePage.Wave.groups.Add(new Group());
                CurrentWavePage.Reload();
            }
        }

        private void b_CreateWave_Click(object sender, EventArgs e) {
            if (SelectedMapIsValid && SelectedChallengeIsValid) {
                Challenge currentChallenge = dbWorker.GetChallenge(CurrentLevelName, CurrentChallenge);
                currentChallenge.waves.Add(new Wave());

                ReloadWavesTab();
                waveTabs.SelectedIndex = waveTabs.TabCount - 1;
            }
        }

        private void b_Upload_Click(object sender, EventArgs e) {
            if (UploadData()) {
                MessageBox.Show("Upload successful!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Upload failed!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_Import_Click(object sender, EventArgs e) {
            openFileDialog1 = new OpenFileDialog() {
                RestoreDirectory = true,

                Filter = "Json files (*.json)|*.json",
                FilterIndex = 1,

                Title = "Browse Database file",
                DefaultExt = "json",
            };

            var result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                dataBaseInterface = new FirebaseInterface(openFileDialog1.FileName);
                dbWorker = new Worker(dataBaseInterface.dbData);

                MessageBox.Show("Database file imported successfully!", "Import operation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!HardReload()) {
                    SimpleReloadAction();
                }
            }
        }

        private void b_Export_Click(object sender, EventArgs e) {

            var result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                dbWorker.ApplyLevelChanges();
                dbWorker.ApplyEnemyChanges();

                System.IO.File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(dbWorker.DataBase));

                MessageBox.Show("Database file exported successfully!", "Export operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}