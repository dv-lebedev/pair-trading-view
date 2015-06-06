using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Econometrics.Basics
{
    public class OrdinaryLeastSquares
    {
        public double[] Coefs { get; protected set; }

        public double[] RValues { get; protected set; }

        public double[] RSquaredValues { get; protected set; }

        public OrdinaryLeastSquares() { }

        public void Compute(double[] y, params double[][] xn)
        {
            double[] ones = new double[xn[0].Length];

            for (int i = 0; i < xn[0].Length; i++)
            {
                ones[i] = 1;
            }

            double[][] matrix = new double[xn.Length + 1][];

            matrix[0] = ones;

            for (int i = 1; i < matrix.Length; i++)
            {
                matrix[i] = xn[i - 1];
            }

            double[][] XX = Matrix.MatrixMatrix(matrix);

            double[] vector = Matrix.GetVector(matrix, y);

            Coefs = Matrix.MatrixVectorProduct(Matrix.MatrixInverse(XX), vector);

            RValues = new double[Coefs.Length - 1];
            RSquaredValues = new double[Coefs.Length - 1];

            double ySd = StdFuncs.StandardDeviation(y);

            for (int i = 0; i < RValues.Length; i++)
            {
                RValues[i] = Coefs[i + 1] * (StdFuncs.StandardDeviation(xn[i]) / ySd);

                RSquaredValues[i] = Math.Pow(RValues[i], 2);
            }
        }
    }
}
