using PairTradingView.Infrastructure;
using PairTradingView.WpfApp.Entities;
using PairTradingView.WpfApp.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PairTradingView.WpfApp.Models
{
    public class FinancialPairsModel : ObservableObject
    {
        private ExtFinancialPair _selectedPair;
        private int _smaValue;

        public ExtFinancialPair SelectedPair
        {
            get => _selectedPair;

            set
            {
                if (_selectedPair != value)
                {
                    _selectedPair = value;
                    OnPropertyChanged();
                    SelectedPairChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public int SmaValue
        {
            get => _smaValue;

            set
            {
                if (_smaValue != value)
                {
                    _smaValue = value;
                    OnPropertyChanged();
                    SmaValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler SelectedPairChanged;
        public event EventHandler SmaValueChanged;

        public ObservableCollection<ExtFinancialPair> Pairs { get; }

        public static readonly FinancialPairsModel Instance = new FinancialPairsModel();

        public event EventHandler PairsChanged;

        private FinancialPairsModel()
        {
            Pairs = new ObservableCollection<ExtFinancialPair>();
        }

        public void ReselectSelectedPair()
        {
            var pair = SelectedPair;
            SelectedPair = null;
            SelectedPair = pair;
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
                Logger.Log.Err(ex);
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

                    new RiskManager(checkedPairs.ToArray(), balance).Calculate();

                    //infoControl.Update(SelectedPair);
                }
                else
                {
                    WindowHelpers.Display("Pairs are not selected.");
                }
            }
            catch (Exception ex)
            {
                WindowHelpers.Display("CalculateRisk => " + ex.Message);
                Logger.Log.Err(ex);
            }
        }

        private void UpdateInfoAndCharts()
        {
          /*  try
            {
                if (dataGridControl.dataGrid.SelectedItem is ExtFinancialPair extFinancialPair)
                {
                    SelectedPair = extFinancialPair;

                    var SMAValue = infoControl.SMA.GetInt32();

                    if (SMAValue < 0) SMAValue = 0;

                    chartControl.Update(SelectedPair.DeltaValues, SelectedPair.Name, SMAValue);
                    infoControl.Update(SelectedPair);
                }
            }
            catch (Exception ex)
            {
                WindowHelpers.Display($"UpdateInfoAndCharts => {ex.Message}");
            }*/
        }
    }
}
