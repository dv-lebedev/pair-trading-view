using System;
using System.Linq;

namespace PairTradingView.Logic.Synthetics.DeltaCalculation
{
    public class SpreadBetaDelta : AbstractDelta
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
                return "if r_value >= 0: y - beta * x \nelse: y + beta * x";
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
                return x.Zip(y, (i, j) => j - Math.Abs(beta) * i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => j + Math.Abs(beta) * i).ToArray();
            }
        }

        public override double GetCurrentDelta(double x, double y, double beta = 0, double correlation = 0)
        {
            if (correlation >= 0)
            {
                return y - Math.Abs(beta) * x;
            }
            else
            {
                return y + Math.Abs(beta) * x;
            }
        }
    }
}
