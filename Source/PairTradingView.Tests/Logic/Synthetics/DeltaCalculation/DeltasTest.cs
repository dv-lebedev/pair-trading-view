using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Logic.Statistics.Models;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Tests.Logic.Synthetics.DeltaCalculation
{
    [TestClass]
    public class DeltasTest
    {
        [TestMethod]
        public void SpreadDeltaTest()
        {
            double[] x = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            double[] y = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };


            AbstractDelta delta = new SpreadDelta();

            var deltas = delta.GetDeltaValues(x, y);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual(y[i] - x[i], deltas[i]);
                Assert.AreEqual(y[i] - x[i], delta.GetCurrentDelta(x[i], y[i]));
            }
        }

        [TestMethod]
        public void SpreadBetaDeltaTest()
        {
            double[] x = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            double[] y = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            var linearRegression = new LinearRegression(y, x);

            AbstractDelta delta = new SpreadBetaDelta();

            var deltas = delta.GetDeltaValues(x, y, beta: linearRegression.Beta);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual(y[i] - linearRegression.Beta *  x[i], deltas[i]);

                Assert.AreEqual(
                    y[i] - linearRegression.Beta * x[i], 
                    delta.GetCurrentDelta(x[i], y[i], linearRegression.Beta));
            }
        }

        [TestMethod]
        public void RatioDeltaTest()
        {
            double[] x = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            double[] y = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            AbstractDelta delta = new RatioDelta();

            var deltas = delta.GetDeltaValues(x, y);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual(y[i] / x[i], deltas[i]);
                Assert.AreEqual(y[i] / x[i], delta.GetCurrentDelta(x[i], y[i]));
            } 
        }

        [TestMethod]
        public void RatioBetaDeltaTest()
        {
            double[] x = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            double[] y = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            var linearRegression = new LinearRegression(y, x);

            AbstractDelta delta = new RatioBetaDelta();
           
            var deltas = delta.GetDeltaValues(x, y, beta: linearRegression.Beta);

            for (int i = 0; i < deltas.Length; i++)
            {
                Assert.AreEqual(y[i] / (linearRegression.Beta * x[i]), deltas[i]);

                Assert.AreEqual(
                    y[i] / (linearRegression.Beta * x[i]),
                    delta.GetCurrentDelta(x[i], y[i], linearRegression.Beta));
            }
        }
    }
}
