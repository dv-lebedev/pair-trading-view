/*
Copyright 2015 Denis Lebedev

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
using PairTradingView.Data;
using System;

namespace PairTradingView.UnitTests.Data
{
    [TestClass]
    public class StockInfoTest
    {
        [TestMethod]
        public void GettersTest()
        {
            StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 1, 1000.00M, 123456789);

            Assert.AreEqual("GOOG", stockInfo.Symbol);
            Assert.AreEqual("GOOG Inc.", stockInfo.Name);
            Assert.AreEqual("Shares", stockInfo.Type);
            Assert.AreEqual(1, stockInfo.Lot);
            Assert.AreEqual(1000.00M, stockInfo.Price);
            Assert.AreEqual(123456789, stockInfo.Volume);
        }


        [TestMethod]
        public void SymbolTest()
        {
            try
            {
                StockInfo stockInfo = new StockInfo(null, "GOOG Inc.", "Shares", 1, 1000.00M, 123456789);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Symbol", e.ParamName);
            }

            try
            {
                StockInfo stockInfo = new StockInfo(string.Empty, "GOOG Inc.", "Shares", 1, 1000.00M, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Symbol", e.ParamName);
            }
        }

        [TestMethod]
        public void NameTest()
        {

            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", null, "Shares", 1, 1000.00M, 123456789);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Name", e.ParamName);
            }

            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", string.Empty, "Shares", 1, 1000.00M, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Name", e.ParamName);
            }
        }

        [TestMethod]
        public void TypeTest()
        {
            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", null, 1, 1000.00M, 123456789);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Type", e.ParamName);
            }

            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", string.Empty, 1, 1000.00M, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Type", e.ParamName);
            }
        }

        [TestMethod]
        public void LotTest()
        {
            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 0, 1000.00M, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Lot", e.ParamName);
            }

            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", -1, 1000.00M, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Lot", e.ParamName);
            }
        }

        [TestMethod]
        public void PriceTest()
        {
            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 1, 0, 123456789);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Price", e.ParamName);
            }

            try
            {
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 1, -1, 123456789);
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
                StockInfo stockInfo = new StockInfo("GOOG", "GOOG Inc.", "Shares", 1, 1000.00M, -1);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Volume", e.ParamName);
            }
        }
    }
}
