
#region LICENSE

/*
Copyright(c) 2015-2016 Denis Lebedev

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

#endregion


using Statistics;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.RiskManagement;

namespace PairTradingView.Logic.Synthetics.Ratio
{
    public class RatioSynthetic : Synthetic
    {
        public RatioSynthetic(InputData[] inputData)
            : base(inputData)
        {
        }

        protected override void Initialize(InputData[] inputData)
        {
            InputData x = inputData[0];
            InputData y = inputData[1];

            SetName(x, y);

            Symbols = new[] { x.StockInfo.Symbol, y.StockInfo.Symbol };

            var xValues = x.History.Select(i => i.Price * x.StockInfo.Lot).ToArray();
            var yValues = y.History.Select(i => i.Price * y.StockInfo.Lot).ToArray();

            SetRegression(xValues, yValues);

            SetValues(xValues, yValues, ((LinearRegression)Regression).RValue);

            StdDevs = new decimal[2]
            {
                MathUtils.GetStandardDeviation(xValues),
                MathUtils.GetStandardDeviation(yValues)
            };
        }


        private void SetName(InputData x, InputData y)
        {
            Name = string.Format("{0}|{1}", y.StockInfo.Symbol, x.StockInfo.Symbol);
        }

        private void SetRegression(decimal[] x, decimal[] y)
        {
            Regression = new LinearRegression();
            Regression.RegressionMethod.Compute(y, x);
        }

        private void SetValues(decimal[] x, decimal[] y, decimal r)
        {
            if (r >= 0)
            {
                DeltaValues = x.Zip(y, (i, j) => j / i).ToArray();
            }
            else
            {
                DeltaValues = x.Zip(y, (i, j) =>
                (decimal)(Math.Log((double)j) * Math.Log((double)i)))
                .ToArray();
            }
        }

        public override void SetRiskParameters(RiskParameters riskParameters)
        {
            if (riskParameters == null)
                throw new ArgumentNullException("riskParameters");

            RiskParameters = riskParameters;

            decimal weight = 1.0M / (1.0M + Math.Abs(((LinearRegression)Regression).Beta));

            RiskParameters.SymbolsBalances.Add(Symbols[0], RiskParameters.Balance * (weight * Math.Abs(((LinearRegression)Regression).Beta)));
            RiskParameters.SymbolsBalances.Add(Symbols[1], RiskParameters.Balance * weight);

        }

        public override void StockInfoUpdated(IEnumerable<StockInfo> stockInfo)
        {
            var x = stockInfo.Where(i => i.Symbol == Symbols[0]).First();
            var y = stockInfo.Where(i => i.Symbol == Symbols[1]).First();

            if (((LinearRegression)Regression).RValue >= 0)
            {
                DeltaValue = (y.Price * y.Lot) / (x.Price * x.Lot);
            }
            else
            {
                DeltaValue = (
                    Math.Log((y.Price * y.Lot).ToDouble()) * 
                    Math.Log((x.Price * x.Lot).ToDouble()))
                    .ToDecimal();
            }
        }
    }
}
