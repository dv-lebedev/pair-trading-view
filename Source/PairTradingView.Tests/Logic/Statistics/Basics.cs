using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Logic.Statistics;

namespace PairTradingView.Tests.Logic.Statistics
{
    [TestClass]
    public class StdFuncsTest
    {

        private double[] testSet = { 1, 4, 2, 5, 3, 
                                     6, 4, 7, 5, 8, 
                                     6, 9, 7, 5, 1, 
                                     6, 2, 7, 3, 85, 
                                     96, 113, 144, 255 };


        [TestMethod]
        public void StandardDeviationDoubleTest()
        {
            var sd = StdFuncs.StandardDeviation(testSet);

            Assert.AreEqual(61.201624, sd, 0.0001);
        }

        [TestMethod]
        public void StandardDeviationDecimalTest()
        {
            var sd = StdFuncs.StandardDeviation(testSet.Select(i => (decimal)i).ToArray());

            Assert.AreEqual<decimal>(61.2016248876522M, sd);
        }

        [TestMethod]
        public void DarbinWatsonTest()
        {
            StdFuncs.DurbinWatson(testSet);
        }

        [TestMethod]
        public void MultiTest()
        {
            var result = StdFuncs.Multi(testSet, testSet);

            Assert.AreEqual(115506, result, 0.00000001);
        }

        [TestMethod]
        public void GetErrorsDoubleTest()
        {

            double[] deltas = { 6, 1, -1, 1, -1, 1, -1, 78, 91, 105, 138, 246 };

            var result = StdFuncs.GetErrors(testSet, 12);

            Assert.AreEqual(deltas.Length, result.Length);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual(deltas[i], result[i], 0.0000000001);
            }
        }

        [TestMethod]
        public void GetErrorsDecimalTest()
        {
            decimal[] deltas = { 6, 1, -1, 1, -1, 1, -1, 78, 91, 105, 138, 246 };

            var result = StdFuncs.GetErrors(testSet.Select(i => (decimal)i).ToArray(), 12);

            Assert.AreEqual(deltas.Length, result.Length);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual<decimal>(deltas[i], result[i]);
            }
        }
    }


    [TestClass]
    public class OrdinaryLeastSquaresTest
    {
        [TestMethod]
        public void ComputeTest()
        {
            double[] y = { 1, 2, 3, 4, 5, 6 };
            double[] x1 = { 60, 61, 62, 63, 64, 65 };
            double[] x2 = { 10, 12, 14, 16, 18, 20 };

            var ols = new OrdinaryLeastSquares();

            ols.Compute(y, x1, x2);

            Assert.AreEqual(-12, ols.Coefs[0], 0.0001);
            Assert.AreEqual(0.140625, ols.RValues[0], 0.0001);

            Assert.AreEqual(0.140625, ols.Coefs[1], 0.0001);
            Assert.AreEqual(0.90625, ols.RValues[1], 0.0001);
        }
    }


    [TestClass]
    public class MovingAveragesTest
    {

        private double[] testSet = { 1, 4, 2, 5, 3, 
                                     6, 4, 7, 5, 8, 
                                     6, 9, 7, 5, 1, 
                                     6, 2, 7, 3, 85, 
                                     96, 113, 144, 255 };


        [TestMethod]
        public void SMADoubleTest()
        {
            double[] expectedRes = { 5, 5.5, 5.583, 5.5, 5.583, 
                                       5.5, 5.583, 5.5, 12, 19.583, 
                                       28.333, 39.833, 60.3333 };

            var result = MovingAverages.SMA(testSet, 12);

            Assert.AreEqual(expectedRes.Length, result.Length);

            for (int i = 0; i < expectedRes.Length; i++)
            {
                Assert.AreEqual(expectedRes[i], result[i], 0.001);
            }

            try
            {
                MovingAverages.SMA(testSet, -5);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period < 0", ex.Message);
            }
        }

        [TestMethod]
        public void SMADecimalTest()
        {
            decimal[] expectedRes = { 5, 5.5M, 5.583M, 5.5M, 5.583M, 
                                       5.5M, 5.583M, 5.5M, 12, 19.583M, 
                                       28.333M, 39.833M, 60.3333M };

            var result = MovingAverages.SMA(testSet.Select(i => (decimal)i).ToArray(), 12);

            Assert.AreEqual(expectedRes.Length, result.Length);

            for (int i = 0; i < expectedRes.Length; i++)
            {
                Assert.AreEqual((double)expectedRes[i], (double)result[i], 0.001);
            }

            try
            {
                MovingAverages.SMA(testSet.Select(i => (decimal)i).ToArray(), -1);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period < 0", ex.Message);
            }
        }

        [TestMethod]
        public void WMADoubleTest()
        {
            double[] expectedRes = { 6.0128, 6.3205, 6.2435, 5.5384, 
                                       5.6153, 5.0641, 5.2948, 4.8974, 
                                       17.1282, 30.0512, 44.4230, 62.2179, 95.3205 };

            var result = MovingAverages.WMA(testSet, 12);

            Assert.AreEqual(expectedRes.Length, result.Length);

            for (int i = 0; i < expectedRes.Length; i++)
            {
                Assert.AreEqual(expectedRes[i], result[i], 0.0001);
            }

            try
            {
                MovingAverages.WMA(testSet, -25);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period < 0", ex.Message);
            }
        }

        [TestMethod]
        public void WMADecimalTest()
        {
            decimal[] testSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            decimal[] expect = { 3.6666M, 4.6666M, 5.6666M, 6.6666M, 7.6666M, 8.6666M };

            var result = MovingAverages.WMA(testSet, 5);

            Assert.AreEqual(expect.Length, result.Length);

            for (int i = 0; i < expect.Length; i++)
            {
                Assert.AreEqual((double)expect[i],(double) result[i], 0.0001);
            }

            try
            {
                MovingAverages.SMA(testSet, -1);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period < 0", ex.Message);
            }
        }

        [TestMethod]
        public void VMATest()
        {
            decimal[] testSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            long[] testSetVol = { 50, 56, 66, 53, 78, 80, 88, 88, 90, 103 };

            decimal[] expect = { 3.1749M, 4.1801M, 5.1945M, 6.2067M, 7.0754M, 8.1069M };

            var result = MovingAverages.VMA(testSet, testSetVol, 5);

            Assert.AreEqual(expect.Length, result.Length);

            for (int i = 0; i < expect.Length; i++)
            {
                Assert.AreEqual((double)expect[i], (double)result[i], 0.0001);
            }

            try
            {
                MovingAverages.VMA(testSet, testSetVol, - 6);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period < 0", ex.Message);
            }
        }
    }
}
