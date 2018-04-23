using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDB
{
    public partial class OnGoingTaskNotifier : Form
    {
        public OnGoingTaskNotifier()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
        }
    }
}
