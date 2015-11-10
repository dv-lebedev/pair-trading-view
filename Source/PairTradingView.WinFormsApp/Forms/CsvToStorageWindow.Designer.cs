namespace PairTradingView.WinFormsApp.Forms
{
    partial class CsvToStorageWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvToStorageWindow));
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoadToDb = new System.Windows.Forms.Button();
            this.containsHeader = new System.Windows.Forms.CheckBox();
            this.separatorBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // formatComboBox
            // 
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(81, 20);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(355, 21);
            this.formatComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CSV Format";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeader3});
            this.listView1.Location = new System.Drawing.Point(15, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(421, 226);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Available to save in Db";
            this.columnHeader2.Width = 129;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "State";
            this.ColumnHeader3.Width = 86;
            // 
            // LoadToDb
            // 
            this.LoadToDb.Location = new System.Drawing.Point(361, 329);
            this.LoadToDb.Name = "LoadToDb";
            this.LoadToDb.Size = new System.Drawing.Size(75, 23);
            this.LoadToDb.TabIndex = 3;
            this.LoadToDb.Text = "Load";
            this.LoadToDb.UseVisualStyleBackColor = true;
            this.LoadToDb.Click += new System.EventHandler(this.LoadToDb_Click);
            // 
            // containsHeader
            // 
            this.containsHeader.AutoSize = true;
            this.containsHeader.Location = new System.Drawing.Point(81, 74);
            this.containsHeader.Name = "containsHeader";
            this.containsHeader.Size = new System.Drawing.Size(105, 17);
            this.containsHeader.TabIndex = 4;
            this.containsHeader.Text = "Contains Header";
            this.containsHeader.UseVisualStyleBackColor = true;
            // 
            // separatorBox
            // 
            this.separatorBox.FormattingEnabled = true;
            this.separatorBox.Location = new System.Drawing.Point(81, 47);
            this.separatorBox.Name = "separatorBox";
            this.separatorBox.Size = new System.Drawing.Size(105, 21);
            this.separatorBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Separator";
            // 
            // dtFormat
            // 
            this.dtFormat.Location = new System.Drawing.Point(295, 47);
            this.dtFormat.Name = "dtFormat";
            this.dtFormat.Size = new System.Drawing.Size(141, 20);
            this.dtFormat.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datetime format";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 334);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(340, 11);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 9;
            // 
            // CsvToStorageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 357);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.separatorBox);
            this.Controls.Add(this.containsHeader);
            this.Controls.Add(this.LoadToDb);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formatComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CsvToStorageWindow";
            this.Text = "CsvToStorage";
            this.Load += new System.EventHandler(this.CsvToDbWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button LoadToDb;
        private System.Windows.Forms.CheckBox containsHeader;
        private System.Windows.Forms.ComboBox separatorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dtFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;

    }
}