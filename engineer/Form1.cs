using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = true;
            maintenancework1.Visible = false;
            permit_application1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = true;
            permit_application1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cert1.Visible = false;
            annual_inspection1.Visible = false;
            maintenancework1.Visible = false;
            permit_application1.Visible = true;
        }

        private void permit_application1_Load(object sender, EventArgs e)
        {

        }
    }
}
