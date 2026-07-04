/*
    Copyright(c) 2026 Denis Lebedev

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

using PairTradingView.Shared;
using PairTradingView.Shared.Statistics.Models;

namespace PairTradingView.UnitTests
{
    public class FinancialPairTests
    {
        const int PriceIndex = 4;
        const bool ContainsHeader = false;

        [Test]
        public void FinancialPairTest()
        {
            Stock lkoh = CsvUtils.Read("csv-files/LKOH.txt", PriceIndex, ContainsHeader);
            Stock tatn = CsvUtils.Read("csv-files/TATN.txt", PriceIndex, ContainsHeader);

            var pair = new FinancialPair(lkoh, tatn);

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
            Assert.That(pair.DeltaValues.Length, Is.EqualTo(254));
            Assert.That(pair.DeltaValues.First(), Is.EqualTo(-88.71).Within(0.01));
            Assert.That(pair.DeltaValues.Last(), Is.EqualTo(-102.61).Within(0.01));
        }

        private void CheckDeviations(FinancialPair pair)
        {
            Assert.That(pair.X.Deviation, Is.EqualTo(454.66).Within(0.01));
            Assert.That(pair.Y.Deviation, Is.EqualTo(84.08).Within(0.01));
        }

        private static void CheckName(FinancialPair pair)
        {
            Assert.That(pair.Name, Is.EqualTo("TATN | LKOH"));
        }

        public void CheckRegression(LinearRegression lr)
        {
            Assert.That(lr.Alpha, Is.EqualTo(-44.122).Within(0.001));
            Assert.That(lr.Beta, Is.EqualTo(0.168).Within(0.001));
            Assert.That(lr.RValue, Is.EqualTo(0.909).Within(0.001));
            Assert.That(lr.RSquared, Is.EqualTo(0.827).Within(0.001));
        }
    }
}
