
/*
Copyright(c) 2015-2017 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using PairTradingView.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PairTradingView.WpfApp
{
    public partial class MainWindow : Window
    {
        private AppData appData;
        private FinancialPair selectedPair;
        private List<FinancialPair> pairs;
        private ChartModel chartModel;

        public ObservableCollection<PairInfo> pairsInfo { get; set; }

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
                WindowStartupLocation = WindowStartupLocation.CenterScreen;

                chartModel = new ChartModel();
                DataContext = chartModel;

                dataGrid.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftDown), true);

                FillDataGrid();

                ShowDefaultValuesForPairInfo();
            }
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("DDD");
        }

        private void OnMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var info = dataGrid.SelectedItem as PairInfo;

                if (info != null)
                {
                    selectedPair = pairs.Find(i => i.Name == info.Name);

                    if (selectedPair != null)
                    {
                        var smaValue = sma.GetInt32();

                        if (smaValue < 0)
                            throw new Exception("SMA should be more or equal 0.");

                        chartModel.Update(selectedPair.DeltaValues, selectedPair.Name, smaValue);
                        plot.InvalidatePlot();

                        ShowValuesForPairInfo();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"OnMouseLeftDown => {ex.Message}");
            }
        }

        private void FillDataGrid()
        {
            pairsInfo = new ObservableCollection<PairInfo>();

            foreach (var item in pairs)
            {
                var deltaAverage = item.DeltaValues.Average();
                var deltaSD = MathUtils.GetStandardDeviation(item.DeltaValues);

                pairsInfo.Add(new PairInfo
                {
                    Name = item.Name,
                    X = item.X.Name,
                    Y = item.Y.Name,
                    Alpha = item.Regression.Alpha,
                    Beta = item.Regression.Beta,
                    R = item.Regression.RValue,
                    RSquared = item.Regression.RSquared,
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
                    if (info.Selected)
                    {
                        var synth = pairs.Find(i => i.Name  == info.Name);

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
