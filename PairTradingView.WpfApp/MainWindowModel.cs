
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
using System.ComponentModel;

namespace PairTradingView.WpfApp
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { plotModel = value; OnPropertyChanged("PlotModel"); }
        }

        public MainWindowModel()
        {
            PlotModel = new PlotModel();
            SetUpModel();
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitle = "Legend";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopRight;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.White;

            var dateAxis = new DateTimeAxis()
            {  
                MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80
            };
            //PlotModel.Axes.Add(dateAxis);

            var valueAxis = new LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value" };
            PlotModel.Axes.Add(valueAxis);

        }

        public void Update(double[] data, string title)
        {
            PlotModel.Series.Clear();

            var lineSerie = new LineSeries
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Red,
                MarkerType = MarkerType.None,
                CanTrackerInterpolatePoints = false,
                Color = OxyColor.Parse("#00A3A3"),
                Title = title,
                Smooth = false
            };

            for (int i = 0; i < data.Length; i++)
            {
                lineSerie.Points.Add(new DataPoint(Axis.ToDouble(i), data[i]));
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
