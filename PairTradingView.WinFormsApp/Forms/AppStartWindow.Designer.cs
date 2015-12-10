namespace PairTradingView
{
    partial class AppStartWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppStartWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quoteDownloaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartBtn = new System.Windows.Forms.Button();
            this.dtCol = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.priceCol = new System.Windows.Forms.NumericUpDown();
            this.dtFmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deltaTypeBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceCol)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quoteDownloaderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(288, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quoteDownloaderToolStripMenuItem
            // 
            this.quoteDownloaderToolStripMenuItem.Name = "quoteDownloaderToolStripMenuItem";
            this.quoteDownloaderToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.quoteDownloaderToolStripMenuItem.Text = "Quote Downloader";
            this.quoteDownloaderToolStripMenuItem.Click += new System.EventHandler(this.quoteDownloaderToolStripMenuItem_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(88, 263);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(120, 23);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // dtCol
            // 
            this.dtCol.Location = new System.Drawing.Point(135, 61);
            this.dtCol.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dtCol.Name = "dtCol";
            this.dtCol.Size = new System.Drawing.Size(120, 20);
            this.dtCol.TabIndex = 2;
            this.dtCol.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DateTime column : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Price column : ";
            // 
            // priceCol
            // 
            this.priceCol.Location = new System.Drawing.Point(135, 128);
            this.priceCol.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priceCol.Name = "priceCol";
            this.priceCol.Size = new System.Drawing.Size(120, 20);
            this.priceCol.TabIndex = 4;
            this.priceCol.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // dtFmt
            // 
            this.dtFmt.Location = new System.Drawing.Point(135, 87);
            this.dtFmt.Name = "dtFmt";
            this.dtFmt.Size = new System.Drawing.Size(120, 20);
            this.dtFmt.TabIndex = 6;
            this.dtFmt.Text = "yyyyMMdd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DateTime format : ";
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(33, 163);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(103, 17);
            this.header.TabIndex = 8;
            this.header.Text = "Contains header";
            this.header.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(85, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "CSV FILES FORMAT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(116, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DELTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Type : ";
            // 
            // deltaTypeBox
            // 
            this.deltaTypeBox.FormattingEnabled = true;
            this.deltaTypeBox.Location = new System.Drawing.Point(134, 217);
            this.deltaTypeBox.Name = "deltaTypeBox";
            this.deltaTypeBox.Size = new System.Drawing.Size(121, 21);
            this.deltaTypeBox.TabIndex = 12;
            // 
            // AppStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 298);
            this.Controls.Add(this.deltaTypeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFmt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceCol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtCol);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppStartWindow";
            this.Text = "AppStartWindow";
            this.Load += new System.EventHandler(this.AppStartWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceCol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quoteDownloaderToolStripMenuItem;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.NumericUpDown dtCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown priceCol;
        private System.Windows.Forms.TextBox dtFmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox header;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox deltaTypeBox;
    }
}