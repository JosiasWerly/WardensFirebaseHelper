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
        public const int UNIT_CARD_SIZE = 40;
        public const int TABS_WIDTH = 750;
        public const int TABS_HEIGHT = 500;

        public IEnumerable<WavePage> CurrentWavePagesCollection => from wavePage in waveTabs.TabPages.Cast<TabPage>() select wavePage as WavePage;
        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;

        public GroupPage CurrentGroupPage => (waveTabs.TabPages[CurrentWaveIndex] as WavePage).CurrentGroup;
        public int CurrentGroupIndex => (waveTabs.TabPages[CurrentWaveIndex] as WavePage).CurrentGroupIndex;

        public WavePage CurrentWavePage => (WavePage)waveTabs.TabPages[CurrentWaveIndex];

        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;

        public bool SelectedChallengeIsValid => challengesComboBox.SelectedItem != null;
        public bool SelectedMapIsValid => mapComboBox.SelectedItem != null;


        List<TabControl> groupTabList = new List<TabControl>();
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

        private void ReloadWavesTab() {
            waveTabs.TabPages.Clear();

            int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
            for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetWave(CurrentLevelName, CurrentChallenge, waveIndex));
                waveTabs.TabPages.Add(wavePage);
            }
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

            mapComboBox.SelectedIndex = 0;
            challengesComboBox.SelectedIndex = 0;
            waveTabs.SelectedIndex = 0;
            CurrentWavePage.GroupControl.SelectedIndex = 0;

            //SetVisibilityForHideableContent(false);
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
    }
}