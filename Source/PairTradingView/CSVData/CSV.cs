#region LICENSE
//Copyright (c) 2015 Denis V Lebedev

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PairTradingView.SqlData.Entities;

namespace PairTradingView.CSVData
{
    public static class CSV
    {
        public static List<StockValue> Read(string path, CSVFormat format)
        {
            List<StockValue> result = null;

            try
            {
                result = new List<StockValue>();

                string[] lines = File.ReadAllLines(path);

                int i = format.ContainsHeader ? 1 : 0;

                for (i = 0; i < lines.Length; i++)
                {
                    string[] cuts = lines[i].Split(new[] { format.Separator }, StringSplitOptions.RemoveEmptyEntries);

                    result.Add(new StockValue
                    {
                        Price = double.Parse(cuts[format.PriceIndex], CultureInfo.InvariantCulture),

                        Volume = long.Parse(cuts[format.VolumeIndex], CultureInfo.InvariantCulture)
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public static ICollection<Stock> LoadDataFromDirectory(string path, CSVFormat format)
        {
            ICollection<Stock> stocks = new List<Stock>();

            foreach (var file in Directory.EnumerateFiles(path))
            {
                var stockTicker = file.Replace(path, "").Replace(".txt", "").Replace(".csv", "");

                var values = CSV.Read(file, format);

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
