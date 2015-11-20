using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairTradingView.Synthetics
{
    public abstract class Delta
    {

        public virtual string Name 
        {
            get { return this.GetType().Name.Replace("Delta", ""); }
        }


        public abstract decimal[] GetValues(decimal[] x, decimal[] y, decimal r_value);

        public abstract decimal GetValue(decimal x, decimal y, decimal r_value);
    }
}
