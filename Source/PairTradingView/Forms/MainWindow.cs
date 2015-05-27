using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmetricGears;
using PairTradingView.Synthetics;
using PairTradingView.Data.SqlData;
using PairTradingView.Data.CSVData;
using PairTradingView.Data.Entities;
using PairTradingView.RiskManagement;
using System.Collections.Generic;

namespace PairTradingView.Forms
{
    public partial class MainWindow : Form
    {
        public Configuration Cfg { get; private set; }

        public DataTasks Tasks { get; private set; }

        public CSVFormat CsvFormat { get; private set; }
        public DeltaType DeltaType { get; set; }

        public PairsContainer PairsContainer { get; set; }

        private FinancialPair SelectedPair { get; set; }

        private RiskCalculation RiskCalculation { get; set; }

        public MainWindow()
        {
            CsvFormat = new CSVFormat() { Separator = ',' };

            Tasks = new DataTasks();
            Tasks.DataSaver.Elapsed += DataSaver_Elapsed;
            Tasks.DataUpdater.Elapsed += DataUpdater_Elapsed;

            try
            {
                Cfg = Configuration.Deserialize("ptview.cfg");
            }
            catch
            {
                Cfg = Configuration.GetDefaultSetting();
            }

            InitializeComponent();

            new AppStartWindow(this).ShowDialog();


            listView1.Click += listView1_Click;
            
            SMAperiodNUD.Maximum = decimal.MaxValue;
            WMAperiodNUD.Maximum = decimal.MaxValue;

            tradeBalanceNUD.Maximum = decimal.MaxValue;
            tradeBalanceNUD.DecimalPlaces = 2;
            tradeBalanceNUD.Value = 1000000.00M;

            tradeRiskNUD.DecimalPlaces = 2;

            this.FormClosing += MainWindow_FormClosing;

            MessageBox.Show(PairsContainer.Items.Count.ToString());
        }

        void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                var xSecurity = item.SubItems[0].Text;
                var ySecurity = item.SubItems[1].Text;

                zedGraphControl.GraphPane.Title.Text = ySecurity + " / " + xSecurity;

                SelectedPair = PairsContainer.Items
                     .First(i => i.Name.X == xSecurity && i.Name.Y == ySecurity);

                var deltas = SelectedPair.DeltaValues.ToArray();

                zedGraphControl.SetDeltas(deltas);
                zedGraphControl.SetDeltaCurrent(deltas.Last());

                SMAperiodNUD_ValueChanged(null, null);
                WMAperiodNUD_ValueChanged(null, null);


