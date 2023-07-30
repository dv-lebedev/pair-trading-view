
/*
Copyright(c) 2015-2019 Denis Lebedev

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
using System.Windows;

namespace PairTradingView.WpfApp
{
    public partial class FilesLoaderWindow : Window
    {
        private const string csvFilesDirectory = "csv-files";
        private Stock[] stocks;

        public FilesLoaderWindow()
        {
            InitializeComponent();
        }

        private void LoadDataFromFilesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int priceColumn = priceCol.SelectedIndex;
                bool header = containsHeader.IsChecked.Value;
                stocks = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceColumn, header);

                filesList.Items.Clear();
                foreach (var stock in stocks)
                {
                    filesList.Items.Add(stock.Name);
                }
            }
            catch (Exception ex)
            {
                this.Display($"LoadDataFromFiles => {ex.Message}");
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (stocks == null || stocks.Length == 0)
            {
                this.Display("No input data.");
            }
            else if(stocks.Length == 1)
            {
                this.Display("You should have 2 stocks minimum.");
            }
            else
            {
               /* Visibility = Visibility.Hidden;
                new MainWindow(stocks).Show();
                Close();*/
            }   
        }
    }
}
