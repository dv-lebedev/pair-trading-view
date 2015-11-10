using System.Collections.Generic;

namespace PairTradingView.Data.DataProviders
{
    public interface IMarketDataProvider
    {
        StockInfo GetStock(string code);

        IEnumerable<StockInfo> GetStocks();
    }
}
