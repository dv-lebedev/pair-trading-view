using System;

namespace PairTradingView.Data.SqlData
{
    public class DataTasks : IDisposable
    {
        public System.Timers.Timer DataUpdater { get; private set; }
        public System.Timers.Timer DataSaver { get; private set; }


        public DataTasks()
        {
            DataUpdater = new System.Timers.Timer();
            DataSaver = new System.Timers.Timer();

            DataUpdater.Interval = 1000;
            DataSaver.Interval = 60 * 1000;
        }


        public void SetDataUpdateInterval(int seconds)
        {
            DataUpdater.Interval = seconds * 1000;
        }

        public void SetDataSaveInterval(int minutes)
        {
            DataSaver.Interval = minutes * 60 * 1000;
        }

        public void Start()
        {
            DataUpdater.Enabled = true;
            DataSaver.Enabled = true;
        }

        public void Stop()
        {
            DataUpdater.Enabled = false;
            DataSaver.Enabled = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool flag)
        {
            if(flag)
            {
                if(DataUpdater != null) DataUpdater.Dispose();

                if(DataSaver != null) DataSaver.Dispose();
            }
        }

    }
}
