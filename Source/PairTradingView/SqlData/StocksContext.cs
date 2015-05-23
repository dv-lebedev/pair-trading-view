using System.Data.Entity;
using PairTradingView.SqlData.Entities;

namespace PairTradingView.SqlData
{
    public class StocksContext : DbContext
    {
        public StocksContext(string connectionStr)
            : base(connectionStr)
        {
          
        }

        public DbSet<Stock> Stocks { get; set; }

    }
}
