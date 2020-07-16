using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

using WardensFirebaseHelper.Structures.Levels;
using System.Security.RightsManagement;


/*
 *  Group page contains:
 *      - GroupPanel
 *      - List<EnemyPanel>
 *      
 *  EnemyPanel is built using EnemyPanelConfig
 */

namespace WardensFirebaseHelper.Files.FormHelpers {
    public struct EnemyPanelConfig {
        public int index;
        public Color color;

        public Size size; 
        public Point location;

        public IEnumerable<string> availableEnemies;
    }

    public class GroupReplicativePanel : Panel {
        
        public Group Group { get; private set; }

        public GroupReplicativePanel(Group group) {
            Group = group;
        }
    }

    public class EnemyReplicativePanel : GroupReplicativePanel {
        public int Index { get; private set; }

        public EnemyReplicativePanel(int index, Group group) : base(group) {
            Index = index;
        }
    }

    public class EnemyPanel : EnemyReplicativePanel {
        public ComboBox EnemySpawnComboBox { get; private set; }
        public TextBox EnemyAmountTextBox { get; private set; }

        public event Action<int, Group> OnDeleteButtonClicked;

        public EnemyPanel(int index, Group group, EnemyPanelConfig config) : base(index, group) {
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
                    Text = group.enemy_spawn[index].quantity.ToString(),
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
                this.EnemySpawnComboBox.SelectedItem = group.enemy_spawn[index].enemy_class;
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
                deleteButton.Click += HandleDeleteButtonClicked; ;
            }

            // Replicates enemy_spawn.enemy_class changes to group
            EnemySpawnComboBox.TextChanged += HandleSpawnClassChanged;

            // Replicates enemy_spawn.quantity changes to group
            EnemyAmountTextBox.TextChanged += HandleQuantityChanged;
        }

        void HandleDeleteButtonClicked(object sender, EventArgs e) {
            Group.enemy_spawn.RemoveAt(Index);
            if (this.Parent != null && (this.Parent is GroupPage)) {
                (this.Parent as GroupPage).Reload();
            }
        }

        void HandleQuantityChanged(object sender, EventArgs args) {
            if (int.TryParse((sender as TextBox).Text, out int value)) {
                Group.enemy_spawn[Index].quantity = value;
            }
        }

        void HandleSpawnClassChanged(object sender, EventArgs args) {
            Group.enemy_spawn[Index].enemy_class = (sender as ComboBox).Text;
        }        
    }

    public class GroupPanel : GroupReplicativePanel {
        public TextBox SpawnLocation { get; }
        public TextBox SpawnTime { get; }

        public GroupPanel(Group group, Size size) : base(group) {
            // Setup
            {
                this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                this.BorderStyle = BorderStyle.FixedSingle;
                this.BackColor = Color.Tomato;
                this.Location = new Point(0, 0);
                this.Size = size;
            }

            // Spawn location
            {
                Label spawnLabel = new Label() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(3, 5),
                    Size = new Size(80, 30),
                    Text = "Spawn location:",
                };
                this.Controls.Add(spawnLabel);

                SpawnLocation = new TextBox() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(85, 10),
                    Size = new Size(150, 30),
                    Text = Group.spawn_location,
                };
                this.Controls.Add(SpawnLocation);
            }

            // Spawn time
            {
                Label timeLabel = new Label() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(250, 10),
                    Size = new Size(80, 30),
                    Text = "Spawn time:",
                };
                this.Controls.Add(timeLabel);

                SpawnTime = new TextBox() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Location = new Point(340, 10),
                    Size = new Size(60, this.Height / 2),
                    Text = Group.spawn_time.ToString(),
                };
                this.Controls.Add(SpawnTime);
            }

            // Method bindings

            // Replicates spawn_texbox changes to group
            SpawnLocation.TextChanged += HandleSpawnLocationChanged;

            // Replicates time_texbox changes to group
            SpawnTime.TextChanged += HandleSpawnTimeChanged;
        }

        void HandleSpawnLocationChanged(object sender, EventArgs args) {
            Group.spawn_location = (sender as TextBox).Text;
        }

        void HandleSpawnTimeChanged(object sender, EventArgs args) {
            if (int.TryParse((sender as TextBox).Text, out int value)) {
                Group.spawn_time = value;
            }
        }
    }

    public class GroupPage : System.Windows.Forms.TabPage {
        public const int UNIT_CARD_SIZE = 40;
        public Group Group { get; private set; }
        public IEnumerable<string> AvailableEnemies { get; set; }

        public GroupPage(string name,  Group group, IEnumerable<string> availableEnemies) {
            Group = group;
            this.BackColor = Color.White;
            this.Text = this.Name = name;
            this.AvailableEnemies = availableEnemies;

            Reload();
        }

        public void Reload() {
            this.Controls.Clear();

            GroupPanel groupPanel = new GroupPanel(Group, new Size(750, UNIT_CARD_SIZE));
            this.Controls.Add(groupPanel);

            for (int enemyIndex = 0; enemyIndex < Group.enemy_spawn.Count; enemyIndex++) {
                EnemyPanel enemyPanel = new EnemyPanel(enemyIndex, Group, new EnemyPanelConfig {
                    index = enemyIndex,
                    color = enemyIndex % 2 == 0 ? Color.Bisque : Color.OldLace,

                    size = new Size(750, UNIT_CARD_SIZE),
                    location = new Point(0, (enemyIndex + 1) * UNIT_CARD_SIZE),

                    availableEnemies = AvailableEnemies,
                });
                this.Controls.Add(enemyPanel);
            }
        }
    }

    public class WavePage : TabPage {
        public IEnumerable<GroupPage> GroupPages =>
            from page in groupControl.TabPages.Cast<GroupPage>()
            select page;

        public int Index { get; private set; }
        public int CurrentGroupIndex => groupControl.SelectedIndex;
        public GroupPage CurrentGroup => (GroupPage)groupControl.TabPages[CurrentGroupIndex];
        TabControl groupControl;

        public WavePage(int index, Size size, IEnumerable<Group> groupCollection, IEnumerable<string> availableEnemies) {
            Index = index;

            this.Name = $"wavePage{Index}";
            this.Text = $"Wave [{Index}]";

            this.BackColor = Color.White;
            this.AutoScroll = true;
            this.Size = Size;

            groupControl = new TabControl() {
                Location = new Point(0, 0),
                Size = size
            };
            this.Controls.Add(groupControl);

            foreach (var group in groupCollection) {
                GroupPage groupPage = new GroupPage($"Group {groupControl.TabPages.Count}", group, availableEnemies);
                groupControl.TabPages.Add(groupPage);
            }
        }
    }
}
