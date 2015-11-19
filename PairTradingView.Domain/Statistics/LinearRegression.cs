using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Statistics
{
    public class LinearRegression
    {
        public decimal Alpha { get; private set; }
        public decimal Beta { get; private set; }
        public decimal RValue { get; private set; }
        public decimal RSquared { get; private set; }

        public LinearRegression(decimal[] x, decimal[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            if (x.Length != y.Length)
                throw new DifferentLengthException();

            decimal xAverage = x.Average();
            decimal yAverage = y.Average();

            var s2x = (BasicFuncs.PowArray(x) / x.Length) - (decimal)Math.Pow((double)xAverage, 2);

            var cov_xy = (BasicFuncs.MultiplyArrays(x, y) / x.Length) - (xAverage * yAverage);

            Beta = cov_xy / s2x;

            Alpha = yAverage - (Beta * xAverage);

            RValue = Beta * (BasicFuncs.GetStandardDeviation(x) / BasicFuncs.GetStandardDeviation(y));

            RSquared = (decimal)Math.Pow((double)RValue, 2);
        }
    }
}
