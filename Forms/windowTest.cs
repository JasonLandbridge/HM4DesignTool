using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows;

namespace HM4DesignTool.Forms
{
    public partial class windowTest : Form
    {
        private windowMain WindowMain;
        public windowTest()
        {
            InitializeComponent();
        }



        public windowTest(windowMain parentWindow)
        {
            WindowMain = parentWindow;
            InitializeComponent();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
