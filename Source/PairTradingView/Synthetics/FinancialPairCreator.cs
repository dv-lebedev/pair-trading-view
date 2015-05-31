using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data.Entities;
using PairTradingView.Synthetics.DeltaCalculation;

namespace PairTradingView.Synthetics
{
    public class FinancialPairCreator
    {
        public static ICollection<FinancialPair> CreatePairs(List<Stock> stocks, AbstractDelta delta)
        {
            ICollection<FinancialPair> pairs = new List<FinancialPair>();

            for (int i = 0; i < stocks.Count; i++)
            {
                for (int j = i + 1; j < stocks.Count; j++)
                {

                    var xSecurity = stocks.ElementAt(i).History.Select(item => item.Price).ToArray();
                    var ySecurity = stocks.ElementAt(j).History.Select(item => item.Price).ToArray();

                    if (xSecurity != null && ySecurity != null)
                    {
                        var pair = new FinancialPair(xSecurity, ySecurity,
                                 new FinancialPairName(stocks.ElementAt(i).Code, stocks.ElementAt(j).Code),
                                 delta);

                        pairs.Add(pair);
                    }
                }
            }

            return pairs;
        }
    }
}
