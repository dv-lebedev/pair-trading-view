using System;
using System.Collections.Generic;
using System.Linq;
using PairTradingView.Logic.Statistics.Models;
using PairTradingView.Logic.Synthetics;

namespace PairTradingView.Logic.RiskManagement
{
    public class RiskCalculation
    {

        private List<FinancialPair> _pairs;

        public double Balance { get; private set; }


        public RiskCalculation(List<FinancialPair> pairs, double balance)
        {
            if (pairs == null)
                throw new ArgumentNullException();

            if (balance < 0)
                throw new ArgumentException("Trade balance shouldn't be less then zero.");

            this._pairs = pairs;
            this.Balance = balance;
        }


        public void Calculate()
        {
            var synthIndex = GetSynthIndex();

            foreach (var item in _pairs)
            {
                item.RiskParameters = new RiskParameters
                {
                    Regression = new LinearRegression(synthIndex.ToArray(), item.DeltaValues.ToArray())
                };
            }

            double summary = 0;

            foreach (var item in _pairs)
            {
                item.RiskParameters.Weight = 1 / (1 + Math.Abs(item.RiskParameters.Regression.Beta));

                summary += item.RiskParameters.Weight;
            }

            foreach (var item in _pairs)
            {
                item.RiskParameters.Weight = item.RiskParameters.Weight / summary;
                item.RiskParameters.TradeBalance = this.Balance * item.RiskParameters.Weight;

                double w = 1 / (1 + Math.Abs( item.Regression.Beta));

                item.RiskParameters.YTradeBalance = item.RiskParameters.TradeBalance * w;
                item.RiskParameters.XTradeBalanace = item.RiskParameters.TradeBalance * (w * Math.Abs(item.Regression.Beta));

            }

        }


        private IEnumerable<double> GetSynthIndex()
        {

            int historicalValuesCount = _pairs.First().DeltaValues.Count();

            foreach (var item in _pairs)
            {
                if (historicalValuesCount != item.DeltaValues.Count())
                {
                    throw new ArgumentException("Delta Values have a different length.");
                }
            }

            var synthIndex = new List<double>();

            for (int i = 0; i < _pairs[0].DeltaValues.Count(); i++)
            {
                double value = 0;

                for (int j = 0; j < _pairs.Count; j++)
                {
                    value += _pairs[j].DeltaValues.ElementAt(i);
                }

                synthIndex.Add(value / _pairs.Count);
            }

            return synthIndex;
        }

    }
}
