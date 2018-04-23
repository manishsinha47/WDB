namespace WDB
{
    partial class HtmlForm
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
            this.Properties = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.frmTarget = new System.Windows.Forms.ComboBox();
            this.frmEnctype = new System.Windows.Forms.ComboBox();
            this.frmMethod = new System.Windows.Forms.ComboBox();
            this.actionUrl = new System.Windows.Forms.TextBox();
            this.frmName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Properties.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Properties
            // 
            this.Properties.AccessibleName = "Properties";
            this.Properties.Controls.Add(this.tabPage1);
            this.Properties.Controls.Add(this.tabPage2);
            this.Properties.Location = new System.Drawing.Point(-1, -2);
            this.Properties.Margin = new System.Windows.Forms.Padding(4);
            this.Properties.Name = "Properties";
            this.Properties.SelectedIndex = 0;
            this.Properties.Size = new System.Drawing.Size(383, 326);
            this.Properties.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cancelBtn);
            this.tabPage1.Controls.Add(this.okBtn);
            this.tabPage1.Controls.Add(this.frmTarget);
            this.tabPage1.Controls.Add(this.frmEnctype);
            this.tabPage1.Controls.Add(this.frmMethod);
            this.tabPage1.Controls.Add(this.actionUrl);
            this.tabPage1.Controls.Add(this.frmName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(375, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Define form";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(275, 250);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 28);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(201, 250);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(65, 28);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // frmTarget
            // 
            this.frmTarget.FormattingEnabled = true;
            this.frmTarget.Items.AddRange(new object[] {
            "_blank",
            "_self",
            "_parent",
            "_top"});
            this.frmTarget.Location = new System.Drawing.Point(144, 159);
            this.frmTarget.Margin = new System.Windows.Forms.Padding(4);
            this.frmTarget.Name = "frmTarget";
            this.frmTarget.Size = new System.Drawing.Size(160, 24);
            this.frmTarget.TabIndex = 9;
            // 
            // frmEnctype
            // 
            this.frmEnctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frmEnctype.FormattingEnabled = true;
            this.frmEnctype.Items.AddRange(new object[] {
            "application/x-www-form-urlencoded",
            "text/plain",
            "multipart/form-data"});
            this.frmEnctype.Location = new System.Drawing.Point(144, 125);
            this.frmEnctype.Margin = new System.Windows.Forms.Padding(4);
            this.frmEnctype.Name = "frmEnctype";
            this.frmEnctype.Size = new System.Drawing.Size(160, 24);
            this.frmEnctype.TabIndex = 8;
            this.frmEnctype.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // frmMethod
            // 
            this.frmMethod.AutoCompleteCustomSource.AddRange(new string[] {
            "POST",
            "GET"});
            this.frmMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frmMethod.FormattingEnabled = true;
            this.frmMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.frmMethod.Location = new System.Drawing.Point(144, 88);
            this.frmMethod.Margin = new System.Windows.Forms.Padding(4);
            this.frmMethod.Name = "frmMethod";
            this.frmMethod.Size = new System.Drawing.Size(103, 24);
            this.frmMethod.TabIndex = 7;
            this.frmMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // actionUrl
            // 
            this.actionUrl.Location = new System.Drawing.Point(144, 52);
            this.actionUrl.Margin = new System.Windows.Forms.Padding(4);
            this.actionUrl.Name = "actionUrl";
            this.actionUrl.Size = new System.Drawing.Size(197, 22);
            this.actionUrl.TabIndex = 6;
            // 
            // frmName
            // 
            this.frmName.Location = new System.Drawing.Point(144, 16);
            this.frmName.Margin = new System.Windows.Forms.Padding(4);
            this.frmName.Name = "frmName";
            this.frmName.Size = new System.Drawing.Size(197, 22);
            this.frmName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Target Frame:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Encoding";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Method:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Action URL:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(375, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // HtmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.Properties);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HtmlForm";
            this.Text = "Form Properties";
            this.Load += new System.EventHandler(this.HtmlForm_Load);
            this.Properties.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Properties;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox frmMethod;
        private System.Windows.Forms.TextBox actionUrl;
        private System.Windows.Forms.TextBox frmName;
        private System.Windows.Forms.ComboBox frmTarget;
        private System.Windows.Forms.ComboBox frmEnctype;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}

