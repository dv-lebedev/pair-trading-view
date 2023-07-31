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
    public class AutoRegression : IRegression
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

        public AutoRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(double[] vectror, int lag)
        {
            if (vectror == null)
                throw new ArgumentNullException("vector");

            if (lag >= vectror.Length)
                throw new IndexOutOfRangeException("lag can't be more or equal x.Length");

            double[] x = new double[vectror.Length - lag];

            for(int i = 0; i < vectror.Length - lag; i++ )
            {
                x[i] = vectror[i];
            }

            double[] y = new double[vectror.Length - lag];

            for (int i = lag; i < vectror.Length; i++)
            {
                y[i - lag] = vectror[i];
            }

            RegressionMethod.Compute(y, x);
        }
    }
}
