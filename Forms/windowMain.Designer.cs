namespace Windows
{
    partial class windowMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.levelListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.levelListGroup = new System.Windows.Forms.GroupBox();
            this.levelListDisplay = new System.Windows.Forms.ListBox();
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.filterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.filterCheckLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.levelListStoryCheck = new System.Windows.Forms.CheckBox();
            this.levelListBonusCheck = new System.Windows.Forms.CheckBox();
            this.levelListUnknownCheck = new System.Windows.Forms.CheckBox();
            this.levelListFilter = new System.Windows.Forms.ComboBox();
            this.levelDataLayout = new System.Windows.Forms.TableLayoutPanel();
            this.levelDataTabs = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabLevelGenerating = new System.Windows.Forms.TabPage();
            this.tabPatientChances = new System.Windows.Forms.TabPage();
            this.previewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.currentPreviewTextBox = new System.Windows.Forms.TextBox();
            this.currentPreviewLabel = new System.Windows.Forms.Label();
            this.afterPreviewTextBox = new System.Windows.Forms.TextBox();
            this.afterPreviewLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.levelListLayout.SuspendLayout();
            this.levelListGroup.SuspendLayout();
            this.filterGroup.SuspendLayout();
            this.filterLayout.SuspendLayout();
            this.filterCheckLayout.SuspendLayout();
            this.levelDataLayout.SuspendLayout();
            this.levelDataTabs.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).BeginInit();
            this.previewSplitContainer.Panel1.SuspendLayout();
            this.previewSplitContainer.Panel2.SuspendLayout();
            this.previewSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainLayout, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 547);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testWindowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(946, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // testWindowToolStripMenuItem
            // 
            this.testWindowToolStripMenuItem.Name = "testWindowToolStripMenuItem";
            this.testWindowToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.testWindowToolStripMenuItem.Text = "TestWindow";
            this.testWindowToolStripMenuItem.Click += new System.EventHandler(this.testWindowToolStripMenuItem_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainLayout.Controls.Add(this.levelListLayout, 0, 0);
            this.mainLayout.Controls.Add(this.levelDataLayout, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(2, 26);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(942, 503);
            this.mainLayout.TabIndex = 1;
            // 
            // levelListLayout
            // 
            this.levelListLayout.ColumnCount = 1;
            this.levelListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.levelListLayout.Controls.Add(this.levelListGroup, 0, 0);
            this.levelListLayout.Controls.Add(this.filterGroup, 0, 1);
            this.levelListLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelListLayout.Location = new System.Drawing.Point(0, 0);
            this.levelListLayout.Margin = new System.Windows.Forms.Padding(0);
            this.levelListLayout.Name = "levelListLayout";
            this.levelListLayout.Padding = new System.Windows.Forms.Padding(2);
            this.levelListLayout.RowCount = 2;
            this.levelListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.levelListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.levelListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.levelListLayout.Size = new System.Drawing.Size(188, 503);
            this.levelListLayout.TabIndex = 0;
            // 
            // levelListGroup
            // 
            this.levelListGroup.Controls.Add(this.levelListDisplay);
            this.levelListGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelListGroup.Location = new System.Drawing.Point(2, 2);
            this.levelListGroup.Margin = new System.Windows.Forms.Padding(0);
            this.levelListGroup.Name = "levelListGroup";
            this.levelListGroup.Padding = new System.Windows.Forms.Padding(2);
            this.levelListGroup.Size = new System.Drawing.Size(184, 414);
            this.levelListGroup.TabIndex = 0;
            this.levelListGroup.TabStop = false;
            this.levelListGroup.Text = "Level List";
            // 
            // levelListDisplay
            // 
            this.levelListDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelListDisplay.FormattingEnabled = true;
            this.levelListDisplay.Location = new System.Drawing.Point(2, 15);
            this.levelListDisplay.Name = "levelListDisplay";
            this.levelListDisplay.Size = new System.Drawing.Size(180, 397);
            this.levelListDisplay.TabIndex = 0;
            this.levelListDisplay.Click += new System.EventHandler(this.onLevelSelected);
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.filterLayout);
            this.filterGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterGroup.Location = new System.Drawing.Point(4, 418);
            this.filterGroup.Margin = new System.Windows.Forms.Padding(2);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Padding = new System.Windows.Forms.Padding(0);
            this.filterGroup.Size = new System.Drawing.Size(180, 81);
            this.filterGroup.TabIndex = 1;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Filters";
            // 
            // filterLayout
            // 
            this.filterLayout.ColumnCount = 1;
            this.filterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterLayout.Controls.Add(this.filterCheckLayout, 0, 1);
            this.filterLayout.Controls.Add(this.levelListFilter, 0, 0);
            this.filterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterLayout.Location = new System.Drawing.Point(0, 13);
            this.filterLayout.Margin = new System.Windows.Forms.Padding(0);
            this.filterLayout.Name = "filterLayout";
            this.filterLayout.RowCount = 2;
            this.filterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.filterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.filterLayout.Size = new System.Drawing.Size(180, 68);
            this.filterLayout.TabIndex = 0;
            this.filterLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // filterCheckLayout
            // 
            this.filterCheckLayout.Controls.Add(this.levelListStoryCheck);
            this.filterCheckLayout.Controls.Add(this.levelListBonusCheck);
            this.filterCheckLayout.Controls.Add(this.levelListUnknownCheck);
            this.filterCheckLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterCheckLayout.Location = new System.Drawing.Point(0, 32);
            this.filterCheckLayout.Margin = new System.Windows.Forms.Padding(0);
            this.filterCheckLayout.Name = "filterCheckLayout";
            this.filterCheckLayout.Size = new System.Drawing.Size(180, 36);
            this.filterCheckLayout.TabIndex = 0;
            this.filterCheckLayout.WrapContents = false;
            // 
            // levelListStoryCheck
            // 
            this.levelListStoryCheck.AutoSize = true;
            this.levelListStoryCheck.Checked = true;
            this.levelListStoryCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.levelListStoryCheck.Location = new System.Drawing.Point(2, 2);
            this.levelListStoryCheck.Margin = new System.Windows.Forms.Padding(2);
            this.levelListStoryCheck.Name = "levelListStoryCheck";
            this.levelListStoryCheck.Size = new System.Drawing.Size(50, 17);
            this.levelListStoryCheck.TabIndex = 0;
            this.levelListStoryCheck.Text = "Story";
            this.levelListStoryCheck.UseVisualStyleBackColor = true;
            this.levelListStoryCheck.CheckedChanged += new System.EventHandler(this.onLevelFilterChange);
            // 
            // levelListBonusCheck
            // 
            this.levelListBonusCheck.AutoSize = true;
            this.levelListBonusCheck.Checked = true;
            this.levelListBonusCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.levelListBonusCheck.Location = new System.Drawing.Point(56, 2);
            this.levelListBonusCheck.Margin = new System.Windows.Forms.Padding(2);
            this.levelListBonusCheck.Name = "levelListBonusCheck";
            this.levelListBonusCheck.Size = new System.Drawing.Size(56, 17);
            this.levelListBonusCheck.TabIndex = 1;
            this.levelListBonusCheck.Text = "Bonus";
            this.levelListBonusCheck.UseVisualStyleBackColor = true;
            this.levelListBonusCheck.CheckedChanged += new System.EventHandler(this.onLevelFilterChange);
            // 
            // levelListUnknownCheck
            // 
            this.levelListUnknownCheck.AutoSize = true;
            this.levelListUnknownCheck.Location = new System.Drawing.Point(116, 2);
            this.levelListUnknownCheck.Margin = new System.Windows.Forms.Padding(2);
            this.levelListUnknownCheck.Name = "levelListUnknownCheck";
            this.levelListUnknownCheck.Size = new System.Drawing.Size(72, 17);
            this.levelListUnknownCheck.TabIndex = 2;
            this.levelListUnknownCheck.Text = "Unknown";
            this.levelListUnknownCheck.UseVisualStyleBackColor = true;
            this.levelListUnknownCheck.CheckedChanged += new System.EventHandler(this.onLevelFilterChange);
            // 
            // levelListFilter
            // 
            this.levelListFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelListFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelListFilter.FormattingEnabled = true;
            this.levelListFilter.Location = new System.Drawing.Point(2, 2);
            this.levelListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.levelListFilter.Name = "levelListFilter";
            this.levelListFilter.Size = new System.Drawing.Size(176, 21);
            this.levelListFilter.TabIndex = 1;
            this.levelListFilter.SelectedValueChanged += new System.EventHandler(this.onLevelFilterChange);
            // 
            // levelDataLayout
            // 
            this.levelDataLayout.ColumnCount = 1;
            this.levelDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.levelDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.levelDataLayout.Controls.Add(this.levelDataTabs, 0, 0);
            this.levelDataLayout.Controls.Add(this.previewSplitContainer, 0, 1);
            this.levelDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelDataLayout.Location = new System.Drawing.Point(190, 2);
            this.levelDataLayout.Margin = new System.Windows.Forms.Padding(2);
            this.levelDataLayout.Name = "levelDataLayout";
            this.levelDataLayout.RowCount = 2;
            this.levelDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.levelDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.levelDataLayout.Size = new System.Drawing.Size(750, 499);
            this.levelDataLayout.TabIndex = 1;
            // 
            // levelDataTabs
            // 
            this.levelDataTabs.Controls.Add(this.tabGeneral);
            this.levelDataTabs.Controls.Add(this.tabLevelGenerating);
            this.levelDataTabs.Controls.Add(this.tabPatientChances);
            this.levelDataTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelDataTabs.Location = new System.Drawing.Point(2, 2);
            this.levelDataTabs.Margin = new System.Windows.Forms.Padding(2);
            this.levelDataTabs.Name = "levelDataTabs";
            this.levelDataTabs.SelectedIndex = 0;
            this.levelDataTabs.Size = new System.Drawing.Size(746, 245);
            this.levelDataTabs.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(2);
            this.tabGeneral.Size = new System.Drawing.Size(738, 219);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(734, 215);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.comboBox2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBox3, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(363, 210);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part of Room: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Difficulty Modifier:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(2, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delay Random Range:\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(2, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(121, 34);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(240, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(121, 98);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(240, 21);
            this.comboBox3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(121, 66);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.MaximumSize = new System.Drawing.Size(0, 24);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(240, 24);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown2.Location = new System.Drawing.Point(89, 2);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown2.MinimumSize = new System.Drawing.Size(56, 0);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(149, 20);
            this.numericUpDown2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(74, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = " - ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Location = new System.Drawing.Point(2, 2);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.MinimumSize = new System.Drawing.Size(56, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(121, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabLevelGenerating
            // 
            this.tabLevelGenerating.Location = new System.Drawing.Point(4, 22);
            this.tabLevelGenerating.Margin = new System.Windows.Forms.Padding(2);
            this.tabLevelGenerating.Name = "tabLevelGenerating";
            this.tabLevelGenerating.Padding = new System.Windows.Forms.Padding(2);
            this.tabLevelGenerating.Size = new System.Drawing.Size(738, 219);
            this.tabLevelGenerating.TabIndex = 1;
            this.tabLevelGenerating.Text = "Level Generating";
            this.tabLevelGenerating.UseVisualStyleBackColor = true;
            // 
            // tabPatientChances
            // 
            this.tabPatientChances.Location = new System.Drawing.Point(4, 22);
            this.tabPatientChances.Margin = new System.Windows.Forms.Padding(2);
            this.tabPatientChances.Name = "tabPatientChances";
            this.tabPatientChances.Padding = new System.Windows.Forms.Padding(2);
            this.tabPatientChances.Size = new System.Drawing.Size(738, 219);
            this.tabPatientChances.TabIndex = 2;
            this.tabPatientChances.Text = "Patient Chances";
            this.tabPatientChances.UseVisualStyleBackColor = true;
            // 
            // previewSplitContainer
            // 
            this.previewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewSplitContainer.Location = new System.Drawing.Point(2, 251);
            this.previewSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.previewSplitContainer.Name = "previewSplitContainer";
            // 
            // previewSplitContainer.Panel1
            // 
            this.previewSplitContainer.Panel1.Controls.Add(this.currentPreviewTextBox);
            this.previewSplitContainer.Panel1.Controls.Add(this.currentPreviewLabel);
            // 
            // previewSplitContainer.Panel2
            // 
            this.previewSplitContainer.Panel2.Controls.Add(this.afterPreviewTextBox);
            this.previewSplitContainer.Panel2.Controls.Add(this.afterPreviewLabel);
            this.previewSplitContainer.Size = new System.Drawing.Size(746, 246);
            this.previewSplitContainer.SplitterDistance = 273;
            this.previewSplitContainer.SplitterWidth = 3;
            this.previewSplitContainer.TabIndex = 1;
            // 
            // currentPreviewTextBox
            // 
            this.currentPreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentPreviewTextBox.Location = new System.Drawing.Point(0, 13);
            this.currentPreviewTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.currentPreviewTextBox.Multiline = true;
            this.currentPreviewTextBox.Name = "currentPreviewTextBox";
            this.currentPreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentPreviewTextBox.Size = new System.Drawing.Size(273, 233);
            this.currentPreviewTextBox.TabIndex = 0;
            // 
            // currentPreviewLabel
            // 
            this.currentPreviewLabel.AutoSize = true;
            this.currentPreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentPreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.currentPreviewLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPreviewLabel.Name = "currentPreviewLabel";
            this.currentPreviewLabel.Size = new System.Drawing.Size(82, 13);
            this.currentPreviewLabel.TabIndex = 1;
            this.currentPreviewLabel.Text = "Current Preview";
            // 
            // afterPreviewTextBox
            // 
            this.afterPreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afterPreviewTextBox.Location = new System.Drawing.Point(0, 13);
            this.afterPreviewTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.afterPreviewTextBox.Multiline = true;
            this.afterPreviewTextBox.Name = "afterPreviewTextBox";
            this.afterPreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.afterPreviewTextBox.Size = new System.Drawing.Size(470, 233);
            this.afterPreviewTextBox.TabIndex = 0;
            // 
            // afterPreviewLabel
            // 
            this.afterPreviewLabel.AutoSize = true;
            this.afterPreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.afterPreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.afterPreviewLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.afterPreviewLabel.Name = "afterPreviewLabel";
            this.afterPreviewLabel.Size = new System.Drawing.Size(70, 13);
            this.afterPreviewLabel.TabIndex = 1;
            this.afterPreviewLabel.Text = "After Preview";
            // 
            // windowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(604, 495);
            this.Name = "windowMain";
            this.Text = "HM4 Design Tool";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.levelListLayout.ResumeLayout(false);
            this.levelListGroup.ResumeLayout(false);
            this.filterGroup.ResumeLayout(false);
            this.filterLayout.ResumeLayout(false);
            this.filterCheckLayout.ResumeLayout(false);
            this.filterCheckLayout.PerformLayout();
            this.levelDataLayout.ResumeLayout(false);
            this.levelDataTabs.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.previewSplitContainer.Panel1.ResumeLayout(false);
            this.previewSplitContainer.Panel1.PerformLayout();
            this.previewSplitContainer.Panel2.ResumeLayout(false);
            this.previewSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).EndInit();
            this.previewSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel levelListLayout;
        private System.Windows.Forms.GroupBox levelListGroup;
        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.TableLayoutPanel filterLayout;
        private System.Windows.Forms.FlowLayoutPanel filterCheckLayout;
        private System.Windows.Forms.CheckBox levelListStoryCheck;
        private System.Windows.Forms.CheckBox levelListBonusCheck;
        private System.Windows.Forms.CheckBox levelListUnknownCheck;
        private System.Windows.Forms.ComboBox levelListFilter;
        private System.Windows.Forms.TableLayoutPanel levelDataLayout;
        private System.Windows.Forms.TabControl levelDataTabs;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabLevelGenerating;
        private System.Windows.Forms.SplitContainer previewSplitContainer;
        private System.Windows.Forms.TextBox currentPreviewTextBox;
        private System.Windows.Forms.Label currentPreviewLabel;
        private System.Windows.Forms.TextBox afterPreviewTextBox;
        private System.Windows.Forms.Label afterPreviewLabel;
        private System.Windows.Forms.TabPage tabPatientChances;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox levelListDisplay;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testWindowToolStripMenuItem;
    }
}

