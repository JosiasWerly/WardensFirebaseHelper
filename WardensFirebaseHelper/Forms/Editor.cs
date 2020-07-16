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
using System.Text.RegularExpressions;
using WardensFirebaseHelper.Structures.Levels;
using Group = WardensFirebaseHelper.Structures.Levels.Group;

namespace WardensFirebaseHelper.Forms {
    public struct UnitPanelStructures {
        public ComboBox cb_enemyClass;
        public TextBox tb_spawnPoint;
        public TextBox tb_spawnTime;
        public TextBox tb_quantity;
    }

    public partial class Editor : Form {
        public const int UNIT_CARD_SIZE = 40;
        public const int TABS_WIDTH = 750;
        public const int TABS_HEIGHT = 500;

        public IEnumerable<WavePage> CurrentWavePagesCollection => from wavePage in waveTabs.TabPages.Cast<TabPage>() select wavePage as WavePage;
        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;

        public GroupPage CurrentGroupPage => (waveTabs.TabPages[CurrentWaveIndex] as WavePage).CurrentGroup;
        public int CurrentGroupIndex => (waveTabs.TabPages[CurrentWaveIndex] as WavePage).CurrentGroupIndex;

        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;

        public bool IsSelectedChallengeValid => challengesComboBox.SelectedItem != null;
        public bool IsSelectedMapValid => mapComboBox.SelectedItem != null;


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

            waveTabs.Selected += HandleWaveSelection;

            foreach (var mapName in dbWorker.GetLevelNames())
                mapComboBox.Items.Add(mapName);
        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(mapComboBox.SelectedItem != null) {
                challengesComboBox.Text = string.Empty;
                challengesComboBox.Items.Clear();

                for (int i = 0; i < dbWorker.GetChallengeCountOf(CurrentLevelName); i++) {
                    challengesComboBox.Items.Add(i);
                }
            }
        }

        private void challengesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(challengesComboBox.SelectedItem != null && mapComboBox.SelectedItem != null) {
                waveTabs.TabPages.Clear();

                SetVisibilityForHideableContent(true);
                
                int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
                for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                    WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetGroups(CurrentLevelName, CurrentChallenge, waveIndex), dbWorker.GetEnemyNames());
                    waveTabs.TabPages.Add(wavePage);
                }
            }
        }

        private void HandleWaveSelection(object sender, EventArgs e) {
            Console.WriteLine("Aaaua");
        }

        private void SetVisibilityForHideableContent(bool visible) {
            splitContainer.Visible = visible;
            c_buttonsContainer.Visible = visible;
        }

        private void b_Save_Click(object sender, EventArgs e) {
            dbWorker.ApplyLevelChanges();
            dataBaseInterface.saveToLocal();
        }

        private void b_Reload_Click(object sender, EventArgs e) {
            dataBaseInterface.loadFromLocal();
            dbWorker = new Worker(dataBaseInterface.dbData);

            challengesComboBox.SelectedItem = null;
            mapComboBox.SelectedItem = null;

            SetVisibilityForHideableContent(false);
        }

        private void b_CreateEnemy_Click(object sender, EventArgs e) {
            if(IsSelectedMapValid && IsSelectedChallengeValid) {
                EnemySpawn enemySpawn = new EnemySpawn();

                CurrentGroupPage.Group.enemy_spawn.Add(enemySpawn);
                CurrentGroupPage.Reload();
            }
        }
    }
}