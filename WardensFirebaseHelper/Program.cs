using System.Windows.Forms;
using WardensFirebaseHelper.Forms;

namespace WardensFirebaseHelper {
   
    static class Program {
        //[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor());            
        }
    }
}