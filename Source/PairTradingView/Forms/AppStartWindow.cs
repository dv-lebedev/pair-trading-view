using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PairTradingView.Data;
using PairTradingView.Data.CSVData;
using PairTradingView.Data.Entities;
using PairTradingView.Data.SqlData;
using PairTradingView.Synthetics;

namespace PairTradingView.Forms
{
    public partial class AppStartWindow : Form
    {
        private MainWindow mWindow = null;

        public AppStartWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mWindow = mainWindow;

            radioSQL.Checked = true;
            radioCSV.Checked = false;

            priceIndexUpDown.Minimum = 5;
            volumeIndexUpDown.Minimum = 6;

            deltaTypeBox.Items.Add("Ratio");
            deltaTypeBox.Items.Add("RatioIncludingBeta");

            deltaTypeBox.Items.Add("Spread");
            deltaTypeBox.Items.Add("SpreadIncludingBeta");

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();

            foreach (var item in SqlHelpers.GetSqlServerNames())
                serverNameBox.Items.Add(item);
            
            if (serverNameBox.Items.Count > 0)
                serverNameBox.Text = serverNameBox.Items[0].ToString();

            dataSaveInterval.Minimum = 1;
            dataSaveInterval.Maximum = decimal.MaxValue;

            dataUpdateInterval.Minimum = 1;
            dataUpdateInterval.Maximum = decimal.MaxValue;

            loadValuesCount.Minimum = 5;
            loadValuesCount.Maximum = decimal.MaxValue;
                   
            dataSaveInterval.Value = mWindow.Cfg.DataSaveInterval;
            dataUpdateInterval.Value = mWindow.Cfg.DataUpdateInterval;
            loadValuesCount.Value = mWindow.Cfg.LoadingValuesCount;

            startTimeTxt.Text = mWindow.Cfg.StartTime.ToString("g");
            stopTimeTxt.Text = mWindow.Cfg.StopTime.ToString("g");
          
        }

        private void AppStartWindow_Load(object sender, EventArgs e)
        {

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

                IDataProvider provider = new CSVDataProvider("MarketData/", mWindow.CsvFormat);

                mWindow.PairsContainer = new PairsContainer(provider, mWindow.DeltaType);
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
                    mWindow.DeltaType = Synthetics.DeltaType.Ratio;
                    explanationLabel.Text = "if r_value >= 0: y / x \nelse: log(y) * log(x)";
                    break;

                case "RatioIncludingBeta":
                    mWindow.DeltaType = Synthetics.DeltaType.RatioIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y / (beta * x) \nelse: log(y) * log(beta * x)";
                    break;

                case "Spread":
                    mWindow.DeltaType = Synthetics.DeltaType.Spread;
                    explanationLabel.Text = "if r_value >= 0: y - x \nelse: y + x";
                    break;

                case "SpreadIncludingBeta":
                    mWindow.DeltaType = Synthetics.DeltaType.SpreadIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y - beta * x \nelse: y + beta * x";
                    break;
            }
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

            if (serverNameBox.Text == string.Empty) 
                MessageBox.Show("Server not found.");
         
            mWindow.Cfg.SqlConnectionString = string.Format("Data Source={0};Initial Catalog=PairTradingViewDb;Integrated Security=True;MultipleActiveResultSets=True;", serverNameBox.Text);

            IDataProvider provider = new SqlDataProvider(mWindow.Cfg);

            mWindow.PairsContainer = new PairsContainer(provider, mWindow.DeltaType);

            mWindow.Tasks.SetDataUpdateInterval((int)dataUpdateInterval.Value);
            mWindow.Tasks.SetDataSaveInterval((int)dataSaveInterval.Value);
            mWindow.Tasks.Start();
        }

        private void startTimeTxt_TextChanged(object sender, EventArgs e)
        {
            TimeSpan ts;

            if (TimeSpan.TryParseExact(startTimeTxt.Text, "g", CultureInfo.CurrentCulture, out ts))
            {
                startTimeTxt.BackColor = Color.LimeGreen;
            }
            else
            {
                startTimeTxt.BackColor = Color.Red;
            }
        }

        private void stopTimeTxt_TextChanged(object sender, EventArgs e)
        {
            TimeSpan ts;

            if (TimeSpan.TryParseExact(stopTimeTxt.Text, "g", CultureInfo.CurrentCulture, out ts))
            {
                stopTimeTxt.BackColor = Color.LimeGreen;
            }
            else
            {
                stopTimeTxt.BackColor = Color.Red;
            }

        }
    }
}
