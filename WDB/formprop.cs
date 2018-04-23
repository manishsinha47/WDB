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
    public partial class HtmlForm : Form
    {
        public string FrmName
        { get; set; }

        public string FrmAction
        { get; set; }
        public string FrmMethod
        { get; set; }
        public string FrmEnctype
        { get; set; }
        public string FrmTargetFrame
        { get; set; }

        public HtmlForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HtmlForm_Load(object sender, EventArgs e)
        {
            frmMethod.SelectedItem = "POST";
            frmEnctype.SelectedItem = "text/plain";
            
        }

        
        

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            FrmName = frmName.Text;
            FrmAction = frmName.Text;
            FrmMethod = frmMethod.SelectedItem.ToString();
            FrmEnctype = frmEnctype.SelectedItem.ToString();
            FrmTargetFrame = frmTarget.Text;
        }
    }
}
