using System.Data.Entity;
using PairTradingView.Data.Entities;

namespace PairTradingView.Data.SqlData
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
