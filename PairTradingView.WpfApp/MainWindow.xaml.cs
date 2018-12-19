
/*
Copyright(c) 2015-2018 Denis Lebedev

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
        public Stock[] Stocks { get; set; }
        public FinancialPair SelectedPair { get; set; }
        public List<FinancialPair> Pairs { get; set; }
        public ObservableCollection<PairInfo> PairsInfo { get; set; }

        public MainWindow(Stock[] stocks)
        {
            InitializeComponent();
            Stocks = stocks ?? throw new ArgumentNullException(nameof(stocks));
            InitPairs();
            InitDataGridView();
            FillDataGrid();
            controlPanel.ShowDefaultValuesForPairInfo();
            controlPanel.Calculate.Click += Calculate_Click;
            controlPanel.SMA.TextChanged += (s, e) => { UpdateInfoAndCharts(); };

            dataGridControl.dataGrid.SelectedIndex = 0;
            UpdateInfoAndCharts();
        }

        private void InitDataGridView()
        {
            dataGridControl.dataGrid.AddHandler(
                MouseLeftButtonDownEvent, 
                new MouseButtonEventHandler((e, c) => { UpdateInfoAndCharts(); }), 
                true);

            dataGridControl.dataGrid.PreviewKeyDown += (s, e) => { UpdateInfoAndCharts(); };
            dataGridControl.dataGrid.PreviewKeyUp += (s, e) => { UpdateInfoAndCharts(); };
            dataGridControl.PairChecked += OnChecked;
        }

        private void InitPairs()
        {
            Pairs = FinancialPair.CreateMany(Stocks);
        }

        private void FillDataGrid()
        {
            PairsInfo = new ObservableCollection<PairInfo>();

            foreach (var item in Pairs)
            {
                var deltaAverage = item.DeltaValues.Average();
                var deltaSD = MathUtils.GetStandardDeviation(item.DeltaValues);

                PairsInfo.Add(new PairInfo
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
            dataGridControl.dataGrid.ItemsSource = PairsInfo;
        }

        private void SetTradeVolumeToDefault()
        {
            foreach (var pair in Pairs)
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

                foreach (var item in PairsInfo)
                {
                    if (item.Selected)
                    {
                        var pair = Pairs.Find(i => i.Name == item.Name);

                        if (pair != null)
                        {
                            checkedPairs.Add(pair);
                        }
                    }
                }

                if (checkedPairs.Count > 0)
                {
                    SetTradeVolumeToDefault();

                    var rc = new RiskManager(checkedPairs.ToArray(), controlPanel.balance.GetDouble());
                    rc.Calculate();

                    controlPanel.ShowValuesForPairInfo(SelectedPair);
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
                if (dataGridControl.dataGrid.SelectedItem is PairInfo info)
                {
                    var selectedPairs = PairsInfo.Where(i => i.Selected && i.Name != info.Name);

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

        private void UpdateInfoAndCharts()
        {
            try
            {
                if (dataGridControl.dataGrid.SelectedItem is PairInfo info)
                {
                    SelectedPair = Pairs.Find(i => i.Name == info.Name);

                    if (SelectedPair != null)
                    {
                        var SMAValue = controlPanel.SMA.GetInt32();

                        if (SMAValue < 0) throw new Exception("SMA should be more or equal 0.");

                        chartControl.chartModel.Update(SelectedPair.DeltaValues, SelectedPair.Name, SMAValue);
                        chartControl.plot.InvalidatePlot();

                        controlPanel.ShowValuesForPairInfo(SelectedPair);
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
