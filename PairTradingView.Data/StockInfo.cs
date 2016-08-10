
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

namespace PairTradingView.Data
{
    public class StockInfo
    {
        private string _symbol;
        private string _name;
        private string _type;
        private int _lot;
        private decimal _price;
        private long _volume;

        public string Symbol
        {
            get
            {
                return _symbol;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Symbol");

                if (value == string.Empty)
                    throw new ArgumentException("Symbol can't be equals emply string.", "Symbol");

                _symbol = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Name");

                if (value == string.Empty)
                    throw new ArgumentException("Name can't be equals emply string.", "Name");

                _name = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Type");

                if (value == string.Empty)
                    throw new ArgumentException("Type can't be equals emply string.", "Type");

                _type = value;
            }
        }

        public int Lot
        {
            get
            {
                return _lot;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Stocks lot can't be less or equals zero.", "Lot");

                _lot = value;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Stocks price can't be less or equals zero.", "Price");

                _price = value;
            }
        }

        public long Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Stocks volume can't be less than zero.", "Volume");

                _volume = value;
            }
        }

        public StockInfo(string symbol, string name, string type,
            int lot, decimal price, long volume)
        {
            Symbol = symbol;
            Name = name;
            Type = type;
            Lot = lot;
            Price = price;
            Volume = volume;
        }
    }
}