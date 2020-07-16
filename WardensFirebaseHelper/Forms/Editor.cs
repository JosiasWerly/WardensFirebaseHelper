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
        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;


        Dictionary<string, Dictionary<int, List<WavePage>>> challengesByLevelName = new Dictionary<string, Dictionary<int, List<WavePage>>>();
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
            SetWavesTabVisibility(false);

            foreach (var mapName in dbWorker.GetLevelNames())
                mapComboBox.Items.Add(mapName);
        }
        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            challengesComboBox.Text = string.Empty;
            challengesComboBox.Items.Clear();

            if (!challengesByLevelName.ContainsKey(CurrentLevelName)) {
                challengesByLevelName.Add(CurrentLevelName, new Dictionary<int, List<WavePage>>());
            }

            for (int i = 0; i < dbWorker.GetChallengeCountOf(CurrentLevelName); i++) {
                challengesComboBox.Items.Add(i);
            }

            SetWavesTabVisibility(IsSelectionValid());
        }

        private void challengesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //SaveToLocal();
            waveTabs.TabPages.Clear();
            SetWavesTabVisibility(IsSelectionValid());

            if (!challengesByLevelName[CurrentLevelName].ContainsKey(CurrentChallenge)) {
                challengesByLevelName[CurrentLevelName].Add(CurrentChallenge, new List<WavePage>());
            }

            if (CurrentChallenge >= 0) {
                int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
                for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                    WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetGroups(CurrentLevelName, CurrentChallenge, waveIndex), dbWorker.GetEnemyNames());
                    challengesByLevelName[CurrentLevelName][CurrentChallenge].Add(wavePage);
                    waveTabs.TabPages.Add(wavePage);
                }
            }
        }


        private void SetWavesTabVisibility(bool visible) {
            splitContainer.Visible = visible;
        }

        private bool IsSelectionValid() {
            return (mapComboBox.SelectedIndex >= 0 && mapComboBox.SelectedIndex <= mapComboBox.Items.Count)
                    && (challengesComboBox.SelectedIndex >= 0 && challengesComboBox.SelectedIndex < challengesComboBox.Items.Count);
        }
        
        private void SaveToLocal() {
            dbWorker.ApplyLevelChanges();
            dataBaseInterface.saveToLocal();
        }

        private void b_Save_Click(object sender, EventArgs e) {
            SaveToLocal();
        }
    }
}