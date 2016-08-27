
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


using System;
using System.Collections.Generic;

namespace PairTradingView.Data
{
    public class InputData
    {
        public StockInfo StockInfo { get; }
        public IEnumerable<StockValue> History { get; }

        public InputData(StockInfo stockInfo, IEnumerable<StockValue> history)
        {
            if (stockInfo == null) throw new ArgumentNullException("stockInfo");
            if (history == null) throw new ArgumentNullException("history");

            StockInfo = stockInfo;
            History = history;
        }
    }
}
