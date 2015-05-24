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
using EmetricGears;
using EmetricGears.Models;

namespace PairTradingView.DataProcessing
{
    public class FinancialPair
    {
        public string XName { get; set; }
        public string YName { get; set; }

        public double XStdDev { get; private set; }
        public double YStdDev { get; private set; }
        public double DeltaStdDev { get; private set; }

        public DeltaType DeltaType { get; private set; }

        public LinearRegressionModel Regression { get; set; }

        public IEnumerable<double> DeltaValues { get; set; }

        public FinancialPair(double[] x, double[] y, DeltaType delta)
        {
            Update(x, y, delta);
        }

        public void Update(double[] x, double[] y, DeltaType delta)
        {
            DeltaType = delta;

            try
            {
                Regression = new LinearRegressionModel(x, y);

                XStdDev = StdFuncs.StandardDeviation(x);
                YStdDev = StdFuncs.StandardDeviation(y);

                DeltaValues = Delta.GetDeltaValues(x, y, Regression.Beta, Regression.Correlation, delta);

                DeltaStdDev = StdFuncs.StandardDeviation(DeltaValues.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double GetCurrentDelta(double x, double y)
        {
            return Delta.GetCurrentDelta(x, y, Regression.Beta, Regression.Correlation, DeltaType);
        }
    }
}
