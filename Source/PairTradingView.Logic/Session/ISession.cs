using System;
namespace PairTradingView.Logic.Session
{
    public interface ISession
    {
        void CalculateRisk(string[] codes, double tradebalance);
        Configuration Cfg { get; }
        event EventHandler<CurrentDeltaValueEventArgs> CurrentDelta;
        void Dispose();
        bool IsSystemStarted { get; }
        DateTime LastDataStore { get; }
        PairTradingView.Logic.Synthetics.PairsContainer PairsContainer { get; }
        void Start();
        void Stop();
    }
}
