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
    public partial class CodeEditor : Form
    {
        dynamic UserSetting = Properties.Settings.Default;
        private int indexToText;
        private Action<string> UpdateWebBrowserContentDelegate = null;
        private String contents;

        public CodeEditor(Action <string>UpdateWebBrowserContentDelegate,String contents)
        {
            InitializeComponent();
            this.contents = contents;
            this.UpdateWebBrowserContentDelegate = UpdateWebBrowserContentDelegate;   
        }
       
       
        private void CodeEditor_Load(object sender, EventArgs e)
        {
           
            Location = new Point(UserSetting.UserCEX, UserSetting.UserCEY);
            Height = UserSetting.UserCEHeight;
            Width = UserSetting.UserCEWidth;
            richTextBox1.Font = UserSetting.UserCEFont;
            AlteredPropertiesOnForm_Load();
        }
        private void AlteredPropertiesOnForm_Load()
        {
           
            this.MinimizeBox = false;
            richTextBox1.Text = contents;
            this.Focus();

        }
        private void CodeEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Dispose();
            UserSetting.UserCEHeight = this.Height;
            UserSetting.UserCEWidth = this.Width;
            UserSetting.UserCEX = Location.X;
            UserSetting.UserCEY = Location.Y;
            UserSetting.Save();
        }

        private void FontBtn_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                if(fd.ShowDialog()==DialogResult.OK)
                {
                    richTextBox1.Font = fd.Font;
                    UserSetting.UserCEFont = fd.Font;
                }
            }
        }
  
      
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {   
            notifyIcon1.ShowBalloonTip(10000);

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (!this.Focused)
            { this.BringToFront(); this.Focus(); }
            else
                notifyIcon1.ShowBalloonTip(10000);
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void tryItBtn_Click(object sender, EventArgs e)
        {
            UpdateWebBrowserContentDelegate.Invoke(richTextBox1.Text);
            //or
            //UpdateWebBrowserContentDelegate(richTextBox1.Text);
        }

        private void CodeEditor_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void findIntext_Click(object sender, EventArgs e)
        {
        }
    }
}
