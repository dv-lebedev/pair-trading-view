namespace PairTradingView.Logic.Statistics.Models
{

    public class MultipleLinearRegression 
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


        public MultipleLinearRegression() 
        {
            ols = new OrdinaryLeastSquares();
        }


        public MultipleLinearRegression(double[] y, params double[][] xn)
            : this()
        {
            this.Compute(y, xn);
        }


        public void Compute(double[] y, params double[][] xn)
        {
            ols.Compute(y, xn);
        }

    }
}
