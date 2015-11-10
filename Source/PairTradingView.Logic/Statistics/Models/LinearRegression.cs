using System;

namespace PairTradingView.Logic.Statistics.Models
{

    /// <summary>
    /// Classical Normal Linear Regression
    /// 
    /// y = Alpha + Beta * x + error_t
    /// </summary>
    public class LinearRegression
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


        public LinearRegression()
        {
            ols = new OrdinaryLeastSquares();
        }


        public LinearRegression(double[] y, double[] x)
            : this()
        {
            this.Compute(y, x);
        }


        public void Compute(double[] y, double[] x)
        {
            if (y.Length != x.Length)
                throw new Exception("Arrays have different lengths.");

            ols.Compute(y, x);
        }
       
    }
}
