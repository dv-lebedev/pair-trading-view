using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmetricGears;
using PairTradingView.DataProcessing;
using PairTradingView.SqlData;
using PairTradingView.SqlData.Entities;
using PairTradingView.CSVData;

namespace PairTradingView.Forms
{
    public partial class MainWindow : Form
    {
        public Dictionary<string, List<StockValue>> Stocks { get; private set; }

        public Configuration Cfg { get; private set; }

        public DataTasks Tasks { get; private set; }

        public CSVFormat CsvFormat { get; private set; }
        public DeltaType DeltaType { get; set; }

        public List<FinancialPair> FinancialPairs { get; private set; }

        private FinancialPair SelectedPair { get; set; }

        public MainWindow()
        {
            CsvFormat = new CSVFormat();
            CsvFormat.Separator = ',';

            FinancialPairs = new List<FinancialPair>();

            Stocks = new Dictionary<string, List<StockValue>>();

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


            AppStartWindow asw = new AppStartWindow(this);
            asw.ShowDialog();

            InitializeComponent();

            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            
            SMAperiodNUD.Maximum = decimal.MaxValue;
            WMAperiodNUD.Maximum = decimal.MaxValue;

            this.FormClosing += MainWindow_FormClosing;
        }

        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration.Serialize("ptview.cfg", Cfg);
        }

        void DataUpdater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    using (var db = new StocksContext(Cfg.SqlConnectionString))
                    {
                        var xStock = db.Stocks.Find(SelectedPair.XName);
                        var yStock = db.Stocks.Find(SelectedPair.YName);

                        if (xStock != null && yStock != null)
                        {
                            var delta = SelectedPair.GetCurrentDelta(xStock.Price, yStock.Price);

                            zedGraphControl.SetDeltaCurrent(delta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }));
        }

        void DataSaver_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            try
            {
                using (var db = new StocksContext(Cfg.SqlConnectionString))
                {

                    foreach (var stock in db.Stocks)
                    {
                        stock.History.Add(new SqlData.Entities.StockValue
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


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
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

                zedGraphControl.SetDeltas(deltas);
                zedGraphControl.SetDeltaCurrent(deltas.Last());

                SMAperiodNUD_ValueChanged(null, null);
                WMAperiodNUD_ValueChanged(null, null);

            }
            finally          
            {
                // ...
            }
        }

        public void CreateFinancialPairs()
        {
            for (int i = 0; i < Stocks.Count; i++)
            {
                for (int j = i + 1; j < Stocks.Count; j++)
                {
                    var pair = new FinancialPair(
                             Stocks.ElementAt(i).Value.Select(item => item.Price).ToArray(),
                             Stocks.ElementAt(j).Value.Select(item => item.Price).ToArray(),
                             DeltaType)
                    {
                        XName = Stocks.ElementAt(i).Key,
                        YName = Stocks.ElementAt(j).Key
                    };

                    FinancialPairs.Add(pair);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CreateFinancialPairs();

            UpdateListView();

            r_valueHighLabel.Text = FinancialPairs.Where
                (i => i.Regression.Correlation >= 0.7 && i.Regression.Correlation <= 1)
                .Count()
                .ToString();

            r_valueLowLabel.Text = FinancialPairs.Where
                (i => i.Regression.Correlation <= -0.7 && i.Regression.Correlation >= -1)
                .Count()
                .ToString();

            stocksCountLabel.Text = Stocks.Count.ToString();
            pairsCreatedLabel.Text = FinancialPairs.Count.ToString();

        }

        private void UpdateListView()
        {
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

    }
}
