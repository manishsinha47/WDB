using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WDB
{
    public partial class SaveProjectTo : Form
    {
        public SaveProjectTo()
        {
            InitializeComponent();
            panel1PathTxtBox.Text = Properties.Settings.Default.DefaultProjectSaveLocation;
            panel1.BringToFront();
        }

        public SaveProjectTo(object obj)
        {
            InitializeComponent();
            
            this.ControlBox = false;
            this.Name = null;
            panel2PathTxtBox.Text = Properties.Settings.Default.DefaultProjectSaveLocation;
            panel2.BringToFront();
           
        }

        private void alterInfoMsg(string text)
        {
            pictureBox1.Visible = true;
            label2.Visible = true;
            label2.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(panel1PathTxtBox.Text!="")
            { if(Directory.Exists(panel1PathTxtBox.Text))
                {
                    
                    label2.ForeColor = Color.Green;
                    alterInfoMsg("Path is Valid.");
                    SavePath();
                }
            else
                { alterInfoMsg("Entered Path to Folder is NOT Valid."); }

            }
           else
            { label2.Visible = true;
                pictureBox1.Visible = true;
            }
        }
        private void OpenFolder(ref TextBox txtBox)
        {
            using (FolderBrowserDialog fd = new FolderBrowserDialog())

            {
                fd.ShowNewFolderButton = true;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                 txtBox.Text   = fd.SelectedPath;

                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFolder(ref panel1PathTxtBox);
        }
        private void SavePath()
        {
            Properties.Settings.Default.DefaultProjectSaveLocation = panel1PathTxtBox.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("The Path Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && (panel1PathTxtBox.Text != ""))
            {
                SavePath();
            }
            if (e.KeyData == (Keys.Control | Keys.O))
            { OpenFolder(ref panel1PathTxtBox); }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.DefaultProjectSaveLocation == "")
            {
                e.Cancel = true;
                label2.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                e.Cancel = false;
                label2.Visible = false;
                pictureBox1.Visible = false;

            }


            base.OnFormClosing(e);
        }

        private void SaveProjectTo_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        { //panel 2
            OpenFolder(ref panel2PathTxtBox);
            Properties.Settings.Default.DefaultProjectSaveLocation = panel2PathTxtBox.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //panel2
            if(e.KeyData==(Keys.Enter))
            {
                ProjectSave();
            }
        }
        private void ProjectSave()
        {
            try
            {
                //panel2
                if (Directory.Exists(panel2PathTxtBox.Text) && panel2NameTxtBox.Text != "")
                {
                    WYSIWYG.ProjectFolderPath = panel2PathTxtBox.Text + @"\" + panel2NameTxtBox.Text;
                    Directory.CreateDirectory(WYSIWYG.ProjectFolderPath);
                    this.Close();
                }
                else
                { alterInfoMsg("Entered Path is NOT Valid."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ProjectSave();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            //panel 2
            if (e.KeyData == (Keys.Control | Keys.O))
            { OpenFolder(ref panel2PathTxtBox); }

        }
    }
}
