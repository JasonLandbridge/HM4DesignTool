using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nucs.JsonSettings;
using SettingsNamespace;

namespace HM4DesignTool.Forms
{
    public partial class windowSettings : Form
    {
        private windowMain WindowMain;
        private Settings SettingsObject;

        public windowSettings(windowMain parentWindow)
        {
            WindowMain = parentWindow;
            SettingsObject = parentWindow.SettingsObject;
            InitializeComponent();
            this.restoreSettings();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                projectDirectoryPathText.Text = folderPath;
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.saveSettings();
            this.Hide();
        }





        private void saveSettings()
        {
           /// Properties.Personal.Default["projectDirectoryPath"] = projectDirectoryPathText.Text;
          ////  Properties.Personal.Default.Save(); // Saves settings in application configuration file

            SettingsObject.ProjectDirectoryPath = projectDirectoryPathText.Text;
            SettingsObject.Save();
        }


        private void restoreSettings()
        {
            projectDirectoryPathText.Text = SettingsObject.ProjectDirectoryPath;
        }
    }
}
