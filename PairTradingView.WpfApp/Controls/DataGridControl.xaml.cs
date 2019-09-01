
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

using PairTradingView.WpfApp.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace PairTradingView.WpfApp
{
    public partial class DataGridControl : UserControl
    {
        public DataGridControl()
        {
            InitializeComponent();          
        }

        public void InitDataGridControl(ObservableCollection<ExtFinancialPair> pairs, Action callback)
        {
            dataGrid.AddHandler(
                MouseLeftButtonDownEvent,
                new MouseButtonEventHandler((e, c) => { callback(); }),
                true);

            dataGrid.PreviewKeyDown += (s, e) => { callback(); };
            dataGrid.PreviewKeyUp += (s, e) => { callback(); };

            dataGrid.ItemsSource = pairs;

            //select first pair to show
            dataGrid.SelectedIndex = 0;
            callback();
        }
    }
}
