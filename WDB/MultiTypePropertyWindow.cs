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
    public partial class MultiTypePropertyWindow : Form
    {
        public string FileName { get; set; }
        public HtmlElement Element {get;set;}

        public MultiTypePropertyWindow()
        {
            InitializeComponent();
            this.tableLayoutPanel1.BringToFront();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.FileName = propertyWindow1.ImagePath;
        }

        private void advancedBtn_Click(object sender, EventArgs e)
        {
            htmlPropertyWindow hpw = new htmlPropertyWindow(this.Element);
                      hpw.ShowDialog();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            this.FileName = "";
            MessageBox.Show("Deleted.Press Apply to continue.");
           
        }
    }
}
