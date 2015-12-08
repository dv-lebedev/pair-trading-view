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
using System.IO;
using System.Windows.Forms;
using TradingTools.Data;


namespace PairTradingView
{
    public partial class AppStartWindow : Form
    {
        private CsvFormat csvFmt;
        private const string CSV_FILES_DIRECTORY = "csv-files";
        private MainWindow mWind;

        public AppStartWindow(MainWindow mainWindow)
        {
            this.mWind = mainWindow;

            csvFmt = new CsvFormat()
            {
                ContainsHeader = false,
                DateTimeFormat = "yyyyMMdd",
                DateTimeIndex = 1,
                PriceIndex = 5
            };

            InitializeComponent();
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

                this.mWind.InputData = GetInputData();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start() => " + ex.Message);
            }
        }

        private InputData[] GetInputData()
        {
            var inputData = new List<InputData>();

            try
            {
                foreach (var file in Directory.EnumerateFiles(CSV_FILES_DIRECTORY))
                {
                    if (file.EndsWith(".txt") || file.EndsWith(".csv"))
                    {
                        var name = Path.GetFileNameWithoutExtension(file);

                        var stockValues = CsvHelper.Read(file, csvFmt);

                        var data = new InputData(new StockInfo(name, name, "Shares", 1, 1, 1), stockValues);

                        inputData.Add(data);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("GetQuotes() => " + e.Message);
            }

            return inputData.ToArray();
        }

        private void AppStartWindow_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
