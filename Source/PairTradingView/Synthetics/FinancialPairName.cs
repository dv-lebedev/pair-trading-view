using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Synthetics
{
    public class FinancialPairName
    {
        public string X { get; private set; }
        public string Y { get; private set; }

        public FinancialPairName(string x, string y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return Y + "/" + X;
        }

    }
}
