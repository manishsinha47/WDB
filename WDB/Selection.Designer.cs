namespace WDB
{
    partial class Selection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addSelectBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.optionValueTxtBox = new System.Windows.Forms.TextBox();
            this.optionTxtBox = new System.Windows.Forms.TextBox();
            this.multipleSelectionCb = new System.Windows.Forms.CheckBox();
            this.selectNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addOption = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addSelectBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.optionValueTxtBox);
            this.groupBox1.Controls.Add(this.optionTxtBox);
            this.groupBox1.Controls.Add(this.multipleSelectionCb);
            this.groupBox1.Controls.Add(this.selectNameTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 166);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection List";
            // 
            // addSelectBtn
            // 
            this.addSelectBtn.Location = new System.Drawing.Point(10, 109);
            this.addSelectBtn.Name = "addSelectBtn";
            this.addSelectBtn.Size = new System.Drawing.Size(100, 26);
            this.addSelectBtn.TabIndex = 8;
            this.addSelectBtn.Text = "Add Name";
            this.addSelectBtn.UseVisualStyleBackColor = true;
            this.addSelectBtn.Click += new System.EventHandler(this.addSelectBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Value";
            this.label3.Visible = false;
            // 
            // optionValueTxtBox
            // 
            this.optionValueTxtBox.Location = new System.Drawing.Point(130, 66);
            this.optionValueTxtBox.Name = "optionValueTxtBox";
            this.optionValueTxtBox.Size = new System.Drawing.Size(153, 22);
            this.optionValueTxtBox.TabIndex = 5;
            this.optionValueTxtBox.Visible = false;
            // 
            // optionTxtBox
            // 
            this.optionTxtBox.Location = new System.Drawing.Point(130, 24);
            this.optionTxtBox.Name = "optionTxtBox";
            this.optionTxtBox.Size = new System.Drawing.Size(153, 22);
            this.optionTxtBox.TabIndex = 4;
            this.optionTxtBox.Visible = false;
            // 
            // multipleSelectionCb
            // 
            this.multipleSelectionCb.AutoSize = true;
            this.multipleSelectionCb.Location = new System.Drawing.Point(130, 113);
            this.multipleSelectionCb.Name = "multipleSelectionCb";
            this.multipleSelectionCb.Size = new System.Drawing.Size(140, 21);
            this.multipleSelectionCb.TabIndex = 3;
            this.multipleSelectionCb.Text = "&Multiple Selection";
            this.multipleSelectionCb.UseVisualStyleBackColor = true;
            // 
            // selectNameTxtBox
            // 
            this.selectNameTxtBox.Location = new System.Drawing.Point(130, 24);
            this.selectNameTxtBox.Name = "selectNameTxtBox";
            this.selectNameTxtBox.Size = new System.Drawing.Size(153, 22);
            this.selectNameTxtBox.TabIndex = 1;
            this.selectNameTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectNameTxtBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "List &Name";
            // 
            // addOption
            // 
            this.addOption.Enabled = false;
            this.addOption.Location = new System.Drawing.Point(6, 24);
            this.addOption.Name = "addOption";
            this.addOption.Size = new System.Drawing.Size(125, 36);
            this.addOption.TabIndex = 2;
            this.addOption.Text = "&Add Option";
            this.addOption.UseVisualStyleBackColor = true;
            this.addOption.Click += new System.EventHandler(this.addOption_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(6, 98);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(125, 36);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "&Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addOption);
            this.groupBox2.Controls.Add(this.removeBtn);
            this.groupBox2.Location = new System.Drawing.Point(321, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 166);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.Location = new System.Drawing.Point(321, 440);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 36);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(187, 440);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(125, 36);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(9, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "_______________________________________________________";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(2, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(458, 225);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Text";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 135;
            // 
            // Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 495);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Selection";
            this.Text = "Select List ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox selectNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox multipleSelectionCb;
        private System.Windows.Forms.Button addOption;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox optionTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox optionValueTxtBox;
        private System.Windows.Forms.Button addSelectBtn;
    }
}