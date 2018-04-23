using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using mshtml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BrowserSettings;
using System.Net.NetworkInformation;
namespace WDB
{
    public partial class WYSIWYG : Form,IMsgs
    {
        #region Variable Declaration
        private IHTMLDocument2 doc;
        string imgPath;
        private ChatBot bot;
        private Insert_Table insertTable;
        private OnGoingTaskNotifier customProgressBar;
        static  private CodeEditor ce;
        private ProjectLocationDialog pldfrm;
        private static Uri CurrentPageLocation=null;
        private static string CurrentPageContent = null;
        private Dictionary<string, string> formatBlockTypes;
        #endregion
        #region Constructor
        public WYSIWYG()
        {
            InitializeComponent();
            new BrowserRegistrySettings(webBrowser1);
            customProgressBar = new OnGoingTaskNotifier();
            bot = new ChatBot(webBrowser1);  // only for Shivam Som
            FormatDelegate = new Func<string, bool, object, bool>(TextEditing);
            SaveUserProjectDelegate = new Action(SaveUserProject);
            OpenUserProjectDelegate = new Action(OpenUserProject);
            NewUserProjectDelegate = new Action(NewUserProject);
            ShowTreeViewDelegate = new Action(ShowProjectView);
            DesignerActivateDelegate = new Action(DesignerOn);
            SwapBtnGrp = new Action<bool>(groupBoxToggle);
        }
        #endregion

        #region Loading Area
        private  void Form1_Load(object sender, EventArgs e)
        { 
            try
            {
                Form1 cBotFrm = new Form1();
                cBotFrm.TopLevel = false;
                cBotFrm.AutoScroll = true;
                Form1.Wb1 = webBrowser1;
                this.splitContainerParent.Panel1.Controls.Add(cBotFrm);
                cBotFrm.Show();
                LoadUserSetting();                   
               
                designModeMenuItem.CheckOnClick = true;
                webBrowser1.ScriptErrorsSuppressed = true;

                loadDefaultWebpage();  //don't put this in Threading, dependency on line 57 
                fillComboxBox();
                


            }
            catch (Exception ex)
            {
                PrintMsg(ex);
            }
        }
        #endregion
        #region Form Closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUserSetting();
        }

