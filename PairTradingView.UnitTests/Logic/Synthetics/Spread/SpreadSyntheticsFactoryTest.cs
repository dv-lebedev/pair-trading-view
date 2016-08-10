
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
using PairTradingView.Logic.Synthetics.Spread;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.UnitTests.Logic.Synthetics.Spread
{
    [TestClass]
    public class SpreadSyntheticsFactoryTest
    {

        [TestMethod]
        public void Test()
        {
            var provider = new ExampleDataProvider();

            InputData[] input =
                {
                    new InputData(provider.GetStockInfo("AAPL"), provider.GetValues("AAPL", 100)),
                    new InputData(provider.GetStockInfo("GOOG"), provider.GetValues("GOOG", 100)),
                    new InputData(provider.GetStockInfo("XOM"), provider.GetValues("XOM", 100))
                };


            var factory = new SpreadSyntheticsFactory(input);


            IEnumerable<Synthetic> synthetics = factory.CreateSynthetics();


            Assert.AreEqual(3, synthetics.Count());

        }

        [TestMethod]
        public void ExceptionsTest()
        {
            var provider = new ExampleDataProvider();

            InputData[] input =
                {
                    new InputData(provider.GetStockInfo("AAPL"), provider.GetValues("AAPL", 100)),
                    new InputData(provider.GetStockInfo("GOOG"), provider.GetValues("GOOG", 100)),
                    new InputData(provider.GetStockInfo("XOM"), provider.GetValues("XOM", 100))
                };


            try
            {
                new SpreadSyntheticsFactory(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }
        }
    }
}
