using System;
using System.Windows.Forms;

namespace engineer
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50; // Set update interval (50ms)
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2); // Increase progress by 2%
            if (progressBar1.Value >= 100)
            {
                timer1.Stop();
                this.Close(); // Close loading form when done
            }
        }
    }
}
