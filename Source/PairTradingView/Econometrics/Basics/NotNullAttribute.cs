using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Econometrics.Basics
{
    public class NotNullAttribute : Attribute
    {
        public string Message { get; set; }
    }
}
