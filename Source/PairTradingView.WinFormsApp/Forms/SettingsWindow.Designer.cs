namespace PairTradingView.Forms
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.testConnection = new System.Windows.Forms.Button();
            this.saveSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.loadValuesCount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeFrom = new System.Windows.Forms.DateTimePicker();
            this.timeTo = new System.Windows.Forms.DateTimePicker();
            this.loadLastNValues = new System.Windows.Forms.RadioButton();
            this.loadForNDays = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataSavingInterval = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.loadNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deltaTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionStr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataUpdateInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadValuesCount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadNumberOfDays)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // testConnection
            // 
            this.testConnection.Location = new System.Drawing.Point(158, 88);
            this.testConnection.Name = "testConnection";
            this.testConnection.Size = new System.Drawing.Size(75, 23);
            this.testConnection.TabIndex = 6;
            this.testConnection.Text = "Test";
            this.testConnection.UseVisualStyleBackColor = true;
            this.testConnection.Click += new System.EventHandler(this.testConnection_Click);
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(286, 249);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(133, 23);
            this.saveSettings.TabIndex = 7;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 139);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(214, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "sec.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(30, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "Interval";
            // 
            // dataUpdateInterval
            // 
            this.dataUpdateInterval.BackColor = System.Drawing.SystemColors.Control;
            this.dataUpdateInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataUpdateInterval.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataUpdateInterval.Location = new System.Drawing.Point(88, 21);
            this.dataUpdateInterval.Name = "dataUpdateInterval";
            this.dataUpdateInterval.Size = new System.Drawing.Size(120, 20);
            this.dataUpdateInterval.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Stop time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(6, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Start time";
            // 
            // loadValuesCount
            // 
            this.loadValuesCount.BackColor = System.Drawing.SystemColors.Control;
            this.loadValuesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadValuesCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadValuesCount.Location = new System.Drawing.Point(80, 21);
            this.loadValuesCount.Name = "loadValuesCount";
            this.loadValuesCount.Size = new System.Drawing.Size(120, 20);
            this.loadValuesCount.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(15, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Interval";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(674, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 139);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Saving";
            // 
            // timeFrom
            // 
            this.timeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFrom.Location = new System.Drawing.Point(78, 18);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.Size = new System.Drawing.Size(119, 20);
            this.timeFrom.TabIndex = 67;
            // 
            // timeTo
            // 
            this.timeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTo.Location = new System.Drawing.Point(78, 44);
            this.timeTo.Name = "timeTo";
            this.timeTo.Size = new System.Drawing.Size(119, 20);
            this.timeTo.TabIndex = 65;
            // 
            // loadLastNValues
            // 
            this.loadLastNValues.AutoSize = true;
            this.loadLastNValues.Location = new System.Drawing.Point(6, 21);
            this.loadLastNValues.Name = "loadLastNValues";
            this.loadLastNValues.Size = new System.Drawing.Size(68, 17);
            this.loadLastNValues.TabIndex = 63;
            this.loadLastNValues.TabStop = true;
            this.loadLastNValues.Text = "Load last";
            this.loadLastNValues.UseVisualStyleBackColor = true;
            // 
            // loadForNDays
            // 
            this.loadForNDays.AutoSize = true;
            this.loadForNDays.Location = new System.Drawing.Point(6, 48);
            this.loadForNDays.Name = "loadForNDays";
            this.loadForNDays.Size = new System.Drawing.Size(64, 17);
            this.loadForNDays.TabIndex = 64;
            this.loadForNDays.TabStop = true;
            this.loadForNDays.Text = "Load for";
            this.loadForNDays.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 231);
            this.tabControl1.TabIndex = 67;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.connectionStr);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.testConnection);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ODBC Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataSavingInterval);
            this.tabPage2.Controls.Add(this.timeFrom);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.timeTo);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data storage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataSavingInterval
            // 
            this.dataSavingInterval.FormattingEnabled = true;
            this.dataSavingInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataSavingInterval.Location = new System.Drawing.Point(78, 71);
            this.dataSavingInterval.Name = "dataSavingInterval";
            this.dataSavingInterval.Size = new System.Drawing.Size(119, 21);
            this.dataSavingInterval.TabIndex = 68;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.loadNumberOfDays);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.loadLastNValues);
            this.tabPage3.Controls.Add(this.loadValuesCount);
            this.tabPage3.Controls.Add(this.loadForNDays);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(399, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Loading data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // loadNumberOfDays
            // 
            this.loadNumberOfDays.BackColor = System.Drawing.SystemColors.Control;
            this.loadNumberOfDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadNumberOfDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadNumberOfDays.Location = new System.Drawing.Point(80, 48);
            this.loadNumberOfDays.Name = "loadNumberOfDays";
            this.loadNumberOfDays.Size = new System.Drawing.Size(120, 20);
            this.loadNumberOfDays.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "days.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "values.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.dataUpdateInterval);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(399, 205);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Data updating";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.descriptionLabel);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.deltaTypeBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(399, 205);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Delta";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionLabel.Location = new System.Drawing.Point(70, 64);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(10, 13);
            this.descriptionLabel.TabIndex = 51;
            this.descriptionLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Delta type :";
            // 
            // deltaTypeBox
            // 
            this.deltaTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaTypeBox.FormattingEnabled = true;
            this.deltaTypeBox.Location = new System.Drawing.Point(73, 22);
            this.deltaTypeBox.Name = "deltaTypeBox";
            this.deltaTypeBox.Size = new System.Drawing.Size(157, 21);
            this.deltaTypeBox.TabIndex = 49;
            this.deltaTypeBox.SelectedIndexChanged += new System.EventHandler(this.deltaTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ODBC connection string";
            // 
            // connectionStr
            // 
            this.connectionStr.Location = new System.Drawing.Point(6, 35);
            this.connectionStr.Multiline = true;
            this.connectionStr.Name = "connectionStr";
            this.connectionStr.Size = new System.Drawing.Size(387, 47);
            this.connectionStr.TabIndex = 8;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 281);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUpdateInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadValuesCount)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadNumberOfDays)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testConnection;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dataUpdateInterval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown loadValuesCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton loadLastNValues;
        private System.Windows.Forms.RadioButton loadForNDays;
        private System.Windows.Forms.DateTimePicker timeTo;
        private System.Windows.Forms.DateTimePicker timeFrom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox dataSavingInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox deltaTypeBox;
        private System.Windows.Forms.NumericUpDown loadNumberOfDays;
        private System.Windows.Forms.TextBox connectionStr;
        private System.Windows.Forms.Label label1;
    }
}