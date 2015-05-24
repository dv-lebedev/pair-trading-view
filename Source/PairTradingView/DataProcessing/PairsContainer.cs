using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data;

namespace PairTradingView.DataProcessing
{
    public class PairsContainer
    {
        public int StocksCount { get; private set; }

        public DeltaType DeltaType { get; private set; }

        public List<FinancialPair> Items { get; private set; }

        public PairsContainer(IDataProvider provider, DeltaType type)
        {
            var stocks = provider.GetStocks();

            StocksCount = stocks.Count;

            Items = new List<FinancialPair>(FinancialPairCreator.CreatePairs(stocks, type));
        }

    }
}
