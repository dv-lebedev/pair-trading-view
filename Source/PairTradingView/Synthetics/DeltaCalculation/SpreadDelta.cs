using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Synthetics.DeltaCalculation
{
    public class SpreadDelta : AbstractDelta
    {

        public override string Name
        {
            get
            {
                return this.GetType().Name;
            }
            protected set
            {
                base.Name = value;
            }
        }

        public override string Description
        {
            get
            {
                return "if r_value >= 0: y - x \nelse: y + x";
            }
            protected set
            {
                base.Description = value;
            }
        }

        public override double[] GetDeltaValues(double[] x, double[] y, double beta = 0, double correlation = 0)
        {
            if (correlation >= 0)
            {
                return x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => j + i).ToArray();
            }
        }

        public override double GetCurrentDelta(double x, double y, double beta = 0, double correlation = 0)
        {
            if (correlation >= 0)
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
