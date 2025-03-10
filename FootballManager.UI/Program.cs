using System;
using System.Windows.Forms;
using FootballManager.UI.Forms;

namespace FootballManager.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Start with the login form
            Application.Run(new LoginForm());
        }
    }
}