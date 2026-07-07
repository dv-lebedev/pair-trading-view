namespace PairTradingView.Shared;

public interface IStockDataProvider
{
    IEnumerable<Stock> GetStocks();
    void Init(Stock[] stocks);
}