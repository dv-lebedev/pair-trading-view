/*
Copyright 2015 Denis Lebedev

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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NSynthetics.Data;
using NSynthetics.Logic.Synthetics;
using NSynthetics.Logic.Synthetics.RiskManagement;
using NSynthetics.Logic.Synthetics.Spread;
using NSynthetics.Statistics;
using NSynthetics.Statistics.Models;

namespace PairTradingView
{
    public partial class MainWindow : Form
    {
        private Synthetic syntheticSelected;
        private List<SpreadSynthetic> synthetics;
        
        public  InputData[] InputData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.listView1.Click += listView1_Click;
            this.SizeChanged += MainWindow_SizeChanged;
            this.SMAPeriod.ValueChanged += SMAPeriod_ValueChanged;
            this.WMAPeriod.ValueChanged += WMAPeriod_ValueChanged;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AppStartWindow startWin = new AppStartWindow(this);
            startWin.ShowDialog();

            if (InputData == null)
            {
                MessageBox.Show("No input data. App will be closed.");

                this.Close();
            }
            try
            {
                var factory = new SpreadSyntheticsFactory(InputData);

                synthetics = factory.CreateSynthetics().Cast<SpreadSynthetic>().ToList();
                ClearListView();
                UpdateListView();

                CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load => " + ex.Message);
            }
        }

        private void WMAPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (WMAPeriod.Value == 0)
                zedGraphControl.ClearWMA();

            if (WMAPeriod.Value > 0)
            {
                if (syntheticSelected == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (WMAPeriod.Value > syntheticSelected.Values.Count())
                {
                    MessageBox.Show("maximum value = " + syntheticSelected.Values.Count());
                }
                else
                {
                    zedGraphControl.SetWMA(
                        MovingAverages.WMA(syntheticSelected.Values.ToArray(), (int)WMAPeriod.Value),
                        (int)WMAPeriod.Value);
                }
            }
        }

        private void SMAPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (SMAPeriod.Value == 0)
                zedGraphControl.ClearSMA();

            if (SMAPeriod.Value > 0)
            { 
                if (syntheticSelected == null)
                {
                    MessageBox.Show("Pair is not selected.");
                }
                else if (SMAPeriod.Value > syntheticSelected.Values.Count())
                {
                    MessageBox.Show("maximum value = " + syntheticSelected.Values.Count());
                }
                else
                {
                    zedGraphControl.SetSMA(
                        MovingAverages.SMA(syntheticSelected.Values.ToArray(), (int)SMAPeriod.Value),
                        (int)SMAPeriod.Value);
                }
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            buttomPanel.Height = this.Height / 3;
            chartPanel.Width = (int)(this.Width * 0.73 + 1);
            zedGraphControl.Width = (int)( this.Width * 0.73);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {       
                ListViewItem item = listView1.SelectedItems[0];
                var name = item.SubItems[0].Name;

                zedGraphControl.GraphPane.Title.Text = name;

                syntheticSelected = synthetics
                     .First(i => i.Name == name);

                var deltas = syntheticSelected.Values;

                zedGraphControl.SetDeltas(deltas);
                zedGraphControl.SetDeltaCurrent(deltas.Last());

                if (syntheticSelected.RiskParameters != null)
                {
                    pairName.Text = syntheticSelected.Name.ToString() + " => ";
                    xName.Text = syntheticSelected.Symbols[0] + " => ";
                    yName.Text = syntheticSelected.Symbols[1] + " => ";

                    pairsTradeBalance.Text = Math.Round(syntheticSelected.RiskParameters.Balance, 4).ToString();
                    yTradeVolume.Text = Math.Round(syntheticSelected.RiskParameters.SymbolsBalances.Values.ElementAt(1), 4).ToString();
                    xTradeVolume.Text = Math.Round(syntheticSelected.RiskParameters.SymbolsBalances.Values.ElementAt(0), 4).ToString();
                    riskLimit.Text = Math.Round((syntheticSelected.RiskParameters.Balance * (risk.Value) / 100.0M), 4).ToString();
                }
                else
                {
                    pairName.Text = "-";
                    xName.Text = "-";
                    yName.Text = "-";
                    pairsTradeBalance.Text = "0";
                    yTradeVolume.Text = "0";
                    xTradeVolume.Text = "0";
                    riskLimit.Text = "0";
                }

                SMAPeriod_ValueChanged(null, null);
                WMAPeriod_ValueChanged(null, null);

            }
            catch (Exception ex)
            {
                Console.WriteLine("listView1_Click(s,e) " + ex.Message);
            }
        }

        private void CalculateRisk_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.CheckedItems.Count > 0)
                {
                    var checkedSynths = new List<Synthetic>();

                    foreach (var code in listView1.CheckedItems.OfType<ListViewItem>().Select(i => i.Name).ToArray())
                    {
                        checkedSynths.Add(synthetics.First(i => i.Name.ToString() == code));
                    }

                    var rc = new RiskManager(checkedSynths.ToArray(), balance.Value);
                    rc.Calculate();

                    listView1_Click(this, null);
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

        private void UpdateListView()
        {
            foreach (var item in synthetics)
            {

                var xSymbol = item.Symbols[0];
                var ySymbol = item.Symbols[1];

                int index = listView1.Items.Add(item.Name.ToString(), xSymbol, 0).Index;

                listView1.Items[index].SubItems.Add(ySymbol);

                var regression = item.Regression as LinearRegression;

                listView1.Items[index].SubItems.Add(Math.Round(item.XStdDeviation, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.YStdDeviation, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(regression.Alpha, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(regression.Beta, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(regression.RValue, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(regression.RSquared, 6).ToString());

                var deltaAverage = item.Values.Average();
                var deltaSD = BasicFuncs.GetStandardDeviation(item.Values);

                listView1.Items[index].SubItems.Add(Math.Round(deltaAverage, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Values.Min(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(item.Values.Max(), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(deltaSD, 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(deltaAverage - (3 * deltaSD), 6).ToString());
                listView1.Items[index].SubItems.Add(Math.Round(deltaAverage + (3 * deltaSD), 6).ToString());

                if (regression.RValue >= 0.7M && regression.RValue <= 1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(38, 153, 38);
                }

                if (regression.RValue <= -0.7M && regression.RValue >= -1)
                {
                    listView1.Items[index].BackColor = Color.FromArgb(191, 48, 48);
                }
            }
        }

        private void ClearListView()
        {
            listView1.Items.Clear();
        }

    }
}
