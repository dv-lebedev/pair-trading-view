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
            this.explanationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serverNameBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.loadValuesCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.radioCSV = new System.Windows.Forms.RadioButton();
            this.radioSQL = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startTimeTxt = new System.Windows.Forms.TextBox();
            this.stopTimeTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.csvSeparator = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceIndexUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeIndexUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSaveInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadValuesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUpdateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // priceIndexUpDown
            // 
            this.priceIndexUpDown.BackColor = System.Drawing.Color.White;
            this.priceIndexUpDown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceIndexUpDown.ForeColor = System.Drawing.Color.Black;
            this.priceIndexUpDown.Location = new System.Drawing.Point(159, 78);
            this.priceIndexUpDown.Name = "priceIndexUpDown";
            this.priceIndexUpDown.Size = new System.Drawing.Size(120, 20);
            this.priceIndexUpDown.TabIndex = 0;
            this.priceIndexUpDown.ValueChanged += new System.EventHandler(this.priceIndexUpDown_ValueChanged);
            // 
            // volumeIndexUpDown
            // 
            this.volumeIndexUpDown.BackColor = System.Drawing.Color.White;
            this.volumeIndexUpDown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.volumeIndexUpDown.ForeColor = System.Drawing.Color.Black;
            this.volumeIndexUpDown.Location = new System.Drawing.Point(159, 107);
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
            this.label1.Location = new System.Drawing.Point(48, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price column :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(41, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Volume column :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(112, 46);
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
            this.Start.Location = new System.Drawing.Point(337, 419);
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
            this.ContainsHeaderCheckBox.Location = new System.Drawing.Point(159, 170);
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
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
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
            this.label4.Location = new System.Drawing.Point(93, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "______________________";
            // 
            // deltaTypeBox
            // 
            this.deltaTypeBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaTypeBox.FormattingEnabled = true;
            this.deltaTypeBox.Location = new System.Drawing.Point(136, 249);
            this.deltaTypeBox.Name = "deltaTypeBox";
            this.deltaTypeBox.Size = new System.Drawing.Size(157, 23);
            this.deltaTypeBox.TabIndex = 9;
            this.deltaTypeBox.SelectedIndexChanged += new System.EventHandler(this.deltaTypeBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(51, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Delta type";
            // 
            // explanationLabel
            // 
            this.explanationLabel.AutoSize = true;
            this.explanationLabel.BackColor = System.Drawing.Color.Black;
            this.explanationLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.explanationLabel.ForeColor = System.Drawing.Color.Gray;
            this.explanationLabel.Location = new System.Drawing.Point(51, 289);
            this.explanationLabel.Name = "explanationLabel";
            this.explanationLabel.Size = new System.Drawing.Size(14, 15);
            this.explanationLabel.TabIndex = 11;
            this.explanationLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(522, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "SQL Server";
            // 
            // serverNameBox
            // 
            this.serverNameBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverNameBox.FormattingEnabled = true;
            this.serverNameBox.Location = new System.Drawing.Point(503, 75);
            this.serverNameBox.Name = "serverNameBox";
            this.serverNameBox.Size = new System.Drawing.Size(167, 23);
            this.serverNameBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(423, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Server :";
            // 
            // dataSaveInterval
            // 
            this.dataSaveInterval.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataSaveInterval.Location = new System.Drawing.Point(550, 197);
            this.dataSaveInterval.Name = "dataSaveInterval";
            this.dataSaveInterval.Size = new System.Drawing.Size(120, 20);
            this.dataSaveInterval.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(472, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Load last";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(468, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Interval :";
            // 
            // loadValuesCount
            // 
            this.loadValuesCount.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadValuesCount.Location = new System.Drawing.Point(550, 248);
            this.loadValuesCount.Name = "loadValuesCount";
            this.loadValuesCount.Size = new System.Drawing.Size(120, 20);
            this.loadValuesCount.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(676, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "values.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(454, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Start time :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(461, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "Stop time :";
            // 
            // radioCSV
            // 
            this.radioCSV.AutoSize = true;
            this.radioCSV.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioCSV.ForeColor = System.Drawing.Color.Gray;
            this.radioCSV.Location = new System.Drawing.Point(337, 357);
            this.radioCSV.Name = "radioCSV";
            this.radioCSV.Size = new System.Drawing.Size(137, 19);
            this.radioCSV.TabIndex = 30;
            this.radioCSV.TabStop = true;
            this.radioCSV.Text = "csv format files";
            this.radioCSV.UseVisualStyleBackColor = true;
            // 
            // radioSQL
            // 
            this.radioSQL.AutoSize = true;
            this.radioSQL.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioSQL.ForeColor = System.Drawing.Color.Gray;
            this.radioSQL.Location = new System.Drawing.Point(337, 380);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(172, 19);
            this.radioSQL.TabIndex = 31;
            this.radioSQL.TabStop = true;
            this.radioSQL.Text = "sql server connection";
            this.radioSQL.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(207, 359);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 15);
            this.label15.TabIndex = 32;
            this.label15.Text = "Data sources :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(444, 278);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 15);
            this.label16.TabIndex = 34;
            this.label16.Text = "Update data :";
            // 
            // dataUpdateInterval
            // 
            this.dataUpdateInterval.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataUpdateInterval.Location = new System.Drawing.Point(550, 274);
            this.dataUpdateInterval.Name = "dataUpdateInterval";
            this.dataUpdateInterval.Size = new System.Drawing.Size(120, 20);
            this.dataUpdateInterval.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(678, 197);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 15);
            this.label17.TabIndex = 35;
            this.label17.Text = "min.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(676, 278);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 15);
            this.label18.TabIndex = 36;
            this.label18.Text = "sec.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(349, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 225);
            this.panel1.TabIndex = 37;
            // 
            // startTimeTxt
            // 
            this.startTimeTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimeTxt.Location = new System.Drawing.Point(550, 144);
            this.startTimeTxt.Name = "startTimeTxt";
            this.startTimeTxt.Size = new System.Drawing.Size(120, 23);
            this.startTimeTxt.TabIndex = 38;
            this.startTimeTxt.TextChanged += new System.EventHandler(this.startTimeTxt_TextChanged);
            // 
            // stopTimeTxt
            // 
            this.stopTimeTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopTimeTxt.Location = new System.Drawing.Point(550, 170);
            this.stopTimeTxt.Name = "stopTimeTxt";
            this.stopTimeTxt.Size = new System.Drawing.Size(120, 23);
            this.stopTimeTxt.TabIndex = 39;
            this.stopTimeTxt.TextChanged += new System.EventHandler(this.stopTimeTxt_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(423, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 40;
            this.label13.Text = "Data save : ";
            // 
            // csvSeparator
            // 
            this.csvSeparator.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.csvSeparator.FormattingEnabled = true;
            this.csvSeparator.Location = new System.Drawing.Point(159, 141);
            this.csvSeparator.Name = "csvSeparator";
            this.csvSeparator.Size = new System.Drawing.Size(120, 23);
            this.csvSeparator.TabIndex = 41;
            this.csvSeparator.SelectedIndexChanged += new System.EventHandler(this.csvSeparator_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(69, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "Separator :";
            // 
            // AppStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(774, 475);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.csvSeparator);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.stopTimeTxt);
            this.Controls.Add(this.startTimeTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dataUpdateInterval);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.radioCSV);
            this.Controls.Add(this.radioSQL);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.loadValuesCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataSaveInterval);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.serverNameBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.explanationLabel);
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
            this.Text = "Start";
            this.Load += new System.EventHandler(this.AppStartWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceIndexUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeIndexUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSaveInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadValuesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUpdateInterval)).EndInit();
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
        private System.Windows.Forms.Label explanationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox serverNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown dataSaveInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown loadValuesCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radioCSV;
        private System.Windows.Forms.RadioButton radioSQL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dataUpdateInterval;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox startTimeTxt;
        private System.Windows.Forms.TextBox stopTimeTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox csvSeparator;
        private System.Windows.Forms.Label label14;
    }
}