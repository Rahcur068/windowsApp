namespace WaterBillingManagement
{
    partial class Billing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Billing));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BPeriod = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.RateTb = new System.Windows.Forms.TextBox();
            this.TaxTb = new System.Windows.Forms.TextBox();
            this.CIdCb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ConsTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BillingDGV = new System.Windows.Forms.DataGridView();
            this.AgentsLbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PrintPdfBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(861, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBtn.BackColor = System.Drawing.Color.Red;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Location = new System.Drawing.Point(143, 542);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(135, 36);
            this.DeleteBtn.TabIndex = 52;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Location = new System.Drawing.Point(212, 487);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(121, 49);
            this.EditBtn.TabIndex = 51;
            this.EditBtn.Text = "Update";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(79, 487);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(127, 49);
            this.SaveBtn.TabIndex = 50;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // BPeriod
            // 
            this.BPeriod.Location = new System.Drawing.Point(79, 215);
            this.BPeriod.Name = "BPeriod";
            this.BPeriod.Size = new System.Drawing.Size(254, 22);
            this.BPeriod.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label10.Location = new System.Drawing.Point(74, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 26);
            this.label10.TabIndex = 48;
            this.label10.Text = "Tax";
            // 
            // RateTb
            // 
            this.RateTb.Enabled = false;
            this.RateTb.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RateTb.Location = new System.Drawing.Point(79, 355);
            this.RateTb.Multiline = true;
            this.RateTb.Name = "RateTb";
            this.RateTb.Size = new System.Drawing.Size(254, 32);
            this.RateTb.TabIndex = 47;
            // 
            // TaxTb
            // 
            this.TaxTb.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxTb.Location = new System.Drawing.Point(79, 422);
            this.TaxTb.Multiline = true;
            this.TaxTb.Name = "TaxTb";
            this.TaxTb.Size = new System.Drawing.Size(254, 43);
            this.TaxTb.TabIndex = 46;
            // 
            // CIdCb
            // 
            this.CIdCb.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CIdCb.FormattingEnabled = true;
            this.CIdCb.Location = new System.Drawing.Point(79, 151);
            this.CIdCb.Name = "CIdCb";
            this.CIdCb.Size = new System.Drawing.Size(254, 32);
            this.CIdCb.TabIndex = 45;
            this.CIdCb.SelectedIndexChanged += new System.EventHandler(this.CIdCb_SelectedIndexChanged);
            this.CIdCb.SelectionChangeCommitted += new System.EventHandler(this.CIdCb_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Location = new System.Drawing.Point(74, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 26);
            this.label8.TabIndex = 44;
            this.label8.Text = "Rate";
            // 
            // ConsTb
            // 
            this.ConsTb.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsTb.Location = new System.Drawing.Point(79, 282);
            this.ConsTb.Multiline = true;
            this.ConsTb.Name = "ConsTb";
            this.ConsTb.Size = new System.Drawing.Size(254, 32);
            this.ConsTb.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label9.Location = new System.Drawing.Point(74, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 26);
            this.label9.TabIndex = 42;
            this.label9.Text = "Consumption in DM3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(74, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 26);
            this.label7.TabIndex = 41;
            this.label7.Text = "Bill Period";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(74, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "Consumer ID";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(26, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("ISOCPEUR", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 41);
            this.label6.TabIndex = 38;
            this.label6.Text = "WDC\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1012, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 36);
            this.label5.TabIndex = 37;
            this.label5.Text = "Dashboard";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(748, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 36);
            this.label4.TabIndex = 36;
            this.label4.Text = "Agent";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(898, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 36);
            this.label3.TabIndex = 35;
            this.label3.Text = "Billing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ISOCPEUR", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(599, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 36);
            this.label2.TabIndex = 34;
            this.label2.Text = "Consumer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BillingDGV
            // 
            this.BillingDGV.AllowUserToAddRows = false;
            this.BillingDGV.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.BillingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillingDGV.Location = new System.Drawing.Point(355, 132);
            this.BillingDGV.MultiSelect = false;
            this.BillingDGV.Name = "BillingDGV";
            this.BillingDGV.ReadOnly = true;
            this.BillingDGV.RowHeadersWidth = 51;
            this.BillingDGV.RowTemplate.Height = 24;
            this.BillingDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BillingDGV.Size = new System.Drawing.Size(798, 417);
            this.BillingDGV.TabIndex = 57;
            this.BillingDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BillingDGV_CellContentClick);
            // 
            // AgentsLbl
            // 
            this.AgentsLbl.AutoSize = true;
            this.AgentsLbl.Font = new System.Drawing.Font("ISOCPEUR", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgentsLbl.Location = new System.Drawing.Point(1080, 76);
            this.AgentsLbl.Name = "AgentsLbl";
            this.AgentsLbl.Size = new System.Drawing.Size(54, 29);
            this.AgentsLbl.TabIndex = 58;
            this.AgentsLbl.Text = "User";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("ISOCPEUR", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(13, 610);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 26);
            this.label11.TabIndex = 59;
            this.label11.Text = "LogOut🚪";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // PrintPdfBtn
            // 
            this.PrintPdfBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintPdfBtn.BackColor = System.Drawing.Color.Snow;
            this.PrintPdfBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintPdfBtn.Location = new System.Drawing.Point(1052, 555);
            this.PrintPdfBtn.Name = "PrintPdfBtn";
            this.PrintPdfBtn.Size = new System.Drawing.Size(101, 34);
            this.PrintPdfBtn.TabIndex = 60;
            this.PrintPdfBtn.Text = "Print";
            this.PrintPdfBtn.UseVisualStyleBackColor = false;
            this.PrintPdfBtn.Click += new System.EventHandler(this.PrintPdfBtn_Click);
            // 
            // Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 645);
            this.Controls.Add(this.PrintPdfBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AgentsLbl);
            this.Controls.Add(this.BillingDGV);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.BPeriod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RateTb);
            this.Controls.Add(this.TaxTb);
            this.Controls.Add(this.CIdCb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ConsTb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Billing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.Billing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker BPeriod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox RateTb;
        private System.Windows.Forms.TextBox TaxTb;
        private System.Windows.Forms.ComboBox CIdCb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ConsTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView BillingDGV;
        private System.Windows.Forms.Label AgentsLbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button PrintPdfBtn;
    }
}