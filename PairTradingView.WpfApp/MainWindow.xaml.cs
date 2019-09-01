
/*
Copyright(c) 2015-2019 Denis Lebedev

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

using PairTradingView.Infrastructure;
using PairTradingView.WpfApp.Logic;
using System.Windows;

namespace PairTradingView.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly LogicMediator logicMediator;

        public MainWindow(Stock[] stocks)
        {
            InitializeComponent();

            logicMediator = new LogicMediator(
                stocks, dataGridControl,
                infoControl, chartControl);
        }
    }
}
