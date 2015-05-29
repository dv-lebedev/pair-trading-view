using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PairTradingView.Data.Entities;
using PairTradingView.Synthetics;

namespace PairTradingView.Data.SqlData
{
    public class SqlDataProvider : IDataProvider
    {
        private Configuration configuration = null;

        public SqlDataProvider(Configuration cfg)
        {
            if (cfg == null) throw new ArgumentNullException();

            configuration = cfg;
        }

        public List<Stock> GetStocks()
        {
            var stocks = new List<Stock>();

            try
            {
                using (var db = new StocksContext(configuration.SqlConnectionString))
                {
                    foreach (var item in db.Stocks)
                    {
                        var values = item.History.OrderByDescending(i => i.Id).Take(configuration.LoadingValuesCount).Reverse();

                        if (values.Count() > 0)
                        {
                            stocks.Add(new Stock
                            {
                                Code = item.Code,
                                Ask = item.Ask,
                                Bid = item.Bid,
                                Price = item.Price,
                                Volume = item.Volume,
                                History = new List<StockValue>(values)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return stocks;
        }
    }
}
