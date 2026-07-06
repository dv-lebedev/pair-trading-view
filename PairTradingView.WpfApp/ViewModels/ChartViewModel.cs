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

using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Entities;
using PairTradingView.Shared.Statistics;
using CommunityToolkit.Mvvm.ComponentModel;
using OxyPlot.Legends;

namespace PairTradingView.WpfApp.ViewModels;

public partial class ChartViewModel : ObservableObject
{
    private readonly OxyColor DeltaColor = OxyColor.Parse("#00ffff");
    private readonly OxyColor SMAColor = OxyColor.Parse("#FF0000");

    private readonly FinancialPairsModel _fpModel;

    [ObservableProperty]
    private PlotModel _plotModel;

    public ChartViewModel(FinancialPairsModel financialPairsModel)
    {
        _fpModel = financialPairsModel ?? throw new ArgumentNullException(nameof(financialPairsModel));

        PlotModel = new PlotModel();
        SetUpModel();
      
        _fpModel.PairsChanged += (s, e) =>
        {
            PlotModel = new PlotModel();
            SetUpModel();
        };

        _fpModel.SelectedPairChanged += UpdatePlot;

        _fpModel.SmaValueChanged += UpdatePlot;
    }

    private void UpdatePlot(object sender, EventArgs e)
    {
        if (_fpModel.SelectedPair is ExtFinancialPair pair)
        {
            Update(pair.DeltaValues, pair.Name, _fpModel.SmaValue);
        }
    }

    private void SetUpModel()
    {
        PlotModel.Legends.Add(new Legend
        {
            LegendPosition = LegendPosition.TopLeft,
            LegendPlacement = LegendPlacement.Outside,
            LegendOrientation = LegendOrientation.Horizontal,
            LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
            LegendBorder = OxyColors.LightGray,
        });

        PlotModel.PlotAreaBorderColor = OxyColors.Transparent;

        var xAxis = new LinearAxis()
        {
            Position = AxisPosition.Left,
            IsZoomEnabled = false,
            IsPanEnabled = false,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot,
            TicklineColor = OxyColors.DimGray,
            AxislineColor = OxyColors.DimGray,
            ExtraGridlineColor = OxyColors.DimGray,
            MajorGridlineColor = OxyColors.DimGray,
            MinorGridlineColor = OxyColors.DimGray,
            TickStyle = TickStyle.None,
            TextColor = OxyColors.LightGray,
            TitleColor = OxyColors.LightGray,
            Title = "Δ"
        };
        PlotModel.Axes.Add(xAxis);

        var yAxis = new LinearAxis()
        {
            Position = AxisPosition.Bottom,
            IsZoomEnabled = false,
            IsPanEnabled = false,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot,
            TickStyle = TickStyle.None,
            TextColor = OxyColors.LightGray,
            TitleColor = OxyColors.LightGray,
            Title = "t"
        };
        PlotModel.Axes.Add(yAxis);
    }

    public void Update(double[] values, string title, int SMAPeriod = 0)
    {
        PlotModel.Title = title;
        PlotModel.TitleColor = OxyColors.LightGray;

        PlotModel.Series.Clear();

        AddLineSerie("Δ", DeltaColor, values, 0);

        if (SMAPeriod > 0 && SMAPeriod < values.Length)
        {
            var SMAValues = MovingAverages.SMA(values, SMAPeriod);
            AddLineSerie("SMA", SMAColor, SMAValues, SMAPeriod);
        }

        PlotModel.InvalidatePlot(true);
    }

    private void AddLineSerie(string title, OxyColor color, double[] values, int offset = 0)
    {
        var lineSerie = new LineSeries
        {
            StrokeThickness = 2,
            MarkerSize = 3,
            MarkerStroke = OxyColors.Red,
            MarkerType = MarkerType.None,
            CanTrackerInterpolatePoints = false,
            Color = color,
            Title = title,
        };

        for (int i = 0; i < values.Length; i++)
        {
            lineSerie.Points.Add(new DataPoint(Axis.ToDouble(i + offset), values[i]));
        }

        PlotModel.Series.Add(lineSerie);
    }
}