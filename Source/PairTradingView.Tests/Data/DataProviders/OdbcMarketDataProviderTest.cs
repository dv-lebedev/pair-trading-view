using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data.DataProviders;
using PairTradingView.Data.DataProviders.ODBC;

namespace PairTradingView.Tests.Data.DataProviders
{
    [TestClass]
    public class OdbcMarketDataProviderTest
    {

        private readonly string _connectionString = 
            "Driver={MySQL ODBC 5.3 ANSI Driver};Server=localhost;Database=stocks;User=test;Password=1234;";


        private string[] codes = { "LKOH", "GAZP", "TATN", "SBER" };


        [TestMethod]
        public void GetStockTest()
        {
            IMarketDataProvider provider = new OdbcMarketDataProvider(_connectionString);

            var lkoh = provider.GetStock("LKOH");
            var gazp = provider.GetStock("GAZP");

            Assert.AreEqual(lkoh.Code, "LKOH");
            Assert.AreEqual(gazp.Code, "GAZP");
        }


        [TestMethod]
        public void GetStocksTest()
        {
            IMarketDataProvider provider = new OdbcMarketDataProvider(_connectionString);

            foreach (var stock in provider.GetStocks())
            {
                Assert.AreNotEqual(null, stock);
            }
        }

    }
}
