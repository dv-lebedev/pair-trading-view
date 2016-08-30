
#region LICENSE

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

#endregion


using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.UnitTests.Logic.Synthetics
{
    [TestClass]
    public class InputValuesTest
    {

        [TestMethod]
        public void Test()
        {
            var provider = new CsvExchange();

            string[] codes = { "GOOG", "AAPL", "KO", "XOM" };

            List<Stock> inputs = new List<Stock>();

            foreach (var item in codes)
            {
                var values = provider.GetValues(item, 20);
                var info = provider.GetStockInfo(item);

                Assert.AreEqual(20, values.Count());

                Stock iv = new Stock(info, values);

                inputs.Add(iv);
            }

            Assert.AreEqual(4, inputs.Count);


            try
            {
                new Stock(null, new List<StockValue>());
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("stockInfo", ex.ParamName);
            }


            try
            {
                var stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 1, 1000.00M, 123456789);

                new Stock(stockInfo, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("history", ex.ParamName);
            }
        }
    }
}
