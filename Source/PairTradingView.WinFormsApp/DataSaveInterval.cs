using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using PairTradingView.Data.Csv;
using PairTradingView.Data.DataProviders;
using PairTradingView.Data.DataProviders.ODBC;

namespace PairTradingView
{

    [Serializable]
    public class DataSaveInterval
    {
        public string Name { get; private set; }
        public int Milliseconds { get; private set; }

        public static List<DataSaveInterval> Intervals { get; private set; }

        public DataSaveInterval(string name, int milliseconds)
        {
            Name = name;
            Milliseconds = milliseconds;
        }

        static DataSaveInterval()
        {
            Intervals = new List<DataSaveInterval>();

            Intervals.Add(new DataSaveInterval("1M", 1000 * 60));
            Intervals.Add(new DataSaveInterval("5M", 1000 * 60 * 5));
            Intervals.Add(new DataSaveInterval("10M", 1000 * 60 * 10));
            Intervals.Add(new DataSaveInterval("15M", 1000 * 60 * 15));
            Intervals.Add(new DataSaveInterval("30M", 1000 * 60 * 30));
            Intervals.Add(new DataSaveInterval("1H", 1000 * 60 * 60));
        }

        public void SetFromMilliseconds(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public void SetFromSeconds(int seconds)
        {
            Milliseconds = 1000 * seconds;
        }

        public int GetSeconds()
        {
            return Milliseconds * 1000;
        }
    }

}
