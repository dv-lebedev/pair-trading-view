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

namespace PairTradingView.Shared.Statistics
{
    public static class MovingAverages
    {
        public static double[] SMA(double[] values, int period)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (period > values.Length) throw new ArgumentException("period > values.Lenght");
            if (period <= 0) throw new ArgumentException("period <= 0");

            double[] result = new double[values.Length - (period - 1)];

            for (int i = 0; i < values.Length - (period - 1); i++)
            {
                for (int j = i; j < i + period; j++)
                {
                    result[i] += values[j];
                }

                result[i] /= period;
            }

            return result;
        }

        public static double[] WMA(double[] values, int period)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (period > values.Length) throw new ArgumentException("period > values.Lenght");
            if (period <= 0) throw new ArgumentException("period <= 0");

            long weight = 0;
            long weightSumm = 0;
            double[] result = new double[values.Length - (period - 1)];

            for (int i = 0; i < values.Length - (period - 1); i++)
            {
                for (int j = i; j < i + period; j++)
                {
                    result[i] += values[j] * ++weight;

                    weightSumm += weight;
                }

                result[i] /= weightSumm;

                weight = 0;

                weightSumm = 0;
            }

            return result;
        }

        public static double[] VMA(double[] values, long[] volumes, int period)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (volumes == null) throw new ArgumentNullException("volumes");
            if (period > values.Length) throw new ArgumentException("period > values.Lenght");
            if (values.Length != volumes.Length) throw new ArgumentException("values.Length != volumes.Length");
            if (period <= 0) throw new ArgumentException("period <= 0");

            long volumeSumm = 0;
            double[] result = new double[values.Length - (period - 1)];

            for (int i = 0; i < values.Length - (period - 1); i++)
            {
                for (int j = i; j < i + period; j++)
                {
                    volumeSumm += volumes[j];

                    result[i] += values[j] * volumes[j];
                }

                result[i] /= volumeSumm;

                volumeSumm = 0;
            }

            return result;
        }
    }
}
