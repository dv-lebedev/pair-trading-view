
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
using PairTradingView.WpfApp.Data;

namespace PairTradingView.WpfApp
{
    public partial class MainWindow : Window
    {
        public FinancialPair SelectedPair { get; set; }
        public ObservableCollection<ExtFinancialPair> Pairs { get; set; }

        public MainWindow(Stock[] stocks)
        {
            InitializeComponent();

            Pairs = new ObservableCollection<ExtFinancialPair>(
                FinancialPair.CreateMany<ExtFinancialPair>(
                    stocks ?? throw new ArgumentNullException(nameof(stocks))
                    ));

            InitDataGridView();
            InitControlPanel();
          
            //select first pair to show
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

            dataGridControl.dataGrid.ItemsSource = Pairs;
        }

        private void InitControlPanel()
        {
            controlPanel.ShowDefaultValuesForPairInfo();
            controlPanel.Calculate.Click += Calculate_Click;
            controlPanel.SMA.TextChanged += (s, e) => { UpdateInfoAndCharts(); };
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
                var checkedPairs = new List<ExtFinancialPair>();

                foreach (var item in Pairs)
                {
                    if (item.Selected)
                    {
                        var pair = Pairs.FirstOrDefault(i => i.Name == item.Name);

                        if (pair != null)
                        {
                            checkedPairs.Add(pair);
                        }
                    }
                }

                if (checkedPairs.Count > 0)
                {
                    SetTradeVolumeToDefault();

                    new RiskManager(checkedPairs.ToArray(), controlPanel.balance.GetDouble()).Calculate();

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
                if (dataGridControl.dataGrid.SelectedItem is ExtFinancialPair ext)
                {
                    var selectedPairs = Pairs.Where(i => i.Selected && i.Name != ext.Name);

                    foreach (var item in selectedPairs)
                    {
                        if (item.X == ext.X || item.X == ext.Y ||
                            item.Y == ext.X || item.Y == ext.Y)
                        {
                            (e.Source as CheckBox).IsChecked = false;

                            this.Display($"You can't choose pairs with identical symbols! {ext.Name} & {item.Name}");
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
                if (dataGridControl.dataGrid.SelectedItem is ExtFinancialPair ext)
                {
                    SelectedPair = Pairs.FirstOrDefault(i => i.Name == ext.Name);

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
                this.Display($"UpdateInfoAndCharts => {ex.Message}");
            }
        }
    }
}
