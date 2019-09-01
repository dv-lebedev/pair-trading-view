
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

using PairTradingView.Infrastructure;
using System.Linq;

namespace PairTradingView.WpfApp.Entities
{
    public class ExtFinancialPair : FinancialPair
    {
        public ExtFinancialPair(Stock x, Stock y)
            : base(x, y)
        {
            DeltaAverage = (decimal)DeltaValues.Average();
            DeltaMax = (decimal)DeltaValues.Max();
            DeltaMin = (decimal)DeltaValues.Min();
            DeltaSD = (decimal)MathUtils.GetStandardDeviation(DeltaValues);
            SD_X = (decimal)X.Deviation;
            SD_Y = (decimal)Y.Deviation;
            DeltaSDMinus3Q = DeltaAverage - (3 * DeltaSD);
            DeltaSDPlus3Q = DeltaAverage + (3 * DeltaSD);
        }

        public bool Selected { get; set; }
        public decimal DeltaAverage { get; set; }
        public decimal DeltaMax { get; set; }
        public decimal DeltaMin { get; set; }
        public decimal DeltaSD { get; set; }
        public decimal SD_X { get; set; }
        public decimal SD_Y { get; set; }
        public decimal DeltaSDMinus3Q { get; set; }
        public decimal DeltaSDPlus3Q { get; set; }
    }
}
