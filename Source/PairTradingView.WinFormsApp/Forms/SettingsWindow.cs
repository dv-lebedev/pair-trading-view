using System;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.Data.DataProviders.ODBC;
using PairTradingView.Logic.Session;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Forms
{
    public partial class SettingsWindow : Form
    {

        private MainWindow mWindow = null;


        public SettingsWindow(MainWindow mainWindow)
        {
            if (mainWindow == null) throw new NullReferenceException();

            this.mWindow = mainWindow;

            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            // connection settings
            connectionStr.Text = mWindow.SessionConfig.ConnectionString;

            //data store
            timeFrom.Value = DateTime.Parse(mWindow.SessionConfig.StartTime.ToString());
            timeTo.Value = DateTime.Parse(mWindow.SessionConfig.StopTime.ToString());
            dataSavingInterval.Items.AddRange(DataSaveInterval.Intervals.Select(i => i.Name).ToArray());


            dataSavingInterval.Text = DataSaveInterval.Intervals
                .Find(i => i.Milliseconds == mWindow.SessionConfig.DataSaveInterval)
                .Name;

            //loading data
            if (mWindow.SessionConfig.LoadingDataType == LoadingDataType.LoadLastValues)
            {
                loadLastNValues.Checked = true;
            }
            else
            {
                loadForNDays.Checked = true;
            }
            loadValuesCount.Maximum = decimal.MaxValue;
            loadValuesCount.Minimum = 1;
            loadValuesCount.Value = mWindow.SessionConfig.LoadingValuesCount;

            loadNumberOfDays.Maximum = decimal.MaxValue;
            loadNumberOfDays.Minimum = 1;
            loadNumberOfDays.Value = mWindow.SessionConfig.LoadingNumberOfDays;

            
            //delta          
            deltaTypeBox.Items.AddRange(DeltaHelpers.GetDeltaInstances().Select(i => i.Name).ToArray());
            deltaTypeBox.Text = mWindow.SessionConfig.DeltaName;

            //data updating
            dataUpdateInterval.Maximum = decimal.MaxValue;
            dataUpdateInterval.Minimum = 1;
            dataUpdateInterval.Value = mWindow.SessionConfig.DataUpdateInterval / 1000;

        }

        private void testConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var odbc = new OdbcMarketDataProvider(connectionStr.Text);
                odbc.GetStocks();

                MessageBox.Show("SUccess!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void saveSettings_Click(object sender, EventArgs e)
        {

            // db connection
            if (connectionStr.Text != "")
            {
                mWindow.SessionConfig.ConnectionString = connectionStr.Text;
            }
            else
            {
                MessageBox.Show("Server settings have mistakes.");
            }


            //data store
            mWindow.SessionConfig.StartTime = timeFrom.Value.TimeOfDay;
            mWindow.SessionConfig.StopTime = timeTo.Value.TimeOfDay;


            mWindow.SessionConfig.DataSaveInterval = DataSaveInterval.Intervals
                .Find(i => i.Name == dataSavingInterval.Text)
                .Milliseconds;


            mWindow.SessionConfig.DeltaName = deltaTypeBox.Text;


            //data loading
            if (loadLastNValues.Checked)
            {
                mWindow.SessionConfig.LoadingDataType = LoadingDataType.LoadLastValues;
            }
            else
            {
                mWindow.SessionConfig.LoadingDataType = LoadingDataType.LoadByNumberOfDays;
            }
            mWindow.SessionConfig.LoadingNumberOfDays = (int)loadNumberOfDays.Value;
            mWindow.SessionConfig.LoadingValuesCount = (int)loadValuesCount.Value;


            //data updating
            mWindow.SessionConfig.DataUpdateInterval = (int)dataUpdateInterval.Value * 1000;


            MessageBox.Show("The changes have been saved.");

        }

        private void deltaTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            descriptionLabel.Text = DeltaHelpers.GetDeltaInstances()
                .First(i => i.Name == deltaTypeBox.Text)
                .Description;
        }

        private void InitDb_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var mysql = new MySqlDataProvider(serverTxt.Text, userTxt.Text, passwordTxt.Text);
            //    mysql.Initialize();

            //    MessageBox.Show("Success.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
