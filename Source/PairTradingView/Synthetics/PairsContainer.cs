using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data;
using PairTradingView.RiskManagement;
using PairTradingView.Synthetics.DeltaCalculation;

namespace PairTradingView.Synthetics
{
    public class PairsContainer
    {
        public int StocksCount { get; private set; }

        public AbstractDelta DeltaCalculation { get; private set; }

        public List<FinancialPair> Items { get; private set; }

        public PairsContainer(IDataProvider provider, AbstractDelta delta)
        {
            var stocks = provider.GetStocks();

            StocksCount = stocks.Count;
            DeltaCalculation = delta;

            Items = new List<FinancialPair>(FinancialPairCreator.CreatePairs(stocks, delta));
        }
    }
}
