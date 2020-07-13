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

        public int spawnTime;
        public string spawnEnemyAt;
        public string selectedEnemy;
        public int selectedEnemyQuantity;
        public IEnumerable<string> availableEnemies;
    }

    public struct UnitPanelStructures {
        public ComboBox cb_enemyClass;
        public TextBox tb_spawnPoint;
        public TextBox tb_spawnTime;
        public TextBox tb_quantity;
    }

    public partial class Editor : Form {
        public const int UNIT_CARD_SIZE = 40;

        public int CurrentChallenge => challengesComboBox.Text != string.Empty ? int.Parse(challengesComboBox.Text) : -1;
        public int CurrentWaveIndex => waveTabs.SelectedIndex;
        public string CurrentLevelName => mapComboBox.Text;


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
                    waveTabs.TabPages.Add(new TabPage() {
                        BackColor = Color.White,
                        AutoScroll = true,

                        Name = $"waveTab{waveIndex}",
                        Text = $"Wave [{waveIndex}]",
                    });

                    int enemyListIndex = 0;
                    int groupCount = dbWorker.GetGroupCountOf(CurrentLevelName, CurrentChallenge, waveIndex);
                    for (int groupIndex = 0; groupIndex < groupCount; groupIndex++) {

                        int enemyCount = dbWorker.GetEnemyCountOf(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex);
                        for (int enemyIndex = 0; enemyIndex < enemyCount; enemyIndex++) {
                            Panel panel;
                            UnitPanelStructures panelStructures;

                            (panel, panelStructures) = ConstructUnitCard(new UnitPanelConfiguration() {
                                index = enemyListIndex,
                                color = enemyListIndex % 2 == 0 ? Color.Bisque : Color.OldLace,

                                size = new Size(750, UNIT_CARD_SIZE),
                                point = new Point(0, enemyListIndex * UNIT_CARD_SIZE),

                                availableEnemies = dbWorker.GetEnemyNames(),

                                spawnEnemyAt = dbWorker.GetSpawnLocationOf(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex),
                                selectedEnemy = dbWorker.GetEnemyByIndex(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex, enemyIndex),
                                selectedEnemyQuantity = dbWorker.GetSpawnQuantityOf(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex, enemyIndex),
                                spawnTime = dbWorker.GetSpawnTimeOf(CurrentLevelName, CurrentChallenge, waveIndex, groupIndex),
                            });

                            enemyListIndex++;
                            waveTabs.TabPages[waveIndex].Controls.Add(panel);
                        }
                    }
                }
            }
        }


        private (Panel, UnitPanelStructures) ConstructUnitCard(UnitPanelConfiguration panelConfiguration) {
            Panel panel = new Panel() {
                BackColor = panelConfiguration.color,

                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = panelConfiguration.point,
                Size = panelConfiguration.size,
            };

            Label spawnLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(3, panel.Height / 3),
                Size = new Size(80, panel.Height / 2),
                Text = $"[{panelConfiguration.index}] Spawn: ",
            };
            panel.Controls.Add(spawnLabel);

            ComboBox spawnCombobox = new ComboBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(85, panel.Height / 4),
                Size = new Size(150, panel.Height/2),
            };
            foreach (string item in panelConfiguration.availableEnemies)
                spawnCombobox.Items.Add(item);

            spawnCombobox.SelectedItem = panelConfiguration.selectedEnemy;
            panel.Controls.Add(spawnCombobox);

            TextBox ammountTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(238, panel.Height / 4),
                Size = new Size(30, panel.Height / 2),
                Text = panelConfiguration.selectedEnemyQuantity.ToString(),
            };
            panel.Controls.Add(ammountTextBox);

            Label timesLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(268, panel.Height / 3),
                Size = new Size(40, panel.Height / 2),
                Text = "Times,",
            };
            panel.Controls.Add(timesLabel);

            Label spawnAtLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(308, panel.Height / 3),
                Size = new Size(25, panel.Height / 2),
                Text = "At:",
            };
            panel.Controls.Add(spawnAtLabel);

            TextBox spawnTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(335, panel.Height / 4),
                Size = new Size(100, panel.Height / 2),
                Text = panelConfiguration.spawnEnemyAt,
            };
            panel.Controls.Add(spawnTextBox);

            Label afterLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(440, panel.Height / 3),
                Size = new Size(40, panel.Height / 2),
                Text = "After:",
            };
            panel.Controls.Add(afterLabel);

            TextBox afterTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(485, panel.Height / 4),
                Size = new Size(30, panel.Height / 2),
                Text = panelConfiguration.spawnTime.ToString(),
            };
            panel.Controls.Add(afterTextBox);

            Label secondsLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(520, panel.Height / 3),
                Size = new Size(60, panel.Height / 2),
                Text = "Seconds.",
            };
            panel.Controls.Add(secondsLabel);

            Button deleteButton = new Button() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(585, panel.Height / 3),
                Size = new Size(60, panel.Height / 2),
                BackColor = Color.WhiteSmoke,
                Text = "Delete",
            };
            panel.Controls.Add(deleteButton);

            UnitPanelStructures structure = new UnitPanelStructures() {
                cb_enemyClass = spawnCombobox,
                tb_quantity = ammountTextBox,
                tb_spawnPoint = spawnTextBox,
                tb_spawnTime = afterTextBox,
            };
            return (panel, structure);
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