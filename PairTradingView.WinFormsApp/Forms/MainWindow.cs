using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.Statistics;
using PairTradingView.Synthetics;
using PairTradingView.WinFormsApp.Forms;

namespace PairTradingView.Forms
{
    public partial class MainWindow : Form
    {
        private Synthetic SyntheticSelected { get; set; }

        public List<Synthetic> Synthetics { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            listView1.Click += listView1_Click;

            SMAperiodNUD.Maximum = decimal.MaxValue;
            WMAperiodNUD.Maximum = decimal.MaxValue;

            tradeBalanceNUD.Maximum = decimal.MaxValue;
            tradeBalanceNUD.DecimalPlaces = 2;
            tradeBalanceNUD.Value = 100000.00M;

            tradeRiskNUD.DecimalPlaces = 2;
            tradeRiskNUD.Value = 0.5M;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                var xSymbol = item.SubItems[0].Text;
                var ySymbol = item.SubItems[1].Text;

                zedGraphControl.GraphPane.Title.Text = ySymbol + " | " + xSymbol;

                SyntheticSelected = Synthetics
                     .First(i => i.Name.X == xSymbol && i.Name.Y == ySymbol);

                var deltas = SyntheticSelected.DeltaValues.ToArray();

                zedGraphControl.SetDeltas(deltas);
                zedGraphControl.SetDeltaCurrent(deltas.Last());

                if (SyntheticSelected.RiskParameters != null)
                {
                    pairName.Text = SyntheticSelected.Name.ToString() + " => ";
                    xName.Text = SyntheticSelected.Name.X + " => ";
                    yName.Text = SyntheticSelected.Name.Y + " => ";

                    pairsTradeBalance.Text = Math.Round(SyntheticSelected.RiskParameters.TradeBalance, 4).ToString();
                    yTradeVolume.Text = Math.Round(SyntheticSelected.RiskParameters.YTradeBalance, 4).ToString();
                    xTradeVolume.Text = Math.Round(SyntheticSelected.RiskParameters.XTradeBalanace, 4).ToString();
                    riskLimit.Text = Math.Round((SyntheticSelected.RiskParameters.TradeBalance * (tradeRiskNUD.Value) / 100.0M), 4).ToString();
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

                SMAperiodNUD_ValueChanged(null, null);
                WMAperiodNUD_ValueChanged(null, null);

            }
            catch (Exception ex)
            {
                Console.WriteLine("listView1_Click(s,e) " + ex.Message);
            }
        }

        private void SMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            if (SMAperiodNUD.Value > 0)
            {
                if (SyntheticSelected == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (SMAperiodNUD.Value > SyntheticSelected.DeltaValues.Count())
                {
                    MessageBox.Show("maximum value = " + SyntheticSelected.DeltaValues.Count());
                }
                else
                {
                    zedGraphControl.SetSMA(
                        MovingAverages.SMA(SyntheticSelected.DeltaValues.ToArray(), (int)SMAperiodNUD.Value),
                        (int)SMAperiodNUD.Value);
                }
            }
        }

        private void WMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            if (WMAperiodNUD.Value > 0)
            {
                if (SyntheticSelected == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (WMAperiodNUD.Value > SyntheticSelected.DeltaValues.Count())
                {
                    MessageBox.Show("maximum value = " + SyntheticSelected.DeltaValues.Count());
                }
                else
                {
                    zedGraphControl.SetWMA(
                        MovingAverages.WMA(SyntheticSelected.DeltaValues.ToArray(), (int)WMAperiodNUD.Value),
                        (int)WMAperiodNUD.Value);
                }
            }
        }

        private void CalculateRisk_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.CheckedItems.Count > 0)
                {
                    Synthetics.ForEach(i => i.RiskParameters = null);

                    var checkedSynths = new List<Synthetic>();

                    foreach (var code in listView1.CheckedItems.OfType<ListViewItem>().Select(i => i.Name).ToArray())
                    {
                        checkedSynths.Add(Synthetics.First(i => i.Name.ToString() == code));
                    }

                    var rc = new RiskManagement.RiskCalculation(checkedSynths, tradeBalanceNUD.Value);
                    rc.Calculate();

                    listView1_Click(this, null);
                }
                else
                {
                    MessageBox.Show("Pairs are not selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CalculateRisk => " + ex.Message);
            }
        }

        public void UpdateListView()
        {
            foreach (var item in Synthetics)
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

                if (item.Regression.RValue >= 0.7M && item.Regression.RValue <= 1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(38, 153, 38);
                }

                if (item.Regression.RValue <= -0.7M && item.Regression.RValue >= -1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(191, 48, 48);
                }
            }
        }

        private void csvFiles_Click(object sender, EventArgs e)
        {
            CsvFiles files = new CsvFiles(this);
            files.ShowDialog();
        }

        private void downloadQuotes_Click(object sender, EventArgs e)
        {
            Downloader downloader = new Downloader();
            downloader.ShowDialog();
        }

    }
}
