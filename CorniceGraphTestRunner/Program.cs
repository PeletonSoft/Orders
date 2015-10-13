using System;
using System.Configuration;
using System.Windows.Forms;

namespace CorniceGraphTestRunner
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
            Application.Run(new CorniceGraph.TfMain(
                1000,
                ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString));
        }
    }
}
