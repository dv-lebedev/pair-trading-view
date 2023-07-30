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

namespace PairTradingView.Shared
{
    public static class MathUtils
    {
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
