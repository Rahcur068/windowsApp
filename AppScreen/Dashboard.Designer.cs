namespace WaterBillingManagement
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BillMonthLbl = new System.Windows.Forms.Label();
            this.AgNumLbl = new System.Windows.Forms.Label();
            this.ConsLbl = new System.Windows.Forms.Label();
            this.BillLbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.BPeriod = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(960, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(19, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("ISOCPEUR", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 41);
            this.label6.TabIndex = 62;
            this.label6.Text = "WDC\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1000, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 36);
            this.label5.TabIndex = 61;
            this.label5.Text = "Dashboard";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(752, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 36);
            this.label4.TabIndex = 60;
            this.label4.Text = "Agent";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(854, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 36);
            this.label3.TabIndex = 59;
            this.label3.Text = "Billing";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 36);
            this.label2.TabIndex = 58;
            this.label2.Text = "Consumer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Gold;
            this.label9.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(95, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 29);
            this.label9.TabIndex = 84;
            this.label9.Text = "Bills";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.BillLbl);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(275, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 159);
            this.panel1.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.ConsLbl);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(780, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 159);
            this.panel2.TabIndex = 86;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Red;
            this.label10.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(75, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 29);
            this.label10.TabIndex = 84;
            this.label10.Text = "Consumers";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gold;
            this.panel3.Controls.Add(this.BillMonthLbl);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(780, 386);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 159);
            this.panel3.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Gold;
            this.label7.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(59, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 29);
            this.label7.TabIndex = 84;
            this.label7.Text = "Bills By Month";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gold;
            this.panel4.Controls.Add(this.AgNumLbl);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(275, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(265, 159);
            this.panel4.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(80, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 84;
            this.label1.Text = "Agents";
            // 
            // BillMonthLbl
            // 
            this.BillMonthLbl.AutoSize = true;
            this.BillMonthLbl.BackColor = System.Drawing.Color.Gold;
            this.BillMonthLbl.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillMonthLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BillMonthLbl.Location = new System.Drawing.Point(75, 63);
            this.BillMonthLbl.Name = "BillMonthLbl";
            this.BillMonthLbl.Size = new System.Drawing.Size(99, 29);
            this.BillMonthLbl.TabIndex = 85;
            this.BillMonthLbl.Text = "Numbers";
            // 
            // AgNumLbl
            // 
            this.AgNumLbl.AutoSize = true;
            this.AgNumLbl.BackColor = System.Drawing.Color.Gold;
            this.AgNumLbl.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgNumLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AgNumLbl.Location = new System.Drawing.Point(75, 65);
            this.AgNumLbl.Name = "AgNumLbl";
            this.AgNumLbl.Size = new System.Drawing.Size(99, 29);
            this.AgNumLbl.TabIndex = 86;
            this.AgNumLbl.Text = "Numbers";
            // 
            // ConsLbl
            // 
            this.ConsLbl.AutoSize = true;
            this.ConsLbl.BackColor = System.Drawing.Color.Red;
            this.ConsLbl.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsLbl.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.ConsLbl.Location = new System.Drawing.Point(75, 65);
            this.ConsLbl.Name = "ConsLbl";
            this.ConsLbl.Size = new System.Drawing.Size(99, 29);
            this.ConsLbl.TabIndex = 87;
            this.ConsLbl.Text = "Numbers";
            this.ConsLbl.Click += new System.EventHandler(this.ConsLbl_Click);
            // 
            // BillLbl
            // 
            this.BillLbl.AutoSize = true;
            this.BillLbl.BackColor = System.Drawing.Color.Gold;
            this.BillLbl.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BillLbl.Location = new System.Drawing.Point(67, 67);
            this.BillLbl.Name = "BillLbl";
            this.BillLbl.Size = new System.Drawing.Size(99, 29);
            this.BillLbl.TabIndex = 86;
            this.BillLbl.Text = "Numbers";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Location = new System.Drawing.Point(-8, 75);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 514);
            this.panel5.TabIndex = 88;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label15.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(43, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 36);
            this.label15.TabIndex = 84;
            this.label15.Text = "Water";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label14.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(20, 231);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 36);
            this.label14.TabIndex = 85;
            this.label14.Text = "Distribution";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label16.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(43, 279);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 36);
            this.label16.TabIndex = 86;
            this.label16.Text = "System";
            // 
            // BPeriod
            // 
            this.BPeriod.Location = new System.Drawing.Point(780, 345);
            this.BPeriod.Name = "BPeriod";
            this.BPeriod.Size = new System.Drawing.Size(254, 22);
            this.BPeriod.TabIndex = 90;
            this.BPeriod.ValueChanged += new System.EventHandler(this.BPeriod_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Location = new System.Drawing.Point(775, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 26);
            this.label8.TabIndex = 89;
            this.label8.Text = "Bill Period";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 575);
            this.Controls.Add(this.BPeriod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label BillLbl;
        private System.Windows.Forms.Label ConsLbl;
        private System.Windows.Forms.Label BillMonthLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label AgNumLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker BPeriod;
        private System.Windows.Forms.Label label8;
    }
}