using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Synthetics.DeltaCalculation
{
    public class RationIncludingBetaDelta : AbstractDelta
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
                return "if r_value >= 0: y / (beta * x) \nelse: log(y) * log(beta * x)";
            }
            protected set
            {
                base.Description = value;
            }
        }


        public override double[] GetDeltaValues(double[] x, double[] y, double beta, double correlation)
        {
            if (correlation >= 0)
            {
                return x.Zip(y, (i, j) => j / (Math.Abs(beta) * i)).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => Math.Log10(j) * Math.Log10(Math.Abs(beta) * i)).ToArray();
            }

        }

        public override double GetCurrentDelta(double x, double y, double beta, double correlation)
        {
            if (correlation >= 0)
            {
                return y / (Math.Abs(beta) * x);
            }
            else
            {
                return Math.Log10(y) * Math.Log10(Math.Abs(beta) * x);
            }
        }
    }
}
