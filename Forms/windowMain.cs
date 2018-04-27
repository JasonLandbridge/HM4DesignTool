
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
            PatientOverview.SetupPatientOverview(patientOverviewLayout, patientOverviewPanel);
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

        private void patientOverviewLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPatientOverviewRemoveRow_Click(object sender, EventArgs e)
        {
            PatientOverview.RemovePatientRow(-1);
        }

        private void patientRowDelay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void patientRowName_TextChanged(object sender, EventArgs e)
        {

        }

        private void patientRowRandomRangeSelect_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void patientOverviewHeaderWeightLabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    public class PatientOverview
    {
        private windowMain mainWindow = Globals.windowMainObject;
        public TableLayoutPanel patientOverviewLayout;
        public Panel patientOverviewPanel;

        private Dictionary<int, PatientOverviewRow> patientOverviewRowsDict = new Dictionary<int, PatientOverviewRow> { };

        public PatientOverview()
        {
            
        }

        public void SetupPatientOverview(TableLayoutPanel patientOverviewLayout, Panel patientOverviewPanel)
        { 
            this.patientOverviewLayout = patientOverviewLayout;
            this.patientOverviewPanel = patientOverviewPanel;
            //Remove the first patient row to ensure that all rows are made by PatientOverview Class
            //AddPatientRow();
            //RemovePatientRow(0);
            
        }

        public void AddPatientRow()
        {
            SuspendLayout(true);
            patientOverviewRowsDict.Add(patientOverviewRowsDict.Count, new PatientOverviewRow(this, patientOverviewLayout.RowCount));
            SuspendLayout(false);
        }

        public void RemovePatientRow(int index = -1)
        {

            if (patientOverviewLayout.RowCount > 0)
            {
                SuspendLayout(true);
                // if index is invalid default to removing the last row
                if(index < 0 || index >= patientOverviewLayout.RowCount)
                {
                    index = patientOverviewLayout.RowCount - 1;
                }
                //Remove patientRow from Layout
                if (0 <= index && index < patientOverviewLayout.RowCount)
                {
                    //https://stackoverflow.com/a/31371962
                    // delete all controls of row that we want to delete
                    for (int i = 0; i < patientOverviewLayout.ColumnCount; i++)
                    {
                        var control = patientOverviewLayout.GetControlFromPosition(i, index);
                        patientOverviewLayout.Controls.Remove(control);
                    }

                    // move up row controls that comes after row we want to remove
                    for (int i = index + 1; i < patientOverviewLayout.RowCount; i++)
                    {
                        for (int j = 0; j < patientOverviewLayout.ColumnCount; j++)
                        {
                            var control = patientOverviewLayout.GetControlFromPosition(j, i);
                            if (control != null)
                            {
                                patientOverviewLayout.SetRow(control, i - 1);
                            }
                        }
                    }

                    // remove last row
                    patientOverviewLayout.RowStyles.RemoveAt(patientOverviewLayout.RowCount - 1);
                    patientOverviewLayout.RowCount--;
                }

                //Remove patientRow from patientOverviewRowsDict
                if (patientOverviewRowsDict.ContainsKey(index))
                {
                    patientOverviewRowsDict.Remove(index);
                }
                SuspendLayout(false);

            }
        }

        public void SuspendLayout(bool state = true)
        {
            if (state)
            {
                //patientOverviewPanel.SuspendLayout();
                patientOverviewLayout.SuspendLayout();
            }
            else
            {
                //patientOverviewPanel.ResumeLayout(false);
                patientOverviewLayout.ResumeLayout(true);
                patientOverviewLayout.PerformLayout();
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
            SuspendLayout(true);
            SetupRow();
            ConstructRow();
            SuspendLayout(false);

            SetRandomRangeVisibility();
        }

        private void ConstructRow()
        {

            patientOverviewLayout.RowCount = patientOverviewLayout.RowCount + 1;
            this.patientOverviewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());

            this.patientOverviewLayout.Controls.Add(this.patientRowSelect, 0, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowName, 1, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowDelay, 2, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowWeight, 3, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowRandomLayout, 5, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTreatmentLayout, 6, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTreatmentButton, 7, rowIndex);
            this.patientOverviewLayout.Controls.Add(this.patientRowTraits, 8, rowIndex);

        }

        private void SetupRow()
        {
            #region setup
            // 
            // patientRowSelect
            // 
            this.patientRowSelect.AutoSize = true;
            this.patientRowSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientRowSelect.Location = new System.Drawing.Point(5, 5);
            this.patientRowSelect.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowSelect.MaximumSize = new System.Drawing.Size(20, 25);
            this.patientRowSelect.MinimumSize = new System.Drawing.Size(20, 0);
            this.patientRowSelect.Name = "patientRowSelect";
            this.patientRowSelect.Size = new System.Drawing.Size(20, 25);
            this.patientRowSelect.TabIndex = 1;
            this.patientRowSelect.UseVisualStyleBackColor = true;
            // 
            // patientRowName
            // 
            this.patientRowName.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowName.Location = new System.Drawing.Point(33, 6);
            this.patientRowName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.patientRowName.MaximumSize = new System.Drawing.Size(120, 25);
            this.patientRowName.MaxLength = 20;
            this.patientRowName.MinimumSize = new System.Drawing.Size(120, 20);
            this.patientRowName.Name = "patientRowName";
            this.patientRowName.Size = new System.Drawing.Size(120, 22);
            this.patientRowName.TabIndex = 2;
            this.patientRowName.WordWrap = false;
            // 
            // patientRowDelay
            // 
            this.patientRowDelay.Location = new System.Drawing.Point(160, 6);
            this.patientRowDelay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.patientRowDelay.MinimumSize = new System.Drawing.Size(80, 0);
            this.patientRowDelay.Name = "patientRowDelay";
            this.patientRowDelay.Size = new System.Drawing.Size(80, 22);
            this.patientRowDelay.TabIndex = 13;
            // 
            // patientRowWeight
            // 
            this.patientRowWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowWeight.Location = new System.Drawing.Point(247, 6);
            this.patientRowWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.patientRowWeight.MinimumSize = new System.Drawing.Size(80, 0);
            this.patientRowWeight.Name = "patientRowWeight";
            this.patientRowWeight.Size = new System.Drawing.Size(80, 22);
            this.patientRowWeight.TabIndex = 4;
            // 
            // patientRowRandomLayout
            // 
            this.patientRowRandomLayout.AutoSize = true;
            this.patientRowRandomLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomButton);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeSelect);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeMin);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeLabel);
            this.patientRowRandomLayout.Controls.Add(this.patientRowRandomRangeMax);
            this.patientRowRandomLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowRandomLayout.Location = new System.Drawing.Point(332, 1);
            this.patientRowRandomLayout.Margin = new System.Windows.Forms.Padding(0);
            this.patientRowRandomLayout.Name = "patientRowRandomLayout";
            this.patientRowRandomLayout.Size = new System.Drawing.Size(186, 32);
            this.patientRowRandomLayout.TabIndex = 17;
            this.patientRowRandomLayout.WrapContents = false;
            // 
            // patientRowRandomButton
            // 
            this.patientRowRandomButton.Location = new System.Drawing.Point(3, 3);
            this.patientRowRandomButton.Name = "patientRowRandomButton";
            this.patientRowRandomButton.Size = new System.Drawing.Size(25, 25);
            this.patientRowRandomButton.TabIndex = 0;
            this.patientRowRandomButton.Text = "R";
            this.patientRowRandomButton.UseVisualStyleBackColor = true;
            // 
            // patientRowRandomRangeSelect
            // 
            this.patientRowRandomRangeSelect.AutoSize = true;
            this.patientRowRandomRangeSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientRowRandomRangeSelect.Location = new System.Drawing.Point(34, 3);
            this.patientRowRandomRangeSelect.Name = "patientRowRandomRangeSelect";
            this.patientRowRandomRangeSelect.Size = new System.Drawing.Size(18, 26);
            this.patientRowRandomRangeSelect.TabIndex = 1;
            this.patientRowRandomRangeSelect.UseVisualStyleBackColor = true;
            // 
            // patientRowRandomRangeMin
            // 
            this.patientRowRandomRangeMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowRandomRangeMin.Location = new System.Drawing.Point(58, 5);
            this.patientRowRandomRangeMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.patientRowRandomRangeMin.MinimumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMin.Name = "patientRowRandomRangeMin";
            this.patientRowRandomRangeMin.Size = new System.Drawing.Size(50, 22);
            this.patientRowRandomRangeMin.TabIndex = 4;
            // 
            // patientRowRandomRangeLabel
            // 
            this.patientRowRandomRangeLabel.AutoSize = true;
            this.patientRowRandomRangeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientRowRandomRangeLabel.Location = new System.Drawing.Point(114, 0);
            this.patientRowRandomRangeLabel.Name = "patientRowRandomRangeLabel";
            this.patientRowRandomRangeLabel.Size = new System.Drawing.Size(13, 32);
            this.patientRowRandomRangeLabel.TabIndex = 3;
            this.patientRowRandomRangeLabel.Text = "-";
            this.patientRowRandomRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patientRowRandomRangeMax
            // 
            this.patientRowRandomRangeMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientRowRandomRangeMax.Location = new System.Drawing.Point(133, 5);
            this.patientRowRandomRangeMax.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.patientRowRandomRangeMax.MinimumSize = new System.Drawing.Size(50, 0);
            this.patientRowRandomRangeMax.Name = "patientRowRandomRangeMax";
            this.patientRowRandomRangeMax.Size = new System.Drawing.Size(50, 22);
            this.patientRowRandomRangeMax.TabIndex = 2;
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
            this.patientRowTreatmentLayout.Location = new System.Drawing.Point(519, 1);
            this.patientRowTreatmentLayout.Margin = new System.Windows.Forms.Padding(0);
            this.patientRowTreatmentLayout.MaximumSize = new System.Drawing.Size(0, 74);
            this.patientRowTreatmentLayout.Name = "patientRowTreatmentLayout";
            this.patientRowTreatmentLayout.Size = new System.Drawing.Size(666, 74);
            this.patientRowTreatmentLayout.TabIndex = 9;
            this.patientRowTreatmentLayout.WrapContents = false;
            // 
            // patientRowTreatment1
            // 
            this.patientRowTreatment1.Dock = System.Windows.Forms.DockStyle.Left;
            this.patientRowTreatment1.FormattingEnabled = true;
            this.patientRowTreatment1.Location = new System.Drawing.Point(4, 4);
            this.patientRowTreatment1.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTreatment1.MaxDropDownItems = 50;
            this.patientRowTreatment1.Name = "patientRowTreatment1";
            this.patientRowTreatment1.Size = new System.Drawing.Size(160, 24);
            this.patientRowTreatment1.Sorted = true;
            this.patientRowTreatment1.TabIndex = 0;
            // 
            // patientRowTreatment2
            // 
            this.patientRowTreatment2.FormattingEnabled = true;
            this.patientRowTreatment2.Location = new System.Drawing.Point(172, 4);
            this.patientRowTreatment2.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTreatment2.Name = "patientRowTreatment2";
            this.patientRowTreatment2.Size = new System.Drawing.Size(160, 24);
            this.patientRowTreatment2.TabIndex = 1;
            // 
            // patientRowTreatment3
            // 
            this.patientRowTreatment3.FormattingEnabled = true;
            this.patientRowTreatment3.Location = new System.Drawing.Point(340, 4);
            this.patientRowTreatment3.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTreatment3.Name = "patientRowTreatment3";
            this.patientRowTreatment3.Size = new System.Drawing.Size(160, 24);
            this.patientRowTreatment3.TabIndex = 2;
            // 
            // patientRowTreatment4
            // 
            this.patientRowTreatment4.FormattingEnabled = true;
            this.patientRowTreatment4.Location = new System.Drawing.Point(508, 4);
            this.patientRowTreatment4.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTreatment4.Name = "patientRowTreatment4";
            this.patientRowTreatment4.Size = new System.Drawing.Size(160, 24);
            this.patientRowTreatment4.TabIndex = 3;
            // 
            // patientRowTreatmentButton
            // 
            this.patientRowTreatmentButton.Location = new System.Drawing.Point(1190, 5);
            this.patientRowTreatmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTreatmentButton.MaximumSize = new System.Drawing.Size(100, 25);
            this.patientRowTreatmentButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.patientRowTreatmentButton.Name = "patientRowTreatmentButton";
            this.patientRowTreatmentButton.Size = new System.Drawing.Size(100, 25);
            this.patientRowTreatmentButton.TabIndex = 10;
            this.patientRowTreatmentButton.Text = "Treatments";
            this.patientRowTreatmentButton.UseVisualStyleBackColor = true;
            // 
            // patientRowTraits
            // 
            this.patientRowTraits.Location = new System.Drawing.Point(1299, 5);
            this.patientRowTraits.Margin = new System.Windows.Forms.Padding(4);
            this.patientRowTraits.MaximumSize = new System.Drawing.Size(100, 25);
            this.patientRowTraits.MinimumSize = new System.Drawing.Size(100, 25);
            this.patientRowTraits.Name = "patientRowTraits";
            this.patientRowTraits.Size = new System.Drawing.Size(100, 25);
            this.patientRowTraits.TabIndex = 11;
            this.patientRowTraits.Text = "Traits";
            this.patientRowTraits.UseVisualStyleBackColor = true;
            #endregion
        }

        public void DestroyRow()
        {

        }

        public void SuspendLayout(bool state = true)
        {
            if (state)
            {
                patientRowRandomLayout.SuspendLayout();
                patientRowTreatmentLayout.SuspendLayout();

                patientRowDelay.SuspendLayout();
                patientRowWeight.SuspendLayout();
            }
            else
            {
                patientRowRandomLayout.ResumeLayout(false);
                patientRowTreatmentLayout.ResumeLayout(false);

                patientRowDelay.ResumeLayout(false);
                patientRowWeight.ResumeLayout(false);



            }
        }

        private void SetRandomRangeVisibility()
        {
            patientRowRandomRangeMin.Visible = patientRowRandomRangeSelect.Checked;
            patientRowRandomRangeLabel.Visible = patientRowRandomRangeSelect.Checked;
            patientRowRandomRangeMax.Visible = patientRowRandomRangeSelect.Checked;

            patientOverviewLayout.PerformLayout();
        }

        #region Signals
        private void patientRowRandomRangeSelect_CheckStateChanged(object sender, EventArgs e)
        {
            SetRandomRangeVisibility();
        }
        #endregion
    }

}


