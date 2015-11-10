using System.Collections.Generic;
using System.Linq;
using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Logic.Synthetics
{
    public class FinancialPairCreator
    {
        public static ICollection<FinancialPair> CreatePairs(Dictionary<string, List<StockValue>> stocks, AbstractDelta delta)
        {
            ICollection<FinancialPair> pairs = new List<FinancialPair>();

            for (int i = 0; i < stocks.Count; i++)
            {
                for (int j = i + 1; j < stocks.Count; j++)
                {

                    var xSecurity = stocks.ElementAt(i).Value.Select(item => (double) item.Price).ToArray();
                    var ySecurity = stocks.ElementAt(j).Value.Select(item => (double) item.Price).ToArray();

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
