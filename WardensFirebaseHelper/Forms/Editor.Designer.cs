namespace WardensFirebaseHelper.Forms {
    partial class Editor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.waveTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.b_Reload = new System.Windows.Forms.Button();
            this.b_Save = new System.Windows.Forms.Button();
            this.challengesComboBox = new System.Windows.Forms.ComboBox();
            this.mapLabel = new System.Windows.Forms.Label();
            this.challengeLabel = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.b_Upload = new System.Windows.Forms.Button();
            this.b_CreateEnemy = new System.Windows.Forms.Button();
            this.c_buttonsContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_CreateGroup = new System.Windows.Forms.Button();
            this.b_CreateWave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.b_Import = new System.Windows.Forms.Button();
            this.b_Export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.waveTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_buttonsContainer)).BeginInit();
            this.c_buttonsContainer.Panel1.SuspendLayout();
            this.c_buttonsContainer.Panel2.SuspendLayout();
            this.c_buttonsContainer.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // waveTabs
            // 
            this.waveTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveTabs.Controls.Add(this.tabPage1);
            this.waveTabs.Location = new System.Drawing.Point(3, 3);
            this.waveTabs.Name = "waveTabs";
            this.waveTabs.SelectedIndex = 0;
            this.waveTabs.Size = new System.Drawing.Size(681, 432);
            this.waveTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(673, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 339);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(620, 339);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mapComboBox
            // 
            this.mapComboBox.DisplayMember = "enemy";
            this.mapComboBox.FormattingEnabled = true;
            this.mapComboBox.Location = new System.Drawing.Point(82, 12);
            this.mapComboBox.Name = "mapComboBox";
            this.mapComboBox.Size = new System.Drawing.Size(132, 21);
            this.mapComboBox.TabIndex = 3;
            this.mapComboBox.ValueMember = "enemy";
            this.mapComboBox.SelectedIndexChanged += new System.EventHandler(this.mapComboBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(3, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 406);
            this.panel3.TabIndex = 4;
            // 
            // b_Reload
            // 
            this.b_Reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Reload.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_Reload.Location = new System.Drawing.Point(123, 3);
            this.b_Reload.Name = "b_Reload";
            this.b_Reload.Size = new System.Drawing.Size(84, 23);
            this.b_Reload.TabIndex = 4;
            this.b_Reload.Text = "Reload";
            this.b_Reload.UseVisualStyleBackColor = false;
            this.b_Reload.Click += new System.EventHandler(this.b_Reload_Click);
            // 
            // b_Save
            // 
            this.b_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Save.Location = new System.Drawing.Point(213, 3);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(84, 23);
            this.b_Save.TabIndex = 5;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // challengesComboBox
            // 
            this.challengesComboBox.DisplayMember = "enemy";
            this.challengesComboBox.FormattingEnabled = true;
            this.challengesComboBox.Location = new System.Drawing.Point(108, 44);
            this.challengesComboBox.Name = "challengesComboBox";
            this.challengesComboBox.Size = new System.Drawing.Size(49, 21);
            this.challengesComboBox.TabIndex = 6;
            this.challengesComboBox.ValueMember = "enemy";
            this.challengesComboBox.SelectedIndexChanged += new System.EventHandler(this.challengesComboBox_SelectedIndexChanged);
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(9, 15);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(67, 13);
            this.mapLabel.TabIndex = 7;
            this.mapLabel.Text = "Current map:";
            // 
            // challengeLabel
            // 
            this.challengeLabel.AutoSize = true;
            this.challengeLabel.Location = new System.Drawing.Point(9, 49);
            this.challengeLabel.Name = "challengeLabel";
            this.challengeLabel.Size = new System.Drawing.Size(93, 13);
            this.challengeLabel.TabIndex = 8;
            this.challengeLabel.Text = "Current challenge:";
            // 
            // comboBox4
            // 
            this.comboBox4.DisplayMember = "enemy";
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(4, 4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 0;
            this.comboBox4.ValueMember = "enemy";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(131, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(259, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(306, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(41, 20);
            this.textBox5.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "enemy";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "enemy";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(131, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(259, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(306, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(41, 20);
            this.textBox4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 132);
            this.label2.TabIndex = 10;
            this.label2.Text = "Please, select a map and challenge to continue.";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 78);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.waveTabs);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel3);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(997, 438);
            this.splitContainer.SplitterDistance = 687;
            this.splitContainer.TabIndex = 11;
            // 
            // b_Upload
            // 
            this.b_Upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Upload.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_Upload.Location = new System.Drawing.Point(303, 3);
            this.b_Upload.Name = "b_Upload";
            this.b_Upload.Size = new System.Drawing.Size(84, 23);
            this.b_Upload.TabIndex = 13;
            this.b_Upload.Text = "Upload";
            this.b_Upload.UseVisualStyleBackColor = false;
            this.b_Upload.Click += new System.EventHandler(this.b_Upload_Click);
            // 
            // b_CreateEnemy
            // 
            this.b_CreateEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_CreateEnemy.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_CreateEnemy.Location = new System.Drawing.Point(3, 3);
            this.b_CreateEnemy.Name = "b_CreateEnemy";
            this.b_CreateEnemy.Size = new System.Drawing.Size(110, 23);
            this.b_CreateEnemy.TabIndex = 13;
            this.b_CreateEnemy.Text = "Create enemy field";
            this.b_CreateEnemy.UseVisualStyleBackColor = false;
            this.b_CreateEnemy.Click += new System.EventHandler(this.b_CreateEnemy_Click);
            // 
            // c_buttonsContainer
            // 
            this.c_buttonsContainer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.c_buttonsContainer.Location = new System.Drawing.Point(12, 522);
            this.c_buttonsContainer.Name = "c_buttonsContainer";
            // 
            // c_buttonsContainer.Panel1
            // 
            this.c_buttonsContainer.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // c_buttonsContainer.Panel2
            // 
            this.c_buttonsContainer.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.c_buttonsContainer.Size = new System.Drawing.Size(997, 29);
            this.c_buttonsContainer.SplitterDistance = 600;
            this.c_buttonsContainer.TabIndex = 13;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.b_CreateEnemy);
            this.flowLayoutPanel2.Controls.Add(this.b_CreateGroup);
            this.flowLayoutPanel2.Controls.Add(this.b_CreateWave);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(688, 43);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // b_CreateGroup
            // 
            this.b_CreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_CreateGroup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_CreateGroup.Location = new System.Drawing.Point(119, 3);
            this.b_CreateGroup.Name = "b_CreateGroup";
            this.b_CreateGroup.Size = new System.Drawing.Size(110, 23);
            this.b_CreateGroup.TabIndex = 14;
            this.b_CreateGroup.Text = "Create new group";
            this.b_CreateGroup.UseVisualStyleBackColor = false;
            this.b_CreateGroup.Click += new System.EventHandler(this.b_CreateGroup_Click);
            // 
            // b_CreateWave
            // 
            this.b_CreateWave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_CreateWave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_CreateWave.Location = new System.Drawing.Point(235, 3);
            this.b_CreateWave.Name = "b_CreateWave";
            this.b_CreateWave.Size = new System.Drawing.Size(110, 23);
            this.b_CreateWave.TabIndex = 15;
            this.b_CreateWave.Text = "Create new wave";
            this.b_CreateWave.UseVisualStyleBackColor = false;
            this.b_CreateWave.Click += new System.EventHandler(this.b_CreateWave_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.b_Upload);
            this.flowLayoutPanel1.Controls.Add(this.b_Save);
            this.flowLayoutPanel1.Controls.Add(this.b_Reload);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 31);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // b_Import
            // 
            this.b_Import.Location = new System.Drawing.Point(922, 10);
            this.b_Import.Name = "b_Import";
            this.b_Import.Size = new System.Drawing.Size(75, 23);
            this.b_Import.TabIndex = 14;
            this.b_Import.Text = "Import";
            this.b_Import.UseVisualStyleBackColor = true;
            this.b_Import.Click += new System.EventHandler(this.b_Import_Click);
            // 
            // b_Export
            // 
            this.b_Export.Location = new System.Drawing.Point(922, 39);
            this.b_Export.Name = "b_Export";
            this.b_Export.Size = new System.Drawing.Size(75, 23);
            this.b_Export.TabIndex = 15;
            this.b_Export.Text = "Export";
            this.b_Export.UseVisualStyleBackColor = true;
            this.b_Export.Click += new System.EventHandler(this.b_Export_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckFileExists = true;
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.Filter = "Json files (*.json)|*.json";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Export Database file";
            this.saveFileDialog1.ValidateNames = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 565);
            this.Controls.Add(this.b_Export);
            this.Controls.Add(this.b_Import);
            this.Controls.Add(this.c_buttonsContainer);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.challengeLabel);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.challengesComboBox);
            this.Controls.Add(this.mapComboBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editor";
            this.Text = "Wardens Wave Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.waveTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.c_buttonsContainer.Panel1.ResumeLayout(false);
            this.c_buttonsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_buttonsContainer)).EndInit();
            this.c_buttonsContainer.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl waveTabs;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button b_Reload;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.ComboBox challengesComboBox;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.Label challengeLabel;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button b_Upload;
        private System.Windows.Forms.Button b_CreateEnemy;
        private System.Windows.Forms.SplitContainer c_buttonsContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button b_CreateGroup;
        private System.Windows.Forms.Button b_CreateWave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button b_Import;
        private System.Windows.Forms.Button b_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}