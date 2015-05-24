using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PairTradingView
{
    [Serializable]
    public class Configuration
    {
        private static Configuration cfg = null;

        public string SqlConnectionString { get; set; }

        public int DataSaveInterval { get; set; }

        public int DataUpdateInterval { get; set; }

        public int LoadingValuesCount { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan StopTime { get; set; }

        public static Configuration Instance
        {
            get
            {
                if (cfg == null)
                {
                    cfg = Configuration.Deserialize("ptview.cfg");
                }

                return cfg;
            }
        }

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
                return (Configuration)new BinaryFormatter().Deserialize(fs);
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
                StopTime = new TimeSpan(18, 45, 00)
            };
        }
    }
}
