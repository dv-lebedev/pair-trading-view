using System;

namespace PairTradingView.Data
{
    public class StockValue
    {
        public DateTime DateTime { get; set; }

        public decimal Price { get; set; }

        public long Volume { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as StockValue;

            if (item == null)
            {
                return false;
            }

            return (DateTime == DateTime) &&
                (Price == Price) &&
                (Volume == Volume);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
