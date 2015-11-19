using System;
using System.Linq;

namespace PairTradingView.Statistics
{
    public static class BasicFuncs
    {
        public static decimal GetStandardDeviation(decimal[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double[] arr = values.Select(i => (double)i).ToArray();

            double result = 0;

            double average = arr.Average();

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow(arr[i] - average, 2);
            }
            return (decimal)Math.Sqrt(result /= arr.Length);
        }

        public static decimal MultiplyArrays(decimal[] x, decimal[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            if (x.Length != y.Length)
                throw new DifferentLengthException();

            decimal result = 0;

            for (int i = 0; i < x.Length; i++)
            {
                result += x[i] * y[i];
            }

            return result;
        }

        public static decimal PowArray(decimal[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                result += Math.Pow((double)values[i], 2);
            }

            return (decimal)result;
        }
    }
}
