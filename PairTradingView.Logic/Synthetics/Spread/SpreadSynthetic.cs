
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
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Statistics;

namespace PairTradingView.Logic.Synthetics.Spread
{
    public class SpreadSynthetic : Synthetic
    {
        public SpreadSynthetic(Stock[] stocks)
            : base(stocks)
        {
        }

        protected override void SetValues(decimal[] x, decimal[] y)
        {
            if (((LinearRegression)Regression).RValue >= 0)
            {
                DeltaValues = x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                DeltaValues = x.Zip(y, (i, j) => j + i).ToArray();
            }
        }

        public override void StockInfoUpdated(IEnumerable<StockInfo> stockInfo)
        {
            var x = stockInfo.Where(i => i.Symbol == Symbols[0]).First();
            var y = stockInfo.Where(i => i.Symbol == Symbols[1]).First();

            if (((LinearRegression)Regression).RValue >= 0)
            {
                DeltaValue = (y.Price * y.Lot) - (x.Price * x.Lot);
            }
            else
            {
                DeltaValue = (y.Price * y.Lot) + (x.Price * x.Lot);
            }
        }
    }
}
