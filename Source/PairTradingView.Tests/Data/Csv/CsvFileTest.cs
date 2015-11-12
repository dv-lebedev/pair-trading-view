using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Data;
using PairTradingView.Data.DataProviders.Csv;

namespace PairTradingView.Tests.Data.Csv
{
    [TestClass]
    public class CsvFileTest
    {
        [TestMethod]
        public void ConvertFromStringTest()
        {
            var format = new CsvFormat
            {
                ContainsHeader = false,
                DateIndex = 0,
                TimeIndex = 0,
                DateTimeFormat = "yyyyMMddHHmmss",
                Separator = ',',
                PriceIndex = 1,
                VolumeIndex = 2
            };

            StockValue valueExp = new StockValue
            {
                DateTime = new DateTime(2014, 3, 9, 12, 56, 1),
                Price = 89570.0000M,
                Volume = 18273645
            };

            var result = CsvFile.Convert("20140309125601, 89570.0000, 18273645", format);

            Assert.AreEqual<StockValue>(valueExp, result);


            try
            {
                CsvFile.Convert("", format);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FormatException));
            }
        }

        [TestMethod]
        public void ConvertFromStringsArrayTest()
        {
            var format = new CsvFormat
            {
                ContainsHeader = false,
                DateIndex = 0,
                TimeIndex = 0,
                DateTimeFormat = "yyyyMMddHHmmss",
                Separator = ',',
                PriceIndex = 1,
                VolumeIndex = 2
            };

            List<StockValue> expectedResult = new List<StockValue>();

            expectedResult.Add(new StockValue
            {
                DateTime = new DateTime(2014, 3, 9, 12, 56, 1),
                Price = 89570.0123M,
                Volume = 147
            });
            expectedResult.Add(new StockValue
            {
                DateTime = new DateTime(2015, 4, 10, 13, 57, 2),
                Price = 89570.0456M,
                Volume = 258
            });
            expectedResult.Add(new StockValue
            {
                DateTime = new DateTime(2016, 5, 11, 14, 58, 3),
                Price = 89570.0789M,
                Volume = 369
            });


            string[] testSet = {
                                   "20140309125601, 89570.0123, 147",
                                   "20150410135702, 89570.0456, 258",
                                   "20160511145803, 89570.0789, 369"
                               };


            var result =  CsvFile.Convert(testSet, format).GetEnumerator();


            foreach (var item in expectedResult)
            {
                result.MoveNext();

                Assert.AreEqual(item, result.Current);
            }
            
        }


        [TestMethod]
        public void ReadTest()
        {
            var csvFormat = new CsvFormat
            {
                DateIndex = 0,
                TimeIndex = 1,
                PriceIndex = 5,
                VolumeIndex = 6,
                Separator = ',',
                DateTimeFormat = "yyyyMMdd HHmmss",
                ContainsHeader = false
            };

            var result = CsvFile.Read("csv-files/test.csv", csvFormat);

            DateTime firstExpected = new DateTime(2014, 1, 6);
            DateTime lastExpected = new DateTime(2014, 12, 30);

            Assert.AreEqual(firstExpected, result.First().DateTime);
            Assert.AreEqual(lastExpected, result.Last().DateTime);
        }


    }
}
