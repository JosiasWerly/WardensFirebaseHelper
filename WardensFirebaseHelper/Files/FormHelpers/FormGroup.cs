using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

using WardensFirebaseHelper.Structures.Levels;
using WardensFirebaseHelper.Forms;

namespace WardensFirebaseHelper.Files.FormHelpers {
    public struct BasePanelConfig {
        public int index;
        public Color color;

        public Size size; 
        public Point location;

        public IEnumerable<string> availableEnemies;

        public BasePanel Build() {
            BasePanel root = new BasePanel();

            root.BackColor = color;

            root.Size = size;
            root.Location = location;
            root.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            Label spawnLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(3, root.Height / 3),
                Size = new Size(80, root.Height / 2),
                Text = $"[{index}] Spawn: ",
            };
            root.Controls.Add(spawnLabel);

            ComboBox spawnCombobox = new ComboBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(85, root.Height / 4),
                Size = new Size(150, root.Height / 2),
            };
            root.Controls.Add(spawnCombobox);
            root.SpawnCombobox = spawnCombobox;

            foreach (string item in availableEnemies)
                spawnCombobox.Items.Add(item);

            return root;
        }
    }

    public class BasePanel : Panel {
        public ComboBox SpawnCombobox { get; set; }

        public BasePanel() { }
    }

    public class EnemyPanel : Panel {
        public ComboBox EnemySpawnComboBox { get; private set; }
        public TextBox EnemyAmountTextBox { get; private set; }

        BasePanel panel;
        

        public EnemyPanel(string initialSpawnClass, int initialAmount, BasePanel panel) {
            this.panel = panel;

            ConstructElements(initialSpawnClass, initialAmount);
        }

        void ConstructElements(string initialSpawnClass, int initialAmount) {
            panel.SpawnCombobox.SelectedItem = initialSpawnClass;
            this.EnemySpawnComboBox = panel.SpawnCombobox;

            TextBox ammountTextBox = new TextBox() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(238, panel.Height / 4),
                Size = new Size(30, panel.Height / 2),
                Text = initialAmount.ToString(),
            };
            this.EnemyAmountTextBox = ammountTextBox;
            panel.Controls.Add(ammountTextBox);

            Label timesLabel = new Label() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(268, panel.Height / 3),
                Size = new Size(40, panel.Height / 2),
                Text = "Times,",
            };
            panel.Controls.Add(timesLabel);

            Button deleteButton = new Button() {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(585, panel.Height / 3),
                Size = new Size(60, panel.Height / 2),
                BackColor = Color.WhiteSmoke,
                Text = "Delete",
            };
            panel.Controls.Add(deleteButton);

            this.Size = panel.Size;
            this.Location = panel.Location;
            panel.Location = new Point(0, 0);

            this.Controls.Add(panel);
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
                EnemyPanel enemyPanel = new EnemyPanel(GetEnemyClass(i), GetSpawnAmount(i), new BasePanelConfig {
                    index = i,
                    color = i % 2 == 0 ? Color.Bisque : Color.OldLace,

                    size = new Size(750, UNIT_CARD_SIZE),
                    location = new Point(0, (i + 1) * UNIT_CARD_SIZE),

                    availableEnemies = availableEnemies,
                }.Build());

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
