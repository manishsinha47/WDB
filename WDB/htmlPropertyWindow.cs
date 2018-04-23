using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDB
{
    public partial class htmlPropertyWindow : Form
    { CSSProperties css;
       
        HtmlElement element;
        public htmlPropertyWindow()
        {
            InitializeComponent();
            
        }

        public htmlPropertyWindow(HtmlElement element)
        {
            InitializeComponent();
            this.element = element; //body
            //if (this.element.TagName == "table")
            //{
            //    CSSTableProperties cssTable = new CSSTableProperties();
            //    propertyGrid1.SelectedObject = cssTable;

            //}
            //else
            //{
                css = new CSSProperties();
                css.defaultProperty();
                propertyGrid1.SelectedObject = css;

            //}

        }
        private void htmlPropertyWindow_Load(object sender, EventArgs e)
        {
         
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.DialogResult)
            {
                element.Style = "background-color:" + ColorTranslator.ToHtml(Color.FromArgb(css.BackgroundColor.ToArgb())) +
                                ";background-repeat:" + css.BackgroundRepeat +
                                ";background-attachment:" + css.BackgroundAttachment +
                                ";background-position:" + css.BackgroundPosition +
                                ";background-size:" + css.BackgroundSize +
                                ";border-style:" + css.BorderStyle +
                                ";border-color:" + css.BorderColor +
                                ";border-width:" + css.BorderWidth + "px" +
                                ";margin-top:" + css.MarginTop + "px" +
                                ";margin-bottom:" + css.MarginBottom + "px" +
                                ";margin-left:" + css.MarginLeft + "px" +
                                ";margin-right:" + css.MarginRight + "px" +
                                ";padding-top:" + css.PaddingTop + "px" +
                                ";padding-bottom:" + css.PaddingBottom + "px" +
                                ";padding-left:" + css.PaddingLeft + "px" +
                                ";padding-right:" + css.PaddingRight + "px";
                    if(css.Display!="")
                {
                    element.Style = element.Style + ";display:" + css.Display;
                }
         

            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            this.Close();
        }
    }
    #region CSS BACKGROUND
    class CSSProperties
    {
        #region Background
        [CategoryAttribute("CSS Background")]
        public Color BackgroundColor
        { get; set; }


        [CategoryAttribute("CSS Background")]
        [Browsable(true)]
        [TypeConverter(typeof(BackgroundSize))]
        public string BackgroundSize
        {
            get; set;
        }

        [CategoryAttribute("CSS Background")]
        [Browsable(true)]
        [TypeConverter(typeof(BackgroundRepeat))]
        public string BackgroundRepeat
        {
            get; set;
        }
        [CategoryAttribute("CSS Background")]
        [Browsable(true)]
        [TypeConverter(typeof(BackgroundAttachment))]
        public string BackgroundAttachment
        { get; set; }

        [CategoryAttribute("CSS Background")]
        [Browsable(true)]
        [TypeConverter(typeof(BackgroundPosition))]
        public string BackgroundPosition
        { get; set; }
        #endregion

        #region Borders
        [CategoryAttribute("CSS Borders")]
        [Browsable(true)]
        [TypeConverter(typeof(BorderStyle))]
        public string BorderStyle
        { get; set; }

        [CategoryAttribute("CSS Borders")]
        public string BorderWidth
        { get; set; }

        [CategoryAttribute("CSS Borders")]
        public Color BorderColor
        { get; set; }
        #endregion

        #region Margins
        [Category("CSS Margins")]
        public string MarginLeft
        { get; set; }
        [Category("CSS Margins")]
        public string MarginRight
        { get; set; }
        
        [Category("CSS Margins")]
        public string MarginTop
        { get; set; }
        [Category("CSS Margins")]
        public string MarginBottom
        { get; set; }
        #endregion

        #region Padding
        [Category("CSS Padding")]
        public string PaddingLeft
        { get; set; }
        [Category("CSS Padding")]
        public string PaddingRight
        { get; set; }
        [Category("CSS Padding")]
        public string PaddingTop
        { get; set; }
        [Category("CSS Padding")]
        public string PaddingBottom
        { get; set; }
        #endregion

        #region Display
        [Category("CSS Display")]
        [Browsable(true)]
        [TypeConverter(typeof(Display))]
        public string Display
        { get; set; }

        #endregion

        public virtual void defaultProperty()
        {
            this.BackgroundColor = Color.White;
            this.BackgroundRepeat = "no-repeat";
            this.BackgroundAttachment = "scroll";
            this.BackgroundPosition = "left-top";
            this.BackgroundSize = "auto";
            this.BorderStyle = "none";
            this.BorderWidth = "1";
            this.BorderColor = Color.White;
            this.MarginTop = "3";
            this.MarginBottom = "3";
            this.MarginLeft = "3";
            this.MarginRight = "3";
            this.PaddingBottom = "3";
            this.PaddingTop = "3";
            this.PaddingLeft = "3";
            this.PaddingRight = "3";
        }
    }


   
    class BackgroundRepeat:System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("repeat");
            list.Add("repeat-x");
            list.Add("repeat-y");
            list.Add("no-repeat");
           
            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        
    }

    class BackgroundAttachment : System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("scroll");
            list.Add("fixed");
            list.Add("local");
          

            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }


    }

    class BackgroundPosition : System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("left top");
            list.Add("left center");
            list.Add("left bottom");
            list.Add("right top");
            list.Add("right center");
            list.Add("right bottom");
            list.Add("center top");
            list.Add("center center");
            list.Add("center bottom");
          


            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }


    }

    class BackgroundSize : System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("auto");
            list.Add("cover");
            list.Add("contain");
           


            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }


    }

    class BorderStyle : System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("none");
            list.Add("hidden");
            list.Add("dotted");
            list.Add("dashed");
            list.Add("solid");
            list.Add("double");
            list.Add("groove");
            list.Add("ridge");
            list.Add("inset");
            list.Add("outset");
            list.Add("dotted solid double dashed");
            list.Add("dotted solid");


            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }


    }

    class Display : System.ComponentModel.StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("none");
            list.Add("block");
            list.Add("inline");
            list.Add("inline-block");

            return new StandardValuesCollection(list);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }


    }



    #endregion
}

