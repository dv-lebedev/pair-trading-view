using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PairTradingView.Logic.Synthetics;

namespace PairTradingView.Logic.Session
{
    public class CurrentDeltaValueEventArgs : EventArgs
    {
        public FinancialPairName Name { get; set; }
        public double Value { get; set; }
    }
}
