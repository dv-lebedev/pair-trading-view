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
using CommunityToolkit.Mvvm.Input;
using PairTradingView.WpfApp.Entities;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Utils;
using Serilog;
using System.Windows;

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
    private double _riskLimit;

    [ObservableProperty]
    private Balance _balance;

    [ObservableProperty]
    private Risk _risk;

    private readonly ILogger _log;

    public FinancialPairsModel Model { get; }

    public SelectedPairInfoViewModel(FinancialPairsModel financialPairsModel, Balance balance, Risk risk, ILogger logger) 
    {
        Model = financialPairsModel ?? throw new ArgumentNullException(nameof(financialPairsModel));
        _log = logger ?? throw new ArgumentNullException(nameof(logger));

        Balance = balance;
        Risk = risk;

        Model.SelectedPairChanged += (s,e) => UpdateUI();
        Model.Calculated += (s,e) => UpdateUI();
    }

    [RelayCommand]
    private void LoadNewData()
    {
        try
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
        catch (Exception ex)
        {
            _log.Error(ex, "Error loading new data");
            UserNotification.Display(ex);
        }
    }

    [RelayCommand]
    private void Calculate()
    {
        try
        {
            Model.Calculate();
            Model.ReselectSelectedPair();
        }
        catch (Exception ex)
        {
            _log.Error(ex, "Error calculating");
            UserNotification.Display(ex);
        }
    }

    private void UpdateUI()
    {
        if (Model.SelectedPair is ExtFinancialPair pair)
        {
            PairName = pair.Name;
            XName = pair.X.Name;
            YName = pair.Y.Name;

            PairsTradeVolume = pair.TradeVolume;
            XTradeVolume = pair.X.TradeVolume;
            YTradeVolume = pair.Y.TradeVolume;
            RiskLimit = pair.TradeVolume * Risk.Value / 100.0;
        }
    }
}