
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PairTradingView.Infrastructure
{
    public static class CsvUtils
    {
        public static Stock[] ReadAllDataFrom(string directory, int priceIndex, bool containsHeader)
        {
            Check.NotNull(directory);

            if (priceIndex < 0) throw new ArgumentException("[priceIndex] can't be less than 0.");

            List<Stock> stocks = new List<Stock>();

            foreach (string file in Directory.EnumerateFiles(directory))
            {
                if (file.EndsWith(".txt") || file.EndsWith(".csv"))
                {
                    Stock stock = Read(file, priceIndex, containsHeader);

                    stocks.Add(stock);
                }
            }

            if(stocks.Count == 0)
            {
                throw new Exception("Files are not found.");
            }

            return stocks.ToArray();
        }

        public static Stock Read(string path, int priceIndex, bool containsHeader)
        {
            string[] lines = File.ReadAllLines(path);

            List<double> result = new List<double>();

            int startlineCount = containsHeader ? 1 : 0;

            for (int i = startlineCount; i < lines.Length; i++)
            {
                string[] cuts = lines[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (cuts.Length == 0)
                    throw new FormatException("Check csv files format.");

                double price = double.Parse(cuts[priceIndex], CultureInfo.InvariantCulture);

                if (price <= 0)
                {
                    throw new FormatException($" price = {price} in {path}");
                }
                result.Add(price);
            }

            string name = Path.GetFileNameWithoutExtension(path);

            return new Stock { Name = name, Prices = result.ToArray() };
        }
    }
}
