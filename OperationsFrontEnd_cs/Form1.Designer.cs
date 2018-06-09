namespace OperationsFrontEnd
{
    partial class Form1
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
            this.countriesComboxExcel = new System.Windows.Forms.ComboBox();
            this.selectByCountryButton = new System.Windows.Forms.Button();
            this.CreateNewExcelFileCheckBox = new System.Windows.Forms.CheckBox();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.cmdExportFromSqlServerToMsAccess = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countriesComboxAccess1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdExportToXml = new System.Windows.Forms.Button();
            this.clbColumnNames = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.countriesComboxAccess2 = new System.Windows.Forms.ComboBox();
            this.cmdExportFromSqlServerToMsAccessDynamic = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkBracketed = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // countriesComboxExcel
            // 
            this.countriesComboxExcel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countriesComboxExcel.FormattingEnabled = true;
            this.countriesComboxExcel.Location = new System.Drawing.Point(176, 21);
            this.countriesComboxExcel.Name = "countriesComboxExcel";
            this.countriesComboxExcel.Size = new System.Drawing.Size(175, 21);
            this.countriesComboxExcel.TabIndex = 2;
            // 
            // selectByCountryButton
            // 
            this.selectByCountryButton.Location = new System.Drawing.Point(18, 48);
            this.selectByCountryButton.Name = "selectByCountryButton";
            this.selectByCountryButton.Size = new System.Drawing.Size(135, 23);
            this.selectByCountryButton.TabIndex = 1;
            this.selectByCountryButton.Text = "Export by Country";
            this.selectByCountryButton.UseVisualStyleBackColor = true;
            this.selectByCountryButton.Click += new System.EventHandler(this.selectByCountryButton_Click);
            // 
            // CreateNewExcelFileCheckBox
            // 
            this.CreateNewExcelFileCheckBox.AutoSize = true;
            this.CreateNewExcelFileCheckBox.Checked = true;
            this.CreateNewExcelFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CreateNewExcelFileCheckBox.Location = new System.Drawing.Point(13, 79);
            this.CreateNewExcelFileCheckBox.Name = "CreateNewExcelFileCheckBox";
            this.CreateNewExcelFileCheckBox.Size = new System.Drawing.Size(161, 17);
            this.CreateNewExcelFileCheckBox.TabIndex = 3;
            this.CreateNewExcelFileCheckBox.Text = "If checked, create a new file";
            this.CreateNewExcelFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(18, 19);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(135, 23);
            this.selectAllButton.TabIndex = 0;
            this.selectAllButton.Text = "Export All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // cmdExportFromSqlServerToMsAccess
            // 
            this.cmdExportFromSqlServerToMsAccess.Location = new System.Drawing.Point(16, 29);
            this.cmdExportFromSqlServerToMsAccess.Name = "cmdExportFromSqlServerToMsAccess";
            this.cmdExportFromSqlServerToMsAccess.Size = new System.Drawing.Size(135, 23);
            this.cmdExportFromSqlServerToMsAccess.TabIndex = 0;
            this.cmdExportFromSqlServerToMsAccess.Text = "Export";
            this.cmdExportFromSqlServerToMsAccess.UseVisualStyleBackColor = true;
            this.cmdExportFromSqlServerToMsAccess.Click += new System.EventHandler(this.cmdExportFromSqlServerToMsAccess_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectByCountryButton);
            this.groupBox1.Controls.Add(this.selectAllButton);
            this.groupBox1.Controls.Add(this.countriesComboxExcel);
            this.groupBox1.Controls.Add(this.CreateNewExcelFileCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel export - static";
            // 
            // countriesComboxAccess1
            // 
            this.countriesComboxAccess1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countriesComboxAccess1.FormattingEnabled = true;
            this.countriesComboxAccess1.Location = new System.Drawing.Point(174, 29);
            this.countriesComboxAccess1.Name = "countriesComboxAccess1";
            this.countriesComboxAccess1.Size = new System.Drawing.Size(175, 21);
            this.countriesComboxAccess1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.countriesComboxAccess1);
            this.groupBox2.Controls.Add(this.cmdExportFromSqlServerToMsAccess);
            this.groupBox2.Location = new System.Drawing.Point(9, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Access export - static";
            // 
            // cmdExportToXml
            // 
            this.cmdExportToXml.Location = new System.Drawing.Point(13, 19);
            this.cmdExportToXml.Name = "cmdExportToXml";
            this.cmdExportToXml.Size = new System.Drawing.Size(135, 23);
            this.cmdExportToXml.TabIndex = 2;
            this.cmdExportToXml.Text = "Export xml";
            this.cmdExportToXml.UseVisualStyleBackColor = true;
            this.cmdExportToXml.Click += new System.EventHandler(this.cmdExportToXml_Click);
            // 
            // clbColumnNames
            // 
            this.clbColumnNames.FormattingEnabled = true;
            this.clbColumnNames.Location = new System.Drawing.Point(10, 31);
            this.clbColumnNames.Name = "clbColumnNames";
            this.clbColumnNames.Size = new System.Drawing.Size(135, 154);
            this.clbColumnNames.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdExportToXml);
            this.groupBox3.Location = new System.Drawing.Point(12, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 59);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "XML export - static";
            // 
            // countriesComboxAccess2
            // 
            this.countriesComboxAccess2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countriesComboxAccess2.FormattingEnabled = true;
            this.countriesComboxAccess2.Location = new System.Drawing.Point(168, 31);
            this.countriesComboxAccess2.Name = "countriesComboxAccess2";
            this.countriesComboxAccess2.Size = new System.Drawing.Size(175, 21);
            this.countriesComboxAccess2.TabIndex = 2;
            // 
            // cmdExportFromSqlServerToMsAccessDynamic
            // 
            this.cmdExportFromSqlServerToMsAccessDynamic.Location = new System.Drawing.Point(10, 201);
            this.cmdExportFromSqlServerToMsAccessDynamic.Name = "cmdExportFromSqlServerToMsAccessDynamic";
            this.cmdExportFromSqlServerToMsAccessDynamic.Size = new System.Drawing.Size(135, 23);
            this.cmdExportFromSqlServerToMsAccessDynamic.TabIndex = 2;
            this.cmdExportFromSqlServerToMsAccessDynamic.Text = "Export";
            this.cmdExportFromSqlServerToMsAccessDynamic.UseVisualStyleBackColor = true;
            this.cmdExportFromSqlServerToMsAccessDynamic.Click += new System.EventHandler(this.cmdExportFromSqlServerToMsAccessDynamic_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkBracketed);
            this.groupBox4.Controls.Add(this.cmdExportFromSqlServerToMsAccessDynamic);
            this.groupBox4.Controls.Add(this.countriesComboxAccess2);
            this.groupBox4.Controls.Add(this.clbColumnNames);
            this.groupBox4.Location = new System.Drawing.Point(15, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 234);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Access export - dynamic";
            // 
            // chkBracketed
            // 
            this.chkBracketed.AutoSize = true;
            this.chkBracketed.Location = new System.Drawing.Point(168, 207);
            this.chkBracketed.Name = "chkBracketed";
            this.chkBracketed.Size = new System.Drawing.Size(134, 17);
            this.chkBracketed.TabIndex = 2;
            this.chkBracketed.Text = "Bracket column names";
            this.chkBracketed.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 572);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample - export from SQL-Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox countriesComboxExcel;
        internal System.Windows.Forms.Button selectByCountryButton;
        internal System.Windows.Forms.CheckBox CreateNewExcelFileCheckBox;
        internal System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button cmdExportFromSqlServerToMsAccess;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox countriesComboxAccess1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdExportToXml;
        private System.Windows.Forms.CheckedListBox clbColumnNames;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox countriesComboxAccess2;
        private System.Windows.Forms.Button cmdExportFromSqlServerToMsAccessDynamic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkBracketed;
    }
}

