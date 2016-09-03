
/*
Copyright(c) 2015-2016 Denis Lebedev

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
using PairTradingView.Infrastructure;
using System.Linq;

namespace PairTradingView.UnitTests
{
    [TestClass()]
    public class CsvUtilsTests
    {
        [TestMethod()]
        public void Read_Test()
        {
            Stock aapl = CsvUtils.Read("csv-samples/AAPL.txt", priceIndex: 4, containsHeader: false);

            Assert.AreEqual(473, aapl.Prices.Length);
            Assert.AreEqual(553.12999, aapl.Prices.First());
            Assert.AreEqual(114.18, aapl.Prices.Last());
        }

        [TestMethod()]
        public void ReadAllDataFrom_Test()
        {
            Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-samples/", priceIndex: 4, containsHeader: false);

            Assert.AreEqual(3, stocks.Length);

            foreach(var stock in stocks)
            {
                Assert.AreEqual(473, stock.Prices.Length);
            }
        }
    }
}
