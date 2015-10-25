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

            if (provider == null) throw new NullReferenceException();
            if (delta == null) throw new NullReferenceException();

            var stocks = provider.GetStocks();

            if (stocks.Count < 2) throw new Exception("You should have 2 or more quotes histories to start working.");
            else
            {
                int historiesCount = stocks.First().History.Count;

                foreach (var item in stocks)
                {
                    if (historiesCount != item.History.Count)
                        throw new Exception("Quotes histories have different length.");
                }
            }

           
            StocksCount = stocks.Count;
            DeltaCalculation = delta;

            Items = new List<FinancialPair>(FinancialPairCreator.CreatePairs(stocks, delta));
        }
    }
}
