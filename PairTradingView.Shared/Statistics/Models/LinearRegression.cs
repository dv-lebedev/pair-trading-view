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

using PairTradingView.Shared.Statistics.Methods;
using System;

namespace PairTradingView.Shared.Statistics.Models
{
    public class LinearRegression : IRegression
    {
        public IRegressionMethod RegressionMethod { get; set; }

        public double Alpha
        {
            get { return RegressionMethod.Coefs[0]; }
        }

        public double Beta
        {
            get { return RegressionMethod.Coefs[1]; }
        }

        public double RValue
        {
            get { return RegressionMethod.RValues[0]; }
        }

        public double RSquared
        {
            get { return RegressionMethod.RSquaredValues[0]; }
        }

        public LinearRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(double[] y, double[] x)
        {
            if (y == null) throw new ArgumentNullException("y");
            if (x == null) throw new ArgumentNullException("x");
            if (x.Length != y.Length) throw new DifferentLengthException();

            RegressionMethod.Compute(y, x);
        }
    }
}
