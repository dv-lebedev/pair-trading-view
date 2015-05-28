using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data;
using PairTradingView.RiskManagement;

namespace PairTradingView.Synthetics
{
    public class PairsContainer
    {
        public int StocksCount { get; private set; }

        public DeltaType DeltaType { get; private set; }

        public List<FinancialPair> Items { get; private set; }

        public RiskCalculation RiskCalculation { get; private set; }

        public PairsContainer(IDataProvider provider, DeltaType type)
        {
            var stocks = provider.GetStocks();

            StocksCount = stocks.Count;
            DeltaType = type;

            Items = new List<FinancialPair>(FinancialPairCreator.CreatePairs(stocks, type));
        }


        public virtual void CalculateRisk(List<FinancialPairName> names)
        {
            foreach (var item in Items) item.RiskParameters = null;


            
        }

    }
}
