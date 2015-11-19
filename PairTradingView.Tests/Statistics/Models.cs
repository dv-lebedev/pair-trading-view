using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Statistics;


namespace PairTradingView.Tests.Logic.Statistics
{
    [TestClass]
    public class LinearRegressionTest
    {
        [TestMethod]
        public void Test()
        {
            decimal[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            decimal[] y = { 60, 61, 62, 63, 64, 65, 66, 67, 68, 69 };


            try
            {
                var modelDara = new LinearRegression(null, y);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("x", ex.ParamName);
            }


            try
            {
                var modelDara = new LinearRegression(x, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("y", ex.ParamName);
            }


            try
            {
                var modelDara = new LinearRegression(x, new decimal[] { 1, 3, 5, -100 });
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(DifferentLengthException), ex.GetType());
            }


            var regression = new LinearRegression(x, y);

            Assert.AreEqual(1, regression.RValue);
            Assert.AreEqual(1, regression.RSquared);
            Assert.AreEqual(59, regression.Alpha);
            Assert.AreEqual(1, regression.Beta);
        }
    }
}
