using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Logic.Statistics.Models;

namespace PairTradingView.Tests.Logic.Statistics
{
    [TestClass]
    public class Models
    {
        [TestMethod]
        public void AutoRegressionTest()
        {
            double[] x = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 
                             110, 107, 120, 150, 160, 170, 180, 190, 
                             210, 220, 230, 250 };

             var autoRegModel = new AutoRegression(x, 4);

            Assert.AreEqual(0.846933402663296, autoRegModel.Beta, 0.0001);
            Assert.AreEqual(0.871350798042506, autoRegModel.RValue, 0.0001);
        }

        [TestMethod]
        public void LinearRegressionTest()
        {
            double[] x = { 1, 2, 3, 4, 5, 6 };
            double[] y = { 60, 61, 62, 63, 64, 65 };

            var lr = new LinearRegression(y, x);

            Assert.AreEqual(lr.Beta, 1.0);
            Assert.AreEqual(lr.RValue, 1.0);
        }

        [TestMethod]
        public void LogitRegressionTest()
        {
            bool[] y = { true, true, true, false, false, true, false, true, true };

            double[] x1 = { 0.1 , 0.112, 0.005, 0.95, 0.97, 0.1, 0.956, 0.100005, 0.1100001 };
            double[] x2 = { 15 , 12, 14, 100, 110, 11, 123, 9, 10.0001 };

            var logitRegression = new LogitRegression(y, x1, x2);

            Assert.AreEqual(1.10469281206948, logitRegression.Coefs[0], 0.0001);
            Assert.AreEqual(-0.704147280983444, logitRegression.RValues[0], 0.0001);

            Assert.AreEqual(-0.806310444145446, logitRegression.Coefs[1], 0.0001);
            Assert.AreEqual(-0.296332660747901, logitRegression.RValues[1], 0.0001);

        }

        [TestMethod]
        public void MultipleLinearRegressionTest()
        {
            double[] y = { 1, 2, 3, 4, 5, 6 };
            double[] x1 = { 60, 61, 62, 63, 64, 65 };
            double[] x2 = { 10, 12, 14, 16, 18, 20 };

            var mr = new MultipleLinearRegression(y, x1, x2);

            Assert.AreEqual(-12, mr.Coefs[0], 0.0001);
            Assert.AreEqual(0.140625, mr.RValues[0], 0.0001);

            Assert.AreEqual(0.140625, mr.Coefs[1], 0.0001);
            Assert.AreEqual(0.90625, mr.RValues[1], 0.0001);
        }
    }
}
