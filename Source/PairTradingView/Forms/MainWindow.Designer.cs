using PairTradingView.Controls;
namespace PairTradingView.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.SMAperiodNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WMAperiodNUD = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stocksCountLabel = new System.Windows.Forms.Label();
            this.pairsCreatedLabel = new System.Windows.Forms.Label();
            this.r_valueHighLabel = new System.Windows.Forms.Label();
            this.r_valueLowLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ReloadApp = new System.Windows.Forms.Button();
            this.IncrementSMAPeriod = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DecrementSMAPeriod = new System.Windows.Forms.Button();
            this.IncrementWMAPeriod = new System.Windows.Forms.Button();
            this.DecrementWMAPeriod = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listView1 = new PairTradingView.Controls.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zedGraphControl = new PairTradingView.Controls.MyZedgraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.SMAperiodNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMAperiodNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // SMAperiodNUD
            // 
            this.SMAperiodNUD.BackColor = System.Drawing.Color.Black;
            this.SMAperiodNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SMAperiodNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SMAperiodNUD.ForeColor = System.Drawing.Color.Gray;
            this.SMAperiodNUD.Location = new System.Drawing.Point(874, 266);
            this.SMAperiodNUD.Name = "SMAperiodNUD";
            this.SMAperiodNUD.Size = new System.Drawing.Size(120, 20);
            this.SMAperiodNUD.TabIndex = 2;
            this.SMAperiodNUD.ValueChanged += new System.EventHandler(this.SMAperiodNUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(804, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "SMA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(804, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "WMA";
            // 
            // WMAperiodNUD
            // 
            this.WMAperiodNUD.BackColor = System.Drawing.Color.Black;
            this.WMAperiodNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WMAperiodNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WMAperiodNUD.ForeColor = System.Drawing.Color.Gray;
            this.WMAperiodNUD.Location = new System.Drawing.Point(874, 292);
            this.WMAperiodNUD.Name = "WMAperiodNUD";
            this.WMAperiodNUD.Size = new System.Drawing.Size(120, 20);
            this.WMAperiodNUD.TabIndex = 4;
            this.WMAperiodNUD.ValueChanged += new System.EventHandler(this.WMAperiodNUD_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(746, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 355);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(803, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stocks Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(803, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pairs Created";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(803, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "R_Value >= 0.7";
            // 
            // stocksCountLabel
            // 
            this.stocksCountLabel.AutoSize = true;
            this.stocksCountLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stocksCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.stocksCountLabel.Location = new System.Drawing.Point(979, 73);
            this.stocksCountLabel.Name = "stocksCountLabel";
            this.stocksCountLabel.Size = new System.Drawing.Size(14, 14);
            this.stocksCountLabel.TabIndex = 10;
            this.stocksCountLabel.Text = "0";
            // 
            // pairsCreatedLabel
            // 
            this.pairsCreatedLabel.AutoSize = true;
            this.pairsCreatedLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairsCreatedLabel.ForeColor = System.Drawing.Color.Red;
            this.pairsCreatedLabel.Location = new System.Drawing.Point(979, 100);
            this.pairsCreatedLabel.Name = "pairsCreatedLabel";
            this.pairsCreatedLabel.Size = new System.Drawing.Size(14, 14);
            this.pairsCreatedLabel.TabIndex = 11;
            this.pairsCreatedLabel.Text = "0";
            // 
            // r_valueHighLabel
            // 
            this.r_valueHighLabel.AutoSize = true;
            this.r_valueHighLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r_valueHighLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.r_valueHighLabel.Location = new System.Drawing.Point(979, 127);
            this.r_valueHighLabel.Name = "r_valueHighLabel";
            this.r_valueHighLabel.Size = new System.Drawing.Size(14, 14);
            this.r_valueHighLabel.TabIndex = 12;
            this.r_valueHighLabel.Text = "0";
            // 
            // r_valueLowLabel
            // 
            this.r_valueLowLabel.AutoSize = true;
            this.r_valueLowLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r_valueLowLabel.ForeColor = System.Drawing.Color.Gold;
            this.r_valueLowLabel.Location = new System.Drawing.Point(979, 153);
            this.r_valueLowLabel.Name = "r_valueLowLabel";
            this.r_valueLowLabel.Size = new System.Drawing.Size(14, 14);
            this.r_valueLowLabel.TabIndex = 14;
            this.r_valueLowLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(804, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "R_Value <= - 0.7";
            // 
            // ReloadApp
            // 
            this.ReloadApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReloadApp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReloadApp.ForeColor = System.Drawing.Color.Gray;
            this.ReloadApp.Location = new System.Drawing.Point(874, 336);
            this.ReloadApp.Name = "ReloadApp";
            this.ReloadApp.Size = new System.Drawing.Size(105, 23);
            this.ReloadApp.TabIndex = 15;
            this.ReloadApp.Text = "Reload App";
            this.ReloadApp.UseVisualStyleBackColor = true;
            this.ReloadApp.Click += new System.EventHandler(this.ReloadApp_Click);
            // 
            // IncrementSMAPeriod
            // 
            this.IncrementSMAPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IncrementSMAPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrementSMAPeriod.ForeColor = System.Drawing.Color.Gray;
            this.IncrementSMAPeriod.Location = new System.Drawing.Point(978, 266);
            this.IncrementSMAPeriod.Name = "IncrementSMAPeriod";
            this.IncrementSMAPeriod.Size = new System.Drawing.Size(21, 21);
            this.IncrementSMAPeriod.TabIndex = 18;
            this.IncrementSMAPeriod.Text = "+";
            this.IncrementSMAPeriod.UseVisualStyleBackColor = true;
            this.IncrementSMAPeriod.Click += new System.EventHandler(this.IncrementSMAPeriod_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(939, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(939, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(939, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 22;
            this.label8.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(939, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = ":";
            // 
            // DecrementSMAPeriod
            // 
            this.DecrementSMAPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DecrementSMAPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrementSMAPeriod.ForeColor = System.Drawing.Color.Gray;
            this.DecrementSMAPeriod.Location = new System.Drawing.Point(852, 266);
            this.DecrementSMAPeriod.Name = "DecrementSMAPeriod";
            this.DecrementSMAPeriod.Size = new System.Drawing.Size(21, 21);
            this.DecrementSMAPeriod.TabIndex = 24;
            this.DecrementSMAPeriod.Text = "-";
            this.DecrementSMAPeriod.UseVisualStyleBackColor = true;
            this.DecrementSMAPeriod.Click += new System.EventHandler(this.DecrementSMAPeriod_Click);
            // 
            // IncrementWMAPeriod
            // 
            this.IncrementWMAPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IncrementWMAPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrementWMAPeriod.ForeColor = System.Drawing.Color.Gray;
            this.IncrementWMAPeriod.Location = new System.Drawing.Point(978, 291);
            this.IncrementWMAPeriod.Name = "IncrementWMAPeriod";
            this.IncrementWMAPeriod.Size = new System.Drawing.Size(21, 21);
            this.IncrementWMAPeriod.TabIndex = 25;
            this.IncrementWMAPeriod.Text = "+";
            this.IncrementWMAPeriod.UseVisualStyleBackColor = true;
            this.IncrementWMAPeriod.Click += new System.EventHandler(this.IncrementWMAPeriod_Click);
            // 
            // DecrementWMAPeriod
            // 
            this.DecrementWMAPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DecrementWMAPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrementWMAPeriod.ForeColor = System.Drawing.Color.Gray;
            this.DecrementWMAPeriod.Location = new System.Drawing.Point(852, 291);
            this.DecrementWMAPeriod.Name = "DecrementWMAPeriod";
            this.DecrementWMAPeriod.Size = new System.Drawing.Size(21, 21);
            this.DecrementWMAPeriod.TabIndex = 26;
            this.DecrementWMAPeriod.Text = "-";
            this.DecrementWMAPeriod.UseVisualStyleBackColor = true;
            this.DecrementWMAPeriod.Click += new System.EventHandler(this.DecrementWMAPeriod_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(882, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = "STOCKS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(853, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "MOVING AVERAGES";
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 431);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1037, 296);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "x";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "y";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "sd(x)";
            this.columnHeader3.Width = 87;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "sd(y)";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "alpha";
            this.columnHeader5.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "beta";
            this.columnHeader6.Width = 88;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "r_value";
            this.columnHeader7.Width = 92;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "r^2";
            this.columnHeader8.Width = 74;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Δ average";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Δ min";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Δ max";
            this.columnHeader11.Width = 82;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "sd(Δ)";
            this.columnHeader12.Width = 106;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(719, 413);
            this.zedGraphControl.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1061, 739);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DecrementWMAPeriod);
            this.Controls.Add(this.IncrementWMAPeriod);
            this.Controls.Add(this.DecrementSMAPeriod);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IncrementSMAPeriod);
            this.Controls.Add(this.ReloadApp);
            this.Controls.Add(this.r_valueLowLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.r_valueHighLabel);
            this.Controls.Add(this.pairsCreatedLabel);
            this.Controls.Add(this.stocksCountLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WMAperiodNUD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SMAperiodNUD);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.zedGraphControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PairTradingView     [dv_lebedev]";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SMAperiodNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMAperiodNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyZedgraphControl zedGraphControl;
        private ListViewNF listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.NumericUpDown SMAperiodNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown WMAperiodNUD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label stocksCountLabel;
        private System.Windows.Forms.Label pairsCreatedLabel;
        private System.Windows.Forms.Label r_valueHighLabel;
        private System.Windows.Forms.Label r_valueLowLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ReloadApp;
        private System.Windows.Forms.Button IncrementSMAPeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button DecrementSMAPeriod;
        private System.Windows.Forms.Button IncrementWMAPeriod;
        private System.Windows.Forms.Button DecrementWMAPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}