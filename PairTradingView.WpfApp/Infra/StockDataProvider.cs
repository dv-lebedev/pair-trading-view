using PairTradingView.Shared;

namespace PairTradingView.WpfApp.Infra;

public class StockDataProvider : IStockDataProvider
{
    private Stock[] _stocks = [];

    public void Init(Stock[] stocks)
    {
        _stocks = stocks ?? throw new ArgumentNullException(nameof(stocks));
    }

    public IEnumerable<Stock> GetStocks()
    {
        return _stocks;
    }
}