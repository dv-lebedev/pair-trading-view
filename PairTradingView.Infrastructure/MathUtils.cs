
/*
Copyright(c) 2015-2017 Denis Lebedev

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

namespace PairTradingView.Infrastructure
{
    public static class MathUtils
    {
        public static double GetStandardDeviation(double[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double[] arr = values.Select(i => i).ToArray();

            double result = 0;

            double average = arr.Average();

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow(arr[i] - average, 2);
            }
            return Math.Sqrt(result /= (arr.Length - 1));
        }
    }
}
