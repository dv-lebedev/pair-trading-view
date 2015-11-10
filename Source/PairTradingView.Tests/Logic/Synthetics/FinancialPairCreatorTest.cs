using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;
using PairTradingView.Data.DataProviders;
using PairTradingView.Logic.Synthetics;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class FinancialPairCreatorTest
    {
        [TestMethod]
        public void CreatorTest()
        {
            var storage = new CsvStorage("data-for-static-test/");

            Dictionary<string, List<StockValue>> stockValues = new Dictionary<string, List<StockValue>>();

            stockValues.Add("LKOH", storage.GetValues("LKOH", 10).ToList());
            stockValues.Add("GAZP", storage.GetValues("GAZP", 10).ToList());
            stockValues.Add("TATN", storage.GetValues("TATN", 10).ToList());
            stockValues.Add("SBER", storage.GetValues("SBER", 10).ToList());

            var pairs = FinancialPairCreator.CreatePairs(stockValues, new SpreadDelta()).ToList();


            Assert.AreEqual(6, pairs.Count);

            foreach (var pair in pairs)
            {
                Assert.AreNotEqual(null, pair.DeltaCalculation);
                Assert.AreNotEqual(null, pair.DeltaValues);
                Assert.AreNotEqual(null, pair.Regression);

                Assert.AreEqual(10, pair.DeltaValues.Count());
            }

        }
    }
}
