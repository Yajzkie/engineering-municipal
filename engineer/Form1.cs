using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engineer
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cert2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cert1.Visible = true;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = false;
            permit_application1.Visible = false;
            programs_works1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = true;
            maintenancework1.Visible = false;
            permit_application1.Visible = false;
            programs_works1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = true;
            permit_application1.Visible = false;
            programs_works1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = false;
            permit_application1.Visible = true;
            programs_works1.Visible = false;
        }

        private void permit_application1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = false;
            permit_application1.Visible = false;
            programs_works1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/jay.sabalo.2024",
                UseShellExecute = true // Ensures it opens in the default web browser
            });
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