                if (SelectedPair.RiskParameters != null)
                {
                    pairName.Text = SelectedPair.Name.ToString();
                    xName.Text = SelectedPair.Name.X;
                    yName.Text = SelectedPair.Name.Y;
                    pairsTradeBalance.Text = SelectedPair.RiskParameters.TradeBalance.ToString();
                    yTradeVolume.Text = SelectedPair.RiskParameters.YTradeBalance.ToString();
                    xTradeVolume.Text =  SelectedPair.RiskParameters.XTradeBalanace.ToString();
                    riskLimit.Text = (SelectedPair.RiskParameters.TradeBalance * ((double)tradeRiskNUD.Value) / 100).ToString();
                }
                else
                {

                    pairName.Text = "-";
                    xName.Text = "-";
                    yName.Text = "-";
                    pairsTradeBalance.Text = "0";
                    yTradeVolume.Text = "0";
                    xTradeVolume.Text = "0";
                    riskLimit.Text = "0";
                }

            }
            catch
            {

            }
        }

        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration.Serialize("ptview.cfg", Cfg);
        }

        void DataUpdater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    if (SelectedPair != null)
                    {
                        using (var db = new StocksContext(Cfg.SqlConnectionString))
                        {

                            var xStock = db.Stocks.Find(SelectedPair.Name.X);
                            var yStock = db.Stocks.Find(SelectedPair.Name.Y);


                            if (xStock != null && yStock != null)
                            {
                                var delta = SelectedPair.GetCurrentDelta(xStock.Price, yStock.Price);

                                zedGraphControl.SetDeltaCurrent(delta);
                            }
                        }
                    }

                }));
            }
            catch
            {

            }
        }

        void DataSaver_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            if (dt.TimeOfDay >= Cfg.StartTime && dt.TimeOfDay <= Cfg.StopTime)
            {
                try
                {
                    using (var db = new StocksContext(Cfg.SqlConnectionString))
                    {

                        foreach (var stock in db.Stocks)
                        {
                            stock.History.Add(new StockValue
                            {
                                DateTime = dt,
                                Price = stock.Price,
                                Volume = stock.Volume
                            });
                        }

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdateListView();

            r_valueHighLabel.Text = PairsContainer.Items.Where
                (i => i.Regression.Correlation >= 0.7 && i.Regression.Correlation <= 1)
                .Count()
                .ToString();

            r_valueLowLabel.Text = PairsContainer.Items.Where
                (i => i.Regression.Correlation <= -0.7 && i.Regression.Correlation >= -1)
                .Count()
                .ToString();

            stocksCountLabel.Text = PairsContainer.StocksCount.ToString();
            pairsCreatedLabel.Text = PairsContainer.Items.Count.ToString();

        }

        private void UpdateListView()
        {
            foreach (var item in PairsContainer.Items)
            {
                int index = listView1.Items.Add(item.Name.ToString(), item.Name.X, 0).Index;

                listView1.Items[index].SubItems.Add(item.Name.Y);
                listView1.Items[index].SubItems.Add(Math.Round(item.XStdDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.YStdDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Alpha, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Beta, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Correlation, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Determination, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Average(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Min(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Max(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaStdDev, 6).ToString());

                if (item.Regression.Correlation >= 0.7 && item.Regression.Correlation <= 1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(38, 153, 38);
                }

                if (item.Regression.Correlation <= -0.7 && item.Regression.Correlation >= -1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(191, 48, 48);
                }
            }
        }

        private void SMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedPair == null)
            {
                MessageBox.Show("Pair is not selected.");
            }
            else if (SMAperiodNUD.Value > SelectedPair.DeltaValues.Count())
            {
                MessageBox.Show("maximum value = " + SelectedPair.DeltaValues.Count());
            }
            else
            {
                zedGraphControl.SetSMA(MovingAverages.SMA(SelectedPair.DeltaValues.ToArray(), (int)SMAperiodNUD.Value), (int)SMAperiodNUD.Value);
            }
        }

        private void WMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedPair == null)
            {
                MessageBox.Show("Pair is not selected.");
            }
            else if (WMAperiodNUD.Value > SelectedPair.DeltaValues.Count())
            {
                MessageBox.Show("maximum value = " + SelectedPair.DeltaValues.Count());
            }
            else
            {
                zedGraphControl.SetWMA(MovingAverages.WMA(SelectedPair.DeltaValues.ToArray(), (int)WMAperiodNUD.Value), (int)WMAperiodNUD.Value);
            }
        }



        private void CalculateRisk_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {

                foreach (var item in PairsContainer.Items)
                {
                    item.RiskParameters = null;
                }


                var pairs = new List<FinancialPair>();

                foreach (var item in listView1.CheckedItems)
                {
                    var name = ((ListViewItem)item).Name;

                    var result = PairsContainer.Items.Find(i => i.Name.ToString() == name);

                    if (result != null)
                    {
                        pairs.Add(result);
                    }
                }

                RiskCalculation = new RiskCalculation(pairs);
                RiskCalculation.TradeBalance = (double)tradeBalanceNUD.Value;


                try
                {
                    RiskCalculation.Calculate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Risk calculation failed. " + ex.Message);
                }

                listView1_Click(this, null);

            }

        }

    }
}
