using System.Collections.Generic;
using System.Windows.Forms;
using WardensFirebaseHelper.Files;

namespace WardensFirebaseHelper {

    public class tComplex {
        public string a { get; set; }
        //public string b { get; set; }
        public List<string> arr { get; set; }
        public tComplex() {
            arr = new List<string>();
        }
    }
    public class tEnemies {
        public List<object> Enemies { get; set; }
    }

    public partial class WaveEditor : Form {
        public WaveEditor() {
            InitializeComponent();
            FirebaseConnector fb = new FirebaseConnector("https://bigmoxiwardens.firebaseio.com/", "AIzaSyDDiV0BvrE0TUA3t7BzwVkz2pH5Ybs8Fgs");

            //tComplex c = fb.downloadData<tComplex>("z_test/complex");
            tEnemies c;
            c = fb.downloadData<tEnemies>("Enemies");

            //fb.uploadData<zTest>("z_test", ztest);
        }
    }
}
