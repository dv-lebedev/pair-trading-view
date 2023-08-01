/*
    Copyright(c) 2023 Denis Lebedev

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/

using System;
using System.Diagnostics;
using System.IO;

namespace PairTradingView.Shared
{
    public class Logger : IDisposable, ILogger
    {
        private const string LogFile = "PairTradingView.log.txt";
        private const string DateTimeFormat = "yyyyMMdd_HHmmss.fff";

        private readonly StreamWriter _sw;

        public static readonly ILogger Log = new Logger();

        private Logger()
        {
            _sw = new StreamWriter(LogFile, true);
        }

        public void Msg(string message)
        {
            _sw.WriteLine(DateTime.Now.ToString(DateTimeFormat));
            _sw.WriteLine(message);
            _sw.WriteLine(Environment.NewLine);
        }

        public void Err(Exception ex)
        {
            Msg(ex.ToString());
            Debug.WriteLine(ex.ToString());
        }

        public void Dispose()
        {
            _sw.Dispose();
        }
    }
}
