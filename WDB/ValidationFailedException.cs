using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WDB
{
    public class ValueValidator
    {
        public int validateInteger(string data, Label alertLbl) {
            try
            {
      return Convert.ToInt32(data);
            }
            catch (FormatException ex)
            {
                 
                throw new ValidationFailedException(alertLbl);
               
            }
      }
       //public char validateCharacter(string data, Label alertLbl) { return '0'; }
       // float validateFloat(string data, Label alertLbl) { return 0F; }
       // double validateDouble(string data, Label alertLbl) { return 0.0; }

    }
    class ValidationFailedException:Exception
    { 
        
        public ValidationFailedException(Label lbl)
        {
            lbl.Visible = true;
        }

        
       
    }
}
