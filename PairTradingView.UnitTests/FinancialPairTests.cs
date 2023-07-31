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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Shared;
using PairTradingView.Shared.Statistics.Models;
using System.Linq;

namespace PairTradingView.UnitTests
{
    [TestClass()]
    public class FinancialPairTests
    {
        [TestMethod()]
        public void FinancialPairTest()
        {
            Stock aapl = CsvUtils.Read("csv-samples/AAPL.txt", 4, false);
            Stock xom = CsvUtils.Read("csv-samples/XOM.txt", 4, false);

            FinancialPair pair = new FinancialPair(aapl, xom);

            CheckStocks(pair);
            CheckName(pair);
            CheckDeviations(pair);
            CheckDeltaValues(pair);
            CheckRegression(pair.Regression);
        }

        private void CheckStocks(FinancialPair pair)
        {
            Assert.IsNotNull(pair.X);
            Assert.IsNotNull(pair.Y);

            Assert.IsNotNull(pair.X.Prices);
            Assert.IsNotNull(pair.Y.Prices);
        }

        private void CheckDeltaValues(FinancialPair pair)
        {
            Assert.AreEqual(473, pair.DeltaValues.Length);
            Assert.AreEqual(89.2855, pair.DeltaValues.First(), 0.001);
            Assert.AreEqual(78.7398, pair.DeltaValues.Last(), 0.001);
        }

        private void CheckDeviations(FinancialPair pair)
        {
            Assert.AreEqual(185.7958, pair.X.Deviation, 0.001);
            Assert.AreEqual(8.441, pair.Y.Deviation, 0.001);
        }

        private static void CheckName(FinancialPair pair)
        {
            Assert.AreEqual("XOM|AAPL", pair.Name);
        }

        public void CheckRegression(LinearRegression lr)
        {
            Assert.AreEqual(86.7434, lr.Alpha, 0.001);
            Assert.AreEqual(0.0189, lr.Beta, 0.001);
            Assert.AreEqual(0.4164, lr.RValue, 0.001);
            Assert.AreEqual(0.1734, lr.RSquared, 0.001);
        }
    }
}
