using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PairTradingView.Data;
using PairTradingView.Logic.RiskManagement;
using PairTradingView.Logic.Synthetics;
using PairTradingView.Logic.Synthetics.DeltaCalculation;


namespace PairTradingView.Logic.Session
{
    public class BaseSession : IDisposable, PairTradingView.Logic.Session.ISession
    {
        public Configuration Cfg { get; private set; }

        public bool IsSystemStarted { get; private set; }

        public PairsContainer PairsContainer { get; private set; }

        private System.Timers.Timer DataStorageTask { get; set; }
        private System.Timers.Timer DataUpdateTask { get; set; }

        public event EventHandler<CurrentDeltaValueEventArgs> CurrentDelta;

        public DateTime LastDataStore { get; private set; }


        public BaseSession(Configuration cfg)
        {
            if (cfg == null) throw new NullReferenceException();

            this.Cfg = cfg;

            Initialize();
        }

        private void Initialize()
        {
            DataStorageTask = new System.Timers.Timer();
            DataUpdateTask = new System.Timers.Timer();

            DataStorageTask.Elapsed += DataStorageTask_Elapsed;
            DataUpdateTask.Elapsed += DataUpdateTask_Elapsed;

            LastDataStore = new DateTime();
        }

        public void CalculateRisk(string [] codes, double tradebalance)
        {
            PairsContainer.Items.ForEach(i => i.RiskParameters = null);

            var checkedPairs = new List<FinancialPair>();

            foreach (var code in codes)
            {
                var result = PairsContainer.Items.Find(i => i.Name.ToString() == code);

                if (result != null)
                {
                    checkedPairs.Add(result);
                }
            }

            var riskCalculation = new RiskCalculation(checkedPairs, tradebalance);

            try
            {
                riskCalculation.Calculate();
            }
            catch (Exception ex)
            {
                throw new Exception("Risk calculation failed. " + ex.Message);
            }
        }

        private void DataStorageTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;

                if (dt.TimeOfDay >= Cfg.StartTime && dt.TimeOfDay <= Cfg.StopTime)
                {
                    var info = Cfg.GetMarketDataProvider().GetStocks();

                    if (info != null)
                    {
                        var storage = Cfg.GetHistoryDataProvider();

                        foreach (var stock in info)
                        {
                            storage.Save(stock.Code, new StockValue
                            {
                                DateTime = dt,
                                Price = stock.Price,
                                Volume = stock.Volume
                            });
                        }

                        LastDataStore = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataStorageTask: " + ex.Message);
            }
        }

        private void DataUpdateTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {           
            try
            {
                foreach (var pair in PairsContainer.Items)
                {
                    var db = Cfg.GetMarketDataProvider();

                    var xStock = db.GetStock(pair.Name.X);
                    var yStock = db.GetStock(pair.Name.Y);

                    if (xStock != null && yStock != null)
                    {
                        var delta = pair.GetCurrentDelta(
                            (double)xStock.Price * xStock.Lot,
                            (double)yStock.Price * yStock.Lot);


                        OnCurrentDelta(this, new CurrentDeltaValueEventArgs
                        {
                            Name = pair.Name,
                            Value = delta
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataUpdateTask" + ex.Message);
            }
        }


        public void Start()
        {
            if (IsSystemStarted)
                throw new InvalidOperationException("System is already started.");

            DataStorageTask.Interval = Cfg.DataSaveInterval;
            DataUpdateTask.Interval = Cfg.DataUpdateInterval;

            Dictionary<string, List<StockValue>> historicalData = null;

            var marketData = Cfg.GetMarketDataProvider().GetStocks();

            if (marketData != null)
            {
                historicalData = new Dictionary<string, List<StockValue>>();

                foreach (var stock in marketData)
                {
                    IEnumerable<StockValue> stockValues = null;

                    switch (Cfg.LoadingDataType)
                    {
                        case LoadingDataType.LoadLastValues:
                            stockValues = Cfg.GetHistoryDataProvider().GetValues(stock.Code, Cfg.LoadingValuesCount);
                            break;

                        case LoadingDataType.LoadByNumberOfDays:
                            stockValues = Cfg.GetHistoryDataProvider().GetValues(stock.Code, GetStartDateTime(Cfg.LoadingNumberOfDays), DateTime.Now);
                            break;

                        default:
                            throw new ArgumentException();
                    }

                    if (stockValues != null)
                    {
                        stockValues.ToList().ForEach(i => i.Price = i.Price * stock.Lot);
                        historicalData.Add(stock.Code, stockValues.ToList());
                    }
                }
            }
            else
            {
                throw new Exception("Market data is not available.");
            }


            if (historicalData.Values.Count == 1)
            {
                throw new Exception("App has found only one stocks history. Minimum => 2.");
            }
            else if (historicalData.Values.Count == 0)
            {
                throw new Exception("No historical data to analyze.");
            }
            else
            {
                PairsContainer = new PairsContainer(historicalData, DeltaHelpers.GetDeltaInstances().First(i => i.Name == Cfg.DeltaName));
            }


            DataStorageTask.Interval = Cfg.DataSaveInterval;
            DataUpdateTask.Interval = Cfg.DataUpdateInterval;

            DataStorageTask.Start();
            DataUpdateTask.Start();

            IsSystemStarted = true;
        }

        public void Stop()
        {
            PairsContainer = null;

            if (DataStorageTask != null) DataStorageTask.Stop();
            if (DataUpdateTask != null) DataUpdateTask.Stop();

            IsSystemStarted = false;
        }


        protected virtual void OnCurrentDelta(object sender, CurrentDeltaValueEventArgs e)
        {
            if (CurrentDelta != null) CurrentDelta(sender, e);
        }

        private DateTime GetStartDateTime(int days)
        {
            DateTime from = DateTime.Now;

            while (days != 0)
            {
                from = from.Subtract(new TimeSpan(24, 00, 00));

                if (from.DayOfWeek != DayOfWeek.Saturday &&
                    from.DayOfWeek != DayOfWeek.Sunday)
                    days--;
            }

            return from;
        }

        public void Dispose()
        {
            if (DataStorageTask != null)
            {
                DataStorageTask.Stop();
                DataStorageTask.Dispose();
            }

            if (DataUpdateTask != null)
            {
                DataUpdateTask.Stop();
                DataUpdateTask.Dispose();
            }
        }

    }
}
