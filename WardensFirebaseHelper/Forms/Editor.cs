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

        public bool SelectedWaveIsValid => waveTabs.SelectedTab != null;


        FirebaseInterface dataBaseInterface;
        Worker dbWorker;

        public Editor() {


            dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");

            var option = MessageBox.Show("Would you like to use the latest version of the databse?", "Startup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option.Equals(DialogResult.Yes)) {
                dataBaseInterface.downloadDB();
            }
            else {
                MessageBox.Show("You're currently using the local copy of the databse, this may not contain the latest changes. Beware when uploading!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataBaseInterface.loadFromLocal();
            }

            //onException?.Invoke(e);
            try {
                dbWorker = new Worker(dataBaseInterface.dbData);

                InitializeComponent();
                SetVisibilityForHideableContent(false);

                WardensEnviroment.AvailableEnemies = dbWorker.GetEnemyNames();

                ResetOwnedMaps();
            }
            catch(JsonReaderException e) {
                MessageBox.Show("Database error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
                this.Close();
            }
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
            catch(Exception) {
                return false;
            }
        }

        private bool UploadData() {
            try {
                dbWorker.ApplyLevelChanges();
                dataBaseInterface.uploadDB();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        private void ReloadWavesTab() {
            waveTabs.TabPages.Clear();

            int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
            for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetWave(CurrentLevelName, CurrentChallenge, waveIndex), HandleDeleteWaveButtonClicked);
                waveTabs.TabPages.Add(wavePage);
            }
        }

        private void SoftReload() {
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

        private void ResetOwnedMaps() {
            foreach (var mapName in dbWorker.GetLevelNames())
                mapComboBox.Items.Add(mapName);
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

                tb_mapName.Text = CurrentLevelName;
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

        private void b_ReloadLocal_Click(object sender, EventArgs e) {
            dataBaseInterface.loadFromLocal();
            dbWorker = new Worker(dataBaseInterface.dbData);

            SoftReload();
        }

        private void b_ReloadOnline_Click(object sender, EventArgs e)
        {
            try
            {
                dataBaseInterface.downloadDB();
                dbWorker = new Worker(dataBaseInterface.dbData);

                SoftReload();

                MessageBox.Show("Database successfully downloaded!", "Database download", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Database download failed!", "Database download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
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
            if(SelectedMapIsValid && SelectedChallengeIsValid && SelectedWaveIsValid) {
                CurrentWavePage.Wave.groups.Add(new Group());
                CurrentWavePage.Reload();
            }
            else {
                Task.Run(() => {
                    MessageBox.Show("Please. You must create a wave firts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
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

        private void b_CreateMap_Click(object sender, EventArgs e) {
            dbWorker.CreateLevel();

            ResetOwnedMaps();

            mapComboBox.SelectedIndex = mapComboBox.Items.Count - 1;
            mapComboBox.Select();
            mapComboBox.Focus();

            challengesComboBox.SelectedIndex = 0;
            challengesComboBox.Select();
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
                    SoftReload();
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

        private void textBox3_TextChanged(object sender, EventArgs e) {
            if (SelectedMapIsValid) {
                dbWorker.ReplaceLevel(CurrentLevelName, (sender as TextBox).Text);
                mapComboBox.Text = (sender as TextBox).Text;

                ResetOwnedMaps();
            }
        }

        private void tb_mapName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                dbWorker.ReplaceLevel(CurrentLevelName, (sender as TextBox).Text);
                mapComboBox.Text = (sender as TextBox).Text;
            }
        }

        private void HandleDeleteWaveButtonClicked(object sender, EventArgs e)
        {
            dbWorker.Delete(CurrentLevelName, CurrentChallenge, ((sender as Control).Parent as WaveInfoPanel).Wave);
            if (!HardReload())
            {
                SoftReload();
            }
        }
    }
}