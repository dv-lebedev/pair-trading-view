using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data.Entities;

namespace PairTradingView.Synthetics
{
    public class FinancialPairCreator
    {
        public static ICollection<FinancialPair> CreatePairs(List<Stock> Stocks, DeltaType DeltaType)
        {
            ICollection<FinancialPair> pairs = new List<FinancialPair>();

            for (int i = 0; i < Stocks.Count; i++)
            {
                for (int j = i + 1; j < Stocks.Count; j++)
                {

                    var xSecurity = Stocks.ElementAt(i).History.Select(item => item.Price).ToArray();
                    var ySecurity = Stocks.ElementAt(j).History.Select(item => item.Price).ToArray();

                    if (xSecurity != null && ySecurity != null)
                    {
                        var pair = new FinancialPair(xSecurity, ySecurity,
                                 new FinancialPairName(Stocks.ElementAt(i).Code, Stocks.ElementAt(j).Code),
                                 DeltaType);

                        pairs.Add(pair);
                    }
                }
            }

            return pairs;
        }
    }
}
