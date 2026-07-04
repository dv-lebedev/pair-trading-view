/*
    Copyright(c) 2026 Denis Lebedev

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

using PairTradingView.WpfApp.Infra;
using Serilog;

namespace PairTradingView.WpfApp;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        SetupLogging();
        RunTheApp();
    }

    private static void SetupLogging()
    {
        Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Verbose()
           .WriteTo.Debug()                          // Output to VS Debug window
           .WriteTo.File(
               path: "logs/ptv-.log",                // File path (relative or absolute)
               rollingInterval: RollingInterval.Day, // New file each day: ptv-20260704.log
               retainedFileCountLimit: 7,            // Keep last 7 days
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
           )
           .CreateLogger();

        Log.Information("Logging setup complete");
    }

    private static void RunTheApp()
    {
        Log.Debug("Starting WPF application...");

        var thread = new Thread(() =>
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        })
        {
            Name = "UI Thread"
        };
        thread.RunSTA(inSync: true);
    }
}