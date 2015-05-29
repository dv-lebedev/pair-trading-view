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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yName = new System.Windows.Forms.Label();
            this.xName = new System.Windows.Forms.Label();
            this.pairName = new System.Windows.Forms.Label();
            this.riskLimit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.xTradeVolume = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tradeRiskNUD = new System.Windows.Forms.NumericUpDown();
            this.CalculateRisk = new System.Windows.Forms.Button();
            this.pairsTradeBalance = new System.Windows.Forms.Label();
            this.yTradeVolume = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tradeBalanceNUD = new System.Windows.Forms.NumericUpDown();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tradeRiskNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeBalanceNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // SMAperiodNUD
            // 
            this.SMAperiodNUD.BackColor = System.Drawing.Color.White;
            this.SMAperiodNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SMAperiodNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SMAperiodNUD.ForeColor = System.Drawing.Color.Black;
            this.SMAperiodNUD.Location = new System.Drawing.Point(118, 333);
            this.SMAperiodNUD.Name = "SMAperiodNUD";
            this.SMAperiodNUD.Size = new System.Drawing.Size(119, 20);
            this.SMAperiodNUD.TabIndex = 2;
            this.SMAperiodNUD.ValueChanged += new System.EventHandler(this.SMAperiodNUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(48, 335);
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
            this.label2.Location = new System.Drawing.Point(48, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "WMA";
            // 
            // WMAperiodNUD
            // 
            this.WMAperiodNUD.BackColor = System.Drawing.Color.White;
            this.WMAperiodNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WMAperiodNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WMAperiodNUD.ForeColor = System.Drawing.Color.Black;
            this.WMAperiodNUD.Location = new System.Drawing.Point(118, 360);
            this.WMAperiodNUD.Name = "WMAperiodNUD";
            this.WMAperiodNUD.Size = new System.Drawing.Size(119, 20);
            this.WMAperiodNUD.TabIndex = 4;
            this.WMAperiodNUD.ValueChanged += new System.EventHandler(this.WMAperiodNUD_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(815, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 355);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(879, 161);
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
            this.label4.Location = new System.Drawing.Point(879, 188);
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
            this.label5.Location = new System.Drawing.Point(879, 215);
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
            this.stocksCountLabel.Location = new System.Drawing.Point(1055, 161);
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
            this.pairsCreatedLabel.Location = new System.Drawing.Point(1055, 188);
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
            this.r_valueHighLabel.Location = new System.Drawing.Point(1055, 215);
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
            this.r_valueLowLabel.Location = new System.Drawing.Point(1055, 241);
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
            this.label10.Location = new System.Drawing.Point(880, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "R_Value <= - 0.7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(1015, 161);
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
            this.label7.Location = new System.Drawing.Point(1015, 241);
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
            this.label8.Location = new System.Drawing.Point(1015, 215);
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
            this.label9.Location = new System.Drawing.Point(1015, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(949, 20);
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
            this.label12.Location = new System.Drawing.Point(95, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "MOVING AVERAGES";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.yName);
            this.panel2.Controls.Add(this.xName);
            this.panel2.Controls.Add(this.pairName);
            this.panel2.Controls.Add(this.riskLimit);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.xTradeVolume);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.tradeRiskNUD);
            this.panel2.Controls.Add(this.CalculateRisk);
            this.panel2.Controls.Add(this.pairsTradeBalance);
            this.panel2.Controls.Add(this.yTradeVolume);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.tradeBalanceNUD);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.SMAperiodNUD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.WMAperiodNUD);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(822, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 434);
            this.panel2.TabIndex = 29;
            // 
            // yName
            // 
            this.yName.AutoSize = true;
            this.yName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yName.ForeColor = System.Drawing.Color.Gray;
            this.yName.Location = new System.Drawing.Point(26, 133);
            this.yName.Name = "yName";
            this.yName.Size = new System.Drawing.Size(14, 14);
            this.yName.TabIndex = 44;
            this.yName.Text = "-";
            // 
            // xName
            // 
            this.xName.AutoSize = true;
            this.xName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xName.ForeColor = System.Drawing.Color.Gray;
            this.xName.Location = new System.Drawing.Point(26, 156);
            this.xName.Name = "xName";
            this.xName.Size = new System.Drawing.Size(14, 14);
            this.xName.TabIndex = 43;
            this.xName.Text = "-";
            // 
            // pairName
            // 
            this.pairName.AutoSize = true;
            this.pairName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairName.ForeColor = System.Drawing.Color.Gray;
            this.pairName.Location = new System.Drawing.Point(26, 98);
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
            this.riskLimit.Location = new System.Drawing.Point(141, 196);
            this.riskLimit.Name = "riskLimit";
            this.riskLimit.Size = new System.Drawing.Size(14, 14);
            this.riskLimit.TabIndex = 41;
            this.riskLimit.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(26, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 14);
            this.label14.TabIndex = 40;
            this.label14.Text = "Risk limit :";
            // 
            // xTradeVolume
            // 
            this.xTradeVolume.AutoSize = true;
            this.xTradeVolume.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTradeVolume.ForeColor = System.Drawing.Color.Gold;
            this.xTradeVolume.Location = new System.Drawing.Point(141, 156);
            this.xTradeVolume.Name = "xTradeVolume";
            this.xTradeVolume.Size = new System.Drawing.Size(14, 14);
            this.xTradeVolume.TabIndex = 39;
            this.xTradeVolume.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(206, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 14);
            this.label18.TabIndex = 38;
            this.label18.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(26, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 14);
            this.label17.TabIndex = 37;
            this.label17.Text = "Trade risk :";
            // 
            // tradeRiskNUD
            // 
            this.tradeRiskNUD.BackColor = System.Drawing.Color.White;
            this.tradeRiskNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tradeRiskNUD.ForeColor = System.Drawing.Color.Black;
            this.tradeRiskNUD.Location = new System.Drawing.Point(144, 48);
            this.tradeRiskNUD.Name = "tradeRiskNUD";
            this.tradeRiskNUD.Size = new System.Drawing.Size(56, 20);
            this.tradeRiskNUD.TabIndex = 36;
            // 
            // CalculateRisk
            // 
            this.CalculateRisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalculateRisk.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculateRisk.ForeColor = System.Drawing.Color.Gray;
            this.CalculateRisk.Location = new System.Drawing.Point(144, 223);
            this.CalculateRisk.Name = "CalculateRisk";
            this.CalculateRisk.Size = new System.Drawing.Size(120, 23);
            this.CalculateRisk.TabIndex = 35;
            this.CalculateRisk.Text = "Get Risk info";
            this.CalculateRisk.UseVisualStyleBackColor = true;
            this.CalculateRisk.Click += new System.EventHandler(this.CalculateRisk_Click);
            // 
            // pairsTradeBalance
            // 
            this.pairsTradeBalance.AutoSize = true;
            this.pairsTradeBalance.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairsTradeBalance.ForeColor = System.Drawing.Color.LawnGreen;
            this.pairsTradeBalance.Location = new System.Drawing.Point(141, 98);
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
            this.yTradeVolume.Location = new System.Drawing.Point(141, 133);
            this.yTradeVolume.Name = "yTradeVolume";
            this.yTradeVolume.Size = new System.Drawing.Size(14, 14);
            this.yTradeVolume.TabIndex = 33;
            this.yTradeVolume.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(26, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 14);
            this.label13.TabIndex = 31;
            this.label13.Text = "Trade balance :";
            // 
            // tradeBalanceNUD
            // 
            this.tradeBalanceNUD.BackColor = System.Drawing.Color.White;
            this.tradeBalanceNUD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tradeBalanceNUD.ForeColor = System.Drawing.Color.Black;
            this.tradeBalanceNUD.Location = new System.Drawing.Point(144, 22);
            this.tradeBalanceNUD.Name = "tradeBalanceNUD";
            this.tradeBalanceNUD.Size = new System.Drawing.Size(120, 20);
            this.tradeBalanceNUD.TabIndex = 30;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
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
            this.listView1.Location = new System.Drawing.Point(12, 477);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1089, 313);
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
            this.columnHeader12.Width = 163;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.IsEnableVPan = false;
            this.zedGraphControl.IsEnableVZoom = false;
            this.zedGraphControl.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(797, 459);
            this.zedGraphControl.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1112, 802);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.r_valueLowLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.r_valueHighLabel);
            this.Controls.Add(this.pairsCreatedLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.stocksCountLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PairTradingView     [dv_lebedev]";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SMAperiodNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMAperiodNUD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tradeRiskNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeBalanceNUD)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown tradeBalanceNUD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label yTradeVolume;
        private System.Windows.Forms.Label pairsTradeBalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown tradeRiskNUD;
        private System.Windows.Forms.Button CalculateRisk;
        private System.Windows.Forms.Label xTradeVolume;
        private System.Windows.Forms.Label riskLimit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label yName;
        private System.Windows.Forms.Label xName;
        private System.Windows.Forms.Label pairName;
    }
}