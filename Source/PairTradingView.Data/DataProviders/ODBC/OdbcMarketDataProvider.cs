using System.Collections.Generic;
using System.Data.Odbc;
using System.Reflection;

namespace PairTradingView.Data.DataProviders.ODBC
{
    public class OdbcMarketDataProvider : IMarketDataProvider
    {
        public string ConnectionString { get; private set; }

        public OdbcMarketDataProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private List<T> GetMany<T>(string request) where T : new()
        {
            using (var cn = new OdbcConnection(ConnectionString))
            {
                cn.Open();

                using (var cmd = new OdbcCommand(request, cn))
                {

                    var reader = cmd.ExecuteReader();

                    List<T> results = new List<T>();

                    PropertyInfo[] properties = typeof(T).GetProperties();

                    while (reader.Read())
                    {
                        T value = new T();

                        foreach (var property in properties)
                        {
                            property.SetValue(value, reader[property.Name.ToLower()]);
                        }

                        results.Add(value);
                    }

                    return results;
                }
            }
        }

        private T Get<T>(string request) where T : new()
        {
            using (var cn = new OdbcConnection(ConnectionString))
            {
                cn.Open();

                using (var cmd = new OdbcCommand(request, cn))
                {

                    var reader = cmd.ExecuteReader();

                    List<T> results = new List<T>();

                    PropertyInfo[] properties = typeof(T).GetProperties();

                    reader.Read();

                    T value = new T();

                    foreach (var property in properties)
                    {
                        property.SetValue(value, reader[property.Name]);
                    }

                    return value;
                }
            }
        }


        public StockInfo GetStock(string code)
        {
            return Get<StockInfo>(string.Format("SELECT code, lot, price, volume FROM market WHERE code='{0}';", code));
        }

        public IEnumerable<StockInfo> GetStocks()
        {
            return GetMany<StockInfo>("SELECT code, lot, price, volume FROM market;");
        }

    }
}
