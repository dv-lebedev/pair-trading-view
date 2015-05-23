using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.CSVData;
using PairTradingView.SqlData;
using PairTradingView.SqlData.Entities;

namespace PairTradingView.Forms
{
    public partial class AppStartWindow : Form
    {
        private MainWindow mWindow = null;

        public AppStartWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            radioSQL.Checked = true;
            radioCSV.Checked = false;

            Debug.Assert(mainWindow != null);

            this.mWindow = mainWindow;

            priceIndexUpDown.Minimum = 5;
            volumeIndexUpDown.Minimum = 6;

            deltaTypeBox.Items.Add("Ratio");
            deltaTypeBox.Items.Add("RatioIncludingBeta");

            deltaTypeBox.Items.Add("Spread");
            deltaTypeBox.Items.Add("SpreadIncludingBeta");

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();

            foreach (var item in SqlHelpers.GetSqlServerNames())
            {
                serverNameBox.Items.Add(item);
            }

            if (serverNameBox.Items.Count > 0)
                serverNameBox.Text = serverNameBox.Items[0].ToString();

            dataSaveInterval.Maximum = decimal.MaxValue;
            dataUpdateInterval.Maximum = decimal.MaxValue;
            loadValuesCount.Maximum = decimal.MaxValue;
            loadValuesCount.Minimum = 5;

            dataSaveInterval.Value = mWindow.Cfg.DataSaveInterval;
            dataUpdateInterval.Value = mWindow.Cfg.DataUpdateInterval;
            loadValuesCount.Value = mWindow.Cfg.LoadingValuesCount;

            startTimeTxt.Text = mWindow.Cfg.StartTime.ToString("g");
            stopTimeTxt.Text = mWindow.Cfg.StopTime.ToString("g");

          
        }

        private void priceIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            mWindow.CsvFormat.PriceIndex = (int)priceIndexUpDown.Value - 1;
        }

        private void volumeIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            mWindow.CsvFormat.VolumeIndex = (int)volumeIndexUpDown.Value - 1;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (radioCSV.Checked)
            {
                if (mWindow.CsvFormat.PriceIndex == mWindow.CsvFormat.VolumeIndex)
                {
                    MessageBox.Show("Price and Volume indeces should have a different values!");
                    return;
                }

                LoadDataFromDirectory();
            }
            if (radioSQL.Checked)
            {
                InitSqlConnection();
            }

            this.Close();
        }

        private void ContainsHeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mWindow.CsvFormat.ContainsHeader = ContainsHeaderCheckBox.Checked;
        }

        private void openDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Downloader DlForm = new Downloader();
            DlForm.Show();
        }

        private void deltaTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (deltaTypeBox.Text)
            {
                case "Ratio":
                    mWindow.DeltaType = DataProcessing.DeltaType.Ratio;
                    explanationLabel.Text = "if r_value >= 0: y / x \nelse: log(y) * log(x)";
                    break;

                case "RatioIncludingBeta":
                    mWindow.DeltaType = DataProcessing.DeltaType.RatioIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y / (beta * x) \nelse: log(y) * log(beta * x)";
                    break;

                case "Spread":
                    mWindow.DeltaType = DataProcessing.DeltaType.Spread;
                    explanationLabel.Text = "if r_value >= 0: y - x \nelse: y + x";
                    break;

                case "SpreadIncludingBeta":
                    mWindow.DeltaType = DataProcessing.DeltaType.SpreadIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y - beta * x \nelse: y + beta * x";
                    break;
            }
        }

        public void LoadDataFromDirectory()
        {
            foreach (var file in Directory.EnumerateFiles("MarketData/"))
            {
                var stockTicker = file.Replace("MarketData/", "").Replace(".txt", "").Replace(".csv", "");

                var values = CSV.Read(file, mWindow.CsvFormat);

                mWindow.Stocks.Add(stockTicker, values);

            }
        }

        public ICollection<Stock> LoadDataFromDirectory(string path = "MarketData/")
        {
            ICollection<Stock> stocks = new List<Stock>();

            foreach (var file in Directory.EnumerateFiles(path))
            {
                var stockTicker = file.Replace(path, "").Replace(".txt", "").Replace(".csv", "");

                var values = CSV.Read(file, mWindow.CsvFormat);

                stocks.Add(new Stock
                {
                    Code = stockTicker,
                    History = values
                });
            }

            return stocks;
        }

        public void InitSqlConnection()
        {
            TimeSpan startTime, stopTime;

            if (TimeSpan.TryParseExact(startTimeTxt.Text, "g", CultureInfo.CurrentCulture, out startTime))
            {
                mWindow.Cfg.StartTime = startTime;
            }

            if (TimeSpan.TryParseExact(stopTimeTxt.Text, "g", CultureInfo.CurrentCulture, out stopTime))
            {
                mWindow.Cfg.StopTime = stopTime;
            }

            mWindow.Cfg.DataSaveInterval = (int)dataSaveInterval.Value;
            mWindow.Cfg.DataUpdateInterval = (int)dataUpdateInterval.Value;
            mWindow.Cfg.LoadingValuesCount = (int)loadValuesCount.Value;

            ConnectToSqlServer();

            mWindow.Tasks.SetDataUpdateInterval((int)dataUpdateInterval.Value);
            mWindow.Tasks.SetDataSaveInterval((int)dataSaveInterval.Value);
            mWindow.Tasks.Start();
            
        }

        public void ConnectToSqlServer()
        {
            if (serverNameBox.Text == string.Empty)
            {
                MessageBox.Show("Server not found.");
            }

            string connectionStr = string.Format("Data Source={0};Initial Catalog=PairTradingViewDb;Integrated Security=True;MultipleActiveResultSets=True;", serverNameBox.Text);

            mWindow.Cfg.SqlConnectionString = connectionStr;

            try
            {
                using (var db = new StocksContext(mWindow.Cfg.SqlConnectionString))
                {
                    foreach (var item in db.Stocks)
                    {
                        var values = item.History.OrderBy(i => i.DateTime).Take(mWindow.Cfg.LoadingValuesCount);

                        mWindow.Stocks.Add(item.Code, values.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppStartWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
