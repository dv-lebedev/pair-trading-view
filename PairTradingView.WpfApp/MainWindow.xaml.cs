
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
using PairTradingView.WpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PairTradingView.WpfApp
{
    public partial class MainWindow : Window
    {
        private Stock[] stocks;
        private FinancialPair selectedPair;
        private List<FinancialPair> pairs;
        private ChartModel chartModel;

        public ObservableCollection<PairInfo> pairsInfo { get; private set; }

        public MainWindow()
        {
            var appStart = new AppStartWindow();
            appStart.ShowDialog();

            stocks = appStart.stocks;

            if (stocks == null)
            {
                Close();
            }
            else if (stocks.Length == 0)
            {
                this.Display("No input data. App will be closed.");
                Close();
            }
            else
            {
                InitPairs();
                InitializeComponent();
                SetWindowParams();
                InitChart();
                InitDataGridView();
                FillDataGrid();
                ShowDefaultValuesForPairInfo();
            }
        }

        private void InitDataGridView()
        {
            dataGrid.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftDown), true);        
        }

        private void InitChart()
        {
            chartModel = new ChartModel();
            DataContext = chartModel;
        }

        private void SetWindowParams()
        {
            Title = "Pair Trading View";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitPairs()
        {
            pairs = FinancialPair.CreateMany(stocks);
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

        private void SetTradeVolumeToDefault()
        {
            foreach (var pair in pairs)
            {
                pair.TradeVolume = 0;
                pair.X.TradeVolume = 0;
                pair.Y.TradeVolume = 0;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkedPairs = new List<FinancialPair>();

                foreach (var item in pairsInfo)
                {
                    if (item.Selected)
                    {
                        var pair = pairs.Find(i => i.Name == item.Name);

                        if (pair != null)
                        {
                            checkedPairs.Add(pair);
                        }
                    }
                }

                if (checkedPairs.Count > 0)
                {
                    SetTradeVolumeToDefault();

                    var rc = new RiskManager(checkedPairs.ToArray(), balance.GetDouble());
                    rc.Calculate();

                    ShowValuesForPairInfo();
                }
                else
                {
                    this.Display("Pairs are not selected.");
                }
            }
            catch (Exception ex)
            {
                this.Display("CalculateRisk => " + ex.Message);
            }
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var info = dataGrid.SelectedItem as PairInfo;

                if (info != null)
                {
                    var selectedPairs = pairsInfo.Where(i => i.Selected && i.Name != info.Name);

                    foreach (var item in selectedPairs)
                    {
                        if (item.X == info.X || item.X == info.Y ||
                            item.Y == info.X || item.Y == info.Y)
                        {
                            (e.Source as CheckBox).IsChecked = false;

                            this.Display($"You can't choose pairs with identical symbols! {info.Name} & {item.Name}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.Display($"OnChecked => {ex.Message}");
            }
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
                        var SMAValue = sma.GetInt32();

                        if (SMAValue < 0) throw new Exception("SMA should be more or equal 0.");

                        chartModel.Update(selectedPair.DeltaValues, selectedPair.Name, SMAValue);
                        plot.InvalidatePlot();

                        ShowValuesForPairInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Display($"OnMouseLeftDown => {ex.Message}");
            }
        }
    }
}