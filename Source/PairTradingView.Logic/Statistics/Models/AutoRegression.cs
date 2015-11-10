﻿using System.Linq;

namespace PairTradingView.Logic.Statistics.Models
{

    public class AutoRegression : OrdinaryLeastSquares
    {

        private OrdinaryLeastSquares ols = null;

        public double Alpha
        {
            get { return ols.Coefs[0]; }
        }

        public double Beta
        {
            get { return ols.Coefs[1]; }
        }

        public double RValue
        {
            get { return ols.RValues[0]; }
        }

        public double RSquared
        {
            get { return ols.RSquaredValues[0]; }
        }


        /// <summary>
        /// AutoRegression
        /// Y = Alpha + Beta * Y_t-i + error_t
        /// </summary>
        public AutoRegression()
        {
            ols = new OrdinaryLeastSquares();
        }


        /// <summary>
        /// AutoRegression
        /// Y = Alpha + Beta * Y_t-i + error_t
        /// </summary>
        public AutoRegression(double[] x, int i)
            : this()
        {
            this.Compute(x, i);
        }


        public void Compute(double[] x, int i)
        {
            if (i > x.Length - 1)
                throw new System.IndexOutOfRangeException("'i' can't be more or equal x.Length");

            double[] _x = x.ToList().GetRange(0, x.Length - i).ToArray();

            double[][] xn = new double[i][];

            for (int j = 0; j < i; j++)
            {
                xn[j] = x.ToList().GetRange(j + 1, x.Length - i).ToArray();
            }

            ols.Compute(_x, xn);  
        }

    }
}
