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

        public double[] X { get; set; }
        public double[] Y { get; set; }

        public double XStandardDev { get; private set; }
        public double YStandardDev { get; private set; }
        public double DeltaStandardDev { get; private set; }

        public LinearRegressionModel Regression { get; set; }

        public IEnumerable<double> DeltaValues { get; set; }

        public FinancialPair(double[] x, double[] y, DeltaType delta)
        {
            Update(x, y, delta);
        }

        public void Update(double[] x, double[] y, DeltaType delta)
        {
            Regression = new LinearRegressionModel(x, y);

            XStandardDev = StdFuncs.StandardDeviation(x);
            YStandardDev = StdFuncs.StandardDeviation(y);


            switch (delta)
            {
                case DeltaType.Ratio:
                    DeltaValues = x.Zip(y, (i, j) => j / i);
                    break;

                case DeltaType.Spread:
                    DeltaValues = x.Zip(y, (i, j) => j - i);
                    break;
            }
            

            DeltaStandardDev = StdFuncs.StandardDeviation(DeltaValues.ToArray());
        }
    }
}
