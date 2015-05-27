using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmetricGears.Models;

namespace PairTradingView.RiskManagement
{
    public class RiskParameters
    {
        public bool IsActive { get; set; }

        public LinearRegressionModel Regression { get; set; }

        public double Weight { get; set; }

        public double TradeBalance { get; set; }

        public double YTradeBalance { get; set; }

        public double XTradeBalanace { get; set; }

    }
}
