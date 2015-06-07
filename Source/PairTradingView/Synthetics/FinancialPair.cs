#region LICENSE
//Copyright (c) 2015 Denis V Lebedev

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.Econometrics.Basics;
using PairTradingView.Econometrics.Models;
using PairTradingView.RiskManagement;
using PairTradingView.Synthetics.DeltaCalculation;

namespace PairTradingView.Synthetics
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
