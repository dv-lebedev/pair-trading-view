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
            this.showDownloaderButton = new System.Windows.Forms.ToolStripMenuItem();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.priceCol = new System.Windows.Forms.NumericUpDown();
            this.header = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceCol)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDownloaderButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showDownloaderButton
            // 
            this.showDownloaderButton.Name = "showDownloaderButton";
            this.showDownloaderButton.Size = new System.Drawing.Size(119, 20);
            this.showDownloaderButton.Text = "Quote Downloader";
            this.showDownloaderButton.Click += new System.EventHandler(this.ShowDownloader_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(102, 144);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(120, 23);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Price column : ";
            // 
            // priceCol
            // 
            this.priceCol.Location = new System.Drawing.Point(149, 70);
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
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(47, 96);
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
            this.label4.Location = new System.Drawing.Point(98, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "CSV FILES FORMAT";
            // 
            // AppStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 186);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceCol);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppStartWindow";
            this.Text = "AppStartWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceCol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDownloaderButton;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown priceCol;
        private System.Windows.Forms.CheckBox header;
        private System.Windows.Forms.Label label4;
    }
}