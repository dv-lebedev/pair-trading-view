using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data.DataProviders;
using PairTradingView.Data.DataProviders.ODBC;
using PairTradingView.Logic.Session;

namespace PairTradingView.Tests.Logic.Session
{
    [TestClass]
    public class SessionTest
    {
        private readonly string _connectionString = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=localhost;Database=stocks;" +
                                              "User=test;Password=1234;";


        [TestMethod]
        public void DefaultCfgTest()
        {
            var cfg = Configuration.GetDefaultSetting();

            Assert.AreNotEqual(null, cfg);
        }

        [TestMethod]
        public void Configuration_DeserializeTest()
        {
            try
            {
                var cfg = Configuration.Deserialize("temp.cfg");

                Assert.Fail();
            }
            catch (SerializationException ex)
            {
                
            }
        }

        [TestMethod]
        public void Configuration_SerializeTest()
        {
            try
            {
                Configuration.Serialize("temp.cfg", Configuration.GetDefaultSetting());

            }
            catch (SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine("Configuration_SerializeTest : " + ex.Message);

                Assert.Fail();
            }
            finally
            {
                File.Delete("temp.cfg");
            }
        }


        [TestMethod]
        public void CreateSessionTest()
        {
            var cfg = Configuration.GetDefaultSetting();
            cfg.ConnectionString = _connectionString;

            ISession session = new BaseSession(cfg);

            try
            {
                session = new BaseSession(null);
                
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException));
            }
        }

        [TestMethod]
        public void StartTest()
        {
            var cfg = Configuration.GetDefaultSetting();

            cfg.LoadingDataType = LoadingDataType.LoadLastValues;
            cfg.LoadingValuesCount = 10;

            cfg.SetHistoryDataProvider(new CsvStorage("storage/"));
            cfg.SetMarketDataProvider(new OdbcMarketDataProvider(_connectionString));

            ISession session = new BaseSession(cfg);

            session.Start();

            Assert.AreEqual(true, session.IsSystemStarted);
            Assert.AreNotEqual(null, session.PairsContainer);


            session.CalculateRisk(new[] { "LKOH/GAZP", "TATN/SBER" }, 100000.00);

            foreach (var item in session.PairsContainer.Items
                .Where(i => i.Name.ToString() == "LKOH/GAZP" &&
                            i.Name.ToString() == "TATN/SBER"))
            {
                Assert.AreNotEqual(null, item.RiskParameters);
            }

            try
            {
                session.Start();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("System is already started.", ex.Message);
            }

        }


        [TestMethod]
        public void Start2Test()
        {
            var cfg = Configuration.GetDefaultSetting();

            cfg.LoadingDataType = LoadingDataType.LoadByNumberOfDays;
            cfg.LoadingNumberOfDays = 100000;

            cfg.SetHistoryDataProvider(new CsvStorage("data-for-static-test/"));
            cfg.SetMarketDataProvider(new OdbcMarketDataProvider(_connectionString));

            ISession session = new BaseSession(cfg);

            session.Start();

            Assert.AreEqual(true, session.IsSystemStarted);
            Assert.AreNotEqual(null, session.PairsContainer);

            session.CalculateRisk(new[] { "LKOH/GAZP", "TATN/SBER" }, 100000.00);

            foreach (var item in session.PairsContainer.Items
                .Where(i => i.Name.ToString() == "LKOH/GAZP" &&
                            i.Name.ToString() == "TATN/SBER"))
            {
                Assert.AreNotEqual(null, item.RiskParameters);
            } 

        }

        [TestMethod]
        public void StopTest()
        {
            var cfg = Configuration.GetDefaultSetting();
            cfg.ConnectionString = _connectionString;

            ISession session = new BaseSession(cfg);
            
            session.Stop();

            Assert.AreEqual(false, session.IsSystemStarted);
        }
    }
}
