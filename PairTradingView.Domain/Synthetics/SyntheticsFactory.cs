using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Synthetics
{
    public class SyntheticsFactory
    {
        private Dictionary<string, decimal[]> stocks;

        public SyntheticsFactory(Dictionary<string, decimal[]> stocks)
        {
            if (stocks == null) 
                throw new ArgumentNullException();

            if (stocks.Count < 2) 
                throw new Exception("You should have 2 or more quotes histories to start working.");
            else
            {
                int historiesCount = stocks.Values.First().Length;

                foreach (var item in stocks)
                {
                    if (historiesCount != item.Value.Length)
                        throw new Exception("Quotes histories have a different length.");
                }
            }

            this.stocks = stocks;   
        }


        public IEnumerable<Synthetic> CreateSynthetics(Delta delta)
        {
            ICollection<Synthetic> synthetics = new List<Synthetic>();

            for (int i = 0; i < stocks.Count; i++)
            {
                for (int j = i + 1; j < stocks.Count; j++)
                {

                    var pair = new Synthetic(stocks.ElementAt(i).Value, stocks.ElementAt(j).Value,
                             new SyntheticName(stocks.ElementAt(i).Key, stocks.ElementAt(j).Key), delta);

                    synthetics.Add(pair);
                }
            }

            return synthetics;
        }
    }
}
