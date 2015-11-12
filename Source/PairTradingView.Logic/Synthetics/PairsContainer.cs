using System;
using System.Collections.Generic;
using System.Linq;
using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Logic.Synthetics
{
    public class PairsContainer
    {
        public int StocksCount { get; private set; }

        public AbstractDelta DeltaCalculation { get; private set; }

        public List<FinancialPair> Items { get; private set; }

        public PairsContainer(Dictionary<string, List<StockValue>> stocks, AbstractDelta delta)
        {

            if (stocks == null) throw new NullReferenceException();
            if (delta == null) throw new NullReferenceException();

            if (stocks.Count < 2) throw new Exception("You should have 2 or more quotes histories to start working.");
            else
            {
                int historiesCount = stocks.Values.First().Count;

                foreach (var item in stocks)
                {
                    if (historiesCount != item.Value.Count)
                        throw new Exception("Quotes histories have a different length.");
                }
            }
        
            StocksCount = stocks.Count;
            DeltaCalculation = delta;

            Items = new List<FinancialPair>(CreatePairs(stocks, delta));
        }

        public IEnumerable<FinancialPair> CreatePairs(Dictionary<string, List<StockValue>> stocks, AbstractDelta delta)
        {
            ICollection<FinancialPair> pairs = new List<FinancialPair>();

            for (int i = 0; i < stocks.Count; i++)
            {
                for (int j = i + 1; j < stocks.Count; j++)
                {

                    var xSecurity = stocks.ElementAt(i).Value.Select(item => (double)item.Price).ToArray();
                    var ySecurity = stocks.ElementAt(j).Value.Select(item => (double)item.Price).ToArray();

                    if (xSecurity != null && ySecurity != null)
                    {
                        var pair = new FinancialPair(xSecurity, ySecurity,
                                 new FinancialPairName(stocks.ElementAt(i).Key, stocks.ElementAt(j).Key),
                                 delta);

                        pairs.Add(pair);
                    }
                }
            }

            return pairs;
        }
    }
}
