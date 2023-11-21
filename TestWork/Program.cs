using System;
using System.Threading;
using System.Windows.Forms;

namespace TestWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = new Mutex(true, "TestWork", out bool onlyInstance);

            if (!onlyInstance)
            {
                MessageBox.Show(
                   "Приложение уже запущено!",
                   "TestWork",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
