using System;
using System.Linq;
using PairTradingView.RiskManagement;
using PairTradingView.Statistics;

namespace PairTradingView.Synthetics
{
    public class Synthetic
    {
        public SyntheticName Name { get; protected set; }
        public string Description { get; protected set; }
        public DeltaType Delta { get; protected set; }

        public decimal XStdDev { get; protected set; }
        public decimal YStdDev { get; protected set; }
        public decimal DeltaStdDev { get; protected set; }

        public LinearRegression Regression { get; protected set; }

        public decimal[] DeltaValues { get; protected set; }

        public RiskParameters RiskParameters { get; set; }


        public Synthetic(decimal[] x, decimal[] y, SyntheticName name, DeltaType delta)
        {
            this.Name = name;
            this.Delta = delta;

            Initialize(x, y);
        }

        protected void Initialize(decimal[] x, decimal[] y)
        {
            try
            {
                Regression = new LinearRegression(y, x);

                XStdDev = BasicFuncs.GetStandardDeviation(x);
                YStdDev = BasicFuncs.GetStandardDeviation(y);

                SetValues(x, y, Regression.RValue);

                DeltaStdDev = BasicFuncs.GetStandardDeviation(DeltaValues.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SpreadSynthetic::Init => {0}", ex.Message));
            }
        }

        private decimal[] GetSpreadValues(decimal[] x, decimal[] y, decimal r_value)
        {
            if (Regression.RValue >= 0)
            {
                return x.Zip(y, (i, j) => j - i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => j + i).ToArray();
            }
        }

        private decimal[] GetRatioValues(decimal[] x, decimal[] y, decimal r_value)
        {
            if (Regression.RValue>= 0)
            {
                return x.Zip(y, (i, j) => j / i).ToArray();
            }
            else
            {
                return x.Zip(y, (i, j) => (decimal)Math.Log10((double)j) * (decimal)Math.Log10((double)i)).ToArray();
            }
        }

        private void SetValues(decimal[] x, decimal[] y, decimal r_value)
        {
            switch (Delta)
            {
                case DeltaType.SPREAD:
                    DeltaValues = GetSpreadValues(x, y, r_value);
                    break;

                case DeltaType.RATIO:
                    DeltaValues = GetRatioValues(x, y, r_value);
                    break;
            }
        }


        private decimal GetSpread(decimal x, decimal y)
        {
            if (Regression.RValue >= 0)
            {
                return y - x;
            }
            else
            {
                return y + x;
            }
        }

        private decimal GetRatio(decimal x, decimal y)
        {
            if (Regression.RValue >= 0)
            {
                return y / x;
            }
            else
            {
                return (decimal)(Math.Log10((double)y) * Math.Log10((double)x));
            }
        }

        public decimal GetValue(decimal x, decimal y)
        {
            switch (Delta)
            {
                case DeltaType.SPREAD:
                    return GetSpread(x, y);

                case DeltaType.RATIO:
                    return GetRatio(x, y);

                default:
                    throw new Exception();
            }
        }
    }
}
