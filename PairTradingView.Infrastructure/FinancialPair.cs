
/*
Copyright(c) 2015-2019 Denis Lebedev

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
    public class FinancialPair
    {
        public string Name => $"{Y.Name}|{X.Name}";

        public Stock X { get; }
        public Stock Y { get; }

        public LinearRegression Regression { get; set; }

        public double[] DeltaValues { get; protected set; }

        public double TradeVolume { get; set; }
        public double Weight { get; set; }

        public FinancialPair(Stock x, Stock y)
        {
            Check.NotNull(x, y);

            X = x;
            Y = y;

            SetRegression(x.Prices, y.Prices);
            SetValues();

            X.Deviation = MathUtils.GetStandardDeviation(x.Prices);
            Y.Deviation = MathUtils.GetStandardDeviation(y.Prices);
        }

        protected void SetRegression(double[] x, double[] y)
        {
            Regression = new LinearRegression();
            Regression.Compute(y.ToDecimal(), x.ToDecimal());
        }

        protected void SetValues()
        { 
            double[] x = X.Prices;
            double[] y = Y.Prices;

            if (Regression.RValue >= 0)
            {
                DeltaValues = x.Zip(y, (i, j) => j  - i * Regression.Beta.ToDouble()).ToArray();
            }
            else
            {
                DeltaValues = x.Zip(y, (i, j) => j  + i * Regression.Beta.ToDouble()).ToArray();
            }
        }

        public static List<T> CreateMany<T>(IEnumerable<Stock> stocks) where T: FinancialPair
        {
            var pairs = new List<T>();

            for (int i = 0; i < stocks.Count(); i++)
            {
                for (int j = i + 1; j < stocks.Count(); j++)
                {
                    Stock x = stocks.ElementAt(i).Copy();
                    Stock y = stocks.ElementAt(j).Copy();

                    pairs.Add((T)Activator.CreateInstance(typeof(T), new[] { x, y }));
                }
            }
            return pairs;
        }

        public static List<FinancialPair> CreateMany(IEnumerable<Stock> stocks) 
        {
            return CreateMany<FinancialPair>(stocks);
        }
    }
}
