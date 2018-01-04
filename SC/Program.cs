using System;
using System.Windows.Forms;
//using DevExpress.UserSkins;
//using DevExpress.Skins;
//using DevExpress.LookAndFeel;

namespace SC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            if (arg == null || arg.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                //BonusSkins.Register();
                //SkinManager.EnableFormSkins();
                //UserLookAndFeel.Default.SetSkinStyle("DevExpress");
                AppContext ctx = new AppContext();
                Application.Run(ctx);
            }
            else {
                foreach (var s in arg)
                {
                    if (s == "-sqlKey")
                    {
                        Application.SetCompatibleTextRenderingDefault(true);
                    }
                }
            }
        }
    }
}
