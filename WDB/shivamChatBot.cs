using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace WDB
{
    public  partial  class ChatBot
    {
        private static List<String> templatesList;  //1 and 2 folder of photography
        private static int templateCounter = 0;
        private WebBrowser wb1;

        public ChatBot(WebBrowser wb1)
        {
            this.wb1 = wb1;
            if (Properties.Settings.Default.DefaultTemplateLocation == "")
            {
                using (var tld = new TemplateLocationDialog())
                {
                    tld.ShowDialog();
                }
             
            }
        }
            
        public string GetFirstTemplate
        {
            get
            {
                return templatesList.First() + @"\index.html";
            }
        }

        public string GetNextTemplate
        {
            get
            {
                if (templateCounter < templatesList.Count - 1)
                {

                    return templatesList.ElementAt(++templateCounter) + @"\index.html";
                }
                else
                    return null;
            }
        }
        public string GetPreviousTemplate
        {
            get
            {
                if (templateCounter > 0)
                {

                    return templatesList.ElementAt(--templateCounter) + @"\index.html";
                }
                else
                {

                    return null;
                }
            }
        }
        public int TemplateCounter
        {
            get { return templateCounter; } //for testing purpose..
            set { templateCounter = value; }
        }

        public void websiteType(string WebsiteType)
        {
            templatesList = new List<String>(); //Templates Path...
            string PATH = Properties.Settings.Default.DefaultTemplateLocation + @"\" + WebsiteType;
            if (Directory.Exists(PATH))
            {
                TemplateCounter = 0;
                foreach (String S in Directory.GetDirectories(PATH))
                {
                    templatesList.Add(S);
                }


            }
            else
            {
                throw new TemplateNotFoundException();
            }

        }

        public void like()
        {   if(WYSIWYG.ProjectFolderPath!=null)
            {
                Program.DirectoryCopy(templatesList.ElementAt(TemplateCounter), WYSIWYG.ProjectFolderPath,true);
            }
        else if(WYSIWYG.ProjectFolderPath==null)
            {
                using (SaveProjectTo dlg = new SaveProjectTo(null))
                {
                    dlg.ShowDialog();
                    Program.DirectoryCopy(templatesList.ElementAt(TemplateCounter), WYSIWYG.ProjectFolderPath, true);
                }
            }
            wb1.Navigate(WYSIWYG.ProjectFolderPath + @"\index.html");
            // MessageBox.Show(WYSIWYG.ProjectFolderPath);
            WYSIWYG.BotShowTreeView();
        }



    } // class ChatBot


    public class TemplateNotFoundException : Exception
    {
        private string message;
        public override string Message
        {
            get
            {
                return message;
            }
        }
        public TemplateNotFoundException()
        {
            message = "Couldn't find such template.";
        }
    }
}
