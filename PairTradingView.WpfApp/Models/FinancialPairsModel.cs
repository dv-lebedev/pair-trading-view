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
using PairTradingView.WpfApp.Entities;
using PairTradingView.WpfApp.Utils;
using Serilog;
using System.Collections.ObjectModel;

namespace PairTradingView.WpfApp.Models;

public partial class FinancialPairsModel : ObservableObject
{
    private readonly ILogger _log;

    private ExtFinancialPair _selectedPair;
    private int _smaValue;

    public ExtFinancialPair SelectedPair
    {
        get => _selectedPair;

        set
        {
            if (SetProperty(ref _selectedPair, value))
                SelectedPairChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public int SmaValue
    {
        get => _smaValue;

        set
        {
            if (SetProperty(ref _smaValue, value))
                SmaValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler SelectedPairChanged;
    public event EventHandler SmaValueChanged;
    public event EventHandler LoadNewDataRequested;

    public ObservableCollection<ExtFinancialPair> Pairs { get; }

    public event EventHandler PairsChanged;

    public FinancialPairsModel(ILogger logger)
    {
        _log = logger ?? throw new ArgumentNullException(nameof(logger));
        Pairs = new ObservableCollection<ExtFinancialPair>();
    }

    public void ReselectSelectedPair()
    {
        var pair = SelectedPair;
        SelectedPair = null;
        SelectedPair = pair;
    }

    public void LoadNewData()
    {
        LoadNewDataRequested?.Invoke(this, EventArgs.Empty);
    }

    public void UpdateStocks(Stock[] stocks)
    {
        try
        {
            var pairs = FinancialPair.CreateMany<ExtFinancialPair>(stocks);

            Pairs.Clear();

            if (pairs != null)
            {
                foreach (var pair in pairs)
                {
                    Pairs.Add(pair);
                }
            }

            PairsChanged?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error updating stocks");
            UserNotification.Display(ex.Message);
        }
    }

    public void Calculate(double balance)
    {
        try
        {
            var checkedPairs = Pairs.Where(i => i.Selected).ToList();

            if (checkedPairs.Count > 0)
            {
                //preparation
                foreach (var pair in Pairs)
                {
                    pair.TradeVolume = 0;
                    pair.X.TradeVolume = 0;
                    pair.Y.TradeVolume = 0;
                }

                new RiskManager(checkedPairs, balance).Calculate();
            }
            else
            {
                UserNotification.Display("Pairs are not selected.");
            }
        }
        catch (Exception ex)
        {
            UserNotification.Display("CalculateRisk => " + ex.Message);
            _log.Error(ex, "Error calculating risk");
        }
    }
}