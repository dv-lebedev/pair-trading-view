using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace PairTradingView.Data.DataProviders.Csv
{
    public static class CsvFile
    {
        public static List<StockValue> Read(string path, CsvFormat format)
        {
            return Convert(File.ReadAllLines(path), format);
        }

        public static List<StockValue> Convert(string[] lines, CsvFormat format)
        {
            var result = new List<StockValue>();         

            int startlineCount = format.ContainsHeader ? 1 : 0;

            for (int i = startlineCount; i < lines.Length; i++)
            {
                result.Add(Convert(lines[i], format));
            }

            return result;
        }

        public static StockValue Convert(string line, CsvFormat format)
        {
            string[] cuts = line.Split(new[] { format.Separator }, StringSplitOptions.RemoveEmptyEntries);

            if (cuts.Length == 0) throw new FormatException();

            var value = new StockValue();   

            value.Price = decimal.Parse(cuts[format.PriceIndex], CultureInfo.InvariantCulture);
            value.Volume = long.Parse(cuts[format.VolumeIndex], CultureInfo.InvariantCulture);

            string dateTimeStr;

            if (format.DateIndex == format.TimeIndex)
            {
                dateTimeStr = cuts[format.DateIndex];
            }
            else
            {
                dateTimeStr = cuts[format.DateIndex] + " " + cuts[format.TimeIndex];
            }

            value.DateTime = DateTime.ParseExact(dateTimeStr, format.DateTimeFormat, CultureInfo.InvariantCulture);

            return value;
        }
    }
}
