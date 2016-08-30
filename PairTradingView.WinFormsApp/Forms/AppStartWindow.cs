
#region LICENSE

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

#endregion


using PairTradingView.Logic.Synthetics;
using System;
using System.Windows.Forms;

namespace PairTradingView
{
    public partial class AppStartWindow : Form
    {
        private CsvFormat csvFmt;
        private MainWindow mWind;

        private const string CSV_FILES_DIRECTORY = "csv-files";

        public AppStartWindow(MainWindow mainWindow)
        {
            mWind = mainWindow;

            csvFmt = new CsvFormat()
            {
                ContainsHeader = false,
                DateTimeFormat = "yyyyMMdd",
                DateTimeIndex = 1,
                PriceIndex = 5
            };

            InitializeComponent();

            var deltaTypes = SyntheticsFactory.GetFactoriesNames();

            foreach(var item in deltaTypes)
            {
                deltaTypeBox.Items.Add(item);
            }

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
        }

        private void AppStartWindow_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void quoteDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Downloader dowloader = new Downloader();
            dowloader.ShowDialog();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                csvFmt.ContainsHeader = header.Checked;
                csvFmt.DateTimeFormat = dtFmt.Text;
                csvFmt.DateTimeIndex = (int)dtCol.Value - 1;
                csvFmt.PriceIndex = (int)priceCol.Value - 1;

                mWind.InputData = CsvUtils.ReadAllDataFrom(CSV_FILES_DIRECTORY, csvFmt);
                mWind.DeltaTypeName = deltaTypeBox.Text;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start() => " + ex.Message);
            }
        }
    }
}
