using mshtml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WDB
{
    public partial class WYSIWYG : Form, IMsgs
    {
       private static    Func<string, bool, object, bool> FormatDelegate;
        private static Action SaveUserProjectDelegate, OpenUserProjectDelegate, NewUserProjectDelegate,DesignerActivateDelegate,ShowTreeViewDelegate;
        public static Action<bool> SwapBtnGrp;
     
        #region Properties
    
        private void DesignerOn()
        { 
            designModeMenuItem.Checked = true;

        }
       
        public static string ProjectFolderPath
        {
            get;
            set;
        }
        public static Action BotSaveProject
        {
            get { return SaveUserProjectDelegate; }
        }
        public static Action BotOpenProject
        {
            get { return OpenUserProjectDelegate; }
        }
        public static Action BotNewProject
        {
            get { return NewUserProjectDelegate; }
        }
        public static Action BotDesignerActivate
        {
            get { return DesignerActivateDelegate; }
        }
        public static Action BotShowTreeView
        {
            get { return ShowTreeViewDelegate; }
        }
        #endregion
        #region UserDefined Modules

        private void groupBoxToggle(bool val)
        {
            groupBox1.Enabled = val;
        }
        public void UpdateWebBrowserContent(string content)
        {
            File.WriteAllText(CurrentPageLocation.AbsolutePath, content);
            webBrowser1.Navigate(CurrentPageLocation);
        }
        private  void  ShowProjectView()
        {
            try
            {
                treeView1.Nodes.Clear();
                ProjectTree prjTree = new ProjectTree(ProjectFolderPath, treeView1);
                prjTree.Create();
              
            }catch(Exception ex)
            { PrintMsg(ex); }
        }
        private void NewUserProject()
        {

            pldfrm = new ProjectLocationDialog();
            pldfrm.ShowDialog();
            if (!String.IsNullOrWhiteSpace(ProjectFolderPath))
            { webBrowser1.Navigate(ProjectFolderPath + @"\index.html"); ShowProjectView(); }
          
        }
        private void OpenCodeEditor()
        {
            if (!backgroundWorkerCE.IsBusy)
            {
                backgroundWorkerCE.RunWorkerAsync(webBrowser1.DocumentText);
            }
            else
            { this.SendToBack(); }
        }
        private void OpenUserProject()
        {
            using (OpenFileDialog obj = new OpenFileDialog())
            {
                obj.Title = "Open Project...";
                obj.InitialDirectory = "d:/";  //to be specified during installation process and store in properties
                obj.Filter = "Html Files(*.html; *.htm)|*.html; *.htm | Php Files (*.php; *.PHP)| *.php; *.PHP|All Files(*.*)| *.*";
                if (obj.ShowDialog() == DialogResult.OK)
                {
                    ProjectFolderPath = Path.GetDirectoryName(obj.FileName);
                    webBrowser1.Navigate(obj.FileName);
                  
                }
                ShowProjectView();
            }
        }
        private void LoadUserSetting()
        {
            Location = new Point(Properties.Settings.Default.UserFX, Properties.Settings.Default.UserFY);
            Height = Properties.Settings.Default.UserFHeight;
            Width = Properties.Settings.Default.UserFWidth;
        }
        private void SaveUserSetting()
        {
            Properties.Settings.Default.UserFX = Location.X;
            Properties.Settings.Default.UserFY = Location.Y;

            Properties.Settings.Default.UserFHeight = Height;
            Properties.Settings.Default.UserFWidth = Width;
            Properties.Settings.Default.Save();
        }
        private async void SaveUserProject()
        {


            if (ProjectFolderPath != null)
            {
                
                Thread customProgressBarThread = new Thread(() => {
                    customProgressBar.ShowDialog();
                });
                
                customProgressBarThread.Start();
                CurrentPageContent = webBrowser1.DocumentText;
                await Task.Run(() => { File.WriteAllText(CurrentPageLocation.AbsolutePath, CurrentPageContent); Thread.Sleep(300); });
                customProgressBarThread.Abort();

            }
        }
        private void loadDefaultWebpage()
        {

            var path = Environment.CurrentDirectory + @"\WDBPage";
            webBrowser1.Url = new Uri(path + @"\index.html");
            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;

        }
        private void fillComboxBox()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                fontNameComboBox.Items.Add(font.Name);
            }
            formatBlockTypes = new Dictionary<string, string>();
            for (int i = 1; i <= 6; i++)
            { formatBlockTypes.Add("Heading " + i, "<h" + i + ">"); }
            formatBlockTypes.Add("Address", "<address>");
            formatBlockTypes.Add("Pre", "<pre>");
        }
        private  async void DesignerOnOffToggle()
        {
            try
            {
               
                doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
                Thread customProgressBarThread = new Thread(() => {
                    customProgressBar.ShowDialog();
                });
                Task designModeOnTask = new Task(() => {
                    doc.designMode = "On";
                });
                Task designModeOffTask = new Task(() => {
                    doc.designMode = "Off";
                });
              
                if (designModeMenuItem.Checked)
                {

                    webBrowser1.AllowNavigation = false;
                    webBrowser1.AllowWebBrowserDrop = false;
                    webBrowser1.IsWebBrowserContextMenuEnabled = false;


                    customProgressBarThread.Start();
                    this.Enabled = false;

                    designModeOnTask.Start();

                    await designModeOnTask;
                    this.Enabled = true;

                    customProgressBarThread.Abort();
                    label1.Text = "Designer Mode On";
                    designerModeIcon.Image = treeViewImageList.Images[20];

                    //for (int i = 0; i < coll.Count; i++)
                    //{
                    //    if (coll[i].TagName.ToLower() == "form")
                    //    {
                    //        coll[i].Style = "border:1px solid red;padding:10px";
                    //    }
                    //}

                }
                else
                {
                    customProgressBarThread.Start();
                    this.Enabled = false;

                    designModeOffTask.Start();
                    await designModeOffTask;
                    Thread.Sleep(10);
                    this.Enabled = true;

                    customProgressBarThread.Abort();
                    label1.Text = "Designer Mode Off";
                    designerModeIcon.Image = treeViewImageList.Images[19];
                    webBrowser1.AllowNavigation = true;
                    webBrowser1.AllowWebBrowserDrop = true;
                    webBrowser1.IsWebBrowserContextMenuEnabled = true;

                   


                }


            }
            catch (Exception ex)
            {
                PrintMsg(ex);
            }
        }
        private bool TextEditing(string cmd, bool showUI, object val)
        {
            try
            {
                if (doc.designMode == "On")
                {
                    webBrowser1.Document.ExecCommand(cmd, showUI, val);
                    return true;
                }
                else
                {
                    MessageBox.Show("Design Mode OFF");
                    return false;
                }
            }
            catch (Exception ex)
            { PrintMsg(ex); return false; }
        }
        public void PrintMsg(Exception ex)
        {
            MessageBox.Show("Message:" + ex.Message + "\nSource:" + ex.Source + "\nTargetSite:" + ex.TargetSite + "\n InnerException" + ex.InnerException);
            //  Environment.Exit(1);
        }
        #endregion

    }


    public class ProjectTree
    {
        private string path ;
        DirectoryInfo din;
      
        TreeNode rootNode, childNode;
        TreeView tree;
        public ProjectTree(string path)
        {

        }
       public  ProjectTree(string path,TreeView tree)
        {
            this.path = path;
            this.tree = tree;
        }
       private void specialIcon(TreeNode node, string ext)
        {
         ext=   ext.ToLower();
            switch(ext)
            {
                case ".avi": node.ImageIndex = 2; node.SelectedImageIndex = 2;break;
                case ".zip": node.ImageIndex = 3; node.SelectedImageIndex = 3;break;
                case ".psd": node.ImageIndex = 4; node.SelectedImageIndex = 4; break;
                case ".exe": node.ImageIndex = 5; node.SelectedImageIndex = 5; break;
                case ".iso": node.ImageIndex = 6; node.SelectedImageIndex = 6; break;
                case ".txt": node.ImageIndex = 7; node.SelectedImageIndex = 7; break;
                case ".doc": node.ImageIndex = 8; node.SelectedImageIndex = 8; break;
                case ".pdf": node.ImageIndex = 9; node.SelectedImageIndex = 9; break;
                case ".mp4": node.ImageIndex = 10; node.SelectedImageIndex = 10; break;
                case ".csv": node.ImageIndex = 11; node.SelectedImageIndex = 11; break;
                case ".xml": node.ImageIndex = 12; node.SelectedImageIndex = 12; break;
                case ".jpg": node.ImageIndex = 13; node.SelectedImageIndex = 13; break;
                case ".png": node.ImageIndex = 14; node.SelectedImageIndex = 14; break;
                case ".html": node.ImageIndex = 15; node.SelectedImageIndex = 15; break;
                case ".mp3": node.ImageIndex = 16; node.SelectedImageIndex = 16; break;
                case ".js": node.ImageIndex = 17; node.SelectedImageIndex = 17; break;
                case ".css": node.ImageIndex = 18; node.SelectedImageIndex = 18; break;
                default: node.ImageIndex = 1; node.SelectedImageIndex = 1;break;
            }


        }
        public void Create()
        {
            din = new DirectoryInfo(path);
            rootNode = new TreeNode(din.Name); //root node creation...
           
            tree.Nodes.Add(rootNode); //appending root node to tree.
            
            LoadSubDirectories(rootNode,din);
            LoadFiles(rootNode,din.GetFiles());
            rootNode.Expand();
        }
        public void LoadSubDirectories(TreeNode tn,DirectoryInfo din)
        {
            DirectoryInfo[] subDirInfo = din.GetDirectories();    
            foreach(DirectoryInfo dir in subDirInfo)
            {
                childNode = new TreeNode(dir.Name);
                
                tn.Nodes.Add(childNode);

                LoadSubDirectories(childNode, dir);
                LoadFiles(childNode,dir.GetFiles());
            }
          
        }

        public void LoadFiles(TreeNode tn,FileInfo[] fin)
        {
            TreeNode fnode;

            foreach (FileInfo f in fin)
            {
                fnode = new TreeNode(f.Name);
          specialIcon(fnode, f.Extension);
                tn.Nodes.Add(fnode);
            }
        }

    }
}
