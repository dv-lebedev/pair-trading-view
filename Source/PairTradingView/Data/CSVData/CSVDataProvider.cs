using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PairTradingView.Data.Entities;
using PairTradingView.DataProcessing;

namespace PairTradingView.Data.CSVData
{
    public class CSVDataProvider : IDataProvider
    {
        public string DirectoryPath { get; private set; }
        public CSVFormat CSVFormat { get; private set; }

        public CSVDataProvider(string path, CSVFormat format)
        {
            DirectoryPath = path;
            CSVFormat = format;
        }

        public List<Stock> GetStocks()
        {
            List<Stock> stocks = new List<Stock>();

            foreach (var file in Directory.EnumerateFiles(DirectoryPath))
            {
                var stockTicker = file.Replace(DirectoryPath, "").Replace(".txt", "").Replace(".csv", "").Replace("/","");

                var values = CSV.Read(file, CSVFormat);

                stocks.Add(new Stock
                {
                    Code = stockTicker,
                    History = values
                });
            }

            return stocks;
        }
    }
}
