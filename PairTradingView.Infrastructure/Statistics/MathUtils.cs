/*
Copyright(c) 2023 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/


using System;
using System.Linq;

namespace PairTradingView.Shared.Statistics
{
    public static class MathUtils
    {
        public static double[] GetError(double[] values)
        {
            double[] result = new double[values.Length - 1];

            for (int i = 1; i < values.Length; i++)
            {
                result[i - 1] = values[i] - values[i - 1];
            }

            return result;
        }

        public static double MultiplyArrays(double[] x, double[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            if (x.Length != y.Length)
                throw new DifferentLengthException();

            double result = 0;

            for (int i = 0; i < x.Length; i++)
            {
                result += x[i] * y[i];
            }

            return result;
        }

        public static double Pow(double value, double power)
        {
            return (double)Math.Pow((double)value, power);
        }

        public static double Pow(double[] values, double power)
        {
            if (values == null) throw new ArgumentNullException("values");

            double result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                result += Math.Pow(values[i], power);
            }

            return result;
        }

        public static double GetStandardDeviation(double[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double result = 0;

            double average = values.Average();

            for (int i = 0; i < values.Length; i++)
            {
                result += Math.Pow(values[i] - average, 2);
            }
            return Math.Sqrt(result /= (values.Length - 1));
        }

        public static double[] GetPercents(double[] prices)
        {
            if (prices == null) throw new ArgumentNullException(nameof(prices));
            if (prices.Length == 0) throw new ArgumentException(nameof(prices));

            double[] result = new double[prices.Length - 1];
            double first = prices[0];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (prices[i + 1] / first - 1.0) * 100.0;
            }
            return result;
        }
    }
}
