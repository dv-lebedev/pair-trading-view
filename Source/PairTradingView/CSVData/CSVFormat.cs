using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.CSVData
{
    [Serializable]
    public class CSVFormat
    {
        public bool ContainsHeader { get; set; }
        public char Separator { get; set; }
        public long PriceIndex { get; set; }
        public long VolumeIndex { get; set; }
    }
}
