using System;
using System.Collections.Generic;


namespace PairTradingView.Data.DataProviders.Csv
{
    [Serializable]
    public class CsvFormat
    {
        public bool ContainsHeader { get; set; }

        public char Separator { get; set; }

        public string DateTimeFormat { get; set; }

        public int DateIndex { get; set; }

        public int TimeIndex { get; set; }

        public int PriceIndex { get; set; }

        public int VolumeIndex { get; set; }
    }
}
