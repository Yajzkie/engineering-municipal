namespace engineer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.programs_works1 = new engineer.programs_works();
            this.permit_application1 = new engineer.permit_application();
            this.maintenancework1 = new engineer.maintenancework();
            this.annual_inspection1 = new engineer.annual_inspection();
            this.cert1 = new engineer.cert();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(47, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "CERTIFICATE OF APPEARANCE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.button2.Location = new System.Drawing.Point(47, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 59);
            this.button2.TabIndex = 5;
            this.button2.Text = "CERTIFICATE OF ANNUAL INSPECTION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Cooper Black", 9.75F);
            this.button3.Location = new System.Drawing.Point(47, 427);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 59);
            this.button3.TabIndex = 6;
            this.button3.Text = "MAINTENANCE WORK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Cooper Black", 9.75F);
            this.button4.Location = new System.Drawing.Point(47, 509);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 59);
            this.button4.TabIndex = 7;
            this.button4.Text = "BUILDING PERMIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Cooper Black", 9.75F);
            this.button5.Location = new System.Drawing.Point(47, 603);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 59);
            this.button5.TabIndex = 8;
            this.button5.Text = "BARANGAY PROGRAM OF WORK";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 808);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 757);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Developed By: Jay B. Sabalo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // programs_works1
            // 
            this.programs_works1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programs_works1.Location = new System.Drawing.Point(262, 0);
            this.programs_works1.Name = "programs_works1";
            this.programs_works1.Size = new System.Drawing.Size(1137, 808);
            this.programs_works1.TabIndex = 6;
            // 
            // permit_application1
            // 
            this.permit_application1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permit_application1.Location = new System.Drawing.Point(262, 0);
            this.permit_application1.Name = "permit_application1";
            this.permit_application1.Size = new System.Drawing.Size(1137, 808);
            this.permit_application1.TabIndex = 5;
            this.permit_application1.Load += new System.EventHandler(this.permit_application1_Load);
            // 
            // maintenancework1
            // 
            this.maintenancework1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintenancework1.Location = new System.Drawing.Point(262, 0);
            this.maintenancework1.Name = "maintenancework1";
            this.maintenancework1.Size = new System.Drawing.Size(1137, 808);
            this.maintenancework1.TabIndex = 4;
            // 
            // annual_inspection1
            // 
            this.annual_inspection1.AutoSize = true;
            this.annual_inspection1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.annual_inspection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annual_inspection1.Location = new System.Drawing.Point(262, 0);
            this.annual_inspection1.Name = "annual_inspection1";
            this.annual_inspection1.Size = new System.Drawing.Size(1137, 808);
            this.annual_inspection1.TabIndex = 3;
            // 
            // cert1
            // 
            this.cert1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cert1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cert1.Location = new System.Drawing.Point(262, 0);
            this.cert1.Name = "cert1";
            this.cert1.Size = new System.Drawing.Size(1137, 808);
            this.cert1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 808);
            this.Controls.Add(this.programs_works1);
            this.Controls.Add(this.permit_application1);
            this.Controls.Add(this.maintenancework1);
            this.Controls.Add(this.annual_inspection1);
            this.Controls.Add(this.cert1);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MUNICIPAL ENGINEERING OFFICE";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private cert cert1;
        private annual_inspection annual_inspection1;
        private maintenancework maintenancework1;
        private permit_application permit_application1;
        private programs_works programs_works1;
        private System.Windows.Forms.Label label1;
    }
}

