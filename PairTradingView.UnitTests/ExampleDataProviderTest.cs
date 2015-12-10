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
using PairTradingView.Logic.Synthetics.Spread;
using System;
using System.Collections.Generic;
using System.Linq;
using Statistics.Models;

namespace PairTradingView.UnitTests
{
    [TestClass]
    public class ExampleDataProviderTest
    {

        public static ExampleDataProvider Load()
        {
            return new ExampleDataProvider();
        }

        [TestMethod]
        public void LoadExampleProviderTest()
        {
            using (var provider = Load())
            {
                Assert.AreNotEqual(null, provider);

                Assert.AreEqual(4, provider.StockValues.Count);
            }
        }

        [TestMethod]
        public void CsvHelperTest()
        {
            List<StockValue> stockValues = CsvHelper.Read("csv-samples/XOM.txt");

            Assert.AreNotEqual(0, stockValues.Count);
        }



        [TestMethod]
        public void GetStockInfoTest()
        {
            using (var provider = Load())
            {
                var stockInfo = provider.GetStockInfo("AAPL");

                Assert.AreNotEqual(null, stockInfo);
                Assert.AreEqual("AAPL", stockInfo.Symbol);
            }

        }

        [TestMethod]
        public void GetAllStocksInfoTest()
        {
            using (var provider = Load())
            {
                var stocksInfo = provider.GetAllStocksInfo();

                Assert.AreNotEqual(null, stocksInfo);
                Assert.AreEqual(4, stocksInfo.Count());
            }

        }

        [TestMethod]
        public void GetMarketSymbolsTest()
        {
            using (var provider = Load())
            {
                var availableSymbols = provider.GetMarketSymbols();

                var symbols = new[] { "AAPL", "GOOG", "KO", "XOM" };

                foreach (var item in symbols)
                {
                    Assert.AreEqual(true, availableSymbols.Contains(item));
                }
            }
        }



        [TestMethod]
        public void GetLastNValuesTest()
        {
            using (var provider = Load())
            {
                var stockValues = provider.GetValues("AAPL", 20);

                Assert.AreNotEqual(null, stockValues);

                Assert.AreEqual(new DateTime(2014, 12, 4), stockValues.First().DateTime);
                Assert.AreEqual(new DateTime(2015, 1, 2), stockValues.Last().DateTime);
            }

        }

        [TestMethod]
        public void GetValuesTest()
        {
            using (var provider = Load())
            {
                var stockValues = provider.GetValues("XOM");

                Assert.AreNotEqual(null, stockValues);

                Assert.AreEqual(253, stockValues.Count());

                Assert.AreEqual(new DateTime(2014, 1, 2), stockValues.First().DateTime);
                Assert.AreEqual(new DateTime(2015, 1, 2), stockValues.Last().DateTime);
            }
        }

        [TestMethod]
        public void GetValuesByDateTimeTest()
        {
            using (var provider = Load())
            {

                DateTime first = new DateTime(2014, 5, 27);
                DateTime last = new DateTime(2014, 6, 24);

                var stockValues = provider.GetValues("KO", first, last);

                Assert.AreNotEqual(null, stockValues);

                Assert.AreEqual(21, stockValues.Count());

                Assert.AreEqual(first, stockValues.First().DateTime);
                Assert.AreEqual(last, stockValues.Last().DateTime);
            }
        }

        [TestMethod]
        public void IsHistoricalValuesExists()
        {
            using (var provider = Load())
            {
                Assert.AreEqual(true, provider.IsHistoricalValuesExists("AAPL"));
                Assert.AreEqual(true, provider.IsHistoricalValuesExists("GOOG"));
                Assert.AreEqual(true, provider.IsHistoricalValuesExists("XOM"));
                Assert.AreEqual(true, provider.IsHistoricalValuesExists("KO"));
            }
        }


        [TestMethod]
        public void AddRemoveUpdateChannelTest()
        {
            using (var provider = Load())
            {
                InputData[] input =
                {
                    new InputData(provider.GetStockInfo("AAPL"), provider.GetValues("AAPL", 100)),
                    new InputData(provider.GetStockInfo("GOOG"), provider.GetValues("GOOG", 100))
                };

                var synthetic = new SpreadSynthetic(input);


                provider.AddDataChannel(synthetic.Name, synthetic);
                Assert.AreEqual(true, provider.DataChannels.ContainsKey(synthetic.Name));

                var yInfo = input[0].StockInfo;
                var xInfo = input[1].StockInfo;


                provider.UpdateChannels(new[] { xInfo, yInfo });
                Assert.AreEqual(true, 0 > ((LinearRegression)synthetic.Regression).RValue);
                Assert.AreEqual(yInfo.Price + xInfo.Price, synthetic.Value);

                provider.RemoveChannel(synthetic.Name);
                Assert.AreEqual(false, provider.DataChannels.ContainsKey(synthetic.Name));
            }
        }
    }
}