using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Csv;
using PairTradingView.Synthetics;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class SyntheticsFactoryTest
    {
        [TestMethod]
        public void Test()
        {
            Dictionary<string, decimal[]> stockValues = new Dictionary<string, decimal[]>();

            stockValues.Add("JPM", CsvFile.Read("csv-files/JPM.txt", 4, false));
            stockValues.Add("GS", CsvFile.Read("csv-files/GS.txt", 4, false));
            stockValues.Add("AAPL", CsvFile.Read("csv-files/AAPL.txt", 4, false));
            stockValues.Add("MSFT", CsvFile.Read("csv-files/MSFT.txt", 4, false));


            var pairs = new SyntheticsFactory(stockValues).CreateSynthetics(new SpreadDelta());


            Assert.AreEqual(6, pairs.Count());

            foreach (var pair in pairs)
            {
                Assert.AreNotEqual(null, pair.DeltaValues);
                Assert.AreNotEqual(null, pair.Regression);

                Assert.AreEqual(473, pair.DeltaValues.Count());
            }


            pairs = new SyntheticsFactory(stockValues).CreateSynthetics(new RatioDelta());


            Assert.AreEqual(6, pairs.Count());

            foreach (var pair in pairs)
            {
                Assert.AreNotEqual(null, pair.DeltaValues);
                Assert.AreNotEqual(null, pair.Regression);

                Assert.AreEqual(473, pair.DeltaValues.Count());
            }

        }
    }
}
