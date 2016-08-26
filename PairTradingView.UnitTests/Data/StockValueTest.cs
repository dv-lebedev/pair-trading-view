
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

namespace PairTradingView.UnitTests.Data
{
    [TestClass]
    public class StockValueTest
    {
        [TestMethod]
        public void GettersTest()
        {
            var dt = DateTime.Now;

            StockValue value = new StockValue(new Symbol("IBM"), dt, 100.00M, 13579);

            Assert.AreEqual("IBM", value.Symbol.Name);
            Assert.AreEqual(dt, value.DateTime);
            Assert.AreEqual(100.00M, value.Price);
            Assert.AreEqual(13579, value.Volume);
        }

        [TestMethod]
        public void SymbolTest()
        {
            try
            {
                var dt = DateTime.Now;
                StockValue value = new StockValue(null, dt, 100.00M, 13579);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Symbol", e.ParamName);
            }
        }

        [TestMethod]
        public void DateTimeTest()
        {
            var dt = DateTime.Now;
            Symbol symbol = new Symbol("IBM");
            StockValue value = new StockValue(symbol, dt, 100.00M, 13579);

            Assert.AreEqual(dt, value.DateTime);

        }

        [TestMethod]
        public void PriceTest()
        {
            try
            {
                Symbol symbol = new Symbol("IBM");
                StockValue value = new StockValue(symbol, DateTime.Now, 0, 13579);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Price", e.ParamName);
            }

            try
            {
                Symbol symbol = new Symbol("IBM");
                StockValue value = new StockValue(symbol, DateTime.Now, -1, 13579);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Price", e.ParamName);
            }
        }

        [TestMethod]
        public void VolumeTest()
        {
            try
            {
                Symbol symbol = new Symbol("IBM");
                StockValue value = new StockValue(symbol, DateTime.Now, 150.00M, -1);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Volume", e.ParamName);
            }
        }
    }
}
