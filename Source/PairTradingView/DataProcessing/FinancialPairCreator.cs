using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.SqlData.Entities;

namespace PairTradingView.DataProcessing
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
                    var pair = new FinancialPair(
                             Stocks.ElementAt(i).History.Select(item => item.Price).ToArray(),
                             Stocks.ElementAt(j).History.Select(item => item.Price).ToArray(),
                             DeltaType)
                    {
                        XName = Stocks.ElementAt(i).Code,
                        YName = Stocks.ElementAt(j).Code
                    };

                    pairs.Add(pair);
                }
            }

            return pairs;
        }
    }
}
