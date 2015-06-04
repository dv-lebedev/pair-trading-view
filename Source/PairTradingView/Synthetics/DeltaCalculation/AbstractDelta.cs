using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Synthetics.DeltaCalculation
{
    public abstract class AbstractDelta
    {
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public abstract double[] GetDeltaValues(double[] x, double[] y, double beta = 0, double correlation = 0);

        public abstract double GetCurrentDelta(double x, double y, double beta = 0, double correlation = 0);

    }
}
