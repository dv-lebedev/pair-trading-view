using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PairTradingView.Csv
{
    public static class CsvFile
    {
        public static decimal[] Read(string path, int priceIndex, bool containsHeader)
        {
            var lines = File.ReadAllLines(path);

            var result = new List<decimal>();

            int startlineCount = containsHeader ? 1 : 0;

            for (int i = startlineCount; i < lines.Length; i++)
            {
                string[] cuts = lines[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (cuts.Length == 0) 
                    throw new FormatException("Check csv files format.");

                result.Add(decimal.Parse(cuts[priceIndex], CultureInfo.InvariantCulture));
            }

            return result.ToArray();
        }
    }
}
