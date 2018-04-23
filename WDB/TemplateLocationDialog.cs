using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDB
{
    public partial class TemplateLocationDialog : Form
    {

        public TemplateLocationDialog()
        {
            InitializeComponent();templatePath.Text = Properties.Settings.Default.DefaultTemplateLocation;
        }

     

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
           
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = true;
                if(fbd.ShowDialog()==DialogResult.OK)
                {
                    templatePath.Text = fbd.SelectedPath;
                   
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (templatePath.Text != "")
                SavePath();
        }

        private void SavePath()
        {
            Properties.Settings.Default.DefaultTemplateLocation = templatePath.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("The Path Saved Successfully.", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void Location_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter && (templatePath.Text!="") )
            {
                SavePath();
            }
          
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(Properties.Settings.Default.DefaultTemplateLocation=="")
            { e.Cancel = true;
               
                label2.Visible = true;
                infoPicture.Visible = true;
            }
            else
            {
                e.Cancel = false;
               
                label2.Visible = false;
                infoPicture.Visible = false;
            }
            base.OnFormClosing(e);
        }

        #region Backdoor to reset Property
        /// <summary>
        /// For Developers Only
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Control|Keys.Alt|Keys.B )){ resetProperty.Visible = true;  }
            else if(keyData == (Keys.Control | Keys.Alt | Keys.N)) { resetProperty.Visible = false; }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void resetProperty_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }
        #endregion
    }
}
