namespace GenerateGhost
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
            this.btnPickFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Go = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPickFile
            // 
            this.btnPickFile.Location = new System.Drawing.Point(31, 18);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(119, 23);
            this.btnPickFile.TabIndex = 0;
            this.btnPickFile.Text = "Select DHCP Dump";
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(31, 48);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(119, 23);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Select Output File";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2.";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(31, 77);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(119, 23);
            this.Go.TabIndex = 4;
            this.Go.Text = "Gather Info";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "3.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "export";
            this.openFileDialog1.Filter = "DHCP Dump|*.csv|All files|*.*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "4.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 152);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(589, 294);
            this.textBox1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDistrict);
            this.groupBox1.Controls.Add(this.txtSite);
            this.groupBox1.Controls.Add(this.txtRegion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(448, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 120);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(72, 81);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.ReadOnly = true;
            this.txtDistrict.Size = new System.Drawing.Size(75, 20);
            this.txtDistrict.TabIndex = 5;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(72, 52);
            this.txtSite.Name = "txtSite";
            this.txtSite.ReadOnly = true;
            this.txtSite.Size = new System.Drawing.Size(75, 20);
            this.txtSite.TabIndex = 4;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(72, 24);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.ReadOnly = true;
            this.txtRegion.Size = new System.Drawing.Size(75, 20);
            this.txtRegion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "District OU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Region";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Site OU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 130);
            this.label8.TabIndex = 13;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 455);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPickFile);
            this.Name = "Form1";
            this.Text = "Ghost Generate v1.1 - Brent Pickup (Ayr State High School)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

