using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data.Csv;
using PairTradingView.Data.DataProviders;
using PairTradingView.Logic.Synthetics;
using PairTradingView.Logic.Synthetics.DeltaCalculation;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class FinancialPairTest
    {
        [TestMethod]
        public void CreateFP()
        {
            var storage = new CsvStorage("data-for-static-test/");

            var fp = new FinancialPair(
                storage.GetValues("LKOH", 20).Select(i => (double)i.Price).ToArray(),
                storage.GetValues("TATN", 20).Select(i => (double)i.Price).ToArray(),
                new FinancialPairName("LKOH", "TATN"),
                new SpreadDelta());
        }
    }
}
