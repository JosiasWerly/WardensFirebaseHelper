using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

using WardensFirebaseHelper.Structures.Levels;
using WardensFirebaseHelper.Forms;

namespace WardensFirebaseHelper.Files.FormHelpers {
    public struct EnemyPanelConfig {
        public int index;
        public Color color;

        public Size size; 
        public Point location;

        public IEnumerable<string> availableEnemies;
    }

    public class EnemyPanel : Panel {
        public ComboBox EnemySpawnComboBox { get; private set; }
        public TextBox EnemyAmountTextBox { get; private set; }        

        public EnemyPanel(string initialSpawnClass, int initialAmount, EnemyPanelConfig config) {
            // Panel setup
            {
                this.Size = config.size;
                this.BackColor = config.color;
                this.Location = config.location;
                this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            // Enemy amount label and textBox
            {
                Label spawnLabel = new Label() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(3, this.Height / 3),
                    Size = new Size(80, this.Height / 2),
                    Text = $"[{config.index}] Spawn: ",
                };
                this.Controls.Add(spawnLabel);

                TextBox ammountTextBox = new TextBox() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(85, this.Height / 4),
                    Size = new Size(30, this.Height / 2),
                    Text = initialAmount.ToString(),
                };
                this.EnemyAmountTextBox = ammountTextBox;
                this.Controls.Add(ammountTextBox);
            }

            // Enemy class comboBox
            {
                ComboBox spawnCombobox = new ComboBox() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(120, this.Height / 4),
                    Size = new Size(150, this.Height / 2),
                };

                foreach (var enemy in config.availableEnemies)
                    spawnCombobox.Items.Add(enemy);

                this.Controls.Add(spawnCombobox);
                this.EnemySpawnComboBox = spawnCombobox;
                this.EnemySpawnComboBox.SelectedItem = initialSpawnClass;
            }

            // Delete button
            {
                Button deleteButton = new Button() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(585, this.Height / 3),
                    Size = new Size(60, this.Height / 2),
                    BackColor = Color.WhiteSmoke,
                    Text = "Delete",
                };
                this.Controls.Add(deleteButton);
            }
        }
    }

    public class GroupPanel : Panel {
        public TextBox SpawnLocation { get; }
        public TextBox SpawnTime { get; }

        public GroupPanel(string spawnLocation, int spawnTime, Size size) {
            Label spawnLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(3, 5),
                Size = new Size(80, 30),
                Text = "Spawn location:",
            };
            this.Controls.Add(spawnLabel);

            TextBox spawnTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(85, 10),
                Size = new Size(150, 30),
                Text = spawnLocation,
            };
            this.SpawnLocation = spawnTextBox;
            this.Controls.Add(spawnTextBox);

            Label timeLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(250, 10),
                Size = new Size(80, 30),
                Text = "Spawn time:",
            };
            this.Controls.Add(timeLabel);

            TextBox spawnTimeTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(340, 10),
                Size = new Size(60, this.Height / 2),
                Text = spawnTime.ToString(),
            };

            this.SpawnTime = spawnTimeTextBox;
            this.Controls.Add(spawnTimeTextBox);

            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.Tomato;
            this.Location = new Point(0, 0);
            this.Size = size;
        }
    }

    public class FormGroup : System.Windows.Forms.TabPage {
        public const int UNIT_CARD_SIZE = 40;
        Group group;

        public FormGroup(string name,  Group group, IEnumerable<string> availableEnemies) {
            this.group = group;
            this.BackColor = Color.White;
            this.Text = this.Name = name;

            for (int i = 0; i < group.enemy_spawn.Count; i++) {
                GroupPanel groupPanel = new GroupPanel(group.spawn_location, group.spawn_time, new Size(750, UNIT_CARD_SIZE));
                EnemyPanel enemyPanel = new EnemyPanel(GetEnemyClass(i), GetSpawnAmount(i), new EnemyPanelConfig {
                    index = i,
                    color = i % 2 == 0 ? Color.Bisque : Color.OldLace,

                    size = new Size(750, UNIT_CARD_SIZE),
                    location = new Point(0, (i + 1) * UNIT_CARD_SIZE),

                    availableEnemies = availableEnemies,
                });

                // Method bindings
                // Replicates spawn_texbox changes to group
                groupPanel.SpawnLocation.TextChanged += (object sender, EventArgs args) => {
                    group.spawn_location = (sender as TextBox).Text;
                };

                // Replicates time_texbox changes to group
                groupPanel.SpawnTime.TextChanged += (object sender, EventArgs args) => {
                    if (int.TryParse((sender as TextBox).Text, out int value)) {
                        group.spawn_time = value;
                    }
                };

                // Replicates enemy_spawn.enemy_class changes to group
                enemyPanel.EnemySpawnComboBox.TextChanged += (object sender, EventArgs args) => {
                    group.enemy_spawn[i].enemy_class = (sender as ComboBox).Text;
                };

                // Replicates enemy_spawn.quantity changes to group
                enemyPanel.EnemyAmountTextBox.TextChanged += (object sender, EventArgs args) => {
                    if (int.TryParse((sender as TextBox).Text, out int value)) {
                        group.enemy_spawn[i].quantity = value;
                    }
                };

                // Add panels to this page
                this.Controls.Add(groupPanel);
                this.Controls.Add(enemyPanel);
            }
        }

        string GetEnemyClass(int index) => group.enemy_spawn[index].enemy_class;
        int GetSpawnAmount(int index) => group.enemy_spawn[index].quantity;
    }
}
