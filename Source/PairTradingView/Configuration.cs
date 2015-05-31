using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PairTradingView.Data.CSVData;
using PairTradingView.Synthetics;

namespace PairTradingView
{
    [Serializable]
    public class Configuration
    {
        public string SqlConnectionString { get; set; }

        public int DataSaveInterval { get; set; }

        public int DataUpdateInterval { get; set; }

        public int LoadingValuesCount { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan StopTime { get; set; }

        public CSVFormat CsvFormat { get; set; }


        public static void Serialize(string path, Configuration item)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, item);
            }
        }

        public static Configuration Deserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
               var item = (Configuration)new BinaryFormatter().Deserialize(fs);

               if (item.CsvFormat == null)
               {
                   item.CsvFormat = new CSVFormat { Separator = ',' };
               }

               return item;
            }
        }

        public static Configuration GetDefaultSetting()
        {
            return new Configuration
            {
                DataSaveInterval = 1,
                DataUpdateInterval = 1,
                LoadingValuesCount = 5,
                StartTime = new TimeSpan(10, 00, 00),
                StopTime = new TimeSpan(18, 45, 00),
                CsvFormat = new CSVFormat { Separator = ',' }
            };
        }
    }
}
