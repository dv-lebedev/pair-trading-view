using System;
using System.Collections.Generic;

namespace PairTradingView.Data.DataProviders
{
    public interface IHistoryDataProvider
    {
        IEnumerable<StockValue> GetValues(string code, int count);

        IEnumerable<StockValue> GetValues(string code, DateTime from, DateTime to);

        IEnumerable<StockValue> GetValues(string code);

        string[] GetCodes();

        bool IsExist(string code);

        void Save(string code, StockValue value);

        void Save(string code, IEnumerable<StockValue> values);
    }
}
