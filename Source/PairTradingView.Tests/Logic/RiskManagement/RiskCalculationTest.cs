using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;
using PairTradingView.Data.Csv;
using PairTradingView.Data.DataProviders;
using PairTradingView.Logic.RiskManagement;
using PairTradingView.Logic.Synthetics;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Tests.Logic.RiskManagement
{
    /// <summary>
    /// Search for test sets in 'data-for-static-test/' folder
    /// </summary>


    [TestClass]
    public class RiskCalculationTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            var testPairs = GetPairs();

            var rc = new RiskCalculation(testPairs, 100000.00);

            rc.Calculate();

            Assert.AreEqual(1, testPairs.Select(i => i.RiskParameters.Weight).Sum(), 0.0000001);

            Assert.AreEqual(100000.00, testPairs.Select(i => i.RiskParameters.TradeBalance).Sum(), 0.000000001);

            Assert.AreEqual(100000.00, testPairs
                .Select(i => i.RiskParameters.XTradeBalanace + i.RiskParameters.YTradeBalance)
                .Sum(),
                0.000000001);
       
            try
            {
                 new RiskCalculation(null, 100000.00);

                 Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentNullException), ex.GetType());
            }



            try
            {
                rc.Calculate(-150790.5569);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }



            try
            {
                new RiskCalculation(testPairs, - 7);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }

        }
        

        public List<FinancialPair> GetPairs()
        {
            var storage = new CsvStorage("data-for-static-test/");

            Dictionary<string, List<StockValue>> stockValues = new Dictionary<string, List<StockValue>>();

            stockValues.Add("LKOH", storage.GetValues("LKOH", 10).ToList());
            stockValues.Add("GAZP", storage.GetValues("GAZP", 10).ToList());
            stockValues.Add("TATN", storage.GetValues("TATN", 10).ToList());
            stockValues.Add("SBER", storage.GetValues("SBER", 10).ToList());

            return FinancialPairCreator.CreatePairs(stockValues, new SpreadDelta()).ToList();
        }

    }
}
