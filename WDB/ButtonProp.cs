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
    public partial class ButtonProp : Form
    {

        public string BtnInnerHtml
        {
            get;set;

        }
        public string BtnType
        {
            get;set;
        }
        public string BtnValue
        {
            get;set;
        }

        public string BtnName
        {
            get;set;
        }
        public ButtonProp()
        {
            InitializeComponent();
            typeCb.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnType = typeCb.SelectedItem.ToString();
            BtnName = nameTxtBox.Text;
            BtnValue = valueTxtBox.Text;
            BtnInnerHtml = innerHtmlTxtBx.Text;
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
              
        }
    }
}
