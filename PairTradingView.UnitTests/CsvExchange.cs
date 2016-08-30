
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
using System.IO;
using System.Linq;

namespace PairTradingView.UnitTests
{
    public class CsvExchange : Exchange
    {
        private Random randomInfo;

        public Dictionary<string, List<StockValue>> StockValues { get; private set; }

        public CsvExchange()
            : base()
        {
            randomInfo = new Random();

            StockValues = new Dictionary<string, List<StockValue>>();

            foreach (var file in Directory.EnumerateFiles("csv-samples/"))
            {
                var name = Path.GetFileNameWithoutExtension(file);

                StockValues.Add(name, CsvUtils.Read(file));
            }
        }

        public override IEnumerable<StockInfo> GetAllStocksInfo()
        {
            var result = new List<StockInfo>();

            foreach (var item in StockValues)
            {
                var randomStockValue = item.Value[randomInfo.Next(item.Value.Count - 1)];

                var stockInfo = new StockInfo(item.Key, item.Key, "Shares", 1, randomStockValue.Price, randomStockValue.Volume);

                result.Add(stockInfo);
            }

            return result;
        }

        public override string[] GetMarketSymbols()
        {
            return StockValues.Keys.ToArray();
        }

        public override StockInfo GetStockInfo(string symbol)
        {
            var stockValues = StockValues[symbol];

            var randomStockValue = stockValues[randomInfo.Next(stockValues.Count - 1)];

            var stockInfo = new StockInfo(symbol, symbol, "Shares", 1, randomStockValue.Price, randomStockValue.Volume);

            return stockInfo;
        }

        public override IEnumerable<StockValue> GetValues(string symbol)
        {
            return StockValues[symbol];
        }

        public override IEnumerable<StockValue> GetValues(string symbol, int lastNRecords)
        {
            return StockValues[symbol].Skip(Math.Max(0, StockValues[symbol].Count - lastNRecords));
        }

        public override IEnumerable<StockValue> GetValues(string symbol, DateTime first, DateTime last)
        {
            return StockValues[symbol].Where(i => i.DateTime >= first && i.DateTime <= last);
        }

        public override bool IsHistoricalValuesExists(string symbol)
        {
            return StockValues.ContainsKey(symbol);
        }

        protected override void OnLoad()
        {
            //...
        }

        protected override void OnDisposed()
        {
            //...
        }

        public void StockInfoUpdated(StockInfo[] stockInfo)
        {
            foreach(var dataChannel in DataChannels.Values)
            {
                dataChannel.StockInfoUpdated(stockInfo);
            }
        }
    }
}
