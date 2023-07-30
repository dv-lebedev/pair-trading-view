/*
Copyright(c) 2015-2023 Denis Lebedev

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

using PairTradingView.Shared;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Views;
using System.Windows.Controls;

namespace PairTradingView.WpfApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly UserControl FilesLoaderView = new FilesLoaderView();
        private readonly UserControl MainView = new MainView();
        private readonly FinancialPairsModel Model = FinancialPairsModel.Instance;

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CurrentView = FilesLoaderView;

            Model.LoadNewDataRequested += (s, e) => CurrentView = FilesLoaderView;
            Model.PairsChanged += (s, e) => CurrentView = MainView;
        }
    }
}
