namespace WardensFirebaseHelper.Forms {
    partial class WaveInfoPanel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.timeLimitTextBox = new System.Windows.Forms.TextBox();
            this.timeLimit = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.waveName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLimitTextBox
            // 
            this.timeLimitTextBox.Location = new System.Drawing.Point(375, 11);
            this.timeLimitTextBox.Name = "timeLimitTextBox";
            this.timeLimitTextBox.Size = new System.Drawing.Size(72, 20);
            this.timeLimitTextBox.TabIndex = 7;
            this.timeLimitTextBox.TextChanged += new System.EventHandler(this.timeLimitTextBox_TextChanged);
            // 
            // timeLimit
            // 
            this.timeLimit.AutoSize = true;
            this.timeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLimit.Location = new System.Drawing.Point(302, 14);
            this.timeLimit.Name = "timeLimit";
            this.timeLimit.Size = new System.Drawing.Size(50, 13);
            this.timeLimit.TabIndex = 6;
            this.timeLimit.Text = "Time limit";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(101, 11);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(180, 20);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextChanged += new System.EventHandler(this.waveNameTextBox_TextChanged);
            // 
            // waveName
            // 
            this.waveName.AutoSize = true;
            this.waveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveName.Location = new System.Drawing.Point(12, 14);
            this.waveName.Name = "waveName";
            this.waveName.Size = new System.Drawing.Size(65, 13);
            this.waveName.TabIndex = 4;
            this.waveName.Text = "Wave name";
            // 
            // WaveInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.Controls.Add(this.timeLimitTextBox);
            this.Controls.Add(this.timeLimit);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.waveName);
            this.Name = "WaveInfoPanel";
            this.Size = new System.Drawing.Size(750, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timeLimitTextBox;
        private System.Windows.Forms.Label timeLimit;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label waveName;
    }
}
