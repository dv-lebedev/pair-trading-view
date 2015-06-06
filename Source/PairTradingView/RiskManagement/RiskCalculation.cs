using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Synthetics;

namespace PairTradingView.RiskManagement
{
    public class RiskCalculation
    {

        private List<FinancialPair> Pairs { get; set; }

        public double TradeBalance { get; private set; }


        public RiskCalculation(List<FinancialPair> pairs, double tradeBalance)
        {
            if (pairs == null)
                throw new ArgumentNullException();

            this.Pairs = pairs;
            this.TradeBalance = tradeBalance;
        }


        public void Calculate()
        {
            this.Calculate(TradeBalance);
        }


        public void Calculate(double tradeBalance)
        {
            this.TradeBalance = tradeBalance;

            var synthIndex = GetSynthIndex(Pairs);

            foreach (var item in Pairs)
            {
                item.RiskParameters = new RiskParameters
                {
                    Regression = new EmetricGears.Models.LinearRegressionModel(item.DeltaValues.ToArray(), synthIndex.ToArray())
                };
            }

            double summary = 0;

            foreach (var item in Pairs)
            {
                item.RiskParameters.Weight = 1 / (1 + Math.Abs(item.RiskParameters.Regression.Beta));

                summary += item.RiskParameters.Weight;
            }

            foreach (var item in Pairs)
            {
                item.RiskParameters.Weight = item.RiskParameters.Weight / summary;
                item.RiskParameters.TradeBalance = this.TradeBalance * item.RiskParameters.Weight;

                double w = 1 / (1 + Math.Abs( item.Regression.Beta));

                item.RiskParameters.YTradeBalance = item.RiskParameters.TradeBalance * w;
                item.RiskParameters.XTradeBalanace = item.RiskParameters.TradeBalance * (w * Math.Abs(item.Regression.Beta));

            }

        }


        public IEnumerable<double> GetSynthIndex(List<FinancialPair> pairs)
        {

            int historicalValuesCount = pairs.First().DeltaValues.Count();

            foreach (var item in pairs)
            {
                if (historicalValuesCount != item.DeltaValues.Count())
                {
                    throw new ArgumentException("Delta Values have a different length.");
                }
            }

            var synthIndex = new List<double>();


            for (int i = 0; i < pairs[0].DeltaValues.Count(); i++)
            {
                double value = 0;

                for (int j = 0; j < pairs.Count; j++)
                {
                    value += pairs[j].DeltaValues.ElementAt(i);
                }

                synthIndex.Add(value / pairs.Count);
            }

            return synthIndex;
        }

    }
}
