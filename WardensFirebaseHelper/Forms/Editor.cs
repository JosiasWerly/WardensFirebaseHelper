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

        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;
        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;


        Dictionary<string, Dictionary<int, object>> challengesByLevelName = new Dictionary<string, Dictionary<int, object>>();
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

            for (int i = 0; i < dbWorker.GetChallengeCountOf(CurrentLevelName); i++) {
                challengesComboBox.Items.Add(i);
            }

            SetWavesTabVisibility(IsSelectionValid());
        }

        private void challengesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            waveTabs.TabPages.Clear();
            SetWavesTabVisibility(IsSelectionValid());

            if (CurrentChallenge >= 0) {
                int waveCount = dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge);
                for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                    WavePage wavePage = new WavePage(waveIndex, new Size(TABS_WIDTH, TABS_HEIGHT), dbWorker.GetGroups(CurrentLevelName, CurrentChallenge, waveIndex), dbWorker.GetEnemyNames());
                    waveTabs.TabPages.Add(wavePage);
                }


                //for (int waveIndex = 0; waveIndex < waveCount; waveIndex++) {
                //    // Create a "Wave page" for each wave
                //    waveTabs.TabPages.Add(new TabPage() {
                //        BackColor = Color.White,
                //        AutoScroll = true,

                //        Name = $"waveTab{waveIndex}",
                //        Text = $"Wave [{waveIndex}]",
                //    });

                //    // Create a "Group tab" for each "Wave page"
                //    // Container of the list of groups in each wave
                //    TabControl groupTab = new TabControl() {
                //        Location = new Point(0, 0),
                //        Size = new Size(TABS_WIDTH, TABS_HEIGHT),
                //    };
                //    groupTabList.Add(groupTab);

                //    int groupCount = dbWorker.GetGroupCountOf(CurrentLevelName, CurrentChallenge, waveIndex);
                //    for (int groupIndex = 0; groupIndex < groupCount; groupIndex++) {
                //        // Create a "Group page" for each group
                //        GroupPage groupPage = new GroupPage($"Group {groupIndex}", dbWorker.GetGroup(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex), dbWorker.GetEnemyNames());
                //        groupTab.TabPages.Add(groupPage);
                //    }

                //    waveTabs.TabPages[waveIndex].Controls.Add(groupTab);
                //}
            }
        }


        private void SetWavesTabVisibility(bool visible) {
            splitContainer.Visible = visible;
        }

        private bool IsSelectionValid() {
            return (mapComboBox.SelectedIndex >= 0 && mapComboBox.SelectedIndex <= mapComboBox.Items.Count)
                    && (challengesComboBox.SelectedIndex >= 0 && challengesComboBox.SelectedIndex < challengesComboBox.Items.Count);
        }

    }
}