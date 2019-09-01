
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

using System;
using System.Linq;

namespace PairTradingView.Infrastructure
{
    public class Stock : ICloneable
    {
        public string Name { get; set; }
        public double[] Prices { get; set; }
        public double Deviation { get; set; }
        public double TradeVolume { get; set; }
        public double Weight { get; set; }

        public Stock Copy()
        {
            Stock stock = MemberwiseClone() as Stock;
            stock.Prices = Prices.ToArray();
            return stock;
        }

        public object Clone()
        {
            return Copy();
        }
    }
}
