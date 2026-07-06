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
using PairTradingView.WpfApp.Entities;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using Serilog;
using System.Windows;
using System.Windows.Input;

namespace PairTradingView.WpfApp.ViewModels;

public partial class SelectedPairInfoViewModel : ObservableObject
{
    [ObservableProperty]
    private string _pairName;

    [ObservableProperty]
    private string _xName;

    [ObservableProperty]
    private string _yName;

    [ObservableProperty]
    private double _pairsTradeVolume;

    [ObservableProperty]
    private double _yTradeVolume;

    [ObservableProperty]
    private double _xTradeVolume;

    [ObservableProperty]
    private double _risk;

    [ObservableProperty]
    private double _riskLimit;

    [ObservableProperty]
    private double _balance;

    private readonly ILogger _log;

    public FinancialPairsModel Model { get; }

    public ICommand CalulateCommand { get; }
    public ICommand LoadNewDataCommand { get; }

    public SelectedPairInfoViewModel(FinancialPairsModel financialPairsModel, ILogger logger) 
    {
        Model = financialPairsModel ?? throw new ArgumentNullException(nameof(financialPairsModel));
        _log = logger ?? throw new ArgumentNullException(nameof(logger));

        CalulateCommand = new RelayCommand(x => CalulateCommandAction(), _log);
        LoadNewDataCommand = new RelayCommand(x => LoadNewDataCommandAction(), _log);
        Balance = 100_000.00;

        Model.SelectedPairChanged += Instance_SelectedPairChanged;
    }

    private void LoadNewDataCommandAction()
    {   
        var dialog = MessageBox.Show(
            "Are you sure you want to load new data? All current data will be lost.",
            "Load New Data",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (dialog == MessageBoxResult.No)
            return;

        Model.LoadNewData();
    }

    private void Instance_SelectedPairChanged(object sender, EventArgs e)
    {
        if (Model.SelectedPair is ExtFinancialPair pair)
        {
            PairName = pair.Name;
            XName = pair.X.Name;
            YName = pair.Y.Name;

            PairsTradeVolume = pair.TradeVolume;
            XTradeVolume = pair.X.TradeVolume;
            YTradeVolume = pair.Y.TradeVolume;
            RiskLimit = pair.TradeVolume * Risk / 100.0;
        }
    }

    private void CalulateCommandAction()
    {
        Model.Calculate(Balance);
        Model.ReselectSelectedPair();
    }
}