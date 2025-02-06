using System.Drawing;

namespace HBOCalculator
{
    partial class Calculator
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.TreatmentNoLabel = new System.Windows.Forms.Label();
            this.TreatmentLabelTextbox = new System.Windows.Forms.TextBox();
            this.TreatmentLengthLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TreatmentDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.psiPerMinuteLabel2 = new System.Windows.Forms.Label();
            this.psiPerMinLabel1 = new System.Windows.Forms.Label();
            this.CompressBeginTimeErrorMessage = new System.Windows.Forms.Label();
            this.DiveRateUpErrorMessage = new System.Windows.Forms.Label();
            this.DiveRateDownErrorMessage = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.DiveTableGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiveRateUpComboBox = new System.Windows.Forms.ComboBox();
            this.DiveRateDownComboBox = new System.Windows.Forms.ComboBox();
            this.DiveRateUpLabel = new System.Windows.Forms.Label();
            this.DiveRateDownLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.lengthAirBreaksTextBoxErrorMessage = new System.Windows.Forms.Label();
            this.numAirBreaksTextBoxErrorMessage = new System.Windows.Forms.Label();
            this.minWOxygenTextBoxErrorMessage = new System.Windows.Forms.Label();
            this.lengthAirBreaksTextBox = new System.Windows.Forms.TextBox();
            this.numAirBreaksTextBox = new System.Windows.Forms.TextBox();
            this.ATATextBoxErrorMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TreatmentProtocolLabel = new System.Windows.Forms.Label();
            this.TreatmentLengthTextbox = new System.Windows.Forms.TextBox();
            this.minWOxygenTextBox = new System.Windows.Forms.TextBox();
            this.MinWOxygenLabel = new System.Windows.Forms.Label();
            this.ATATextBox = new System.Windows.Forms.TextBox();
            this.ATALabel = new System.Windows.Forms.Label();
            this.TreatmentProtocolComboBox = new System.Windows.Forms.ComboBox();
            this.ATAErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.TreatmentDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveTableGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ATAErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TreatmentNoLabel
            // 
            this.TreatmentNoLabel.AutoSize = true;
            this.TreatmentNoLabel.Location = new System.Drawing.Point(26, 35);
            this.TreatmentNoLabel.Name = "TreatmentNoLabel";
            this.TreatmentNoLabel.Size = new System.Drawing.Size(146, 20);
            this.TreatmentNoLabel.TabIndex = 0;
            this.TreatmentNoLabel.Text = "Treatment Number:";
            // 
            // TreatmentLabelTextbox
            // 
            this.TreatmentLabelTextbox.Location = new System.Drawing.Point(191, 30);
            this.TreatmentLabelTextbox.Name = "TreatmentLabelTextbox";
            this.TreatmentLabelTextbox.Size = new System.Drawing.Size(100, 26);
            this.TreatmentLabelTextbox.TabIndex = 1;
            // 
            // TreatmentLengthLabel
            // 
            this.TreatmentLengthLabel.AutoSize = true;
            this.TreatmentLengthLabel.Location = new System.Drawing.Point(26, 74);
            this.TreatmentLengthLabel.Name = "TreatmentLengthLabel";
            this.TreatmentLengthLabel.Size = new System.Drawing.Size(140, 20);
            this.TreatmentLengthLabel.TabIndex = 2;
            this.TreatmentLengthLabel.Text = "Treatment Length:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TreatmentDetailsGroupBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.TreatmentProtocolComboBox);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 670);
            this.panel1.TabIndex = 3;
            // 
            // TreatmentDetailsGroupBox
            // 
            this.TreatmentDetailsGroupBox.Controls.Add(this.psiPerMinuteLabel2);
            this.TreatmentDetailsGroupBox.Controls.Add(this.psiPerMinLabel1);
            this.TreatmentDetailsGroupBox.Controls.Add(this.CompressBeginTimeErrorMessage);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateUpErrorMessage);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateDownErrorMessage);
            this.TreatmentDetailsGroupBox.Controls.Add(this.calculateButton);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveTableGridView);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateUpComboBox);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateDownComboBox);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateUpLabel);
            this.TreatmentDetailsGroupBox.Controls.Add(this.DiveRateDownLabel);
            this.TreatmentDetailsGroupBox.Location = new System.Drawing.Point(27, 223);
            this.TreatmentDetailsGroupBox.Name = "TreatmentDetailsGroupBox";
            this.TreatmentDetailsGroupBox.Size = new System.Drawing.Size(1182, 409);
            this.TreatmentDetailsGroupBox.TabIndex = 4;
            this.TreatmentDetailsGroupBox.TabStop = false;
            this.TreatmentDetailsGroupBox.Text = "Treatment Details";
            // 
            // psiPerMinuteLabel2
            // 
            this.psiPerMinuteLabel2.AutoSize = true;
            this.psiPerMinuteLabel2.Location = new System.Drawing.Point(292, 102);
            this.psiPerMinuteLabel2.Name = "psiPerMinuteLabel2";
            this.psiPerMinuteLabel2.Size = new System.Drawing.Size(81, 20);
            this.psiPerMinuteLabel2.TabIndex = 11;
            this.psiPerMinuteLabel2.Text = "psi/minute";
            // 
            // psiPerMinLabel1
            // 
            this.psiPerMinLabel1.AutoSize = true;
            this.psiPerMinLabel1.Location = new System.Drawing.Point(292, 57);
            this.psiPerMinLabel1.Name = "psiPerMinLabel1";
            this.psiPerMinLabel1.Size = new System.Drawing.Size(81, 20);
            this.psiPerMinLabel1.TabIndex = 10;
            this.psiPerMinLabel1.Text = "psi/minute";
            // 
            // CompressBeginTimeErrorMessage
            // 
            this.CompressBeginTimeErrorMessage.AutoSize = true;
            this.CompressBeginTimeErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.CompressBeginTimeErrorMessage.Location = new System.Drawing.Point(6, 383);
            this.CompressBeginTimeErrorMessage.Name = "CompressBeginTimeErrorMessage";
            this.CompressBeginTimeErrorMessage.Size = new System.Drawing.Size(185, 20);
            this.CompressBeginTimeErrorMessage.TabIndex = 9;
            this.CompressBeginTimeErrorMessage.Text = "Please enter a start time.";
            this.CompressBeginTimeErrorMessage.Visible = false;
            // 
            // DiveRateUpErrorMessage
            // 
            this.DiveRateUpErrorMessage.AutoSize = true;
            this.DiveRateUpErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.DiveRateUpErrorMessage.Location = new System.Drawing.Point(390, 102);
            this.DiveRateUpErrorMessage.Name = "DiveRateUpErrorMessage";
            this.DiveRateUpErrorMessage.Size = new System.Drawing.Size(220, 20);
            this.DiveRateUpErrorMessage.TabIndex = 7;
            this.DiveRateUpErrorMessage.Text = "Please select or enter a value.";
            this.DiveRateUpErrorMessage.Visible = false;
            // 
            // DiveRateDownErrorMessage
            // 
            this.DiveRateDownErrorMessage.AutoSize = true;
            this.DiveRateDownErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.DiveRateDownErrorMessage.Location = new System.Drawing.Point(390, 57);
            this.DiveRateDownErrorMessage.Name = "DiveRateDownErrorMessage";
            this.DiveRateDownErrorMessage.Size = new System.Drawing.Size(220, 20);
            this.DiveRateDownErrorMessage.TabIndex = 8;
            this.DiveRateDownErrorMessage.Text = "Please select or enter a value.";
            this.DiveRateDownErrorMessage.Visible = false;
            // 
            // calculateButton
            // 
            this.calculateButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateButton.Location = new System.Drawing.Point(669, 102);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(225, 45);
            this.calculateButton.TabIndex = 5;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Visible = false;
            // 
            // DiveTableGridView
            // 
            this.DiveTableGridView.AllowUserToAddRows = false;
            this.DiveTableGridView.AllowUserToDeleteRows = false;
            this.DiveTableGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DiveTableGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DiveTableGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DiveTableGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DiveTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiveTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DiveTableGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiveTableGridView.EnableHeadersVisualStyles = false;
            this.DiveTableGridView.Location = new System.Drawing.Point(0, 200);
            this.DiveTableGridView.MultiSelect = false;
            this.DiveTableGridView.Name = "DiveTableGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DiveTableGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DiveTableGridView.RowHeadersWidth = 120;
            this.DiveTableGridView.RowTemplate.Height = 28;
            this.DiveTableGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DiveTableGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DiveTableGridView.Size = new System.Drawing.Size(1182, 209);
            this.DiveTableGridView.TabIndex = 4;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.NullValue = "\"\"";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Compress Begins";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tx Pressure Reached";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Airbreak 1 Start";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Airbreak 1 End";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Airbreak 2 Start";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Airbreak 2 End";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Airbreak 3 Start";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Airbreak 3 End";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Decompress Begins";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Decompress Ends";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DiveRateUpComboBox
            // 
            this.DiveRateUpComboBox.FormattingEnabled = true;
            this.DiveRateUpComboBox.Items.AddRange(new object[] {
            "1.0",
            "1.5",
            "2.0"});
            this.DiveRateUpComboBox.Location = new System.Drawing.Point(182, 99);
            this.DiveRateUpComboBox.Name = "DiveRateUpComboBox";
            this.DiveRateUpComboBox.Size = new System.Drawing.Size(103, 28);
            this.DiveRateUpComboBox.TabIndex = 3;
            // 
            // DiveRateDownComboBox
            // 
            this.DiveRateDownComboBox.FormattingEnabled = true;
            this.DiveRateDownComboBox.Items.AddRange(new object[] {
            "1.0",
            "1.5",
            "2.0"});
            this.DiveRateDownComboBox.Location = new System.Drawing.Point(182, 54);
            this.DiveRateDownComboBox.Name = "DiveRateDownComboBox";
            this.DiveRateDownComboBox.Size = new System.Drawing.Size(103, 28);
            this.DiveRateDownComboBox.TabIndex = 2;
            // 
            // DiveRateUpLabel
            // 
            this.DiveRateUpLabel.AutoSize = true;
            this.DiveRateUpLabel.Location = new System.Drawing.Point(36, 102);
            this.DiveRateUpLabel.Name = "DiveRateUpLabel";
            this.DiveRateUpLabel.Size = new System.Drawing.Size(108, 20);
            this.DiveRateUpLabel.TabIndex = 1;
            this.DiveRateUpLabel.Text = "Dive Rate Up:";
            // 
            // DiveRateDownLabel
            // 
            this.DiveRateDownLabel.AutoSize = true;
            this.DiveRateDownLabel.Location = new System.Drawing.Point(36, 57);
            this.DiveRateDownLabel.Name = "DiveRateDownLabel";
            this.DiveRateDownLabel.Size = new System.Drawing.Size(128, 20);
            this.DiveRateDownLabel.TabIndex = 0;
            this.DiveRateDownLabel.Text = "Dive Rate Down:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetButton);
            this.groupBox1.Controls.Add(this.lengthAirBreaksTextBoxErrorMessage);
            this.groupBox1.Controls.Add(this.numAirBreaksTextBoxErrorMessage);
            this.groupBox1.Controls.Add(this.minWOxygenTextBoxErrorMessage);
            this.groupBox1.Controls.Add(this.lengthAirBreaksTextBox);
            this.groupBox1.Controls.Add(this.numAirBreaksTextBox);
            this.groupBox1.Controls.Add(this.ATATextBoxErrorMessage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TreatmentProtocolLabel);
            this.groupBox1.Controls.Add(this.TreatmentLengthTextbox);
            this.groupBox1.Controls.Add(this.TreatmentNoLabel);
            this.groupBox1.Controls.Add(this.minWOxygenTextBox);
            this.groupBox1.Controls.Add(this.TreatmentLabelTextbox);
            this.groupBox1.Controls.Add(this.TreatmentLengthLabel);
            this.groupBox1.Controls.Add(this.MinWOxygenLabel);
            this.groupBox1.Controls.Add(this.ATATextBox);
            this.groupBox1.Controls.Add(this.ATALabel);
            this.groupBox1.Location = new System.Drawing.Point(23, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1157, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HBO Treatment Details";
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Firebrick;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.resetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resetButton.Location = new System.Drawing.Point(1013, 17);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(128, 45);
            this.resetButton.TabIndex = 12;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Clear";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // lengthAirBreaksTextBoxErrorMessage
            // 
            this.lengthAirBreaksTextBoxErrorMessage.AutoSize = true;
            this.lengthAirBreaksTextBoxErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lengthAirBreaksTextBoxErrorMessage.Location = new System.Drawing.Point(752, 79);
            this.lengthAirBreaksTextBoxErrorMessage.Name = "lengthAirBreaksTextBoxErrorMessage";
            this.lengthAirBreaksTextBoxErrorMessage.Size = new System.Drawing.Size(208, 20);
            this.lengthAirBreaksTextBoxErrorMessage.TabIndex = 14;
            this.lengthAirBreaksTextBoxErrorMessage.Text = "Please enter a valid number.";
            this.lengthAirBreaksTextBoxErrorMessage.Visible = false;
            // 
            // numAirBreaksTextBoxErrorMessage
            // 
            this.numAirBreaksTextBoxErrorMessage.AutoSize = true;
            this.numAirBreaksTextBoxErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.numAirBreaksTextBoxErrorMessage.Location = new System.Drawing.Point(591, 157);
            this.numAirBreaksTextBoxErrorMessage.Name = "numAirBreaksTextBoxErrorMessage";
            this.numAirBreaksTextBoxErrorMessage.Size = new System.Drawing.Size(208, 20);
            this.numAirBreaksTextBoxErrorMessage.TabIndex = 13;
            this.numAirBreaksTextBoxErrorMessage.Text = "Please enter a valid number.";
            this.numAirBreaksTextBoxErrorMessage.Visible = false;
            // 
            // minWOxygenTextBoxErrorMessage
            // 
            this.minWOxygenTextBoxErrorMessage.AutoSize = true;
            this.minWOxygenTextBoxErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.minWOxygenTextBoxErrorMessage.Location = new System.Drawing.Point(307, 157);
            this.minWOxygenTextBoxErrorMessage.Name = "minWOxygenTextBoxErrorMessage";
            this.minWOxygenTextBoxErrorMessage.Size = new System.Drawing.Size(208, 20);
            this.minWOxygenTextBoxErrorMessage.TabIndex = 12;
            this.minWOxygenTextBoxErrorMessage.Text = "Please enter a valid number.";
            this.minWOxygenTextBoxErrorMessage.Visible = false;
            // 
            // lengthAirBreaksTextBox
            // 
            this.lengthAirBreaksTextBox.Location = new System.Drawing.Point(756, 117);
            this.lengthAirBreaksTextBox.Name = "lengthAirBreaksTextBox";
            this.lengthAirBreaksTextBox.Size = new System.Drawing.Size(100, 26);
            this.lengthAirBreaksTextBox.TabIndex = 11;
            this.lengthAirBreaksTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numAirBreaksTextBox
            // 
            this.numAirBreaksTextBox.Location = new System.Drawing.Point(649, 117);
            this.numAirBreaksTextBox.Name = "numAirBreaksTextBox";
            this.numAirBreaksTextBox.Size = new System.Drawing.Size(100, 26);
            this.numAirBreaksTextBox.TabIndex = 9;
            this.numAirBreaksTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ATATextBoxErrorMessage
            // 
            this.ATATextBoxErrorMessage.AutoSize = true;
            this.ATATextBoxErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ATATextBoxErrorMessage.Location = new System.Drawing.Point(83, 157);
            this.ATATextBoxErrorMessage.Name = "ATATextBoxErrorMessage";
            this.ATATextBoxErrorMessage.Size = new System.Drawing.Size(208, 20);
            this.ATATextBoxErrorMessage.TabIndex = 6;
            this.ATATextBoxErrorMessage.Text = "Please enter a valid number.";
            this.ATATextBoxErrorMessage.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(862, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "minute air breaks";
            // 
            // TreatmentProtocolLabel
            // 
            this.TreatmentProtocolLabel.AutoSize = true;
            this.TreatmentProtocolLabel.Location = new System.Drawing.Point(26, 121);
            this.TreatmentProtocolLabel.Name = "TreatmentProtocolLabel";
            this.TreatmentProtocolLabel.Size = new System.Drawing.Size(152, 20);
            this.TreatmentProtocolLabel.TabIndex = 4;
            this.TreatmentProtocolLabel.Text = "Treatment Protocol: ";
            // 
            // TreatmentLengthTextbox
            // 
            this.TreatmentLengthTextbox.Location = new System.Drawing.Point(191, 73);
            this.TreatmentLengthTextbox.Name = "TreatmentLengthTextbox";
            this.TreatmentLengthTextbox.ReadOnly = true;
            this.TreatmentLengthTextbox.Size = new System.Drawing.Size(100, 26);
            this.TreatmentLengthTextbox.TabIndex = 3;
            // 
            // minWOxygenTextBox
            // 
            this.minWOxygenTextBox.Location = new System.Drawing.Point(355, 116);
            this.minWOxygenTextBox.Name = "minWOxygenTextBox";
            this.minWOxygenTextBox.Size = new System.Drawing.Size(100, 26);
            this.minWOxygenTextBox.TabIndex = 7;
            this.minWOxygenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MinWOxygenLabel
            // 
            this.MinWOxygenLabel.AutoSize = true;
            this.MinWOxygenLabel.Location = new System.Drawing.Point(461, 120);
            this.MinWOxygenLabel.Name = "MinWOxygenLabel";
            this.MinWOxygenLabel.Size = new System.Drawing.Size(187, 20);
            this.MinWOxygenLabel.TabIndex = 8;
            this.MinWOxygenLabel.Text = "min w/ 100% oxygen, and";
            // 
            // ATATextBox
            // 
            this.ATATextBox.Location = new System.Drawing.Point(189, 114);
            this.ATATextBox.Name = "ATATextBox";
            this.ATATextBox.Size = new System.Drawing.Size(100, 26);
            this.ATATextBox.TabIndex = 5;
            this.ATATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ATALabel
            // 
            this.ATALabel.AutoSize = true;
            this.ATALabel.Location = new System.Drawing.Point(296, 120);
            this.ATALabel.Name = "ATALabel";
            this.ATALabel.Size = new System.Drawing.Size(51, 20);
            this.ATALabel.TabIndex = 6;
            this.ATALabel.Text = "ATA x";
            // 
            // TreatmentProtocolComboBox
            // 
            this.TreatmentProtocolComboBox.FormattingEnabled = true;
            this.TreatmentProtocolComboBox.Items.AddRange(new object[] {
            "2.0 ATA x 90 min w/ 100% oxygen, and no air breaks",
            "2.4 ATA x 90 min w/ 100% oxygen, and two 5 minute air breaks"});
            this.TreatmentProtocolComboBox.Location = new System.Drawing.Point(939, 201);
            this.TreatmentProtocolComboBox.Name = "TreatmentProtocolComboBox";
            this.TreatmentProtocolComboBox.Size = new System.Drawing.Size(431, 28);
            this.TreatmentProtocolComboBox.TabIndex = 5;
            this.TreatmentProtocolComboBox.TabStop = false;
            this.TreatmentProtocolComboBox.Visible = false;
            // 
            // ATAErrorProvider
            // 
            this.ATAErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ATAErrorProvider.ContainerControl = this;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 694);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Calculator";
            this.Text = "Ejere Wound Care HBO Calculator";
            this.panel1.ResumeLayout(false);
            this.TreatmentDetailsGroupBox.ResumeLayout(false);
            this.TreatmentDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveTableGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ATAErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TreatmentNoLabel;
        private System.Windows.Forms.TextBox TreatmentLabelTextbox;
        private System.Windows.Forms.Label TreatmentLengthLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TreatmentProtocolLabel;
        private System.Windows.Forms.TextBox TreatmentLengthTextbox;
        private System.Windows.Forms.ComboBox TreatmentProtocolComboBox;
        private System.Windows.Forms.GroupBox TreatmentDetailsGroupBox;
        private System.Windows.Forms.ComboBox DiveRateUpComboBox;
        private System.Windows.Forms.ComboBox DiveRateDownComboBox;
        private System.Windows.Forms.Label DiveRateUpLabel;
        private System.Windows.Forms.Label DiveRateDownLabel;
        private System.Windows.Forms.DataGridView DiveTableGridView;
        private System.Windows.Forms.TextBox ATATextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numAirBreaksTextBox;
        private System.Windows.Forms.Label MinWOxygenLabel;
        private System.Windows.Forms.TextBox minWOxygenTextBox;
        private System.Windows.Forms.Label ATALabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label ATATextBoxErrorMessage;
        private System.Windows.Forms.Label DiveRateUpErrorMessage;
        private System.Windows.Forms.Label DiveRateDownErrorMessage;
        private System.Windows.Forms.Label CompressBeginTimeErrorMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.TextBox lengthAirBreaksTextBox;
        private System.Windows.Forms.Label psiPerMinLabel1;
        private System.Windows.Forms.Label psiPerMinuteLabel2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ErrorProvider ATAErrorProvider;
        private System.Windows.Forms.Label lengthAirBreaksTextBoxErrorMessage;
        private System.Windows.Forms.Label numAirBreaksTextBoxErrorMessage;
        private System.Windows.Forms.Label minWOxygenTextBoxErrorMessage;
    }
}