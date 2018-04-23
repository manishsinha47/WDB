using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using BrowserSettings;
using mshtml;
using AIMLbot;
using System.Windows.Forms;
using System.Diagnostics;

namespace WDB
{
   public partial class ChatBot : Form,IMsgs
    {
        string entity = null, template_response = null, designer_response = null;
        WebClient wb = new WebClient();
        Form1 f = new Form1();
        string templateLike = "Do you like this template?";

        public String getOutput(String input)
        {
            #region LUIS Code
            input = input.ToLower();
            entity = luisLink(input);

            try
            {
                switch (entity)
                {
                    case "UserHello":
                        return "Good Day! How may I help you?";

                    case "Blog":
                        templateNavigate(entity);
                        return templateLike;

                    case "Business":
                        templateNavigate(entity);
                        return templateLike;

                    case "CarDealership":
                        templateNavigate(entity);
                        return templateLike;

                    case "Cooking":
                        templateNavigate(entity);
                        return templateLike;

                    case "Event":
                        templateNavigate(entity);
                        return templateLike;

                    case "Fitness":
                        templateNavigate(entity);
                        return templateLike;

                    case "Photography":
                        templateNavigate(entity);
                        return templateLike;

                    case "Portfolio":
                        templateNavigate(entity);
                        return templateLike;

                    case "Product":
                        templateNavigate(entity);
                        return templateLike;

                    case "Property":
                        templateNavigate(entity);
                        return templateLike;

                    case "Retail":
                        templateNavigate(entity);
                        return templateLike;

                    case "Services":
                        templateNavigate(entity);
                        return templateLike;

                    case "Sports":
                        templateNavigate(entity);
                        return templateLike;

                    case "Travelling":
                        templateNavigate(entity);
                        return templateLike;

                    case "Weather":
                        templateNavigate(entity);
                        return templateLike;

                    case "Positive":
                        if (template_response.Equals("shown"))
                        {
                            designer_response = "asked";
                            template_response = "lol";
                            like();
                            WYSIWYG.SwapBtnGrp(false);
                            return "Would you like to customize your template?";
                        }
                        else if (designer_response.Equals("asked"))
                        {
                            WYSIWYG.BotDesignerActivate();
                            return "Toggle design mode:CTRL+D. Save:CTRL+S";
                        }
                        else return null;

                    case "Negative":
                        if (template_response.Equals("shown"))
                        {
                            if (templateCounter < templatesList.Count - 1)
                            {
                                wb1.Navigate(GetNextTemplate);
                                return "What about this one?";
                            }
                            else
                                return "That's all the templates we have!";
                        }
                        else if (designer_response.Equals("asked"))
                        {
                            WYSIWYG.BotSaveProject();
                            return "Toggle design mode:CTRL+D. Save:CTRL+S";
                            //return "Save your file using the FILE menu or CTRL+S";
                        }
                        else return "";

                    case "OpenProject":
                        WYSIWYG.BotOpenProject();
                        return "Here you go!";

                    case "NewProject":
                        WYSIWYG.BotNewProject();
                        return "New project has been created!";

                    case "BotIntroduction":
                        return "Hi! I am Website Designer Bot!";

                    default: return entity;
                }
            }
            catch (ArgumentNullException ae)
            {
                PrintMsg(ae);
                return "I don't understand!";
            }
            catch (NullReferenceException ne)
            {
                PrintMsg(ne);
                return "I don't understand!";
            }
            catch(TemplateNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return "Sorry!!! Amigo";
            }
            catch(Exception e)
            {
                PrintMsg(e);        
                return "Sorry!!! Amigo";
            }
            
        }

        #endregion

        #region Template Navigation

        private void templateNavigate(string s)
        {
            websiteType(s);
            wb1.Navigate(GetFirstTemplate);
            template_response = "shown";
            WYSIWYG.SwapBtnGrp(true);
        }

        #endregion 

        #region LUIS Link
        private string luisLink(string usrInput)
        {
            string input = usrInput;
            string op = wb.DownloadString("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/15c6bd2a-ecdc-41de-a054-0cce461e13a3?subscription-key=b72bdbb572fe4e90837647eb9c82b1c0&verbose=true&timezoneOffset=0&q=" + input);
            var jsonParse = JsonConvert.DeserializeObject<JClass>(op);

            if (jsonParse.entities.Count != 0)
            {
                entity = jsonParse.entities[0].type;
                return entity;
            }
            else
            {
                AIMLChatBot a = new AIMLChatBot();
                string aiml_response = a.getOutput(input);
                return aiml_response;
            }
        }

        public void PrintMsg(Exception ex)
        {
            MessageBox.Show(ex.Message , "Exception Occured" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region AIML

        public class AIMLChatBot
        {
            const string UserId = "szabist";
            private Bot AimlBot;
            private User myUser;

            public AIMLChatBot()
            {
                AimlBot = new Bot();
                myUser = new User(UserId, AimlBot);
                Initialize();
            }

            // Loads all the AIML files in the \AIML folder         
            public void Initialize()
            {
                AimlBot.loadSettings();
                AimlBot.isAcceptingUserInput = false;
                AimlBot.loadAIMLFromFiles();
                AimlBot.isAcceptingUserInput = true;
            }

            // Given an input string, finds a response using AIMLbot lib
            public String getOutput(String input)
            {
                Request r = new Request(input, myUser, AimlBot);
                Result res = AimlBot.Chat(r);
                return (res.Output);
            }
        }
        #endregion

    }

}

