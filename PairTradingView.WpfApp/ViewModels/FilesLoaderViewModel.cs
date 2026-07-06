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

using CommunityToolkit.Mvvm.ComponentModel;
using PairTradingView.Shared;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Utils;
using Serilog;
using System.Windows.Input;

namespace PairTradingView.WpfApp.ViewModels;

public partial class FilesLoaderViewModel : ObservableObject
{
    private const string CsvFilesDirectory = "csv-files";

    private readonly FinancialPairsModel _fpModel;
    private readonly ILogger _log;

    [ObservableProperty]
    private Stock[]? _stocks;

    [ObservableProperty]
    private CsvSeparator _selectedSeparator;

    [ObservableProperty]
    private int _selectedPriceColumnNumber = 4;

    [ObservableProperty]
    private bool _containsHeader;

    public int[] PriceColumnNumbers { get; } = Enumerable.Range(1, 20).ToArray();

    public ICollection<CsvSeparator> Separators { get; }

    public ICommand LoadDataFromFilesCommand { get; }
    public ICommand CalculateButtonCommand { get; }

    public FilesLoaderViewModel(FinancialPairsModel financialPairsModel, ILogger logger)
    {
        _fpModel = financialPairsModel ?? throw new ArgumentNullException(nameof(financialPairsModel));
        _log = logger ?? throw new ArgumentNullException(nameof(logger));

        LoadDataFromFilesCommand = new RelayCommand(x => LoadDataFromFilesAction(), _log);
        CalculateButtonCommand = new RelayCommand(x => CalculateButtonAction(), _log);

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
                Stocks = CsvUtils.ReadAllDataFrom(CsvFilesDirectory, priceColumn, header, separator);
            }
        }
        catch (Exception ex)
        {
            _log.Error(ex, "Error loading data from files");
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
            _fpModel.UpdateStocks(Stocks);
        }
    }
}