
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
using System.Windows;

namespace PairTradingView.WpfApp
{
    public partial class AppStartWindow : Window
    {
        private string csvFilesDirectory = "csv-files";
        public AppData AppData { get; private set; }

        public AppStartWindow()
        {
            InitializeComponent();
            InitDeltaTypeBox();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitDeltaTypeBox()
        {
            foreach (var item in Enum.GetNames(typeof(DeltaType)))
            {
                deltaTypeBox.Items.Add(item);
            }

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int priceIndex = priceCol.GetInt32() - 1;

                bool header = containsHeader.IsChecked.Value;

                AppData = new AppData();

                AppData.InputData = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceIndex, header);
                AppData.DeltaTypeName = deltaTypeBox.Text;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Start => {ex.Message}");
            }
        }
    }
}
