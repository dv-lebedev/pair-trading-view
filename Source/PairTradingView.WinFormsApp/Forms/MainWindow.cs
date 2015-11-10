using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.Data.DataProviders;
using PairTradingView.Data.DataProviders.ODBC;
using PairTradingView.Logic.Session;
using PairTradingView.Logic.Statistics;
using PairTradingView.Logic.Synthetics;
using PairTradingView.WinFormsApp.Forms;

namespace PairTradingView.Forms
{
    public partial class MainWindow : Form
    {
        public Configuration SessionConfig { get; private set; }

        public ISession Session { get; private set; }

        private FinancialPair SelectedPair { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                SessionConfig = Configuration.Deserialize("session.cfg");
            }
            catch (Exception ex)
            {
                SessionConfig = Configuration.GetDefaultSetting();

                Debug.WriteLine(ex.Message);

                MessageBox.Show("Initialize by default settings.");
            }
            finally
            {

                SessionConfig.SetHistoryDataProvider(new CsvStorage());
                SessionConfig.SetMarketDataProvider(new OdbcMarketDataProvider(SessionConfig.ConnectionString));


                Session = new BaseSession(SessionConfig);

                Session.CurrentDelta += Session_CurrentDelta;

                listView1.Click += listView1_Click;

                SMAperiodNUD.Maximum = decimal.MaxValue;
                WMAperiodNUD.Maximum = decimal.MaxValue;

                tradeBalanceNUD.Maximum = decimal.MaxValue;
                tradeBalanceNUD.DecimalPlaces = 2;
                tradeBalanceNUD.Value = 100000.00M;

                tradeRiskNUD.DecimalPlaces = 2;
                tradeRiskNUD.Value = 1.7M;

                this.FormClosing += MainWindow_FormClosing;
            }
        }

        void Session_CurrentDelta(object sender, CurrentDeltaValueEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    if (SelectedPair != null && SelectedPair.Name == e.Name)
                    {
                        zedGraphControl.SetDeltaCurrent(e.Value);
                        lastDataSavingTime.Text = "Last data saving time : " + Session.LastDataStore.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }));
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                var xSecurity = item.SubItems[0].Text;
                var ySecurity = item.SubItems[1].Text;

                zedGraphControl.GraphPane.Title.Text = ySecurity + " / " + xSecurity;

                SelectedPair = Session.PairsContainer.Items
                     .First(i => i.Name.X == xSecurity && i.Name.Y == ySecurity);

                var deltas = SelectedPair.DeltaValues.ToArray();

                zedGraphControl.SetDeltas(deltas);
                zedGraphControl.SetDeltaCurrent(deltas.Last());

                SMAperiodNUD_ValueChanged(null, null);
                WMAperiodNUD_ValueChanged(null, null);


                if (SelectedPair.RiskParameters != null)
                {
                    pairName.Text = SelectedPair.Name.ToString() + " => ";
                    xName.Text = SelectedPair.Name.X + " => ";
                    yName.Text = SelectedPair.Name.Y + " => ";

                    pairsTradeBalance.Text = Math.Round(SelectedPair.RiskParameters.TradeBalance, 4).ToString();
                    yTradeVolume.Text = Math.Round(SelectedPair.RiskParameters.YTradeBalance, 4).ToString();
                    xTradeVolume.Text = Math.Round(SelectedPair.RiskParameters.XTradeBalanace, 4).ToString();
                    riskLimit.Text = Math.Round((SelectedPair.RiskParameters.TradeBalance * ((double)tradeRiskNUD.Value) / 100), 4).ToString();
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
            catch(Exception ex)
            {
                Console.WriteLine("listView1_Click(s,e) " + ex.Message);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Session.IsSystemStarted)
                    Session.Stop();

                Configuration.Serialize("session.cfg", SessionConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                if (listView1.CheckedItems.Count > 0)
                {
                    var codes = listView1.CheckedItems.OfType<ListViewItem>().Select(i => i.Name).ToArray();

                    Session.CalculateRisk(codes, (double)tradeBalanceNUD.Value);

                    listView1_Click(this, null);
                }
                else
                {
                    MessageBox.Show("Pairs are not selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateListView()
        {
            foreach (var item in Session.PairsContainer.Items)
            {
                int index = listView1.Items.Add(item.Name.ToString(), item.Name.X, 0).Index;

                listView1.Items[index].SubItems.Add(item.Name.Y);
                listView1.Items[index].SubItems.Add(Math.Round(item.XStdDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.YStdDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Alpha, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Beta, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.RValue, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.RSquared, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Average(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Min(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Max(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaStdDev, 6).ToString());

                if (item.Regression.RValue >= 0.7 && item.Regression.RValue <= 1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(38, 153, 38);
                }

                if (item.Regression.RValue <= -0.7 && item.Regression.RValue >= -1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(191, 48, 48);
                }
            }
        }


        #region START_MENU ITEMS


        private void startMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Start();

                UpdateListView();

                if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                    listView1_Click(this, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopMenuItem_Click(this, null);
            startMenuItem_Click(this, null);
        }

        private void stopMenuItem_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            listView1.Update();

            Session.Stop();
        }


        #endregion


        #region SERVICE_MENU ITEMS


        private void mySqlConnectionMenuItem_Click(object sender, EventArgs e)
        {
            var window = new SettingsWindow(this);
            window.ShowDialog();
        }

        private void csvToDbMenuItem_Click(object sender, EventArgs e)
        {
            var window = new CsvToStorageWindow(this);
            window.ShowDialog();
        }

        private void quoteDownloaderMenuItem_Click(object sender, EventArgs e)
        {
            var window = new Downloader();
            window.ShowDialog();
        }


        #endregion

    }
}
