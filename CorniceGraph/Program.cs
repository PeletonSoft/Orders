using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CorniceGraph
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TfMain(1094,"Password=p1wd6;Data Source=192.168.1.2; Initial Catalog=Магазин2;Persist Security Info=True;User ID=Продавец"));
        }
    }
}
