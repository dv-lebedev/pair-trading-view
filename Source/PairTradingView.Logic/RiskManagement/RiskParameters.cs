using PairTradingView.Logic.Statistics.Models;

namespace PairTradingView.Logic.RiskManagement
{
    public class RiskParameters
    {


        public LinearRegression Regression { get; set; }

        public double Weight { get; set; }

        public double TradeBalance { get; set; }

        public double YTradeBalance { get; set; }

        public double XTradeBalanace { get; set; }

    }
}
