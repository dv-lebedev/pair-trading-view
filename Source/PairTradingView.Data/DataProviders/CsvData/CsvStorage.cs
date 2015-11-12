using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PairTradingView.Data.DataProviders.Csv
{
    public class CsvStorage : IHistoryDataProvider
    {
        private string storageDirectoryPath;
        private CsvFormat csvFormat;

        private static readonly object _dataSaveLock = new object();

        public CsvStorage(string path)
        {
            storageDirectoryPath = path;

            if (!Directory.Exists(storageDirectoryPath))
                Directory.CreateDirectory(storageDirectoryPath);

            csvFormat = new CsvFormat
            {
                ContainsHeader = false,
                DateIndex = 0,
                TimeIndex = 0,
                DateTimeFormat = "yyyyMMddHHmmss",
                Separator = ',',
                PriceIndex = 1,
                VolumeIndex = 2
            };
        }

        private string GetPathOfStock(string code)
        {
            return Path.Combine(storageDirectoryPath, code);
        }

        private bool IsStockHistoryFileExists(string code)
        {
            return File.Exists(GetPathOfStock(code));
        }

        public IEnumerable<StockValue> GetValues(string code, int lastNRecords)
        {
            if (IsStockHistoryFileExists(code))
            {
                var lines = File.ReadLines(GetPathOfStock(code)).Reverse().Take(lastNRecords).Reverse().ToArray();

                return CsvFile.Convert(lines, csvFormat);
            }

            return null;
        }

        public IEnumerable<StockValue> GetValues(string code, DateTime first, DateTime last)
        {
            if (!IsStockHistoryFileExists(code)) return null;

            var values = new List<StockValue>();

            var dtFromInt = Convert.ToInt64(first.ToString("yyyyMMddHHmmss"));
            var dtToInt = Convert.ToInt64(last.ToString("yyyyMMddHHmmss"));

            using (var sr = new StreamReader(GetPathOfStock(code)))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    var date = Convert.ToInt64(line.Substring(0, 14));

                    if (date >= dtFromInt && date <= dtToInt)
                    {
                        values.Add(CsvFile.Convert(line, csvFormat));
                    }
                }
            }

            return values.Count > 0 ? values : null;
        }

        public IEnumerable<StockValue> GetValues(string code)
        {
            return IsStockHistoryFileExists(code) ? CsvFile.Convert(File.ReadAllLines(GetPathOfStock(code)), csvFormat) : null;
        }

        public string[] GetCodes()
        {
            return Directory.EnumerateFiles(storageDirectoryPath)
                .Select(i => Path.GetFileNameWithoutExtension(i))
                .ToArray();
        }

        public bool IsExist(string code)
        {
            return IsStockHistoryFileExists(code);
        }

        public void Save(string code, StockValue value)
        {
            lock (_dataSaveLock)
            {
                using (var sr = new StreamWriter(GetPathOfStock(code), true))
                {
                    sr.WriteLine(StockValueToString(value));
                }
            }
        }

        public void Save(string code, IEnumerable<StockValue> values)
        {
            lock (_dataSaveLock)
            {
                using (var sr = new StreamWriter(GetPathOfStock(code), true))
                {
                    foreach (var value in values)
                    {
                        sr.WriteLine(StockValueToString(value));
                    }
                }
            }
        }

        public string StockValueToString(StockValue value)
        {
            return string.Format("{0}, {1}, {2}",
                        value.DateTime.ToString("yyyyMMddHHmmss"),
                        value.Price.ToString(CultureInfo.InvariantCulture),
                        value.Volume);
        }

    }
}
