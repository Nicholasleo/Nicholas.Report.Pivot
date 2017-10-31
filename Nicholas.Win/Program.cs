using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nicholas.Win
{
    static class Program
    {
        /// <summary>
        /// 重登陆
        /// </summary>
        public static bool ReLogIn = false;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            Application.EnableVisualStyles();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            StartMain();
        }

        static void StartMain()
        {
            FrmLogin login = new FrmLogin();
            DialogResult loginResult = login.ShowDialog();
            if (loginResult == DialogResult.OK)
            {
                ReLogIn = false;
                Cursor.Current = Cursors.WaitCursor;
                Application.Run(new FrmMain());
                login.Dispose();
                if (ReLogIn)
                {
                    StartMain();
                }
            }
        }
    }
}
