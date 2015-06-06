using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Econometrics.Basics;

namespace PairTradingView.Econometrics.Models
{
    public class LogitRegression
    {

        private OrdinaryLeastSquares ols = null;


        public double[] Coefs
        {
            get { return ols.Coefs; }
        }

        public double[] RValues
        {
            get { return ols.RValues; }
        }

        public double[] RSquaredValues
        {
            get { return ols.RSquaredValues; }
        }


        public LogitRegression()
        {
            ols = new OrdinaryLeastSquares();
        }


        public LogitRegression(bool[] y, params double[][] xn)
            : this()
        {
            this.Compute(y.Select(i => Convert.ToDouble(i)).ToArray(), xn);
        }


        public LogitRegression(double[] y, params double[][] xn)
            : this()
        {
            this.Compute(y, xn);
        }


        public void Compute(bool[] y, double[][] xn)
        {
            ols.Compute(y.Select(i => Convert.ToDouble(i)).ToArray(), xn);
        }


        public void Compute(double[] y, double[][] xn)
        {
            ols.Compute(y, xn);
        }


        public double PredictValue(params double[] xValues)
        {
            if (xValues.Length != Coefs.Length - 1)
                throw new DifferentLenghtsException();


            double y = Coefs[0];

            for (int i = 0; i < xValues.Length; i++)
            {
                y += Coefs[i + 1] * xValues[i];
            }

            return 1 / (1 + Math.Pow(Math.E, -y));
        }

        public bool TryPredictValue(out double result, params double[] xValues)
        {
            result = 0;

            if (xValues.Length == Coefs.Length - 1)
            {
                result = PredictValue(xValues);

                return true;
            }

            return false;
        }

    }
}
