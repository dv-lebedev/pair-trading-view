using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using EmetricGears;
using PairTradingView.Controls;
using PairTradingView.DataProcessing;

namespace PairTradingView.Forms
{
    public partial class MainWindow : Form
    {

        public Dictionary<string, List<PairTradingView.DataProcessing.Value>> Stocks { get; private set; }

        public CsvFormat CsvFormat { get; private set; }

        public List<FinancialPair> FinancialPairs { get; private set; }

        public FinancialPair SelectedPair { get; private set; }

        public int RValueHighCount { get; private set; }
        public int RValueLowCount { get; private set; }

        public MainWindow()
        {

            AppStartWindow asw = new AppStartWindow();
            asw.ShowDialog();

            this.CsvFormat = asw.CsvFormat;
            this.CsvFormat.Separator = ',';

            InitializeComponent();


            zedGraphControl.BlackTheme();

            FinancialPairs = new List<FinancialPair>();
            Stocks = new Dictionary<string, List<PairTradingView.DataProcessing.Value>>();

            listView1.MouseDoubleClick += listView1_MouseDoubleClick;

            SMAperiodNUD.Maximum = decimal.MaxValue;
            WMAperiodNUD.Maximum = decimal.MaxValue;
        }

        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                var xSecurity = item.SubItems[0].Text;
                var ySecurity = item.SubItems[1].Text;

                zedGraphControl.GraphPane.Title.Text = ySecurity + " / " + xSecurity;

                SelectedPair = FinancialPairs
                     .First(i => i.XName == xSecurity && i.YName == ySecurity);

                var deltas = SelectedPair.DeltaValues.ToArray();
                zedGraphControl.SetDeltas(deltas.ToArray());

                SetSMA();
                SetWMA();

            }
            finally { }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ICollection<Task> tasks = new List<Task>();

            foreach (var file in Directory.EnumerateFiles("MarketData/"))
            {
                var t = new Task(() =>
                {
                    var stockTicker = file.Replace("MarketData/", "").Replace(".txt", "").Replace(".csv", "");

                    Stocks.Add(stockTicker, CsvFile.Read(file, CsvFormat));
                });

                t.RunSynchronously();
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            for (int i = 0; i < Stocks.Count; i++)
            {
                for (int j = i + 1; j < Stocks.Count; j++)
                {
                    var t = new Task(() =>
                    {
                        var pair = new FinancialPair(
                            Stocks.ElementAt(i).Value.Select(item => item.Price).ToArray(),
                            Stocks.ElementAt(j).Value.Select(item => item.Price).ToArray())
                        {
                            XName = Stocks.ElementAt(i).Key,
                            YName = Stocks.ElementAt(j).Key
                        };

                        FinancialPairs.Add(pair);
                    });

                    t.RunSynchronously();
                    tasks.Add(t);
                }
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var item in FinancialPairs)
            {
                int index = listView1.Items.Add(item.XName).Index;

                listView1.Items[index].SubItems.Add(item.YName);
                listView1.Items[index].SubItems.Add(Math.Round(item.XStandardDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.YStandardDev, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Alpha, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Beta, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Correlation, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Regression.Determination, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Average(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Min(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaValues.Max(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.DeltaStandardDev, 6).ToString());

                if (item.Regression.Correlation >= 0.7 && item.Regression.Correlation <= 1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(38, 153, 38);
                    RValueHighCount++;
                }

                if (item.Regression.Correlation <= -0.7 && item.Regression.Correlation >= -1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(191, 48, 48);
                    RValueLowCount++;
                }
            }

            r_valueHighLabel.Text = RValueHighCount.ToString();
            r_valueLowLabel.Text = RValueLowCount.ToString();
            stocksCountLabel.Text = Stocks.Count.ToString();
            pairsCreatedLabel.Text = FinancialPairs.Count.ToString();

        }

        public void SetSMA()
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

        public void SetWMA()
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

        private void SMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            SetSMA();
        }

        private void WMAperiodNUD_ValueChanged(object sender, EventArgs e)
        {
            SetWMA();
        }

        private void ReloadApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void IncrementSMAPeriod_Click(object sender, EventArgs e)
        {
            SMAperiodNUD.Value += 1;
        }

        private void DecrementSMAPeriod_Click(object sender, EventArgs e)
        {
            SMAperiodNUD.Value -= 1;
        }

        private void IncrementWMAPeriod_Click(object sender, EventArgs e)
        {
            WMAperiodNUD.Value += 1;
        }

        private void DecrementWMAPeriod_Click(object sender, EventArgs e)
        {
            WMAperiodNUD.Value -= 1;
        }
    }
}
