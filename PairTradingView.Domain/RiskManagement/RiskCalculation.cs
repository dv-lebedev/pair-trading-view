using System;
using System.Collections.Generic;
using System.Linq;
using PairTradingView.Statistics;
using PairTradingView.Synthetics;

namespace PairTradingView.RiskManagement
{
    public class RiskCalculation
    {
        private List<Synthetic> synthetics;
        public decimal Balance { get; private set; }

        public RiskCalculation(List<Synthetic> synthetics, decimal balance)
        {
            if (synthetics == null)
                throw new ArgumentNullException("synthetics");

            if (balance <= 0)
                throw new ArgumentException("balance <= 0");

            this.synthetics = synthetics;
            this.Balance = balance;
        }


        public void Calculate()
        {
            var synthIndex = GetSynthIndex();

            foreach (var item in synthetics)
            {
                item.RiskParameters = new RiskParameters
                {
                    Regression = new LinearRegression(synthIndex.ToArray(), item.DeltaValues.ToArray())
                };
            }

            decimal summary = 0;

            foreach (var item in synthetics)
            {
                item.RiskParameters.Weight = 1 / (1 + Math.Abs(item.RiskParameters.Regression.Beta));

                summary += item.RiskParameters.Weight;
            }

            foreach (var item in synthetics)
            {
                item.RiskParameters.Weight = item.RiskParameters.Weight / summary;
                item.RiskParameters.TradeBalance = this.Balance * item.RiskParameters.Weight;

                decimal weight = 1.0M / (1.0M + Math.Abs(item.Regression.Beta));

                item.RiskParameters.YTradeBalance = item.RiskParameters.TradeBalance * weight;
                item.RiskParameters.XTradeBalanace = item.RiskParameters.TradeBalance * (weight * Math.Abs(item.Regression.Beta));
            }
        }


        private IEnumerable<decimal> GetSynthIndex()
        {

            int historicalValuesCount = synthetics.First().DeltaValues.Count();

            foreach (var item in synthetics)
            {
                if (historicalValuesCount != item.DeltaValues.Count())
                {
                    throw new ArgumentException("Delta Values have a different length.");
                }
            }

            var synthIndex = new List<decimal>();

            for (int i = 0; i < synthetics[0].DeltaValues.Count(); i++)
            {
                decimal value = 0;

                for (int j = 0; j < synthetics.Count; j++)
                {
                    value += synthetics[j].DeltaValues.ElementAt(i);
                }

                synthIndex.Add(value / synthetics.Count);
            }

            return synthIndex;
        }

    }
}
