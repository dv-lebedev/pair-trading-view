
/*
Copyright(c) 2015-2017 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Statistics;
using Statistics.Models;
using System;
using System.Linq;

namespace PairTradingView.Infrastructure
{
    public class RiskManager
    {
        private FinancialPair[] pairs;
        private double[] synthIndex;

        public double Balance { get; }

        public RiskManager(FinancialPair[] pairs, double balance)
        {
            Check.NotNull(pairs);

            if (balance < 0) throw new ArgumentException("[balance] can't have negative value.");

            this.pairs = pairs;
            Balance = balance;

            SetSynthIndex();
        }

        private void SetSynthIndex()
        {
            synthIndex = new double[pairs.First().DeltaValues.Length];

            for (int i = 0; i < pairs.First().DeltaValues.Length; i++)
            {
                double value = 0;

                for (int j = 0; j < pairs.Length; j++)
                {
                    value += pairs[j].DeltaValues[i];
                }

                synthIndex[i] += (value / pairs.Length);
            }
        }

        public void Calculate()
        {
            double summary = 0;

            foreach (var pair in pairs)
            {
                var regression = new LinearRegression();
                regression.Compute(pair.DeltaValues.ToDecimal(), synthIndex.ToDecimal());

                pair.Weight = 1 / (1 + Math.Abs(regression.Beta.ToDouble()));

                summary += pair.Weight;
            }

            foreach (var pair in pairs)
            {
                pair.Weight = pair.Weight / summary;
                pair.TradeVolume = Balance * pair.Weight;
            }

            foreach (var pair in pairs)
            {
                double beta = pair.Regression.Beta.ToDouble();
                double weight = 1.0 / (1.0 + Math.Abs(beta));

                pair.X.TradeVolume = pair.TradeVolume * (weight * Math.Abs(beta));
                pair.Y.TradeVolume = pair.TradeVolume * weight;
            }
        }
    }
}
