using HM4DesignTool.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsNamespace;
using DataNameSpace;

namespace HM4DesignTool
{
    public partial class windowMain : Form
    {
        public Data DataObject = new Data();
        public Settings SettingsObject = new Settings();
        public windowSettings SettingsWindow;

        public windowMain()
        {
            InitializeComponent();
            SettingsWindow = new windowSettings(this);
            SettingsWindow.Hide();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow.Show();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            string text = SettingsObject.ProjectDirectoryPath;
            Console.WriteLine(text);

        }
    }
}
