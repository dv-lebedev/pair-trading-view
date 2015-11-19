using System;

namespace PairTradingView.Statistics
{
    public static class MovingAverages
    {
        public static decimal[] SMA(decimal[] values, int period)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (period > values.Length) throw new ArgumentException("period > values.Lenght");
            if (period <= 0) throw new ArgumentException("period <= 0");

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

        public static decimal[] WMA(decimal[] values, int period)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (period > values.Length) throw new ArgumentException("period > values.Lenght");
            if (period <= 0) throw new ArgumentException("period <= 0");

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
    }
}
