using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nicholas.WinBase
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBase());
        }
    }
}
