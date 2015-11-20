using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairTradingView.Synthetics
{
    public class SpreadDelta : Delta
    {

        public override decimal[] GetValues(decimal[] x, decimal[] y, decimal r_value)
        {
            if (r_value >= 0)
            {
                return x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => j + i).ToArray();
            }
        }

        public override decimal GetValue(decimal x, decimal y, decimal r_value)
        {
            if (r_value >= 0)
            {
                return y - x;
            }
            else
            {
                return y + x;
            }
        }
    }
}
