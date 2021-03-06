﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

using WardensFirebaseHelper.Structures.Levels;
using System.Security.RightsManagement;
using WardensFirebaseHelper.Forms;


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

                foreach (var enemy in WardensEnviroment.AvailableEnemies)
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

        public Button DeleteButton { get; }

        public GroupPanel(Group group, Size size, EventHandler onButotnClicked) : base(group) {
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

                DeleteButton = new Button()
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    BackColor = Color.WhiteSmoke,
                    Location = new Point(550, 5),
                    Size = new Size(100, 23),
                    Text = "Delete group",
                };
                this.Controls.Add(DeleteButton);
                DeleteButton.Click += onButotnClicked;
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
        EventHandler onButotnClicked;

        public GroupPage(string name,  Group group, EventHandler onButotnClicked) {
            Group = group;
            this.BackColor = Color.White;
            this.Text = this.Name = name;
            this.onButotnClicked = onButotnClicked;
            Reload();
        }

        public void Reload() {
            this.Controls.Clear();

            GroupPanel groupPanel = new GroupPanel(Group, new Size(750, UNIT_CARD_SIZE), onButotnClicked);
            this.Controls.Add(groupPanel);

            for (int enemyIndex = 0; enemyIndex < Group.enemy_spawn.Count; enemyIndex++) {
                EnemyPanel enemyPanel = new EnemyPanel(enemyIndex, Group, new EnemyPanelConfig {
                    index = enemyIndex,
                    color = enemyIndex % 2 == 0 ? Color.Bisque : Color.OldLace,

                    size = new Size(750, UNIT_CARD_SIZE),
                    location = new Point(0, (enemyIndex + 1) * UNIT_CARD_SIZE),
                });
                this.Controls.Add(enemyPanel);
            }
        }
    }

    public class WavePage : TabPage {
        public IEnumerable<GroupPage> GroupPages =>
            from page in GroupControl.TabPages.Cast<GroupPage>()
            select page;

        EventHandler OnDeleteButtonClicked { get; }
        public Wave Wave { get; private set; }
        public int Index { get; private set; }

        public int CurrentGroupIndex => GroupControl.SelectedIndex;
        public GroupPage CurrentGroup {
            get {
                return CurrentGroupIndex >= 0 && CurrentGroupIndex < GroupControl.TabPages.Count ?
                    (GroupPage)GroupControl.TabPages[CurrentGroupIndex] :
                    null;
            }
        }

        public TabControl GroupControl { get; private set; }

        public WavePage(int index, Size size, Wave wave, EventHandler onDeleteButtonClicked) {
            Wave = wave;
            Index = index;
            OnDeleteButtonClicked = onDeleteButtonClicked;

            this.Name = $"wavePage{Index}";
            this.Text = $"Wave [{Index}]";

            this.BackColor = Color.White;
            this.AutoScroll = true;
            this.Size = Size;

            WaveInfoPanel waveInfoPanel = new WaveInfoPanel(wave, OnDeleteButtonClicked) {
                Location = new Point(0, 0),
            };
            this.Controls.Add(waveInfoPanel);

            GroupControl = new TabControl() {
                Location = new Point(0, waveInfoPanel.Height),
                Size = new Size(size.Width, size.Height - waveInfoPanel.Height)
            };
            this.Controls.Add(GroupControl);
            GroupControl.Selected += OnGroupTabSelected;

            Reload();
        }

        public void Reload() {
            GroupControl.Controls.Clear();

            foreach (var group in Wave.groups) {
                GroupPage groupPage = new GroupPage($"Group {GroupControl.TabPages.Count}", group, OnDeleteGroupClicked);
                GroupControl.TabPages.Add(groupPage);
            }
        }

        void OnGroupTabSelected(object sender, TabControlEventArgs e) {

            this.AutoScroll = true;
            this.VerticalScroll.Value = 0;
        }

        void OnDeleteGroupClicked(object sender, EventArgs e)
        {
            Wave.groups.Remove(((sender as Control).Parent as GroupPanel).Group);
            Reload();
        }
    }
}
