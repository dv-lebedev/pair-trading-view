
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

using Statistics;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Infrastructure
{
    public enum DeltaType { Spread, Ratio };

    public class FinancialPair
    {
        public string Name => $"{Y.Name}|{X.Name}";

        public Stock X { get; }
        public Stock Y { get; }

        public LinearRegression Regression { get; set; }

        public DeltaType DeltaType { get; set; }
        public double[] DeltaValues { get; protected set; }

        public double TradeVolume { get; set; }
        public double Weight { get; set; }

        public FinancialPair(Stock x, Stock y, DeltaType deltaType)
        {
            X = x;
            Y = y;
            DeltaType = deltaType;

            SetRegression(x.Prices, y.Prices);
            SetValues(X.Prices, Y.Prices);

            X.Deviation = MathUtils.GetStandardDeviation(x.Prices);
            Y.Deviation = MathUtils.GetStandardDeviation(y.Prices);
        }

        protected void SetRegression(double[] x, double[] y)
        {
            Regression = new LinearRegression();
            Regression.Compute(x.ToDecimal(), y.ToDecimal());
        }

        protected void SetValues(double[] x, double[] y)
        {
            switch (DeltaType)
            {
                case DeltaType.Ratio: SetValuesAsRatios(x, y); break;
                case DeltaType.Spread: SetValuesAsSpreads(x, y); break;
            }
        }

        private void SetValuesAsRatios(double[] x, double[] y)
        {
            if (Regression.RValue >= 0)
            {
                DeltaValues = x.Zip(y, (i, j) => j / i).ToArray();
            }
            else
            {
                DeltaValues = x.Zip(y, (i, j) => Math.Log(j) * Math.Log(i)).ToArray();
            }
        }

        private void SetValuesAsSpreads(double[] x, double[] y)
        {
            if (Regression.RValue >= 0)
            {
                DeltaValues = x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                DeltaValues = x.Zip(y, (i, j) => j + i).ToArray();
            }
        }

        public static List<FinancialPair> CreateMany(Stock[] stocks, DeltaType deltaType)
        {
            var pairs = new List<FinancialPair>();

            for (int i = 0; i < stocks.Count(); i++)
            {
                for (int j = i + 1; j < stocks.Count(); j++)
                {
                    Stock xStock = stocks[i];
                    Stock yStock = stocks[j];

                    Stock x = new Stock { Name = xStock.Name, Prices = xStock.Prices.ToArray() };
                    Stock y = new Stock { Name = yStock.Name, Prices = yStock.Prices.ToArray() };

                    pairs.Add(new FinancialPair(x, y, deltaType));
                }
            }
            return pairs;
        }
    }
}
