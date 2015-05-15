namespace PairTradingView.Forms
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
            this.priceIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.volumeIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.ContainsHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.downloadQuotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDownloaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.deltaTypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceIndexUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeIndexUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // priceIndexUpDown
            // 
            this.priceIndexUpDown.BackColor = System.Drawing.Color.Black;
            this.priceIndexUpDown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceIndexUpDown.ForeColor = System.Drawing.Color.Gray;
            this.priceIndexUpDown.Location = new System.Drawing.Point(242, 77);
            this.priceIndexUpDown.Name = "priceIndexUpDown";
            this.priceIndexUpDown.Size = new System.Drawing.Size(120, 20);
            this.priceIndexUpDown.TabIndex = 0;
            this.priceIndexUpDown.ValueChanged += new System.EventHandler(this.priceIndexUpDown_ValueChanged);
            // 
            // volumeIndexUpDown
            // 
            this.volumeIndexUpDown.BackColor = System.Drawing.Color.Black;
            this.volumeIndexUpDown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.volumeIndexUpDown.ForeColor = System.Drawing.Color.Gray;
            this.volumeIndexUpDown.Location = new System.Drawing.Point(242, 106);
            this.volumeIndexUpDown.Name = "volumeIndexUpDown";
            this.volumeIndexUpDown.Size = new System.Drawing.Size(120, 20);
            this.volumeIndexUpDown.TabIndex = 1;
            this.volumeIndexUpDown.ValueChanged += new System.EventHandler(this.volumeIndexUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(131, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(131, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Volume index";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(210, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "CSV Format";
            // 
            // Start
            // 
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.ForeColor = System.Drawing.Color.Gray;
            this.Start.Location = new System.Drawing.Point(201, 248);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(101, 23);
            this.Start.TabIndex = 5;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ContainsHeaderCheckBox
            // 
            this.ContainsHeaderCheckBox.AutoSize = true;
            this.ContainsHeaderCheckBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContainsHeaderCheckBox.ForeColor = System.Drawing.Color.Gray;
            this.ContainsHeaderCheckBox.Location = new System.Drawing.Point(134, 143);
            this.ContainsHeaderCheckBox.Name = "ContainsHeaderCheckBox";
            this.ContainsHeaderCheckBox.Size = new System.Drawing.Size(116, 17);
            this.ContainsHeaderCheckBox.TabIndex = 6;
            this.ContainsHeaderCheckBox.Text = "Contains header";
            this.ContainsHeaderCheckBox.UseVisualStyleBackColor = true;
            this.ContainsHeaderCheckBox.CheckedChanged += new System.EventHandler(this.ContainsHeaderCheckBox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadQuotesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(489, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // downloadQuotesToolStripMenuItem
            // 
            this.downloadQuotesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDownloaderToolStripMenuItem});
            this.downloadQuotesToolStripMenuItem.Name = "downloadQuotesToolStripMenuItem";
            this.downloadQuotesToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.downloadQuotesToolStripMenuItem.Text = "Download Quotes";
            // 
            // openDownloaderToolStripMenuItem
            // 
            this.openDownloaderToolStripMenuItem.Name = "openDownloaderToolStripMenuItem";
            this.openDownloaderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openDownloaderToolStripMenuItem.Text = "Open Downloader";
            this.openDownloaderToolStripMenuItem.Click += new System.EventHandler(this.openDownloaderToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(173, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "______________________";
            // 
            // deltaTypeBox
            // 
            this.deltaTypeBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaTypeBox.FormattingEnabled = true;
            this.deltaTypeBox.Location = new System.Drawing.Point(242, 199);
            this.deltaTypeBox.Name = "deltaTypeBox";
            this.deltaTypeBox.Size = new System.Drawing.Size(120, 23);
            this.deltaTypeBox.TabIndex = 9;
            this.deltaTypeBox.SelectedIndexChanged += new System.EventHandler(this.deltaTypeBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(131, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Delta type";
            // 
            // AppStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(489, 283);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deltaTypeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ContainsHeaderCheckBox);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volumeIndexUpDown);
            this.Controls.Add(this.priceIndexUpDown);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppStartWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AppStartWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceIndexUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeIndexUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown priceIndexUpDown;
        private System.Windows.Forms.NumericUpDown volumeIndexUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.CheckBox ContainsHeaderCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadQuotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDownloaderToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox deltaTypeBox;
        private System.Windows.Forms.Label label5;
    }
}