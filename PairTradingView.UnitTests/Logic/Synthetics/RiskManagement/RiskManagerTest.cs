
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
using PairTradingView.Logic.Synthetics;
using PairTradingView.Logic.Synthetics.RiskManagement;
using PairTradingView.Logic.Synthetics.Spread;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.UnitTests.Logic.Synthetics.RiskManagement
{
    [TestClass]
    public class RiskManagerTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            var provider = new ExampleDataProvider();

            Stock[] input =
                {
                    new Stock(provider.GetStockInfo("AAPL"), provider.GetValues("AAPL", 100)),
                    new Stock(provider.GetStockInfo("GOOG"), provider.GetValues("GOOG", 100)),
                    new Stock(provider.GetStockInfo("XOM"), provider.GetValues("XOM", 100))
                };

            var factory = new SpreadSyntheticsFactory(input);
            IEnumerable<Synthetic> synthetics = factory.CreateSynthetics();


            var manager = new RiskManager(synthetics.ToArray(), 100000.00M);
            manager.Calculate();

            decimal balances = 0;
            decimal weights = 0;

            foreach (var item in synthetics)
            {
                Assert.AreNotEqual(null, item.RiskParameters);
                balances += item.RiskParameters.TradeLimit;
                weights += item.RiskParameters.Weight;
                System.Diagnostics.Debug.WriteLine(item.Name);
            }

            Assert.AreEqual(100000.00M, balances);
            Assert.AreEqual(1M, weights);


            var GOOG_AAPL = synthetics.First(i => i.Name == "GOOG|AAPL").RiskParameters;
            Assert.AreEqual(
                (double)GOOG_AAPL.TradeLimit,
                (double)(GOOG_AAPL.SymbolsTradeLimits["GOOG"] + GOOG_AAPL.SymbolsTradeLimits["AAPL"]),
                0.0001);

            var XOM_AAPL = synthetics.First(i => i.Name == "XOM|AAPL").RiskParameters;
            Assert.AreEqual(
                (double)XOM_AAPL.TradeLimit,
                (double)(XOM_AAPL.SymbolsTradeLimits["XOM"] + XOM_AAPL.SymbolsTradeLimits["AAPL"]),
                0.0001);
        }
    }
}
