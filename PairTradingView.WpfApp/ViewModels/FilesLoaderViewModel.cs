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

using PairTradingView.Shared;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PairTradingView.WpfApp.ViewModels
{
    public class FilesLoaderViewModel : ObservableObject
    {
        private readonly FinancialPairsModel Model = FinancialPairsModel.Instance;

        private const string csvFilesDirectory = "csv-files";
        private Stock[] _stocks;
        private CsvSeparator _selectedSeparator;

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

        public ICollection<CsvSeparator> Separators { get; }

        public CsvSeparator SelectedSeparator
        {
            get => _selectedSeparator;

            set
            {
                _selectedSeparator = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataFromFilesCommand { get; }
        public ICommand CalculateButtonCommand { get; }

        public FilesLoaderViewModel()
        {
            LoadDataFromFilesCommand = new RelayCommand(x => LoadDataFromFilesAction());
            CalculateButtonCommand = new RelayCommand(x => CalculateButtonAction());

            Separators = new List<CsvSeparator>
            {
                CsvSeparator.Comma,
                CsvSeparator.Space,
                CsvSeparator.Tab,
            };

            SelectedSeparator = Separators.FirstOrDefault();  
        }

        private void LoadDataFromFilesAction()
        {
            try
            {
                int priceColumn = SelectedPriceColumnNumber;
                bool header = ContainsHeader;

                if (SelectedSeparator?.Value is char separator)
                {
                    Stocks = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceColumn, header, separator);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Err(ex);
                UserNotification.Display(ex);
            }
        }

        private void CalculateButtonAction()
        {
            if (Stocks == null || Stocks.Length == 0)
            {
                UserNotification.Display("No input data.");
            }
            else if (Stocks.Length == 1)
            {
                UserNotification.Display("You should have 2 stocks minimum.");
            }
            else
            {
                Model.UpdateStocks(Stocks);
            }
        }
    }
}
