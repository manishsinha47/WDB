using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDB
{
    [Serializable]
    class Data
    {
        private  string saveProjPath;

      public Data(string path)
        {
            saveProjPath = path;
        }

        public String ProjPath
        {
            get { return saveProjPath; }
                
        }

    }   
}
