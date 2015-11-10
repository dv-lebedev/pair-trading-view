using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Logic.Statistics
{

    public static class MovingAverages
    {
        public static double[] SMA(double[] values, int period)
        {

            if (period < 0) throw new ArgumentException("period < 0");


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

        public static decimal[] SMA(decimal[] values, int period)
        {

            if (period < 0) throw new ArgumentException("period < 0");


            decimal[] result = new decimal[values.Length - (period - 1)];

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
            if (period < 0) throw new ArgumentException("period < 0");

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

        public static decimal[] WMA(decimal[] values, int period)
        {
            if (period < 0) throw new ArgumentException("period < 0");

            long weight = 0;
            long weightSumm = 0;
            decimal[] result = new decimal[values.Length - (period - 1)];

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


        public static decimal[] VMA(decimal[] prices, long[] volumes, int period)
        {
            if (period < 0) throw new ArgumentException("period < 0");

            long volumeSumm = 0;
            decimal[] result = new decimal[prices.Length - (period - 1)];

            for (int i = 0; i < prices.Length - (period - 1); i++)
            {
                for (int j = i; j < i + period; j++)
                {
                    volumeSumm += volumes[j];
                    result[i] += prices[j] * volumes[j];
                }
                result[i] /= volumeSumm;
                volumeSumm = 0;
            }

            return result;           
        }

    }
}
