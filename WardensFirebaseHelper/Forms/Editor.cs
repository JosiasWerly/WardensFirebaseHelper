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

namespace WardensFirebaseHelper.Forms {
    public struct UnitPanelConfiguration {
        public int index;
        public Size size;
        public Point point;
        public Color color;

        public int maxSpawnCount;
        public string selectedEnemy;
        public int selectedEnemyQuantity;
        public IEnumerable<string> availableEnemies;
    }

    public partial class Editor : Form {
        public const int UNIT_CARD_SIZE = 40;

        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;
        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;


        FirebaseInterface dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");
        Worker dbWorker;

        public Editor() {
            try {
                dbWorker = new Worker(dataBaseInterface.dbData);
            }

            // Some cached keys can be invalid and require the db to be download again
            catch (SystemException) {
                dataBaseInterface.downloadDB();
                dbWorker = new Worker(dataBaseInterface.dbData);
            }
            
            InitializeComponent();

            waveTabs.Visible = false;
            foreach (var mapName in dbWorker.GetLevelNames())
                mapComboBox.Items.Add(mapName);
        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            challengesComboBox.Text = string.Empty;
            challengesComboBox.Items.Clear();

            for (int i = 0; i < dbWorker.GetChallengeCountOf(CurrentLevelName); i++) {
                challengesComboBox.Items.Add(i);
            }
        }

        private void challengesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            waveTabs.Visible = true;
            waveTabs.TabPages.Clear();

            if(CurrentChallenge >= 0) {
                for (int i = 0; i < dbWorker.GetWaveCountOf(CurrentLevelName, CurrentChallenge); i++) {
                    waveTabs.TabPages.Add(new TabPage() {
                        BackColor = Color.White,
                        AutoScroll = true,

                        Name = $"waveTab{i}",
                        Text = $"Wave [{i}]",
                    });


                    for (int j = 0; j < dbWorker.GetEnemyCountOf(CurrentLevelName, CurrentChallenge, i); j++) {
                        var panel = ConstructUnitCard(new UnitPanelConfiguration() {
                            index = j,
                            color = j % 2 == 0 ? Color.Bisque : Color.OldLace,

                            size = new Size(waveTabs.TabPages[i].Width, UNIT_CARD_SIZE),
                            point = new Point(0, j * UNIT_CARD_SIZE),
                            maxSpawnCount = 30,

                            availableEnemies = dbWorker.GetEnemyNames(),
                            selectedEnemy = dbWorker.GetEnemyByIndex(CurrentLevelName, CurrentChallenge, i, j),
                            selectedEnemyQuantity = dbWorker.GetEnemyQuantityByIndex(CurrentLevelName, CurrentChallenge, i, j)
                        });
                        waveTabs.TabPages[i].Controls.Add(panel);
                    }
                }
            }
        }

        private Panel ConstructUnitCard(UnitPanelConfiguration panelConfiguration) {
            Panel panel = new Panel() {
                BackColor = panelConfiguration.color,

                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = panelConfiguration.point,
                Size = panelConfiguration.size,
            };

            Label spawnLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(3, panel.Height / 3),
                Size = new Size(45, panel.Height / 2),
                Text = "Spawn: ",
            };
            panel.Controls.Add(spawnLabel);

            ComboBox spawnCombobox = new ComboBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(50, panel.Height / 4),
                Size = new Size(150, panel.Height/2),
            };
            foreach (string item in panelConfiguration.availableEnemies)
                spawnCombobox.Items.Add(item);

            spawnCombobox.SelectedItem = panelConfiguration.selectedEnemy;
            panel.Controls.Add(spawnCombobox);

            TextBox ammountTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(203, panel.Height / 4),
                Size = new Size(30, panel.Height / 2),
                Text = panelConfiguration.selectedEnemyQuantity.ToString(),
            };
            panel.Controls.Add(ammountTextBox);

            Label timesLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(233, panel.Height / 3),
                Size = new Size(45, panel.Height / 2),
                Text = "Times",
            };
            panel.Controls.Add(timesLabel);

            return panel;
        }
    }
}