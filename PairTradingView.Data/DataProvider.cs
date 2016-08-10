
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

using System;
using System.Collections.Generic;

namespace PairTradingView.Data
{
    public abstract class DataProvider : IDisposable, PairTradingView.Data.IHistoricalDataProvider, PairTradingView.Data.IMarketDataProvider
    {
        public Dictionary<string, DataChannel> DataChannels { get;  }

        public DataProvider()
        {
            DataChannels = new Dictionary<string, DataChannel>();

            OnLoad();
        }

        public virtual void AddDataChannel(string key, DataChannel channel)
        {
            DataChannels.Add(key, channel);
        }

        public virtual bool RemoveChannel(string key)
        {
            return DataChannels.Remove(key);
        }


        public abstract StockInfo GetStockInfo(string symbol);

        public abstract IEnumerable<StockInfo> GetAllStocksInfo();

        public abstract string[] GetMarketSymbols();


        public abstract IEnumerable<StockValue> GetValues(string symbol, int lastNRecords);

        public abstract IEnumerable<StockValue> GetValues(string symbol, DateTime first, DateTime last);

        public abstract IEnumerable<StockValue> GetValues(string symbol);

        public abstract bool IsHistoricalValuesExists(string symbol);

        protected abstract void OnLoad();

        protected abstract void OnDispose();

        protected virtual void OnStockInfoUpdated(IEnumerable<StockInfo> stockInfo)
        {
            foreach (var channel in DataChannels.Values)
            {
                channel.StockInfoUpdated(stockInfo);
            }
        }

        public virtual void Dispose()
        {
            OnDispose();
        }
    }
}
