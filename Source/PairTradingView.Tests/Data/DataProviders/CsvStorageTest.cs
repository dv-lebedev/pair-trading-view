using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;
using PairTradingView.Data.DataProviders;

namespace PairTradingView.Tests.Data.DataProviders
{
    [TestClass]
    public class CsvStorageTest
    {

        private string pathToCsvStorageDirectory = "storage/";

        [TestMethod]
        public void InitTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            Assert.AreEqual(Directory.Exists("storage/"), true);
        }

        [TestMethod]
        public void GetCodesTest()
        {
            var codesExpect = new string[] { "LKOH", "SBER", "TATN", "GAZP"};

            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var codes = storage.GetCodes();

            foreach (var code in codes)
            {
                Assert.AreEqual(codesExpect.Contains(code), true);
            }
        }

        [TestMethod]
        public void IsExistTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            Assert.AreEqual(storage.IsExist("LKOH"), true);
            Assert.AreEqual(storage.IsExist("SBER"), true);
            Assert.AreEqual(storage.IsExist("TATN"), true);
            Assert.AreEqual(storage.IsExist("GAZP"), true);
        }

        [TestMethod]
        public void SaveTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var valueExpected = new StockValue
            {
                DateTime = DateTime.Now,
                Price = (decimal)new Random().NextDouble(),
                Volume = long.MaxValue
            };

            storage.Save("LKOH", valueExpected);

            var result = storage.GetValues("LKOH", 1).First();

            Assert.AreEqual(valueExpected, result);
        }

        [TestMethod]
        public void SaveManyTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var stockValues = new List<StockValue>();
            stockValues.Add(new StockValue { DateTime = new DateTime(2000, 1, 2), Price = 0.00085001M, Volume = 652465476355356345 });
            stockValues.Add(new StockValue { DateTime = new DateTime(2001, 2, 3), Price = 0.100000M, Volume = 23987686723823025 });
            stockValues.Add(new StockValue { DateTime = new DateTime(2002, 3, 4), Price = 1.00075M, Volume = 8763481236423 });
            stockValues.Add(new StockValue { DateTime = new DateTime(2003, 4, 5), Price = 10.0000M, Volume = 878637843554654 });
            stockValues.Add(new StockValue { DateTime = new DateTime(2004, 5, 6), Price = 1004500.00730600M });

            storage.Save("LKOH", stockValues);

            IEnumerable<StockValue> valuesSaved = storage.GetValues("LKOH", 5);

            IEnumerator<StockValue> enumerator = valuesSaved.GetEnumerator();

            foreach (var valueExpected in stockValues)
            {
                enumerator.MoveNext();

                Assert.AreEqual(valueExpected, enumerator.Current);
            }

            Assert.AreEqual(valuesSaved.Count(), 5);

        }

        [TestMethod]
        public void GetValuesLastTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var values = storage.GetValues("GAZP", 7);

            Assert.AreEqual(7, values.Count());

            values = storage.GetValues("AZWDFV", 1928374);

            Assert.AreEqual(null, values);
        }

        [TestMethod]
        public void GetValuesAllTest()
        {
            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var values = storage.GetValues("GAZP");

            Assert.AreEqual(10, values.Count());

            values = storage.GetValues("ZADFGHCJ");

            Assert.AreEqual(null, values);
        }

        [TestMethod]
        public void GetValuesByDateTest()
        {
            DateTime dtFirst = DateTime.ParseExact("20150105100300", "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            DateTime dtLast = DateTime.ParseExact("20150105100900", "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            var storage = new CsvStorage(pathToCsvStorageDirectory);

            var values = storage.GetValues("GAZP", dtFirst, dtLast);

            Assert.AreEqual(7, values.Count());

            Assert.AreEqual(dtFirst, values.First().DateTime);
            Assert.AreEqual(dtLast, values.Last().DateTime);


            values = storage.GetValues("DFDSF", dtFirst, dtLast);

            Assert.AreEqual(null, values);
        }

        [TestMethod]
        public void StockValueToStringTest()
        {
            var value = new StockValue
            {
                DateTime = new DateTime(2014, 1, 2, 23, 43, 59),
                Price = 1526374859.05947382M,
                Volume = 5235166434521
            };

            string expectedResult = "20140102234359, 1526374859.05947382, 5235166434521";

            var storage = new CsvStorage(pathToCsvStorageDirectory);

            string result = storage.StockValueToString(value);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
