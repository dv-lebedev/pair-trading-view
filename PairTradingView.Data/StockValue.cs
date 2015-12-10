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

using System;

namespace PairTradingView.Data
{
    public class StockValue
    {
        private string symbol;
        private DateTime dateTime;
        private decimal price;
        private long volume;

        public string Symbol
        {
            get
            {
                return symbol;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Symbol");

                if (value == string.Empty)
                    throw new ArgumentException("Symbol can't be equals emply string.", "Symbol");

                symbol = value;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            private set
            {
                dateTime = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Stocks price can't be less or equals zero.", "Price");

                price = value;
            }
        }

        public long Volume
        {
            get
            {
                return volume;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Stocks volume can't be less than zero.", "Volume");

                volume = value;
            }
        }

        public StockValue(string symbol, DateTime dateTime, decimal price, long volume)
        {
            Symbol = symbol;
            DateTime = dateTime;
            Price = price;
            Volume = volume;
        }
    }
}
