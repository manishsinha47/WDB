using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDB
{
    interface IMenuFunctions
    {
    
       string ProjectFolderPath
            {
            get;
        }
        #region New Project
        String NewProject();
       
        #endregion
        
    }
}
