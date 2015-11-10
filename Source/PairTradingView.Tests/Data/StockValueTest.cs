using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;

namespace PairTradingView.Tests.Data
{

    [TestClass]
    public class StockValueTest
    {

        [TestMethod]
        public void EqualsTest()
        {
            DateTime dt = DateTime.Now;
            decimal price = 838429354.0000023020054M;
            long volume = 2918747236856823658;

            var value1 = new StockValue
            {
                DateTime = dt,
                Price = price,
                Volume = volume
            };

            var value2 = new StockValue
            {
                DateTime = dt,
                Price = price,
                Volume = volume
            };

            Assert.AreEqual(true, value1.Equals(value2));

            Assert.AreEqual(false, value1.Equals(null));

            Assert.AreEqual(false, value1.Equals(new object()));
        }

    }
}
