using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Csv;

namespace PairTradingView.Tests.Data.Csv
{
    [TestClass]
    public class CsvFileTest
    {
        [TestMethod]
        public void ReadTest()
        {
            var prices = CsvFile.Read("csv-files/JPM.txt", 4, false);

            Assert.AreEqual(58.209999M, prices.First());
            Assert.AreEqual(66.510002M, prices.Last());


            prices = CsvFile.Read("csv-files/JPM.txt", 4, true);

            Assert.AreEqual(58.66M, prices.First());
            Assert.AreEqual(66.510002M, prices.Last());

        }
    }
}
