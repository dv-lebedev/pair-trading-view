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

using PairTradingView.Shared;
using PairTradingView.Shared.Statistics;
using System.ComponentModel;

namespace PairTradingView.WpfApp.Entities;

public class ExtFinancialPair : FinancialPair, INotifyPropertyChanged
{
    public ExtFinancialPair(Stock x, Stock y)
        : base(x, y)
    {
        DeltaAverage = DeltaValues.Average();
        DeltaMax = DeltaValues.Max();
        DeltaMin = DeltaValues.Min();
        DeltaSD = MathUtils.GetStandardDeviation(DeltaValues);
        SD_X = X.Deviation;
        SD_Y = Y.Deviation;
        DeltaSDMinus3Q = DeltaAverage - (3 * DeltaSD);
        DeltaSDPlus3Q = DeltaAverage + (3 * DeltaSD);
    }

    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        set
        {
            if (_selected != value)
            {
                _selected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selected)));
                SelectedChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public double DeltaAverage { get; set; }
    public double DeltaMax { get; set; }
    public double DeltaMin { get; set; }
    public double DeltaSD { get; set; }
    public double SD_X { get; set; }
    public double SD_Y { get; set; }
    public double DeltaSDMinus3Q { get; set; }
    public double DeltaSDPlus3Q { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler? SelectedChanged;
}