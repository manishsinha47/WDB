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

namespace WDB
{
    public partial class Insert_Table : Form
    {
        private ValueValidator vv;
     
        public HtmlDocument doc
        { get; set; }

        public int TableRows { get; set; }
        public int TableColumns { get; set; }
   
        public int TableWidth { get; set; }
        public int TableBorder { get; set; }

        public int TableCellSpacing { get; set; }
        public int TableCellPadding { get; set; }

        private CSSTableProperties csstbprop = new CSSTableProperties();

       public bool IsFirstRowTableHead
        {
            get {
                return isTableHead.Checked;
            }
        }
      
        public Insert_Table()
        {
            InitializeComponent();
            vv = new ValueValidator();
            propertyGrid1.SelectedObject = csstbprop;
            csstbprop.defaultProperty();
         }
      
       
        private void advanceBtn_Click(object sender, EventArgs e)
        {

        }
       
        private void Insert_Table_Load(object sender, EventArgs e)
        {
            tableRows.Text = "2";
            tableColumns.Text = "2";
            tableWidth.Text = "100";
            tableBorder.Text = "1";
            cPadding.Text = "2";
            cSpacing.Text = "2";


        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              TableRows =       vv.validateInteger(tableRows.Text, alertLbl1);
                alertLbl1.Visible = false;
               TableColumns=    vv.validateInteger(tableColumns.Text, alertLbl2);
                alertLbl2.Visible = false;
             TableWidth=        vv.validateInteger(tableWidth.Text, alertLbl3);
                alertLbl3.Visible = false;
              TableBorder=      vv.validateInteger(tableBorder.Text, alertLbl4);
                alertLbl4.Visible = false;
              TableCellSpacing = vv.validateInteger(cSpacing.Text, alertlbl5);
                alertlbl5.Visible = false;
                TableCellPadding = vv.validateInteger(cPadding.Text, alertlbl6);
                alertlbl6.Visible = false;

                HtmlElement element=doc.CreateElement("style");
                element.InnerText = "table,th,tr,td{" +
                                                    "border: " + csstbprop.BorderWidth + "px " + csstbprop.BorderStyle + " " + ColorTranslator.ToHtml(Color.FromArgb(csstbprop.BorderColor.ToArgb())) +";\n"+
                                                    "border-collapse:" + csstbprop.BorderCollapse +";\n"+
                                                    "background-color:" + ColorTranslator.ToHtml(Color.FromArgb(csstbprop.BackgroundColor.ToArgb())) + ";\n"+
                                                    "background-attachment:" + csstbprop.BackgroundAttachment +";\n"+
                                                    "background-position:" + csstbprop.BackgroundPosition +";\n"+
                                                    "background-repeat:" + csstbprop.BackgroundRepeat +";\n"+
                                                    "background-size:" + csstbprop.BackgroundSize +";\n"+
                                                    "margin:" + csstbprop.MarginTop + "px " + csstbprop.MarginBottom + "px " + csstbprop.MarginLeft + "px " + csstbprop.MarginRight+"px ;\n"+
                                                    "padding:" + csstbprop.PaddingTop + "px " + csstbprop.PaddingBottom + "px " + csstbprop.PaddingLeft + "px " + csstbprop.PaddingRight + "px ;\n" +

                                                    "}";
                                                   

                doc.Body.AppendChild(element);
                this.Close();
            }
            catch (ValidationFailedException vfe)
            {
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        
    }

    #region TableCss
    class CSSTableProperties : CSSProperties
    {
        [Category("Table Border")]
        public new int BorderWidth
        { get; set; }

        [Category("Table Border")]
        [Browsable(true)]
        [TypeConverter(typeof(TableBorderStyle))]
        public new string BorderStyle
        { get; set; }


        [Category("Table Border")]
        public new Color BorderColor
        { get; set; }
        [Category("Table Border")]
        public bool BorderCollapse
        { get; set; }

        public override void defaultProperty()
        {
            this.BorderWidth = 1;
            this.BorderStyle = "solid";
            this.BorderColor = Color.Black;
            this.BorderCollapse = false;

            this.BackgroundColor = Color.White;
            this.BackgroundRepeat = "no-repeat";
            this.BackgroundAttachment = "scroll";
            this.BackgroundPosition = "left-top";
            this.BackgroundSize = "auto";
           
            this.MarginTop = "1";
            this.MarginBottom = "1";
            this.MarginLeft = "1";
            this.MarginRight = "1";

            this.PaddingBottom = "1";
            this.PaddingTop = "1";
            this.PaddingLeft = "1";
            this.PaddingRight = "1";
        }

        public void applyChanges()
        {
        
            //create CSS make a static css files(styles.css)
        }

    }
    class TableBorderStyle : BorderStyle
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            list.Add("solid");
            list.Add("none");
            list.Add("hidden");
            list.Add("dotted");
            list.Add("dashed");

            return new StandardValuesCollection(list);
        }
        
    }
    #endregion


}
