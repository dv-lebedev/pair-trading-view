using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Statistics;

namespace PairTradingView.Tests.Logic.Statistics
{
    [TestClass]
    public class BasicFuncsTest
    {

        [TestMethod]
        public void GetStandardDeviationTest()
        {
            decimal[] values = { 1, 3, 5, 7, 9, 11, 15, 17 };

            try
            {
                BasicFuncs.GetStandardDeviation(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            decimal result = BasicFuncs.GetStandardDeviation(values);

            Assert.AreEqual(5.2678, (double)result, 0.0001);


            values = new decimal[] { -3, -5, -8, -13, -35, -57 };

            result = BasicFuncs.GetStandardDeviation(values);

            Assert.AreEqual(19.5824, (double)result, 0.0001);

        }


        [TestMethod]
        public void MultiplyArraysTest()
        {
            decimal[] x = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 35 };

            decimal[] y = { -1001, 2, 6, 98, 23, -56, -34, 56, -345, 7 };

            Assert.AreEqual(true, x.Length == y.Length);


            try
            {
                BasicFuncs.MultiplyArrays(null, y);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("x", ex.ParamName);
            }


            try
            {
                BasicFuncs.MultiplyArrays(x, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("y", ex.ParamName);
            }


            decimal result = BasicFuncs.MultiplyArrays(x, y);

            Assert.AreEqual(-6556, result);
        }


        [TestMethod]
        public void PowArrayTest()
        {
            decimal[] values = { 12, 65, 83, 55, 100, 248, 201, 0, 0, -3, -255 };


            try
            {
                BasicFuncs.PowArray(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            decimal result = BasicFuncs.PowArray(values);

            Assert.AreEqual(191222, result);
        }
    }

    [TestClass]
    public class MovingAveragesTest
    {
        [TestMethod]
        public void SMATest()
        {

            decimal[] values = { 1, 3, 5, 7, 9, 2, 4, 6, 8, 11, 13, 15, 24, 46, 68 };

            try
            {
                var smaResult = MovingAverages.SMA(values, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period <= 0", ex.Message);
            }


            try
            {
                var smaResult = MovingAverages.SMA(null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            try
            {
                var result = MovingAverages.SMA(values, values.Length + 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period > values.Lenght", ex.Message);
            }



            var sma5Result = MovingAverages.SMA(values, 5);

            decimal[] expectedValues = { 5, 5.2M, 5.4M, 5.6M, 5.8M, 6.2M, 8.4M, 10.6M, 14.2M, 21.8M, 33.2M };

            Assert.AreEqual(expectedValues.Length, sma5Result.Length);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], sma5Result[i]);
            }

        }

        [TestMethod]
        public void WMATest()
        {
            decimal[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5 };

            try
            {
                var smaResult = MovingAverages.WMA(values, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period <= 0", ex.Message);
            }


            try
            {
                var smaResult = MovingAverages.WMA(null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            try
            {
                var result = MovingAverages.WMA(values, values.Length + 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period > values.Lenght", ex.Message);
            }


            var wma3Result = MovingAverages.WMA(values, 3);

            double[] expectedValues = { 2.33, 3.33, 4.33, 5.33, 6.33, 7.33, 8.33, 4.83, 2.83, 2.33, 3.33, 4.33 };

            Assert.AreEqual(expectedValues.Length, wma3Result.Length);

            for (int i = 0; i < wma3Result.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], (double)wma3Result[i], 0.01);
            }
        }
    }
}
