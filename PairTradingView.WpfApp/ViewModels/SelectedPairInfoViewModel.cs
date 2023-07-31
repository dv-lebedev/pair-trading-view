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
using PairTradingView.WpfApp.Entities;
using PairTradingView.WpfApp.Infra;
using PairTradingView.WpfApp.Models;
using System;
using System.Windows.Input;

namespace PairTradingView.WpfApp.ViewModels
{
    public class SelectedPairInfoViewModel : ObservableObject
    {
        private string _pairName;
        private string _xName;
        private string _yName;
        private double _pairsTradeVolume;
        private double _yTradeVolume;
        private double _xTradeVolume;
        private double _risk;
        private double _riskLimit;
        private double _balance;
        private double _sma;

        public string PairName
        {
            get => _pairName;

            set
            {
                _pairName = value;
                OnPropertyChanged();
            }
        }

        public string XName
        {
            get => _xName;

            set
            {
                _xName = value;
                OnPropertyChanged();
            }
        }

        public string YName
        {
            get => _yName;

            set
            {
                _yName = value;
                OnPropertyChanged();
            }
        }

        public double PairsTradeVolume
        {
            get => _pairsTradeVolume;

            set
            {
                _pairsTradeVolume = value;
                OnPropertyChanged();
            }
        }

        public double YTradeVolume
        {
            get => _yTradeVolume;

            set
            {
                _yTradeVolume = value;
                OnPropertyChanged();
            }
        }

        public double XTradeVolume
        {
            get => _xTradeVolume;

            set
            {
                _xTradeVolume = value;
                OnPropertyChanged();
            }
        }

        public double Risk
        {
            get => _risk;

            set
            {
                _risk = value;
                OnPropertyChanged();
            }
        }

        public double RiskLimit
        {
            get => _riskLimit;

            set
            {
                _riskLimit = value;
                OnPropertyChanged();
            }
        }

        public double Balance
        {
            get => _balance;

            set
            {
                _balance = value;
                OnPropertyChanged();
            }
        }

        public FinancialPairsModel Model { get; } = FinancialPairsModel.Instance;

        public ICommand CalulateCommand { get; }
        public ICommand LoadNewDataCommand { get; }

        public SelectedPairInfoViewModel() 
        {
            CalulateCommand = new RelayCommand(x => CalulateCommandAction());
            LoadNewDataCommand = new RelayCommand(x => LoadNewDataCommandAction());
            Balance = 100_000.00;

            Model.SelectedPairChanged += Instance_SelectedPairChanged;
        }

        private void LoadNewDataCommandAction()
        {   
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
}
