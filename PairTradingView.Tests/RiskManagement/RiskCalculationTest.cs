using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Csv;
using PairTradingView.RiskManagement;
using PairTradingView.Synthetics;

namespace PairTradingView.Tests.Logic.RiskManagement
{

    [TestClass]
    public class RiskCalculationTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            var testPairs = GetPairs();

            var rc = new RiskCalculation(testPairs, 100000.00M);

            rc.Calculate();

            Assert.AreEqual(1, (double)testPairs.Select(i => i.RiskParameters.Weight).Sum(), 0.0000001);

            Assert.AreEqual(100000.00, (double) testPairs.Select(i => i.RiskParameters.TradeBalance).Sum(), 0.000000001);

            Assert.AreEqual(100000.00, (double)testPairs
                .Select(i => i.RiskParameters.XTradeBalanace + i.RiskParameters.YTradeBalance)
                .Sum(),
                0.000000001);
       
            try
            {
                 new RiskCalculation(null, 100000.00M);

                 Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentNullException), ex.GetType());
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
        

        public List<Synthetic> GetPairs()
        {

            Dictionary<string, decimal[]> stockValues = new Dictionary<string, decimal[]>();

            stockValues.Add("JPM", CsvFile.Read("csv-files/JPM.txt", 4, false));
            stockValues.Add("GS", CsvFile.Read("csv-files/GS.txt", 4, false));
            stockValues.Add("AAPL", CsvFile.Read("csv-files/AAPL.txt", 4, false));
            stockValues.Add("MSFT", CsvFile.Read("csv-files/MSFT.txt", 4, false));

            SyntheticsFactory factory = new SyntheticsFactory(stockValues);

            return factory.CreateSynthetics(DeltaType.SPREAD).ToList();
        }

    }
}
