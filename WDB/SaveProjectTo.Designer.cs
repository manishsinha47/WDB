namespace WDB
{
    partial class SaveProjectTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveProjectTo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1BtnExit = new System.Windows.Forms.Button();
            this.panel1BtnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1PathTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2BtnOk = new System.Windows.Forms.Button();
            this.panel2BtnBrowse = new System.Windows.Forms.Button();
            this.panel2PathTxtBox = new System.Windows.Forms.TextBox();
            this.panel2NameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel1BtnExit);
            this.panel1.Controls.Add(this.panel1BtnOk);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel1PathTxtBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 140);
            this.panel1.TabIndex = 0;
            // 
            // panel1BtnExit
            // 
            this.panel1BtnExit.Location = new System.Drawing.Point(343, 100);
            this.panel1BtnExit.Name = "panel1BtnExit";
            this.panel1BtnExit.Size = new System.Drawing.Size(75, 34);
            this.panel1BtnExit.TabIndex = 4;
            this.panel1BtnExit.Text = "Exit";
            this.panel1BtnExit.UseVisualStyleBackColor = true;
            this.panel1BtnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1BtnOk
            // 
            this.panel1BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.panel1BtnOk.Location = new System.Drawing.Point(21, 100);
            this.panel1BtnOk.Name = "panel1BtnOk";
            this.panel1BtnOk.Size = new System.Drawing.Size(75, 34);
            this.panel1BtnOk.TabIndex = 3;
            this.panel1BtnOk.Text = "OK";
            this.panel1BtnOk.UseVisualStyleBackColor = true;
            this.panel1BtnOk.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(388, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 37);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1PathTxtBox
            // 
            this.panel1PathTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1PathTxtBox.Location = new System.Drawing.Point(21, 57);
            this.panel1PathTxtBox.Name = "panel1PathTxtBox";
            this.panel1PathTxtBox.Size = new System.Drawing.Size(361, 26);
            this.panel1PathTxtBox.TabIndex = 1;
            this.panel1PathTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save Project to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(62, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Field Cannot be Empty";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 29);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel2BtnOk);
            this.panel2.Controls.Add(this.panel2BtnBrowse);
            this.panel2.Controls.Add(this.panel2PathTxtBox);
            this.panel2.Controls.Add(this.panel2NameTxtBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 143);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name : ";
            // 
            // panel2BtnOk
            // 
            this.panel2BtnOk.Location = new System.Drawing.Point(333, 67);
            this.panel2BtnOk.Name = "panel2BtnOk";
            this.panel2BtnOk.Size = new System.Drawing.Size(84, 23);
            this.panel2BtnOk.TabIndex = 4;
            this.panel2BtnOk.Text = "OK";
            this.panel2BtnOk.UseVisualStyleBackColor = true;
            this.panel2BtnOk.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2BtnBrowse
            // 
            this.panel2BtnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.panel2BtnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2BtnBrowse.BackgroundImage")));
            this.panel2BtnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2BtnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2BtnBrowse.FlatAppearance.BorderSize = 0;
            this.panel2BtnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panel2BtnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.panel2BtnBrowse.Location = new System.Drawing.Point(387, 95);
            this.panel2BtnBrowse.Name = "panel2BtnBrowse";
            this.panel2BtnBrowse.Size = new System.Drawing.Size(30, 37);
            this.panel2BtnBrowse.TabIndex = 3;
            this.panel2BtnBrowse.UseVisualStyleBackColor = false;
            this.panel2BtnBrowse.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2PathTxtBox
            // 
            this.panel2PathTxtBox.Location = new System.Drawing.Point(23, 103);
            this.panel2PathTxtBox.Name = "panel2PathTxtBox";
            this.panel2PathTxtBox.Size = new System.Drawing.Size(349, 22);
            this.panel2PathTxtBox.TabIndex = 2;
            this.panel2PathTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // panel2NameTxtBox
            // 
            this.panel2NameTxtBox.Location = new System.Drawing.Point(84, 67);
            this.panel2NameTxtBox.Name = "panel2NameTxtBox";
            this.panel2NameTxtBox.Size = new System.Drawing.Size(232, 22);
            this.panel2NameTxtBox.TabIndex = 1;
            this.panel2NameTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(20, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "How do you want to Name your Project ?";
            // 
            // SaveProjectTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 188);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveProjectTo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Project To..";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveProjectTo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button panel1BtnExit;
        private System.Windows.Forms.Button panel1BtnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox panel1PathTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button panel2BtnOk;
        private System.Windows.Forms.Button panel2BtnBrowse;
        private System.Windows.Forms.TextBox panel2PathTxtBox;
        private System.Windows.Forms.TextBox panel2NameTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}