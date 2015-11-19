using PairTradingView.Statistics;

namespace PairTradingView.RiskManagement
{
    public class RiskParameters
    {
        public LinearRegression Regression { get; set; }
        public decimal Weight { get; set; }
        public decimal TradeBalance { get; set; }
        public decimal YTradeBalance { get; set; }
        public decimal XTradeBalanace { get; set; }
    }
}
