using System;
using System.Collections.Generic;
using System.Linq;
using PairTradingView.Logic.RiskManagement;
using PairTradingView.Logic.Statistics;
using PairTradingView.Logic.Statistics.Models;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Logic.Synthetics
{
    public class FinancialPair
    {
        public FinancialPairName Name { get; private set; }

        public double XStdDev { get; private set; }
        public double YStdDev { get; private set; }
        public double DeltaStdDev { get; private set; }

        public AbstractDelta DeltaCalculation { get; private set; }

        public LinearRegression Regression { get; private set; }

        public IEnumerable<double> DeltaValues { get; private set; }

        public RiskParameters RiskParameters { get; set; }

        public FinancialPair(double[] x, double[] y, FinancialPairName name, AbstractDelta delta)
        {
            if (name == null) throw new ArgumentNullException();

            if (delta == null) throw new ArgumentNullException();

            Name = name;

            Update(x, y, delta);
        }

        public void Update(double[] x, double[] y, AbstractDelta delta)
        {
            DeltaCalculation = delta;

            try
            {
                Regression = new LinearRegression(y, x);

                XStdDev = StdFuncs.StandardDeviation(x);
                YStdDev = StdFuncs.StandardDeviation(y);

                DeltaValues = DeltaCalculation.GetDeltaValues(x, y, Regression.Beta, Regression.RValue);

                DeltaStdDev = StdFuncs.StandardDeviation(DeltaValues.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double GetCurrentDelta(double x, double y)
        {
            return DeltaCalculation.GetCurrentDelta(x, y, Regression.Beta, Regression.RValue);
        }
    }
}
