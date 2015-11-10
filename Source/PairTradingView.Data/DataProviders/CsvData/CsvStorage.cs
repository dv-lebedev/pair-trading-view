using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using PairTradingView.Data.Csv;

namespace PairTradingView.Data.DataProviders
{
    public class CsvStorage : IHistoryDataProvider
    {
        private string storeDirectoryPath;
        private CsvFormat csvFormat;

        private readonly object _lockObj = new object();

        public CsvStorage()
            : this("storage/")
        {

        }

        public CsvStorage(string path)
        {
            storeDirectoryPath = path;

            if (!Directory.Exists(storeDirectoryPath))
                Directory.CreateDirectory(storeDirectoryPath);

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


        public IEnumerable<StockValue> GetValues(string code, int count)
        {
            if (IsExist(code))
            {
                var lines = File.ReadLines(storeDirectoryPath + code).Reverse().Take(count).Reverse().ToArray();

                return CsvFile.Convert(lines, csvFormat);
            }

            return null;
        }

        public IEnumerable<StockValue> GetValues(string code, DateTime from, DateTime to)
        {
            if (!File.Exists(storeDirectoryPath + code))
                return null;

            var values = new List<StockValue>();

            var dtFromInt = Convert.ToInt64(from.ToString("yyyyMMddHHmmss"));
            var dtToInt = Convert.ToInt64(to.ToString("yyyyMMddHHmmss"));

            using (var sr = new StreamReader(storeDirectoryPath + code))
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
            return IsExist(code) ? CsvFile.Convert(File.ReadAllLines(storeDirectoryPath + code), csvFormat) : null;
        }

        public string[] GetCodes()
        {
            return Directory.EnumerateFiles(storeDirectoryPath)
                .Select(i => i.Replace(storeDirectoryPath, ""))
                .ToArray();
        }

        public bool IsExist(string code)
        {
            return File.Exists(storeDirectoryPath + code);
        }

        public void Save(string code, StockValue value)
        {
            lock (_lockObj)
            {
                using (var sr = new StreamWriter(storeDirectoryPath + code, true))
                {
                    sr.WriteLine(StockValueToString(value));
                }
            }
        }

        public void Save(string code, IEnumerable<StockValue> values)
        {
            lock (_lockObj)
            {
                using (var sr = new StreamWriter(storeDirectoryPath + code, true))
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
