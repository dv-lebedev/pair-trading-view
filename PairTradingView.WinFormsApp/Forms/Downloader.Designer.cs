namespace PairTradingView.Forms
{
    partial class Downloader
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
            this.toYear = new System.Windows.Forms.NumericUpDown();
            this.fromYear = new System.Windows.Forms.NumericUpDown();
            this.toDay = new System.Windows.Forms.NumericUpDown();
            this.fromDay = new System.Windows.Forms.NumericUpDown();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.toMonth = new System.Windows.Forms.ComboBox();
            this.fromMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTicker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.indexComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dow30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sP100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nasdaq100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.toYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toYear
            // 
            this.toYear.BackColor = System.Drawing.SystemColors.Control;
            this.toYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toYear.Location = new System.Drawing.Point(224, 94);
            this.toYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.toYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.toYear.Name = "toYear";
            this.toYear.Size = new System.Drawing.Size(67, 20);
            this.toYear.TabIndex = 32;
            this.toYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // fromYear
            // 
            this.fromYear.BackColor = System.Drawing.SystemColors.Control;
            this.fromYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fromYear.Location = new System.Drawing.Point(224, 62);
            this.fromYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.fromYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.fromYear.Name = "fromYear";
            this.fromYear.Size = new System.Drawing.Size(67, 20);
            this.fromYear.TabIndex = 31;
            this.fromYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // toDay
            // 
            this.toDay.BackColor = System.Drawing.SystemColors.Control;
            this.toDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toDay.Location = new System.Drawing.Point(169, 92);
            this.toDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.toDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toDay.Name = "toDay";
            this.toDay.Size = new System.Drawing.Size(48, 20);
            this.toDay.TabIndex = 30;
            this.toDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fromDay
            // 
            this.fromDay.BackColor = System.Drawing.SystemColors.Control;
            this.fromDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fromDay.Location = new System.Drawing.Point(169, 62);
            this.fromDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.fromDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fromDay.Name = "fromDay";
            this.fromDay.Size = new System.Drawing.Size(48, 20);
            this.fromDay.TabIndex = 29;
            this.fromDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.BackColor = System.Drawing.SystemColors.Control;
            this.rbMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMonthly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbMonthly.Location = new System.Drawing.Point(308, 105);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rbMonthly.TabIndex = 28;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = false;
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.BackColor = System.Drawing.SystemColors.Control;
            this.rbWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbWeekly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbWeekly.Location = new System.Drawing.Point(308, 83);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(61, 17);
            this.rbWeekly.TabIndex = 27;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = false;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.BackColor = System.Drawing.SystemColors.Control;
            this.rbDaily.Checked = true;
            this.rbDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDaily.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDaily.Location = new System.Drawing.Point(308, 62);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(48, 17);
            this.rbDaily.TabIndex = 26;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = false;
            // 
            // toMonth
            // 
            this.toMonth.BackColor = System.Drawing.SystemColors.Control;
            this.toMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toMonth.FormattingEnabled = true;
            this.toMonth.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.toMonth.Location = new System.Drawing.Point(111, 90);
            this.toMonth.Name = "toMonth";
            this.toMonth.Size = new System.Drawing.Size(50, 21);
            this.toMonth.TabIndex = 25;
            // 
            // fromMonth
            // 
            this.fromMonth.BackColor = System.Drawing.SystemColors.Control;
            this.fromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fromMonth.FormattingEnabled = true;
            this.fromMonth.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.fromMonth.Location = new System.Drawing.Point(111, 62);
            this.fromMonth.Name = "fromMonth";
            this.fromMonth.Size = new System.Drawing.Size(50, 21);
            this.fromMonth.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Start Date:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(384, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 46);
            this.button2.TabIndex = 21;
            this.button2.Text = "Download to .txt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(72, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 39);
            this.label2.TabIndex = 34;
            this.label2.Text = "Ticker symbols, \n separate with \n a comma ,";
            // 
            // textBoxTicker
            // 
            this.textBoxTicker.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxTicker.Location = new System.Drawing.Point(197, 132);
            this.textBoxTicker.Multiline = true;
            this.textBoxTicker.Name = "textBoxTicker";
            this.textBoxTicker.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTicker.Size = new System.Drawing.Size(279, 125);
            this.textBoxTicker.TabIndex = 33;
            this.textBoxTicker.Text = "GOOG, AAPL, AMZN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Folder Path:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(384, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 36;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPath.Location = new System.Drawing.Point(110, 31);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(256, 20);
            this.txtPath.TabIndex = 35;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexComponentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // indexComponentsToolStripMenuItem
            // 
            this.indexComponentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dow30ToolStripMenuItem,
            this.sP100ToolStripMenuItem,
            this.nasdaq100ToolStripMenuItem});
            this.indexComponentsToolStripMenuItem.Name = "indexComponentsToolStripMenuItem";
            this.indexComponentsToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.indexComponentsToolStripMenuItem.Text = "Index Components";
            // 
            // dow30ToolStripMenuItem
            // 
            this.dow30ToolStripMenuItem.Name = "dow30ToolStripMenuItem";
            this.dow30ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dow30ToolStripMenuItem.Text = "Dow 30";
            this.dow30ToolStripMenuItem.Click += new System.EventHandler(this.dow30ToolStripMenuItem_Click);
            // 
            // sP100ToolStripMenuItem
            // 
            this.sP100ToolStripMenuItem.Name = "sP100ToolStripMenuItem";
            this.sP100ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sP100ToolStripMenuItem.Text = "S&&P 100";
            this.sP100ToolStripMenuItem.Click += new System.EventHandler(this.sP100ToolStripMenuItem_Click);
            // 
            // nasdaq100ToolStripMenuItem
            // 
            this.nasdaq100ToolStripMenuItem.Name = "nasdaq100ToolStripMenuItem";
            this.nasdaq100ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.nasdaq100ToolStripMenuItem.Text = "Nasdaq 100";
            this.nasdaq100ToolStripMenuItem.Click += new System.EventHandler(this.nasdaq100ToolStripMenuItem_Click);
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(515, 274);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTicker);
            this.Controls.Add(this.toYear);
            this.Controls.Add(this.fromYear);
            this.Controls.Add(this.toDay);
            this.Controls.Add(this.fromDay);
            this.Controls.Add(this.rbMonthly);
            this.Controls.Add(this.rbWeekly);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.toMonth);
            this.Controls.Add(this.fromMonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Gray;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Downloader";
            this.ShowIcon = false;
            this.Text = "Quote Downloader";
            this.Load += new System.EventHandler(this.Downloader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown toYear;
        private System.Windows.Forms.NumericUpDown fromYear;
        private System.Windows.Forms.NumericUpDown toDay;
        private System.Windows.Forms.NumericUpDown fromDay;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.ComboBox toMonth;
        private System.Windows.Forms.ComboBox fromMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem indexComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dow30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sP100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nasdaq100ToolStripMenuItem;
    }
}