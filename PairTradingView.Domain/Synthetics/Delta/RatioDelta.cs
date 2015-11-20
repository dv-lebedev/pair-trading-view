using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairTradingView.Synthetics
{
    public class RatioDelta : Delta
    {
        public override decimal[] GetValues(decimal[] x, decimal[] y, decimal r_value)
        {
            if (r_value >= 0)
            {
                return x.Zip(y, (i, j) => j / i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => (decimal)Math.Log10((double)j) * (decimal)Math.Log10((double)i)).ToArray();
            }
            
        }

        public override decimal GetValue(decimal x, decimal y, decimal r_value)
        {
            if (r_value >= 0)
            {
                return y / x;
            }
            else
            {
                return (decimal)(Math.Log10((double)y) * Math.Log10((double)x));
            }
        }
    }
}
