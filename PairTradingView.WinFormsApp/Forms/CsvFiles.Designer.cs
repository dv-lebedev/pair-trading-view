namespace PairTradingView.WinFormsApp.Forms
{
    partial class CsvFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvFiles));
            this.label1 = new System.Windows.Forms.Label();
            this.LoadToDb = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.CheckBox();
            this.priceColumn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.deltaTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CSV Format";
            // 
            // LoadToDb
            // 
            this.LoadToDb.Location = new System.Drawing.Point(99, 156);
            this.LoadToDb.Name = "LoadToDb";
            this.LoadToDb.Size = new System.Drawing.Size(125, 23);
            this.LoadToDb.TabIndex = 3;
            this.LoadToDb.Text = "Load";
            this.LoadToDb.UseVisualStyleBackColor = true;
            this.LoadToDb.Click += new System.EventHandler(this.Load_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(61, 70);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(105, 17);
            this.header.TabIndex = 4;
            this.header.Text = "Contains Header";
            this.header.UseVisualStyleBackColor = true;
            // 
            // priceColumn
            // 
            this.priceColumn.Location = new System.Drawing.Point(141, 44);
            this.priceColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.Size = new System.Drawing.Size(120, 20);
            this.priceColumn.TabIndex = 10;
            this.priceColumn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Price column : ";
            // 
            // deltaTypeBox
            // 
            this.deltaTypeBox.FormattingEnabled = true;
            this.deltaTypeBox.Location = new System.Drawing.Point(141, 110);
            this.deltaTypeBox.Name = "deltaTypeBox";
            this.deltaTypeBox.Size = new System.Drawing.Size(121, 21);
            this.deltaTypeBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Delta type  : ";
            // 
            // CsvFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deltaTypeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceColumn);
            this.Controls.Add(this.header);
            this.Controls.Add(this.LoadToDb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CsvFiles";
            this.Text = "Csv Files";
            this.Load += new System.EventHandler(this.CsvToDbWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadToDb;
        private System.Windows.Forms.CheckBox header;
        private System.Windows.Forms.NumericUpDown priceColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox deltaTypeBox;
        private System.Windows.Forms.Label label3;

    }
}