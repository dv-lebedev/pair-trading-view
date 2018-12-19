
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
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Globalization;

namespace PairTradingView.WpfApp
{
    public partial class ControlPanel : UserControl
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        public void ShowDefaultValuesForPairInfo()
        {
            pairName.Text = "-";
            xName.Text = "-";
            yName.Text = "-";
            pairsTradeBalance.Text = "0";
            yTradeVolume.Text = "0";
            xTradeVolume.Text = "0";
            riskLimit.Text = "0";
        }

        public void ShowValuesForPairInfo(FinancialPair selectedPair)
        {
            pairName.Text = selectedPair.Name.ToString();
            xName.Text = selectedPair.X.Name;
            yName.Text = selectedPair.Y.Name;

            pairsTradeBalance.Text = Math.Round(selectedPair.TradeVolume, 4).ToString();
            yTradeVolume.Text = Math.Round(selectedPair.Y.TradeVolume, 4).ToString();
            xTradeVolume.Text = Math.Round(selectedPair.X.TradeVolume, 4).ToString();
            riskLimit.Text = Math.Round((selectedPair.TradeVolume * risk.GetDouble() / 100.0), 4).ToString();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "") tb.Text = "0";

                if (tb.Text.StartsWith("0") && tb.Text.Length > 1 && tb.Text[1] != '.')
                {
                    int i = 0;
                    while (tb.Text[i] == '0' && i < tb.Text.Length - 1) i++;
                    tb.Text = tb.Text.Remove(0, i);
                }            

                if (!double.TryParse(tb.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double result))
                {
                    tb.Background = (Brush)new BrushConverter().ConvertFromString("#f8d7da");
                }
                else
                {
                    tb.Background = (Brush)new BrushConverter().ConvertFromString("#cce5ff");
                }
            }
        }
    }
}
