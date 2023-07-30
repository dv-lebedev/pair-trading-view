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
using System.Linq;

namespace PairTradingView.Shared.Statistics.Models
{
    public class LogitRegression : IRegression
    {

        public IRegressionMethod RegressionMethod { get; set; }

        public double[] Coefs
        {
            get { return RegressionMethod.Coefs; }
        }

        public double[] RValues
        {
            get { return RegressionMethod.RValues; }
        }

        public double[] RSquaredValues
        {
            get { return RegressionMethod.RSquaredValues; }
        }

        public LogitRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(bool[] y, params double[][] xn)
        {
            RegressionMethod.Compute(y.Select(i => Convert.ToDouble(i)).ToArray(), xn);
        }

        public double PredictValue(params double[] xValues)
        {
            if (xValues.Length != Coefs.Length - 1)
                throw new DifferentLengthException();

            double y = Coefs[0];

            for (int i = 0; i < xValues.Length; i++)
            {
                y += Coefs[i + 1] * xValues[i];
            }

            return (1 / (1 + Math.Pow(Math.E, -y)));
        }

        public bool TryPredictValue(out double result, params double[] xValues)
        {
            result = 0;

            if (xValues.Length == Coefs.Length - 1)
            {
                result = PredictValue(xValues);

                return true;
            }

            return false;
        }
    }
}
