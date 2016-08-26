
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


using PairTradingView.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PairTradingView
{
    public class CsvFormat
    {
        public int PriceIndex { get; set; }
        public int DateTimeIndex { get; set; }
        public string DateTimeFormat { get; set; }
        public bool ContainsHeader { get; set; }
    }

    public class CsvHelper
    {
        public static List<StockValue> Read(string path, CsvFormat fmt)
        {
            var lines = File.ReadAllLines(path);

            var result = new List<StockValue>();

            int startlineCount = fmt.ContainsHeader ? 1 : 0;

            for (int i = startlineCount; i < lines.Length; i++)
            {
                string[] cuts = lines[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (cuts.Length == 0)
                    throw new FormatException("Check csv files format.");

                var value = new StockValue(
                    symbol: new Symbol(path),
                    dateTime: DateTime.ParseExact(cuts[fmt.DateTimeIndex], fmt.DateTimeFormat, CultureInfo.InvariantCulture),
                    price: decimal.Parse(cuts[fmt.PriceIndex], CultureInfo.InvariantCulture),
                    volume: 1);

                result.Add(value);
            }

            return result;
        }
    }
}
