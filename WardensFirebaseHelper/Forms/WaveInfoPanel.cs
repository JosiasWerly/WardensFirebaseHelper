using WardensFirebaseHelper.Structures.Levels;

using System.Windows.Forms;
using System;

namespace WardensFirebaseHelper.Forms {
    public partial class WaveInfoPanel : UserControl {
        public Wave Wave { get; private set; }

        public WaveInfoPanel(Wave wave, EventHandler onDeleteButtonClicked) {
            Wave = wave;

            InitializeComponent();

            nameTextBox.Text = Wave.wave_name;
            timeLimitTextBox.Text = Wave.time_limit.ToString();
            b_DeleteButton.Click += onDeleteButtonClicked;
        }

        private void waveNameTextBox_TextChanged(object sender, EventArgs e) {
            Wave.wave_name = (sender as TextBox).Text;
        }

        private void timeLimitTextBox_TextChanged(object sender, EventArgs e) {
            if (int.TryParse((sender as TextBox).Text, out int result))  {
                Wave.time_limit = result;
            }
        }
    }
}
