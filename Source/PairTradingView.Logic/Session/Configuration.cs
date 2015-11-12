using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using PairTradingView.Data.DataProviders;
using PairTradingView.Data.DataProviders.ODBC;

namespace PairTradingView.Logic.Session
{

    [Serializable]
    public enum LoadingDataType
    {
        LoadLastValues,
        LoadByNumberOfDays
    }


    [Serializable]
    public class Configuration
    {

        #region DATABASE SETTINGS


        public string ConnectionString { get; set; }

        #endregion


        #region DELTA SETTINGS

        public string DeltaName { get; set; }

        #endregion


        #region DATA_SAVING

        public int DataSaveInterval { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan StopTime { get; set; }

        #endregion


        #region DATA_LOADING

        public int LoadingValuesCount { get; set; }
        public int LoadingNumberOfDays { get; set; }
        public LoadingDataType LoadingDataType { get; set; }

        #endregion


        #region DATA_UPDATING

        public int DataUpdateInterval { get; set; }

        #endregion


        #region DATA_PROVIDERS

        [NonSerialized]
        private IMarketDataProvider _marketDataProvider;

        [NonSerialized]
        private IHistoryDataProvider _historyDataProvider;


        public void SetMarketDataProvider(IMarketDataProvider provider)
        {
            _marketDataProvider = provider;
        }

        public IMarketDataProvider GetMarketDataProvider()
        {
            return _marketDataProvider;
        }

        public void SetHistoryDataProvider(IHistoryDataProvider provider)
        {
            _historyDataProvider = provider;
        }

        public IHistoryDataProvider GetHistoryDataProvider()
        {
            return _historyDataProvider;
        }

        #endregion


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
                DeltaName = new PairTradingView.Logic.Synthetics.DeltaCalculation.SpreadDelta().Name,

                DataSaveInterval = 1000 * 60 * 15,
                StartTime = new TimeSpan(10, 00, 00),
                StopTime = new TimeSpan(18, 45, 00),

                LoadingValuesCount = 10,
                LoadingNumberOfDays = 5,
                LoadingDataType = LoadingDataType.LoadByNumberOfDays,

                DataUpdateInterval = 1000,       

            };
        }

        public static BaseSession GetBaseSession(string path)
        {
            return new BaseSession(Deserialize(path));
        }

    }
}
