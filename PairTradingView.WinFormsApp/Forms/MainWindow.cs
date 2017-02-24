
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
using System.Linq;
using System.Windows.Forms;

namespace PairTradingView
{
    public partial class MainWindow : Form
    {
        private FinancialPair selectedPair;
        private List<FinancialPair> pairs;

        private Stock[] stocks;

        public MainWindow()
        {
            InitializeComponent();

            listView.Click += listView_Click;
            SizeChanged += MainWindow_SizeChanged;
            SMAPeriod.ValueChanged += SMAPeriod_ValueChanged;
            WMAPeriod.ValueChanged += WMAPeriod_ValueChanged;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AppStartWindow startWin = new AppStartWindow();
            startWin.ShowDialog();

            stocks = startWin.Stocks;

            if (stocks == null)
            {
                Close();
            }
            else if (stocks.Length == 0)
            {
                MessageBox.Show("No input data. App will be closed.");
                Close();
            }
            else
            {
                pairs = FinancialPair.CreateMany(stocks);
                listView.Items.Clear();
                listView.Update(pairs);
                CenterToScreen();
            }
        }

        private void WMAPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (WMAPeriod.Value == 0)
                chart.ClearWMA();

            if (WMAPeriod.Value > 0)
            {
                if (selectedPair == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (WMAPeriod.Value > selectedPair.DeltaValues.Count())
                {
                    MessageBox.Show("maximum value = " + selectedPair.DeltaValues.Count());
                }
                else
                {
                    double[] sma = MovingAverages.WMA(selectedPair.DeltaValues.ToArray(), (int)WMAPeriod.Value);
                    chart.SetWMA(sma, (int)WMAPeriod.Value);
                }
            }
        }

        private void SMAPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (SMAPeriod.Value == 0)
                chart.ClearSMA();

            if (SMAPeriod.Value > 0)
            {
                if (selectedPair == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (SMAPeriod.Value > selectedPair.DeltaValues.Count())
                {
                    MessageBox.Show("maximum value = " + selectedPair.DeltaValues.Count());
                }
                else
                {
                    chart.SetSMA(
                        MovingAverages.SMA(selectedPair.DeltaValues.ToArray(), (int)SMAPeriod.Value),
                        (int)SMAPeriod.Value);
                }
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            buttomPanel.Height = Height / 3;
            chartPanel.Width = (int)(Width * 0.73 + 1);
            chart.Width = (int)(Width * 0.73);
        }

        private void listView_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView.SelectedItems[0];
                var name = item.SubItems[0].Name;

                chart.GraphPane.Title.Text = name;

                selectedPair = pairs.First(i => i.Name == name);

                var deltas = selectedPair.DeltaValues;

                chart.SetDeltaValues(deltas);
                chart.SetCurrentDeltaValue(deltas.Last());

                ShowValuesForPairInfo();

                SMAPeriod_ValueChanged(null, null);
                WMAPeriod_ValueChanged(null, null);

            }
            catch (Exception ex)
            {
                Console.WriteLine("listView1_Click(s,e) " + ex.Message);
            }
        }

        private void ShowValuesForPairInfo()
        {
            pairName.Text = selectedPair.Name.ToString() + " => ";
            xName.Text = selectedPair.X.Name + " => ";
            yName.Text = selectedPair.Y.Name + " => ";

            pairsTradeBalance.Text = Math.Round(selectedPair.TradeVolume, 4).ToString();
            yTradeVolume.Text = Math.Round(selectedPair.Y.TradeVolume, 4).ToString();
            xTradeVolume.Text = Math.Round(selectedPair.X.TradeVolume, 4).ToString();
            riskLimit.Text = Math.Round((selectedPair.TradeVolume * (double)risk.Value/ 100.0), 4).ToString();
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

        private void CalculateRisk_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.CheckedItems.Count > 0)
                {
                    SetTradeVolumeToDefault();

                    var checkedSynths = new List<FinancialPair>();

                    foreach (var code in listView.CheckedItems.OfType<ListViewItem>().Select(i => i.Name).ToArray())
                    {
                        checkedSynths.Add(pairs.First(i => i.Name.ToString() == code));
                    }

                    var rc = new RiskManager(checkedSynths.ToArray(), (double)balance.Value);
                    rc.Calculate();

                    listView_Click(this, null);
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
