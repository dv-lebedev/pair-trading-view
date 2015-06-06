using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Econometrics.Basics
{
    public class DifferentLenghtsException : Exception
    {

        public override string Message
        {
            get
            {
                return "Arrays have different lengths";
            }
        }

    }
}
