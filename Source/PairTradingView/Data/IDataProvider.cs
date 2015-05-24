using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTradingView.Data.Entities;

namespace PairTradingView.Data
{
    public interface IDataProvider
    {
        List<Stock> GetStocks();
    }
}
