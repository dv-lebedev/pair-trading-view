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

            Items = new List<FinancialPair>(FinancialPairCreator.CreatePairs(stocks, delta));
        }
    }
}
