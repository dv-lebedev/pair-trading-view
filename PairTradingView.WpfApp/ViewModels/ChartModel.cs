
/*
Copyright(c) 2015-2017 Denis Lebedev

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

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlotDemo.Annotations;
using PairTradingView.Infrastructure;
using System.ComponentModel;

namespace PairTradingView.WpfApp
{
    public class ChartModel : INotifyPropertyChanged
    {
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { plotModel = value; OnPropertyChanged("PlotModel"); }
        }

        public ChartModel()
        {
            PlotModel = new PlotModel();
            SetUpModel();
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitle = "";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopLeft;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.White;

            var valueAxis = new LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Δ" };
            PlotModel.Axes.Add(valueAxis);
        }

        public void Update(double[] values, string title, int SMAPeriod = 0)
        {
            PlotModel.Title = title;

            PlotModel.Series.Clear();

            AddLineSerie("Δ", OxyColor.Parse("#00A3A3"), values, 0);

            if (SMAPeriod > 0)
            {
                var SMAValues = MovingAverages.SMA(values, SMAPeriod);
                AddLineSerie("SMA", OxyColor.Parse("#FF0000"), SMAValues, SMAPeriod);
            }
        }

        public void AddLineSerie(string title, OxyColor color, double[] values, int offset = 0)
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
                Smooth = false
            };

            for (int i = 0; i < values.Length; i++)
            {
                lineSerie.Points.Add(new DataPoint(Axis.ToDouble(i + offset), values[i]));
            }

            PlotModel.Series.Add(lineSerie);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
