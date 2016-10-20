using PairTradingView.Controls;

namespace PairTradingView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yName = new System.Windows.Forms.Label();
            this.xName = new System.Windows.Forms.Label();
            this.pairName = new System.Windows.Forms.Label();
            this.riskLimit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.xTradeVolume = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.CalculateRisk = new System.Windows.Forms.Button();
            this.pairsTradeBalance = new System.Windows.Forms.Label();
            this.yTradeVolume = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttomPanel = new System.Windows.Forms.Panel();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.chart = new PairTradingView.Controls.ZedGraphChart();
            this.listView = new PairTradingView.Controls.ListViewNF();
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
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WMAPeriod = new PairTradingView.Controls.NumericBox();
            this.SMAPeriod = new PairTradingView.Controls.NumericBox();
            this.risk = new PairTradingView.Controls.NumericBox();
            this.balance = new PairTradingView.Controls.NumericBox();
            this.panel2.SuspendLayout();
            this.buttomPanel.SuspendLayout();
            this.chartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(42, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "SMA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(42, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "WMA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(123, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = "INFO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(89, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "MOVING AVERAGES";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WMAPeriod);
            this.panel2.Controls.Add(this.SMAPeriod);
            this.panel2.Controls.Add(this.risk);
            this.panel2.Controls.Add(this.balance);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.yName);
            this.panel2.Controls.Add(this.xName);
            this.panel2.Controls.Add(this.pairName);
            this.panel2.Controls.Add(this.riskLimit);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.xTradeVolume);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.CalculateRisk);
            this.panel2.Controls.Add(this.pairsTradeBalance);
            this.panel2.Controls.Add(this.yTradeVolume);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 491);
            this.panel2.TabIndex = 29;
            // 
            // yName
            // 
            this.yName.AutoSize = true;
            this.yName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yName.ForeColor = System.Drawing.Color.DarkGray;
            this.yName.Location = new System.Drawing.Point(20, 145);
            this.yName.Name = "yName";
            this.yName.Size = new System.Drawing.Size(14, 14);
            this.yName.TabIndex = 44;
            this.yName.Text = "-";
            // 
            // xName
            // 
            this.xName.AutoSize = true;
            this.xName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xName.ForeColor = System.Drawing.Color.DarkGray;
            this.xName.Location = new System.Drawing.Point(20, 168);
            this.xName.Name = "xName";
            this.xName.Size = new System.Drawing.Size(14, 14);
            this.xName.TabIndex = 43;
            this.xName.Text = "-";
            // 
            // pairName
            // 
            this.pairName.AutoSize = true;
            this.pairName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairName.ForeColor = System.Drawing.Color.DarkGray;
            this.pairName.Location = new System.Drawing.Point(20, 110);
            this.pairName.Name = "pairName";
            this.pairName.Size = new System.Drawing.Size(14, 14);
            this.pairName.TabIndex = 42;
            this.pairName.Text = "-";
            // 
            // riskLimit
            // 
            this.riskLimit.AutoSize = true;
            this.riskLimit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riskLimit.ForeColor = System.Drawing.Color.Red;
            this.riskLimit.Location = new System.Drawing.Point(123, 208);
            this.riskLimit.Name = "riskLimit";
            this.riskLimit.Size = new System.Drawing.Size(14, 14);
            this.riskLimit.TabIndex = 41;
            this.riskLimit.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(20, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 14);
            this.label14.TabIndex = 40;
            this.label14.Text = "Risk-limit $ :";
            // 
            // xTradeVolume
            // 
            this.xTradeVolume.AutoSize = true;
            this.xTradeVolume.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTradeVolume.ForeColor = System.Drawing.Color.Gold;
            this.xTradeVolume.Location = new System.Drawing.Point(123, 168);
            this.xTradeVolume.Name = "xTradeVolume";
            this.xTradeVolume.Size = new System.Drawing.Size(14, 14);
            this.xTradeVolume.TabIndex = 39;
            this.xTradeVolume.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkGray;
            this.label17.Location = new System.Drawing.Point(20, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 37;
            this.label17.Text = "Risk % :";
            // 
            // CalculateRisk
            // 
            this.CalculateRisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalculateRisk.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculateRisk.ForeColor = System.Drawing.Color.DarkGray;
            this.CalculateRisk.Location = new System.Drawing.Point(126, 240);
            this.CalculateRisk.Name = "CalculateRisk";
            this.CalculateRisk.Size = new System.Drawing.Size(151, 23);
            this.CalculateRisk.TabIndex = 35;
            this.CalculateRisk.Text = "Get Risk Info";
            this.CalculateRisk.UseVisualStyleBackColor = true;
            this.CalculateRisk.Click += new System.EventHandler(this.CalculateRisk_Click);
            // 
            // pairsTradeBalance
            // 
            this.pairsTradeBalance.AutoSize = true;
            this.pairsTradeBalance.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairsTradeBalance.ForeColor = System.Drawing.Color.LawnGreen;
            this.pairsTradeBalance.Location = new System.Drawing.Point(123, 110);
            this.pairsTradeBalance.Name = "pairsTradeBalance";
            this.pairsTradeBalance.Size = new System.Drawing.Size(14, 14);
            this.pairsTradeBalance.TabIndex = 34;
            this.pairsTradeBalance.Text = "0";
            // 
            // yTradeVolume
            // 
            this.yTradeVolume.AutoSize = true;
            this.yTradeVolume.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yTradeVolume.ForeColor = System.Drawing.Color.Gold;
            this.yTradeVolume.Location = new System.Drawing.Point(123, 145);
            this.yTradeVolume.Name = "yTradeVolume";
            this.yTradeVolume.Size = new System.Drawing.Size(14, 14);
            this.yTradeVolume.TabIndex = 33;
            this.yTradeVolume.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(20, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 14);
            this.label13.TabIndex = 31;
            this.label13.Text = "Balance $ :";
            // 
            // buttomPanel
            // 
            this.buttomPanel.BackColor = System.Drawing.Color.Black;
            this.buttomPanel.Controls.Add(this.listView);
            this.buttomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttomPanel.Location = new System.Drawing.Point(0, 523);
            this.buttomPanel.Name = "buttomPanel";
            this.buttomPanel.Size = new System.Drawing.Size(1210, 289);
            this.buttomPanel.TabIndex = 30;
            // 
            // chartPanel
            // 
            this.chartPanel.BackColor = System.Drawing.Color.Lime;
            this.chartPanel.Controls.Add(this.chart);
            this.chartPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.chartPanel.Location = new System.Drawing.Point(331, 0);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(879, 523);
            this.chartPanel.TabIndex = 31;
            // 
            // zedGraphControl
            // 
            this.chart.Dock = System.Windows.Forms.DockStyle.Right;
            this.chart.IsEnableVPan = false;
            this.chart.IsEnableVZoom = false;
            this.chart.Location = new System.Drawing.Point(2, 0);
            this.chart.Name = "zedGraphControl";
            this.chart.ScrollGrace = 0D;
            this.chart.ScrollMaxX = 0D;
            this.chart.ScrollMaxY = 0D;
            this.chart.ScrollMaxY2 = 0D;
            this.chart.ScrollMinX = 0D;
            this.chart.ScrollMinY = 0D;
            this.chart.ScrollMinY2 = 0D;
            this.chart.Size = new System.Drawing.Size(877, 523);
            this.chart.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.BackColor = System.Drawing.Color.Black;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.ForeColor = System.Drawing.Color.White;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView1";
            this.listView.OwnerDraw = true;
            this.listView.Size = new System.Drawing.Size(1210, 289);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "x";
            this.columnHeader1.Width = 67;
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
            this.columnHeader12.Width = 86;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Δ -3Q";
            this.columnHeader13.Width = 97;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Δ +3Q";
            this.columnHeader14.Width = 106;
            // 
            // WMAPeriod
            // 
            this.WMAPeriod.BackColor = System.Drawing.Color.Black;
            this.WMAPeriod.ForeColor = System.Drawing.Color.White;
            this.WMAPeriod.Location = new System.Drawing.Point(126, 392);
            this.WMAPeriod.MinimumSize = new System.Drawing.Size(151, 22);
            this.WMAPeriod.Name = "WMAPeriod";
            this.WMAPeriod.Size = new System.Drawing.Size(151, 22);
            this.WMAPeriod.TabIndex = 48;
            this.WMAPeriod.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // SMAPeriod
            // 
            this.SMAPeriod.BackColor = System.Drawing.Color.Black;
            this.SMAPeriod.ForeColor = System.Drawing.Color.White;
            this.SMAPeriod.Location = new System.Drawing.Point(126, 366);
            this.SMAPeriod.MinimumSize = new System.Drawing.Size(151, 22);
            this.SMAPeriod.Name = "SMAPeriod";
            this.SMAPeriod.Size = new System.Drawing.Size(151, 22);
            this.SMAPeriod.TabIndex = 47;
            this.SMAPeriod.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // risk
            // 
            this.risk.BackColor = System.Drawing.Color.Black;
            this.risk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.risk.ForeColor = System.Drawing.Color.White;
            this.risk.Location = new System.Drawing.Point(126, 60);
            this.risk.MinimumSize = new System.Drawing.Size(151, 22);
            this.risk.Name = "risk";
            this.risk.Size = new System.Drawing.Size(151, 22);
            this.risk.TabIndex = 46;
            this.risk.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // balance
            // 
            this.balance.BackColor = System.Drawing.Color.Black;
            this.balance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balance.ForeColor = System.Drawing.Color.White;
            this.balance.Location = new System.Drawing.Point(126, 32);
            this.balance.MinimumSize = new System.Drawing.Size(151, 22);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(151, 22);
            this.balance.TabIndex = 45;
            this.balance.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            131072});
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1210, 812);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.buttomPanel);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pair Trading View";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.buttomPanel.ResumeLayout(false);
            this.chartPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraphChart chart;
        private ListViewNF listView;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label yTradeVolume;
        private System.Windows.Forms.Label pairsTradeBalance;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button CalculateRisk;
        private System.Windows.Forms.Label xTradeVolume;
        private System.Windows.Forms.Label riskLimit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label yName;
        private System.Windows.Forms.Label xName;
        private System.Windows.Forms.Label pairName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel buttomPanel;
        private System.Windows.Forms.Panel chartPanel;
        private NumericBox risk;
        private NumericBox balance;
        private NumericBox WMAPeriod;
        private NumericBox SMAPeriod;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
    }
}