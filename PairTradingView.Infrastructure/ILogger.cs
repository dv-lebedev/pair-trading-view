using System;

namespace PairTradingView.Infrastructure
{
    public interface ILogger
    {
        void Dispose();
        void Err(Exception ex);
        void Msg(string message);
    }
}