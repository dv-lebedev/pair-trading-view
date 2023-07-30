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

using PairTradingView.Infrastructure;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PairTradingView.WpfApp.ViewModels
{
    public class FilesLoaderViewModel : ObservableObject
    {
        private const string csvFilesDirectory = "csv-files";
        private Stock[] _stocks;

        private int _selectedPriceColumnNumber = 4;
        private bool _containsHeader;

        public Stock[] Stocks
        {
            get => _stocks;

            set
            {
                _stocks = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPriceColumnNumber
        {
            get => _selectedPriceColumnNumber;

            set
            {
                _selectedPriceColumnNumber = value;
                OnPropertyChanged();
            }
        }

        public int[] PriceColumnNumbers { get; } = Enumerable.Range(1, 20).ToArray();

        public bool ContainsHeader
        {
            get => _containsHeader;

            set
            {
                _containsHeader = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataFromFilesCommand { get; }
        public ICommand CalculateButtonCommand { get; }

        public FilesLoaderViewModel()
        {
            LoadDataFromFilesCommand = new RelayCommand(x => LoadDataFromFilesAction());
            CalculateButtonCommand = new RelayCommand(x => CalculateButtonAction());
        }

        private void LoadDataFromFilesAction()
        {
            try
            {
                int priceColumn = SelectedPriceColumnNumber;
                bool header = ContainsHeader;
                Stocks = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceColumn, header);
            }
            catch (Exception ex)
            {
                Logger.Log.Err(ex);
            }
        }

        private void CalculateButtonAction()
        {
            if (Stocks == null || Stocks.Length == 0)
            {
                MessageBox.Show("No input data.");
            }
            else if (Stocks.Length == 1)
            {
                MessageBox.Show("You should have 2 stocks minimum.");
            }
            else
            {
                FinancialPairsModel.Instance.UpdateStocks(Stocks);
            }
        }
    }
}
