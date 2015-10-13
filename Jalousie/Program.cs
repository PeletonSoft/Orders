using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Jalousie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            LocalService.ShopId = argv.Length > 0 ? Convert.ToInt32(argv[0]) : 12;
            //MessageBox.Show(LocalService.ShopId.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TfMain());
        }
    }
}
