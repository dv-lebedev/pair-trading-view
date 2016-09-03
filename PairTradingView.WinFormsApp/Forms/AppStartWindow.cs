
/*
Copyright(c) 2015-2016 Denis Lebedev

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
using System.Windows.Forms;

namespace PairTradingView
{
    public partial class AppStartWindow : Form
    {
        private MainWindow mainWindow;
        private string csvFilesDirectory = "csv-files";

        public AppStartWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            InitDeltaTypeBox();
            CenterToScreen();
        }

        private void InitDeltaTypeBox()
        {
            foreach (var item in Enum.GetNames(typeof(DeltaType)))
            {
                deltaTypeBox.Items.Add(item);
            }

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
        }

        private void ShowDownloader_Click(object sender, EventArgs e)
        {
            Downloader dowloader = new Downloader();
            dowloader.ShowDialog();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int priceIndex = (int)priceCol.Value - 1;
                bool containsHeader = header.Checked;

                mainWindow.InputData = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceIndex, containsHeader);
                mainWindow.DeltaTypeName = deltaTypeBox.Text;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Start => {ex.Message}");
            }
        }
    }
}
