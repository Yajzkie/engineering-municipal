using System;
using System.Windows.Forms;

namespace engineer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the loading screen first
            loading splash = new loading();
            splash.ShowDialog();

            // After loading, open the main form
            Application.Run(new Form1()); // Replace MainForm with your actual main form
        }
    }
}
