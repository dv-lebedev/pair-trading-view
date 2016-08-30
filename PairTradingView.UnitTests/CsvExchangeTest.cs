
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
using PairTradingView.Logic.Synthetics.Spread;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.UnitTests
{
    [TestClass]
    public class CsvExchangeTest
    {
        public static CsvExchange LoadExchange()
        {
            return new CsvExchange();
        }

        [TestMethod]
        public void LoadExchangeTest()
        {
            using (var exchange = LoadExchange())
            {
                Assert.IsNotNull(exchange);

                Assert.AreEqual(4, exchange.StockValues.Count);
            }
        }

        [TestMethod]
        public void CsvHelperTest()
        {
            List<StockValue> stockValues = CsvUtils.Read("csv-samples/XOM.txt");

            Assert.AreNotEqual(0, stockValues.Count);
        }



        [TestMethod]
        public void GetStockInfoTest()
        {
            using (var exchange = LoadExchange())
            {
                var stockInfo = exchange.GetStockInfo("AAPL");

                Assert.IsNotNull(stockInfo);
                Assert.AreEqual("AAPL", stockInfo.Symbol);
            }

        }

        [TestMethod]
        public void GetAllStocksInfoTest()
        {
            using (var exchange = LoadExchange())
            {
                var stocksInfo = exchange.GetAllStocksInfo();

                Assert.IsNotNull(stocksInfo);
                Assert.AreEqual(4, stocksInfo.Count());
            }

        }

        [TestMethod]
        public void GetMarketSymbolsTest()
        {
            using (var exchange = LoadExchange())
            {
                var availableSymbols = exchange.GetMarketSymbols();

                var symbols = new[] { "AAPL", "GOOG", "KO", "XOM" };

                foreach (var item in symbols)
                {
                    Assert.IsTrue(availableSymbols.Contains(item));
                }
            }
        }



        [TestMethod]
        public void GetLastNValuesTest()
        {
            using (var exchange = LoadExchange())
            {
                var stockValues = exchange.GetValues("AAPL", 20);

                Assert.IsNotNull(stockValues);

                Assert.AreEqual(new DateTime(2014, 12, 4), stockValues.First().DateTime);
                Assert.AreEqual(new DateTime(2015, 1, 2), stockValues.Last().DateTime);
            }

        }

        [TestMethod]
        public void GetValuesTest()
        {
            using (var exchange = LoadExchange())
            {
                var stockValues = exchange.GetValues("XOM");

                Assert.IsNotNull(stockValues);

                Assert.AreEqual(253, stockValues.Count());

                Assert.AreEqual(new DateTime(2014, 1, 2), stockValues.First().DateTime);
                Assert.AreEqual(new DateTime(2015, 1, 2), stockValues.Last().DateTime);
            }
        }

        [TestMethod]
        public void GetValuesByDateTimeTest()
        {
            using (var exchange = LoadExchange())
            {

                DateTime first = new DateTime(2014, 5, 27);
                DateTime last = new DateTime(2014, 6, 24);

                var stockValues = exchange.GetValues("KO", first, last);

                Assert.IsNotNull(stockValues);

                Assert.AreEqual(21, stockValues.Count());

                Assert.AreEqual(first, stockValues.First().DateTime);
                Assert.AreEqual(last, stockValues.Last().DateTime);
            }
        }

        [TestMethod]
        public void IsHistoricalValuesExists()
        {
            using (var exchange = LoadExchange())
            {
                Assert.IsTrue(exchange.IsHistoricalValuesExists("AAPL"));
                Assert.IsTrue(exchange.IsHistoricalValuesExists("GOOG"));
                Assert.IsTrue(exchange.IsHistoricalValuesExists("XOM"));
                Assert.IsTrue(exchange.IsHistoricalValuesExists("KO"));
            }
        }


        [TestMethod]
        public void AddRemoveUpdateChannelTest()
        {
            using (var exchange = LoadExchange())
            {
                Stock[] input =
                {
                    new Stock(exchange.GetStockInfo("AAPL"), exchange.GetValues("AAPL", 100)),
                    new Stock(exchange.GetStockInfo("GOOG"), exchange.GetValues("GOOG", 100))
                };

                var synthetic = new SpreadSynthetic(input);


                exchange.DataChannels.Add(synthetic.Name, synthetic);
                Assert.IsTrue(exchange.DataChannels.ContainsKey(synthetic.Name));

                var yInfo = input[0].Info;
                var xInfo = input[1].Info;


                exchange.StockInfoUpdated(new[] { xInfo, yInfo });
                Assert.IsTrue(0 > ((LinearRegression)synthetic.Regression).RValue);
                Assert.AreEqual(yInfo.Price + xInfo.Price, synthetic.DeltaValue);

                exchange.DataChannels.Remove(synthetic.Name);
                Assert.IsFalse(exchange.DataChannels.ContainsKey(synthetic.Name));
            }
        }
    }
}