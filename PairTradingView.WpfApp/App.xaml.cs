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

using Microsoft.Extensions.DependencyInjection;
using PairTradingView.Shared;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.ViewModels;
using System.Windows;

namespace PairTradingView.WpfApp
{
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; private set; }

        public App()
        {
            BuildServices();
        }

        private static void BuildServices()
        {
            var sc = new ServiceCollection();
            sc.AddAsOneServices();
            Services = sc.BuildServiceProvider();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Logger.Log.Dispose();
        }
    }
}
