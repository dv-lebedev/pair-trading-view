using System;
using System.Linq;

namespace PairTradingView.Logic.Statistics
{
    public static class StdFuncs
    {
        public static double StandardDeviation(double[] values)
        {
            double result = 0;

            double average = values.Average();

            for (int i = 0; i < values.Length; i++)
            {
                result += Math.Pow(values[i] - average, 2);
            }

            return Math.Sqrt(result /= values.Length);
        }

        public static decimal StandardDeviation(decimal[] values)
        {
            decimal result = 0;

            decimal average = values.Average();

            for (int i = 0; i < values.Length; i++)
            {
                result += (decimal)Math.Pow((double)(values[i] - average), 2);
            }

            return (decimal) Math.Sqrt((double)(result /= values.Length));
        }

        public static double DurbinWatson(double[] values)
        {
            double numerator = 0;
            double denominator = 0;

            for (int i = values.Length - 1; i > 0; i--)
            {
                numerator += Math.Pow(values[i] - values[i - 1], 2);
            }

            for (int i = values.Length - 1; i > -1; i--)
            {
                denominator += Math.Pow(values[i] - values.Average(), 2);
            }

            return numerator / denominator;
        }

        public static double Multi(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new Exception("Arrays have different lengths.");

            double result = 0;

            for (int i = 0; i < x.Length; i++)
            {
                result += x[i] * y[i];
            }

            return result;
        }


        public static double[] GetErrors(double[] vector, int period)
        {

            if (period < 0) 
                throw new Exception("period can't be less than 0.");

            if (period >= vector.Length)
                throw new Exception("Too big period.");
           
            double[] result = new double[vector.Length - (period)];

            for (int i = 0; i < vector.Length - (period); i++)
            {
                result[i] = vector[i + period] - vector[i];
            }

            return result;
        }

        public static decimal[] GetErrors(decimal[] vector, int period)
        {
            if (period < 0)
                throw new Exception("period can't be less than 0.");

            if (period >= vector.Length)
                throw new Exception("Too big period.");

            decimal[] result = new decimal[vector.Length - (period)];

            for (int i = 0; i < vector.Length - (period); i++)
            {
                result[i] = vector[i + period] - vector[i];
            }

            return result;
        }

    }
}
