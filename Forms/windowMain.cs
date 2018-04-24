
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
        public PatientOverview PatientOverview;
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
            SetupPatientOverview();
        }


        private void SetupWindow()
        {
            levelListFilter.Items.Add("All");
            levelListFilter.Items.AddRange(Globals.roomCategories.ToArray<String>());
            levelListFilter.SelectedIndex = 0;

            loadLevels();

        }

        private void SetupPatientOverview()
        {
            PatientOverview = new PatientOverview();
            PatientOverview.patientOverviewLayout = patientOverviewLayout;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        #region ShortKeys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void buttonPatientOverviewAddRow_Click(object sender, EventArgs e)
        {
            PatientOverview.AddPatientRow();
        }
    }

    public class PatientOverview
    {
        private windowMain mainWindow = Globals.windowMainObject;
        public TableLayoutPanel patientOverviewLayout;

        private Dictionary<int, PatientOverviewRow> patientOverviewRowsDict = new Dictionary<int, PatientOverviewRow> { };

        public PatientOverview()
        {
            
        }

        public void AddPatientRow()
        {
            SuspendLayout(true);
            patientOverviewRowsDict.Add(patientOverviewRowsDict.Count, new PatientOverviewRow(this, patientOverviewLayout.RowCount));
            SuspendLayout(false);
        }

        public void SuspendLayout(bool state = true)
        {
            if (state)
            {
                patientOverviewLayout.SuspendLayout();
            }
            else
            {
                patientOverviewLayout.ResumeLayout(true);
            }
        }
    }

    public class PatientOverviewRow : Object
    {
        private PatientOverview parent;
        private TableLayoutPanel patientOverviewLayout;

        private int rowIndex = 0;

        private CheckBox patientRowSelect = new CheckBox();
        private TextBox patientRowName = new TextBox();
        private NumericUpDown patientRowDelay = new NumericUpDown();
        private NumericUpDown patientRowWeight = new NumericUpDown();
        private FlowLayoutPanel patientRowRandomLayout = new FlowLayoutPanel();
        private Button patientRowRandomButton = new Button(); 
        private CheckBox patientRowRandomRangeSelect = new CheckBox();
        private NumericUpDown patientRowRandomRangeMin = new NumericUpDown();
        private Label patientRowRandomRangeLabel = new Label();
        private NumericUpDown patientRowRandomRangeMax = new NumericUpDown();
        private FlowLayoutPanel patientRowTreatmentLayout = new FlowLayoutPanel();
        private ComboBox patientRowTreatment1 = new ComboBox();
        private ComboBox patientRowTreatment2 = new ComboBox();
        private ComboBox patientRowTreatment3 = new ComboBox();
        private ComboBox patientRowTreatment4 = new ComboBox();
        private Button patientRowTreatmentButton = new Button();
        private Button patientRowTraits = new Button();

        public PatientOverviewRow(PatientOverview parentPatientOverview, int rowIndex)
        {
            parent = parentPatientOverview;
            this.rowIndex = rowIndex;
            patientOverviewLayout = parent.patientOverviewLayout;
            ConstructRow();
            SetupRow();
        }

        private void ConstructRow()
        {

            patientOverviewLayout.RowCount = patientOverviewLayout.RowCount + 1;
            patientOverviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

            this.patientOverviewLayout.Controls.Add(this.patientRowSelect, 0, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowName, 1, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowDelay, 3, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowWeight, 4, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowRandomLayout, 5, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTreatmentLayout, 6, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTreatmentButton, 7, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTraits, 8, rowIndex);


        }

        private void SetupRow()
        {
            // 
            // patientRowSelect
            // 
            this.patientRowSelect.AutoSize = true;
            this.patientRowSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientRowSelect.Location = new System.Drawing.Point(4, 4);
            this.patientRowSelect.MaximumSize = new System.Drawing.Size(0, 25);
            this.patientRowSelect.Name = "patientRowSelect";
            this.patientRowSelect.Size = new System.Drawing.Size(15, 24);
            this.patientRowSelect.TabIndex = 1;
            this.patientRowSelect.UseVisualStyleBackColor = true;
            // 
            // patientRowName
            // 
            this.patientRowName.Location = new System.Drawing.Point(26, 7);
            this.patientRowName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowName.MinimumSize = new System.Drawing.Size(120, 4);
            this.patientRowName.Name = "patientRowName";
            this.patientRowName.Size = new System.Drawing.Size(120, 20);
            this.patientRowName.TabIndex = 2;
            // 
            // patientRowDelay
            // 
            this.patientRowDelay.Location = new System.Drawing.Point(154, 7);
            this.patientRowDelay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowDelay.MaximumSize = new System.Drawing.Size(80, 0);
            this.patientRowDelay.Name = "patientRowDelay";
            this.patientRowDelay.Size = new System.Drawing.Size(80, 20);
            this.patientRowDelay.TabIndex = 3;
            this.patientRowDelay.ThousandsSeparator = true;
            // 
            // patientRowWeight
            // 
            this.patientRowWeight.Location = new System.Drawing.Point(241, 7);
            this.patientRowWeight.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowWeight.MaximumSize = new System.Drawing.Size(80, 0);
            this.patientRowWeight.MinimumSize = new System.Drawing.Size(100, 0);
            this.patientRowWeight.Name = "patientRowWeight";
            this.patientRowWeight.Size = new System.Drawing.Size(100, 20);
            this.patientRowWeight.TabIndex = 4;
            // 
            // patientRowRandomLayout
            // 
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomButton);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeSelect);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeMin);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeLabel);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeMax);
            this.patientRowRandomLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowRandomLayout.Location = new System.Drawing.Point(345, 1);
            this.patientRowRandomLayout.Margin = new System.Windows.Forms.Padding(0);
            this.patientRowRandomLayout.MaximumSize = new System.Drawing.Size(190, 30);
            this.patientRowRandomLayout.Name = "patientRowRandomLayout";
            this.patientRowRandomLayout.Size = new System.Drawing.Size(190, 30);
            this.patientRowRandomLayout.TabIndex = 8;
            this.patientRowRandomLayout.WrapContents = false;
            // 
            // patientRowRandomButton
            // 
            this.patientRowRandomButton.Location = new System.Drawing.Point(3, 3);
            this.patientRowRandomButton.Name = "patientRowRandomButton";
            this.patientRowRandomButton.Size = new System.Drawing.Size(23, 23);
            this.patientRowRandomButton.TabIndex = 0;
            this.patientRowRandomButton.Text = "R";
            this.patientRowRandomButton.UseVisualStyleBackColor = true;
            // 
            // patientRowRandomRangeSelect
            // 
            this.patientRowRandomRangeSelect.AutoSize = true;
            this.patientRowRandomRangeSelect.Location = new System.Drawing.Point(32, 3);
            this.patientRowRandomRangeSelect.MinimumSize = new System.Drawing.Size(0, 25);
            this.patientRowRandomRangeSelect.Name = "patientRowRandomRangeSelect";
            this.patientRowRandomRangeSelect.Size = new System.Drawing.Size(15, 25);
            this.patientRowRandomRangeSelect.TabIndex = 1;
            this.patientRowRandomRangeSelect.UseVisualStyleBackColor = true;
            // 
            // patientRowRandomRangeMin
            // 
            this.patientRowRandomRangeMin.Location = new System.Drawing.Point(53, 6);
            this.patientRowRandomRangeMin.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowRandomRangeMin.MaximumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMin.MinimumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMin.Name = "patientRowRandomRangeMin";
            this.patientRowRandomRangeMin.Size = new System.Drawing.Size(50, 20);
            this.patientRowRandomRangeMin.TabIndex = 2;
            // 
            // patientRowRandomRangeLabel
            // 
            this.patientRowRandomRangeLabel.AutoSize = true;
            this.patientRowRandomRangeLabel.Location = new System.Drawing.Point(109, 6);
            this.patientRowRandomRangeLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowRandomRangeLabel.Name = "patientRowRandomRangeLabel";
            this.patientRowRandomRangeLabel.Size = new System.Drawing.Size(16, 13);
            this.patientRowRandomRangeLabel.TabIndex = 4;
            this.patientRowRandomRangeLabel.Text = " - ";
            this.patientRowRandomRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patientRowRandomRangeMax
            // 
            this.patientRowRandomRangeMax.Location = new System.Drawing.Point(131, 6);
            this.patientRowRandomRangeMax.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.patientRowRandomRangeMax.MaximumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMax.MinimumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMax.Name = "patientRowRandomRangeMax";
            this.patientRowRandomRangeMax.Size = new System.Drawing.Size(50, 20);
            this.patientRowRandomRangeMax.TabIndex = 3;
            // 
            // patientRowTreatmentLayout
            // 
            this.patientRowTreatmentLayout.AutoSize = true;
            this.patientRowTreatmentLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patientRowTreatmentLayout.Controls.Add(this.patientRowTreatment1);
            this.patientRowTreatmentLayout.Controls.Add(this.patientRowTreatment2);
            this.patientRowTreatmentLayout.Controls.Add(this.patientRowTreatment3);
            this.patientRowTreatmentLayout.Controls.Add(this.patientRowTreatment4);
            this.patientRowTreatmentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientRowTreatmentLayout.Location = new System.Drawing.Point(539, 4);
            this.patientRowTreatmentLayout.MaximumSize = new System.Drawing.Size(0, 60);
            this.patientRowTreatmentLayout.Name = "patientRowTreatmentLayout";
            this.patientRowTreatmentLayout.Size = new System.Drawing.Size(328, 24);
            this.patientRowTreatmentLayout.TabIndex = 9;
            // 
            // patientRowTreatment1
            // 
            this.patientRowTreatment1.FormattingEnabled = true;
            this.patientRowTreatment1.Location = new System.Drawing.Point(3, 3);
            this.patientRowTreatment1.Name = "patientRowTreatment1";
            this.patientRowTreatment1.Size = new System.Drawing.Size(121, 21);
            this.patientRowTreatment1.TabIndex = 0;
            // 
            // patientRowTreatment2
            // 
            this.patientRowTreatment2.FormattingEnabled = true;
            this.patientRowTreatment2.Location = new System.Drawing.Point(130, 3);
            this.patientRowTreatment2.Name = "patientRowTreatment2";
            this.patientRowTreatment2.Size = new System.Drawing.Size(121, 21);
            this.patientRowTreatment2.TabIndex = 1;
            // 
            // patientRowTreatment3
            // 
            this.patientRowTreatment3.FormattingEnabled = true;
            this.patientRowTreatment3.Location = new System.Drawing.Point(3, 30);
            this.patientRowTreatment3.Name = "patientRowTreatment3";
            this.patientRowTreatment3.Size = new System.Drawing.Size(121, 21);
            this.patientRowTreatment3.TabIndex = 2;
            // 
            // patientRowTreatment4
            // 
            this.patientRowTreatment4.FormattingEnabled = true;
            this.patientRowTreatment4.Location = new System.Drawing.Point(130, 30);
            this.patientRowTreatment4.Name = "patientRowTreatment4";
            this.patientRowTreatment4.Size = new System.Drawing.Size(121, 21);
            this.patientRowTreatment4.TabIndex = 3;
            // 
            // patientRowTreatmentButton
            // 
            this.patientRowTreatmentButton.Location = new System.Drawing.Point(874, 4);
            this.patientRowTreatmentButton.Name = "patientRowTreatmentButton";
            this.patientRowTreatmentButton.Size = new System.Drawing.Size(75, 23);
            this.patientRowTreatmentButton.TabIndex = 10;
            this.patientRowTreatmentButton.Text = "Treatments";
            this.patientRowTreatmentButton.UseVisualStyleBackColor = true;
            // 
            // patientRowTraits
            // 
            this.patientRowTraits.Location = new System.Drawing.Point(956, 4);
            this.patientRowTraits.Name = "patientRowTraits";
            this.patientRowTraits.Size = new System.Drawing.Size(75, 23);
            this.patientRowTraits.TabIndex = 11;
            this.patientRowTraits.Text = "Traits";
            this.patientRowTraits.UseVisualStyleBackColor = true;

        }
    }


    
}
