/*
Copyright 2015 Denis Lebedev

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

using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.RiskManagement;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Statistics;

namespace PairTradingView.Logic.Synthetics.Spread
{
    public class SpreadSynthetic : Synthetic
    {
        public SpreadSynthetic(InputData[] values)
            : base(values)
        {

            InputData x = values[0];
            InputData y = values[1];

            SetName(x, y);

            Symbols = new[] { x.StockInfo.Symbol, y.StockInfo.Symbol };

            var xValues = x.Values.Select(i => i.Price * x.StockInfo.Lot).ToArray();
            var yValues = y.Values.Select(i => i.Price * y.StockInfo.Lot).ToArray();

            SetRegression(xValues, yValues);

            SetValues(xValues, yValues, ((LinearRegression)Regression).RValue);

            StdDevs = new decimal[2] 
            {
                BasicFuncs.GetStandardDeviation(xValues),
                BasicFuncs.GetStandardDeviation(yValues)
            };
        }


        private void SetName(InputData x, InputData y)
        {
            Name = string.Format("{0}|{1}", y.StockInfo.Symbol, x.StockInfo.Symbol);
        }

        private void SetRegression(decimal[] x, decimal[] y)
        {
            Regression = new LinearRegression(x, y);
        }

        private void SetValues(decimal[] x, decimal[] y, decimal r)
        {
            if (r >= 0)
            {
                Values = x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                Values = x.Zip(y, (i, j) => j + i).ToArray();
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
                Value = (y.Price * y.Lot) - (x.Price * x.Lot);
            }
            else
            {
                Value = (y.Price * y.Lot) + (x.Price * x.Lot);
            }
        }
    }
}