        #endregion

       
        private  void toggleDesignMode(object sender, EventArgs e)
        {   DesignerOnOffToggle(); }
        #region WYSIWYG COMPONENTS
        #region FormatBlock ComboBox
        private void formatBlockToolStripBtn_TextChanged(object sender, EventArgs e)
        {
            string selectedFormatBlock;
            formatBlockTypes.TryGetValue(formatBlockToolStripBtn.SelectedItem.ToString(), out selectedFormatBlock);
            FormatDelegate("FormatBlock", true, selectedFormatBlock);
        }
        #endregion
        #region Indent
        private void indentToolStripButton_Click(object sender, EventArgs e)
        {
            FormatDelegate("Indent", false, null);
        }
        #endregion
        #region Outdent
        private void outdentToolStripButton_Click(object sender, EventArgs e)
        {
            FormatDelegate("Outdent", false, null);
        }
        #endregion
        #region Insert Paragraph
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TextEditing("insertParagraph", true, "[Insert Text Here]");
        }
        #endregion
        #region Font and Sizes Formatting

        private void fontNameComboBox_TextChanged(object sender, EventArgs e)
        {
            TextEditing("FontName", false, fontNameComboBox.SelectedItem.ToString());
        }
        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            TextEditing("FontSize", false, fontSizeComboBox.Text);
           
        }
        #endregion
        #region Undo and Redo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormatDelegate("undo", false, null);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormatDelegate("redo", false, null);
        }
        #endregion
        #region Bold,Italic,UnderLine
        private void boldBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("bold", false, null);
           
        }
        private void italicBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("italic", false, null);

        }
        private void underlineBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("Underline", false, null);
        }
        #endregion
        #region Strikethrough,SuperScript,Subscript
        private void strikeBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("StrikeThrough", false, null);
          
        }
        private void supBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("SuperScript", false, null);
        }
        private void subBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("SubScript", false, null);
        }
        #endregion
        #region Cut,copy,paste
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            FormatDelegate("cut", false, null);
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            FormatDelegate("copy", false, null);
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            FormatDelegate("paste", false, null);
        }
        #endregion
        #region HyperLinking
        private void addHyperLink_Click(object sender, EventArgs e)
        {
            FormatDelegate("CreateLink", true, null);
        }
        private void removeHyperLink_Click(object sender, EventArgs e)
        {
            FormatDelegate("Unlink", true, null);
        }
        #endregion
        #region Alignment
        private void alignLeft_Click(object sender, EventArgs e)
        {
            FormatDelegate("justifyLeft", false, null);
        }

        private void alignCenter_Click(object sender, EventArgs e)
        {
            FormatDelegate("justifyCenter", false, null);
        }

        private void alignRight_Click(object sender, EventArgs e)
        {
            FormatDelegate("justifyRight", false, null);
        }

        private void alignFull_Click(object sender, EventArgs e)
        {
            FormatDelegate("justifyFull", false, null);
        }

        #endregion
        #region Add Image
        private void addImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Image Files(*.JPG; *.JPEG; *.PNG; *.BMP; *.GIF)|*.JPG; *.JPEG; *.PNG; *.BMP; *.GIF ";
                    ofd.ShowDialog();
                    imgPath = ofd.FileName;
                    if (ProjectFolderPath != null && imgPath != "")
                    {
                        if (!imgPath.Equals(ProjectFolderPath + @"\css\" + ofd.SafeFileName))
                        { File.Copy(imgPath, ProjectFolderPath + @"\css\" + ofd.SafeFileName, true); }
                        imgPath = ProjectFolderPath + @"\css\" + ofd.SafeFileName;
                        TextEditing("InsertImage", false, imgPath);
                    }
                    else if (imgPath != "")
                    {
                        TextEditing("InsertImage", false, imgPath);
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    Directory.CreateDirectory(ProjectFolderPath + @"\css");
                    File.Copy(imgPath, ProjectFolderPath + @"\css\" + ofd.SafeFileName, true); 

                }
            }
            }
        
        #endregion
        #region Text Highlight
        private void textHighlightBtn_Click(object sender, EventArgs e)
        {
            using (ColorDialog obj = new ColorDialog())
            {
                if(obj.ShowDialog()== DialogResult.OK)
                {
                    TextEditing("backColor", true, obj.Color);
                    
                }

            }

        }


        #endregion
        #region Font Color
        private void fontColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog clrobj = new ColorDialog())
            {
                if (clrobj.ShowDialog() == DialogResult.OK)
                {
                    TextEditing("forecolor", true, clrobj.Color);
                    fontColor.ForeColor = clrobj.Color;
                }
            }
        }
        #endregion
        #region InOrder List
        private void inOrderListBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("insertOrderedList", true, null);
        }
        #endregion
        #region UnorderList
        private void inUnorderedListBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("insertUnOrderedList", true, null);
        }
        #endregion
        #region HorizontalRule
        private void horizontalRuleBtn_Click(object sender, EventArgs e)
        {
            FormatDelegate("insertHorizontalRule", true, null);
        }


        #endregion
        #region Draw Table
        private void insertTableToolStripBtn_Click(object sender, EventArgs e)
        {
            #region Table Insert
            if (doc.designMode == "On")
            {
                HtmlElement table, tbody, thead, th, tr, td;
               
                using (insertTable = new Insert_Table())
                {
                    table = webBrowser1.Document.CreateElement("table");
                    insertTable.doc = webBrowser1.Document;
                    insertTable.ShowDialog();

                    if (insertTable.TableRows != 0 && insertTable.TableColumns != 0)
                    {
                        int ntr = insertTable.TableRows;


                        webBrowser1.Document.ActiveElement.AppendChild(table);
                        if (insertTable.IsFirstRowTableHead)
                        {
                            thead = webBrowser1.Document.CreateElement("thead");
                            table.AppendChild(thead);

                            tr = webBrowser1.Document.CreateElement("tr");  //1 row for <th>'s
                            thead.AppendChild(tr);
                            for (int i = 0; i < insertTable.TableColumns; i++)
                            {
                                th = webBrowser1.Document.CreateElement("th");
                                th.InnerText = "Header" + i.ToString();
                                tr.AppendChild(th);
                            }
                            ntr = ntr - 1;
                        }
                        tbody = webBrowser1.Document.CreateElement("tbody");
                        table.AppendChild(tbody);

                        for (int i = 0; i < ntr; i++)
                        {

                            tr = webBrowser1.Document.CreateElement("tr");
                            tbody.AppendChild(tr);

                            for (int j = 0; j < insertTable.TableColumns; j++)
                            {
                                td = webBrowser1.Document.CreateElement("td");
                                td.InnerText = i.ToString();
                                tr.AppendChild(td);
                            }
                        }
                      //  table.SetAttribute("border", "1px");
                        //  MessageBox.Show(table.GetHashCode().ToString());
                    }

                }

            }
            else
            {
                MessageBox.Show("Design Mode OFF. NOPE!!!!!!!!!");
            }
            #endregion
        }

        #endregion
        #endregion

        #region MenuItems Events

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserProjectDelegate();
        }
        
        private  void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUserProjectDelegate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUserProjectDelegate();
        }
        private void templateLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TemplateLocationDialog tld = new TemplateLocationDialog())
            {
                tld.ShowDialog();
            }
        }
        #endregion

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyData == Keys.Enter)&&textBox1.Text!="")
            {
                webBrowser1.Navigate(textBox1.Text);
            }
        }

        #region Robotics
        private void UserYes_Click(object sender, EventArgs e)
        {
            bot.like();
        }

      

        private async void PrevTemp_Click(object sender, EventArgs e)
        {
            var templateUrl = bot.GetPreviousTemplate;
            if (templateUrl != null)
                await Task.Run(()=> {
                                         webBrowser1.Navigate(templateUrl);
                                    }
                              );                                
            else
            { MessageBox.Show("Thats All we have for now."); }

        }

        private async void NextTemp_Click(object sender, EventArgs e)
        {
            var templateUrl = bot.GetNextTemplate;
            if (templateUrl != null)
            {
                await Task.Run(() => {
                                             webBrowser1.Navigate(templateUrl);
                                     }
                              );
            }
            else
            { MessageBox.Show("Thats All we have for now."); }
        }
  

        private async void WebsiteType_KeyDown(object sender, KeyEventArgs e)
        {
            
           
            if(e.KeyData == Keys.Enter && (WebsiteType.Text!=""))
            {
                try
                {
                    
                    //Photography

                    bot.websiteType(WebsiteType.Text);
                    await Task.Run(() =>
                                    {
                                        webBrowser1.Navigate(bot.GetFirstTemplate);
                                    });

                    //to be implemented in ChatBot from line 359 to 363
                    #region Don't Touch
                    groupBox2.Enabled = true;  
                    groupBox1.Enabled = true;
                    e.SuppressKeyPress = true;
                    Properties.Settings.Default.UserSearch = WebsiteType.Text;
                    Properties.Settings.Default.Save();
                    //----------------------------------
                    #endregion
                }
                catch (TemplateNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(Exception ex)
                {    
                    PrintMsg(ex);
                }
                finally
                {
                    
                }
               
            }
        }

        private void WebsiteType_Enter(object sender, EventArgs e)
        {
            WebsiteType.Text = Properties.Settings.Default.UserSearch;
        }
        #endregion

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);

            //if((e.CurrentProgress>0) && (e.CurrentProgress < 100))
            //{
            //    progressBar1.Value = Convert.ToInt32(e.CurrentProgress);
            //}
            //    progressStatus.Text = ((e.CurrentProgress/progressBar1.Maximum)*100) + " %"; 
        }
        #region Code Editor
        private void codeBtn_Click(object sender, EventArgs e)
        {
            OpenCodeEditor();       
        }
        private void backgroundWorkerCE_DoWork(object sender, DoWorkEventArgs e)
        {
            ce = new CodeEditor(UpdateWebBrowserContent, (string)e.Argument);
            ce.ShowDialog();

        }
        #endregion
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FormatDelegate("FormatBlock", false, "<blockquote>");
        }

       

        private void WYSIWYG_KeyDown(object sender, KeyEventArgs e)
        {
            #region Ctrl+E
            if (e.Control && e.KeyCode.ToString()=="E")  
            {
                OpenCodeEditor();
               
            }
            #endregion
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            CurrentPageLocation = webBrowser1.Document.Url;
            CurrentPageContent = webBrowser1.DocumentText;
   //         richTextBox1.Text = CurrentPageLocation.ToString();
        }

        private void CreateInputElement(string type, string name , string value,string placeholder)
        {
            HtmlElement element = webBrowser1.Document.CreateElement("input");
            element.SetAttribute("type", type);
            element.SetAttribute("name", name);
            element.SetAttribute("value", value);
            if(type=="Text"||type=="Password")
            { element.SetAttribute("placeholder", placeholder);
            }
            webBrowser1.Document.ActiveElement.AppendChild(element);

        }
        private void buttonToolStripButton3_Click(object sender, EventArgs e)
        {
            #region UnManaged Button Code
            //    IHTMLElement elem = doc.createElement("BUTTON");
            //    elem.innerText = "Touche,Pussy Cat";
            //    (doc.activeElement as IHTMLDOMNode).appendChild(elem as IHTMLDOMNode);
            #endregion

            #region Managed Button Code
            HtmlElement el = webBrowser1.Document.CreateElement("Button");
            el.SetAttribute("type", "reset");
            el.InnerText = "Ok";

            webBrowser1.Document.ActiveElement.AppendChild(el);
           

            #endregion

        }

        private void radioBtn_Click(object sender, EventArgs e)
        {
            if (doc.designMode == "On")
            {
                HtmlElement el = webBrowser1.Document.CreateElement("input");
                el.SetAttribute("type", "radio");
                el.SetAttribute("name", "xyz");
                webBrowser1.Document.ActiveElement.AppendChild(el);
            }
            else { MessageBox.Show("Design mode is Off!"); }
        }

        private void checkboxBtn_Click(object sender, EventArgs e)
        {
            if (doc.designMode == "On")
            {
                HtmlElement el = webBrowser1.Document.CreateElement("input");
                el.SetAttribute("type", "checkbox");
                el.SetAttribute("checked", "false");
                webBrowser1.Document.ActiveElement.AppendChild(el);
            }
            else { MessageBox.Show("Design mode is Off!"); }
        }

        private void toolStripBackground_Click(object sender, EventArgs e)
        {
            if (doc.designMode == "On")
            {
                MultiTypePropertyWindow window = new MultiTypePropertyWindow();
                window.Element = webBrowser1.Document.Body;
                if (DialogResult.OK == window.ShowDialog())
                {
                    if (ProjectFolderPath != null)
                    {
                        if (window.FileName != null)
                        {
                            string temp = ProjectFolderPath + @"\css\" + Path.GetFileName(window.FileName);
                            File.Copy(window.FileName, temp, true);
                            webBrowser1.Document.Body.SetAttribute("background", temp);
                            webBrowser1.Document.Body.Style = "background-repeat:no-repeat;background-size:cover;background-position:center;";

                        }
                        else
                        {
                            webBrowser1.Document.Body.SetAttribute("background", "");
                        }
                        // MessageBox.Show(webBrowser1.DocumentText);
                        File.WriteAllText(CurrentPageLocation.AbsolutePath, webBrowser1.DocumentText);
                    }
                }
            }

        }

        private void defaultSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveProjectTo obj = new SaveProjectTo())
            {
                if (obj.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        private void formBtn_ButtonClick(object sender, EventArgs e)
        {
            HtmlElement form = webBrowser1.Document.CreateElement("form");
            //form
            if (doc.designMode == "On")
            {
                HtmlForm frmObj = new HtmlForm();
                if (DialogResult.OK == frmObj.ShowDialog())
                {
                    form.SetAttribute("name", frmObj.FrmName);
                    form.SetAttribute("method", frmObj.FrmMethod);
                    form.SetAttribute("action", frmObj.FrmAction);
                    form.SetAttribute("enctype", frmObj.FrmEnctype);
                    form.SetAttribute("target", frmObj.FrmTargetFrame);


                    webBrowser1.Document.ActiveElement.AppendChild(form).Focus();
                    form.Style = "border: 1px dotted red; padding : 10px;";

                }
            }
            else
            { MessageBox.Show("Design Mode OFF"); }
         
        }

        private void formFieldToolStripMenuItem_Click(object sender, EventArgs e)
        { Input inp;
            if (doc.designMode == "On")
            {
                using (inp = new Input())
                {
                    if (DialogResult.OK == inp.ShowDialog())
                    {
                        CreateInputElement(inp.FieldType, inp.FieldName, inp.InitialValue, inp.PlaceholderText);
                    }
                }
            }
            else
            { MessageBox.Show("Design Mode is Off."); }
        }

        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection selObj;
            if (doc.designMode == "On")
            {
                using (selObj = new Selection()) {
                    if(DialogResult.OK==selObj.ShowDialog())
                    {
                        CreateSelectTag(selObj);     
                   
                    }
                }
            }
            else
            {
                MessageBox.Show("Design Mode is Off");
            }
        }

        private void CreateSelectTag(Selection obj)
        {
            HtmlElement selectTag;
            HtmlElement optionTag;
            
            selectTag = webBrowser1.Document.CreateElement("select");
            if(obj.SelectMultiple!="")
            {
                selectTag.SetAttribute("multiple", "true");
            }
            selectTag.Name = obj.SelectTagName;
            for (int i= 0;i< obj.Option.Length;i++)
            {
                optionTag = webBrowser1.Document.CreateElement("option");

                optionTag.InnerHtml = obj.Option[i].Name;
                optionTag.SetAttribute("value", obj.Option[i].Value);

                selectTag.AppendChild(optionTag);

            }
            webBrowser1.Document.ActiveElement.AppendChild(selectTag);
        }
        private void CreateButtonElement(string type,string value,string name,string innerHTML)
        {
            HtmlElement button = webBrowser1.Document.CreateElement("button");
            button.SetAttribute("type", type);
            button.SetAttribute("name", name);
            button.SetAttribute("value", value);
            button.InnerHtml = innerHTML;

            webBrowser1.Document.ActiveElement.AppendChild(button);

        }

        private void defineButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonProp btn;
            if (doc.designMode == "On")
            {
                using (btn = new ButtonProp())
                {
                    if(DialogResult.OK==btn.ShowDialog())
                    {
                        CreateButtonElement(btn.BtnType,btn.BtnValue,btn.BtnName,btn.BtnInnerHtml);
                    }
                }
            }else
            { MessageBox.Show("Design Mode is Off.");
            }
        }
    }
    }


