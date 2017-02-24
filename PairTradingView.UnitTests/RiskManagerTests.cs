
/*
Copyright(c) 2015-2017 Denis Lebedev

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
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Infrastructure.Tests
{
    [TestClass()]
    public class RiskManagerTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-samples/", 4, false);

            List<FinancialPair> pairs = FinancialPair.CreateMany(stocks);

            RiskManager rm = new RiskManager(pairs.ToArray(), 100000.00);
            rm.Calculate();

            pairs.ForEach(i => { Assert.AreNotEqual(0, i.TradeVolume); });

            Assert.AreEqual(100000.00, pairs.Select(i => i.TradeVolume).Sum());

            Assert.AreEqual(1, pairs.Select(i => i.Weight).Sum());
        }
    }
}