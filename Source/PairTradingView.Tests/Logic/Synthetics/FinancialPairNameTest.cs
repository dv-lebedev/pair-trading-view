using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Logic.Synthetics;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class FinancialPairNameTest
    {
        [TestMethod]
        public void NameTest()
        {
            FinancialPairName n1 = new FinancialPairName("ABCD", "WXYZ");
            FinancialPairName n2 = new FinancialPairName("ABCD", "WXYZ");
            FinancialPairName n3 = new FinancialPairName("WXYZ", "ABCD");

            Assert.AreEqual(n1, n2);
            Assert.AreNotEqual(n1, n3);
        }
    }
}
