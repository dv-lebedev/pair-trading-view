using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Synthetics;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class SyntheticsNameTest
    {
        [TestMethod]
        public void NameTest()
        {
            SyntheticName n1 = new SyntheticName("ABCD", "WXYZ");
            SyntheticName n2 = new SyntheticName("ABCD", "WXYZ");
            SyntheticName n3 = new SyntheticName("WXYZ", "ABCD");

            Assert.AreEqual(n1, n2);
            Assert.AreNotEqual(n1, n3);

            Assert.AreEqual("WXYZ/ABCD", n1.ToString());
        }
    }
}
