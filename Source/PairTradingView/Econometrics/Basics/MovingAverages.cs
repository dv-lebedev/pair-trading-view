using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data.Entities;

namespace PairTradingView.Econometrics.Basics
{
    public static class MovingAverages
    {
        public static double[] SMA(double[] values, int period)
        {

            if (period < 0) throw new Exception();


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

            if (period < 0) throw new Exception();


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


        public static double[] SMA(List<StockValue> values, int period)
        {
            return SMA(values.Select(i => i.Price).ToArray(), period);
        }


        public static double[] WMA(double[] values, int period)
        {
            if (period < 0) throw new Exception();

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
            if (period < 0) throw new Exception();

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


        public static double[] WMA(List<StockValue> values, int period)
        {
            return WMA(values.Select(i => i.Price).ToArray(), period);
        }


        public static double[] VMA(List<StockValue> values, int period)
        {
            if (period < 0) throw new Exception();

            long volumeSumm = 0;
            double[] result = new double[values.Count - (period - 1)];

            for (int i = 0; i < values.Count - (period - 1); i++)
            {
                for (int j = i; j < i + period; j++)
                {
                    volumeSumm += values[j].Volume;
                    result[i] += values[j].Price * values[j].Volume;
                }
                result[i] /= volumeSumm;
                volumeSumm = 0;
            }

            return result;
        }

    }
}
