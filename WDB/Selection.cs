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
    public partial class Selection : Form
    {
      public struct optionTag
        {
           public string Name, Value;
        }
        public string SelectTagName
        {
            get;set;
        }
        public string SelectMultiple
        {
            get; set;

        }
        public optionTag[] Option
        {
            get ;set;
        }
        
        public Selection()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            SelectTagName = listView1.Items[0].Text;
            optionTag[] obj = new optionTag[listView1.Items.Count-1];
            Option = obj;
         for(int i=1; i<=listView1.Items.Count -1; i++)
            {
               obj[i-1].Name=  listView1.Items[i].SubItems[0].Text;
               obj[i-1].Value= listView1.Items[i].SubItems[1].Text;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createList()
        {
            item = new ListViewItem(selectNameTxtBox.Text);
            listView1.Items.Add(item);
            item.Focused = true;
            if (multipleSelectionCb.Checked)
            {
                SelectMultiple = "multiple";
            }
            else
            {
                SelectMultiple = "";
            }
            selectNameTxtBox.Visible = false;
            multipleSelectionCb.Visible = false;
            groupBox1.Text = "Option";
            optionTxtBox.Visible = true;
            label1.Text = "&Text";
            addOption.Enabled = true;
            label3.Visible = true;
            optionValueTxtBox.Visible = true;
            addSelectBtn.Visible = false;
        }
        ListViewItem item;
        private void selectNameTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                createList();    
            }
        }

      
        private void addOption_Click(object sender, EventArgs e)
        {
            if (optionTxtBox.Text != "" && optionValueTxtBox.Text != "")
            {
                ListViewItem optionItem = new ListViewItem(optionTxtBox.Text);

                optionItem.SubItems.Add(optionValueTxtBox.Text);

                listView1.Items.Add(optionItem);
            }
            else
            { MessageBox.Show("Fields Cannot Be  Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count >0)
            {
                listView1.Items.Remove(listView1.FocusedItem);
                
            }
        }

        private void addSelectBtn_Click(object sender, EventArgs e)
        {
            createList();
        }
    }
}
