using PairTradingView.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PairTradingView.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FinancialPair selectedPair;
        private List<FinancialPair> pairs;
        private MainWindowModel viewModel;
        public ObservableCollection<PairInfo> pairsInfo { get; set; }
        private AppData appData;

        public MainWindow()
        {
            var appStart = new AppStartWindow();
            appStart.ShowDialog();

            appData = appStart.AppData;

            if (appData == null)
            {
                Close();
            }
            else if (appData.InputData == null)
            {
                MessageBox.Show("No input data. App will be closed.");
                Close();
            }
            else
            {
                DeltaType deltaType = (DeltaType)Enum.Parse(typeof(DeltaType), appData.DeltaTypeName);

                pairs = FinancialPair.CreateMany(appData.InputData, deltaType);            

                InitializeComponent();

                Title = "Pair Trading View";

                FillDataGrid();

                WindowStartupLocation = WindowStartupLocation.CenterScreen;

                viewModel = new MainWindowModel();
                DataContext = viewModel;

                dataGrid.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftDown), true);

                ShowDefaultValuesForPairInfo();
            }
        }

        private void OnMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            PairInfo info = dataGrid.SelectedItem as PairInfo;

            if (info != null)
            {
                selectedPair = pairs.Find(i => i.X.Name == info.X && i.Y.Name == info.Y);

                if (selectedPair != null)
                {
                    viewModel.Update(selectedPair.DeltaValues, selectedPair.Name);
                    Plot1.InvalidatePlot();
                }
            }

            ShowValuesForPairInfo();
        }

        private void FillDataGrid()
        {
            pairsInfo = new ObservableCollection<PairInfo>();

            foreach(var item in pairs)
            {
                var deltaAverage = item.DeltaValues.Average();
                var deltaSD = MathUtils.GetStandardDeviation(item.DeltaValues);

                pairsInfo.Add(new PairInfo
                {
                    Alpha = item.Regression.Alpha,
                    Beta = item.Regression.Beta,
                    X = item.X.Name,
                    Y = item.Y.Name,
                    R = item.Regression.RValue,
                    R_Squared = item.Regression.RSquared,
                    DeltaAverage = (decimal)deltaAverage,
                    DeltaMax = (decimal)item.DeltaValues.Max(),
                    DeltaMin = (decimal)item.DeltaValues.Min(),
                    DeltaSD = (decimal)deltaSD,
                    SD_X = (decimal)item.X.Deviation,
                    SD_Y = (decimal)item.Y.Deviation,
                    DeltaSDMinus3Q = (decimal)(deltaAverage - (3 * deltaSD)),
                    DeltaSDPlus3Q = (decimal)(deltaAverage + (3 * deltaSD))
                });
            }
            dataGrid.ItemsSource = pairsInfo;
        }

        private void ShowDefaultValuesForPairInfo()
        {
            pairName.Text = "-";
            xName.Text = "-";
            yName.Text = "-";
            pairsTradeBalance.Text = "0";
            yTradeVolume.Text = "0";
            xTradeVolume.Text = "0";
            riskLimit.Text = "0";
        }

        private void ShowValuesForPairInfo()
        {
            pairName.Text = selectedPair.Name.ToString() + " => ";
            xName.Text = selectedPair.X.Name + " => ";
            yName.Text = selectedPair.Y.Name + " => ";

            pairsTradeBalance.Text = Math.Round(selectedPair.TradeVolume, 4).ToString();
            yTradeVolume.Text = Math.Round(selectedPair.Y.TradeVolume, 4).ToString();
            xTradeVolume.Text = Math.Round(selectedPair.X.TradeVolume, 4).ToString();
            riskLimit.Text = Math.Round((selectedPair.TradeVolume * risk.GetDouble() / 100.0), 4).ToString();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkedSynths = new List<FinancialPair>();

                foreach (var info in pairsInfo)
                {
                    if (info.Select)
                    {
                        var synth = pairs.Find(i => i.X.Name == info.X && i.Y.Name == info.Y);

                        if (synth != null)
                        {
                            checkedSynths.Add(synth);
                        }
                    }
                }

                if (checkedSynths.Count > 0)
                {
                    SetTradeVolumeToDefault();         

                    var rc = new RiskManager(checkedSynths.ToArray(), balance.GetDouble());
                    rc.Calculate();

                    ShowValuesForPairInfo();
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

        private void SetTradeVolumeToDefault()
        {
            foreach (var pair in pairs)
            {
                pair.TradeVolume = 0;
                pair.X.TradeVolume = 0;
                pair.Y.TradeVolume = 0;
            }
        }
    }
}
