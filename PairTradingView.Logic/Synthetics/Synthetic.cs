
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


using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.RiskManagement;
using Statistics;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Logic.Synthetics
{
    public abstract class Synthetic : DataChannel
    {
        public string Name { get; protected set; }

        public IRegression Regression { get; set; }

        public virtual RiskParameters RiskParameters { get; set; }

        public decimal[] DeltaValues { get; protected set; }

        public virtual decimal DeltaValue { get; protected set; }

        public string[] Symbols { get; protected set; }

        public decimal[] StdDevs { get; protected set; }

        public Synthetic(Stock[] stocks)
        {
            if (stocks == null) throw new ArgumentNullException("stocks");

            Initialize(stocks);
        }

        protected virtual void Initialize(Stock[] stocks)
        {
            Stock x = stocks[0];
            Stock y = stocks[1];

            SetName(x, y);

            Symbols = new[] { x.Info.Symbol, y.Info.Symbol };

            var xValues = x.History.Select(i => i.Price * x.Info.Lot).ToArray();
            var yValues = y.History.Select(i => i.Price * y.Info.Lot).ToArray();

            SetRegression(xValues, yValues);

            SetValues(xValues, yValues);

            StdDevs = new decimal[2]
            {
                MathUtils.GetStandardDeviation(xValues),
                MathUtils.GetStandardDeviation(yValues)
            };
        }

        protected virtual void SetName(Stock x, Stock y)
        {
            Name = string.Format("{0}|{1}", y.Info.Symbol, x.Info.Symbol);
        }

        protected virtual void SetRegression(decimal[] x, decimal[] y)
        {
            Regression = new LinearRegression();
            Regression.RegressionMethod.Compute(y, x);
        }

        protected abstract void SetValues(decimal[] xValues, decimal[] yValues);
        public abstract void StockInfoUpdated(IEnumerable<StockInfo> stockInfo);
    }
}
