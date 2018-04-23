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
    public  partial class ProjectLocationDialog : Form,IMenuFunctions
    {
        public ProjectLocationDialog()
        {
            InitializeComponent();
        }

        public  string ProjectFolderPath
        {

            get;
            set;
        }

        public string NewProject()
        {   Directory.CreateDirectory(ProjectFolderPath);
            Directory.CreateDirectory(ProjectFolderPath + @"\css");
            Directory.CreateDirectory(ProjectFolderPath + @"\js");
            using (FileStream stream = new FileStream(ProjectFolderPath + @"\index.html", FileMode.CreateNew, FileAccess.ReadWrite))
            {
                string contents = "<html>\n<head>\n\t<title>"+nameTxtBox.Text+"</title>\n</head>\n<body>[Write Your Content Here...]</body>\n</html>";
                byte[] data = new UTF8Encoding(true).GetBytes(contents);
                stream.Write(data, 0, data.Length);
                WYSIWYG.ProjectFolderPath = ProjectFolderPath;
                stream.Close();
            }
            return nameTxtBox.Text;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {   try
            {
                if (!String.IsNullOrEmpty(locationTxtBox.Text) && !string.IsNullOrWhiteSpace(nameTxtBox.Text))
                {
                    if (radioButton1.Checked)
                    {
                        ProjectFolderPath = locationTxtBox.Text + @"\" + nameTxtBox.Text;
                        NewProject();
                        this.Close();
                    }
                    else
                    {
                        ProjectFolderPath = locationTxtBox.Text + @"\" + nameTxtBox.Text;
                        Directory.CreateDirectory(ProjectFolderPath);
                        Form1.AddOutMsgDel("What type of Website You want?. Like for ex. Sports, Fitness,Portfolio,etc..");
                        WYSIWYG.ProjectFolderPath = this.ProjectFolderPath;
                        this.Close();
                    }
                }
                else
                { MessageBox.Show("Please Enter valid filename and location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pldbrowseBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    folderBrowserDialog1.ShowNewFolderButton = true;
                    locationTxtBox.Text = folderBrowserDialog1.SelectedPath;

                }
            }
        }

        private void PldcancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
