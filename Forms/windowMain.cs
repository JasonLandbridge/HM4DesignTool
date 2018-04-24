
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM4DesignTool.Forms;
using SettingsNamespace;
using DataNameSpace;
using LevelData;

namespace Windows
{
    public partial class windowMain : Form
    {
        public windowSettings SettingsWindow;
        public windowTest TestWindow;


        public windowMain()
        {
            InitializeComponent();
            Globals.windowMainObject = this;
            SettingsWindow = new windowSettings(this);
            SettingsWindow.Hide();
            TestWindow = new windowTest(this);
            TestWindow.Hide();

            SetupWindow();
        }


        private void SetupWindow()
        {
            levelListFilter.Items.Add("All");
            levelListFilter.Items.AddRange(Globals.roomCategories.ToArray<String>());
            levelListFilter.SelectedIndex = 0;

            loadLevels();

        }

        private void loadLevels()
        {
            int roomIndex = levelListFilter.SelectedIndex;
            bool storyFilter = levelListStoryCheck.Checked;
            bool bonusFilter = levelListBonusCheck.Checked;
            bool unknownFilter = levelListUnknownCheck.Checked;


            List<String> levelList = Globals.DataObject.GetFilteredLevels(roomIndex, storyFilter, bonusFilter, unknownFilter);
            levelListDisplay.Items.Clear();
            foreach (String level in levelList)
            {
                levelListDisplay.Items.Add(level);
                Console.WriteLine(level);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SettingsWindow.Visible)
            {
                SettingsWindow.Show();
            }
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            string text = Globals.SettingsObject.projectPathData;
            Console.WriteLine(text);
            loadLevels();

        }

        private void onLevelFilterChange(object sender, EventArgs e)
        {
            loadLevels();
        }

        private void onLevelSelected(object sender, EventArgs e)
        {
            String levelName = levelListDisplay.SelectedItem.ToString();
            Level levelObject = Globals.DataObject.GetLevelByName(levelName);
            currentPreviewTextBox.Text = levelObject.GetCurrentLevelScript();
            afterPreviewTextBox.Text = levelObject.GetLevelScript();
        }

        private void testWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestWindow.Show();
        }
    }



}
