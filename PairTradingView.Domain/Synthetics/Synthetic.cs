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
        public Delta Delta { get; protected set; }

        public decimal XStdDev { get; protected set; }
        public decimal YStdDev { get; protected set; }
        public decimal DeltaStdDev { get; protected set; }

        public LinearRegression Regression { get; protected set; }

        public decimal[] DeltaValues { get; protected set; }

        public RiskParameters RiskParameters { get; set; }


        public Synthetic(decimal[] x, decimal[] y, SyntheticName name, Delta delta)
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

        private void SetValues(decimal[] x, decimal[] y, decimal r_value)
        {
            DeltaValues = Delta.GetValues(x, y, Regression.RValue);
        }


        public decimal GetValue(decimal x, decimal y)
        {
            return Delta.GetValue(x, y, Regression.RValue);
        }
    }
}
