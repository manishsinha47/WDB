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
    public partial class Input : Form
    {
     
        public string FieldType
        { get;
            set;
        }
        public string FieldName
        { get;
            set;

        }
        public string InitialValue
        { get;
            set;
        }
        public string PlaceholderText
        {
            get;set;
        }
        public Input()
        {
            InitializeComponent();

            fieldType.SelectedIndex = 0;

        }

        private void fieldType_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(fieldType.SelectedItem.ToString())
            {
                case "RadioButton":   label1.Text = "Group &Name";
                    break;
                case "Text": label2.Text = "Initial &Value"; label4.Visible = true; placeholderTxtBox.Visible = true;
                    break;
                case "Password": label2.Text = "Initial &Value"; label4.Visible = true; placeholderTxtBox.Visible = true;
                    break;
                default: label2.Text = "Field &Value";
                    label1.Text = "Field &Name";
                    label4.Visible = false; placeholderTxtBox.Visible =false;
                    break;

            }
            if (fieldType.SelectedItem.ToString().Equals("CheckBox"))
            {
                label2.Text = "Field &Value";
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            FieldType = fieldType.SelectedItem.ToString();
            FieldName = nameTxtBox.Text;
            InitialValue = valueTxtBox.Text;
      
            PlaceholderText = placeholderTxtBox.Text;
        }
    }
}
