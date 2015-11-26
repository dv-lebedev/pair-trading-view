/*
Copyright 2015 Denis Lebedev

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

using System.Drawing;
using ZedGraph;

namespace PairTradingView.Controls
{
    public class MyZedgraphControl : ZedGraphControl
    {

        private PointPairList deltas;
        private PointPairList deltaSMA;
        private PointPairList deltaWMA;
        private PointPairList deltaCurrent;

        private LineItem deltasCurve;
        private LineItem deltaSMACurve;
        private LineItem deltaWMACurve;
        private LineItem deltaCurrentCurve;

        public MyZedgraphControl()
        {
            MasterPane mp = MasterPane;
            mp.Border.IsVisible = true;
            mp.Border.Color = Color.Yellow;

            ZedGraph.GraphPane pane = GraphPane;
            pane.Title.Text = "/";
            pane.Title.FontSpec.FontColor = Color.Gray;
            pane.IsFontsScaled = false;
            pane.XAxis.Title.Text = "t ";
            pane.YAxis.Title.Text = "Δ";

            deltas = new PointPairList();
            deltaSMA = new PointPairList();
            deltaWMA = new PointPairList();
            deltaCurrent = new PointPairList();

            deltasCurve = GraphPane.AddCurve("Δ", deltas, Color.FromArgb(0, 204, 0), SymbolType.None);
            deltaSMACurve = GraphPane.AddCurve("sma", deltaSMA, Color.FromArgb(255, 0, 0), SymbolType.None);
            deltaWMACurve = GraphPane.AddCurve("wma", deltaWMA, Color.Yellow, SymbolType.None);
            deltaCurrentCurve = GraphPane.AddCurve("now", deltaCurrent, Color.Gray, SymbolType.None);

            SetTheme();
        }


        public void SetDeltas(decimal[] values)
        {
            deltas.Clear();
            GraphPane.XAxis.Scale.Max = values.Length - 1;

            for (int i = 0; i < values.Length; i++)
            {
                deltas.Add(i, (double)values[i]);
            }

            AxisChange();
            Invalidate();
        }

        public void SetDeltaCurrent(decimal currentDelta)
        {
            deltaCurrent.Clear();

            for (int i = 0; i < deltas.Count; i++)
            {
                deltaCurrent.Add(i, (double)currentDelta);
            }

            AxisChange();
            Invalidate();
        }

        public void SetSMA(decimal[] values, int interval)
        {
            deltaSMA.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                deltaSMA.Add(i + interval, (double)values[i]);
            }

            AxisChange();
            Invalidate();
        }

        public void ClearSMA()
        {
            deltaSMA.Clear();

            AxisChange();
            Invalidate();
        }

        public void SetWMA(decimal[] values, int interval)
        {
            deltaWMA.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                deltaWMA.Add(i + interval, (double)values[i]);
            }

            AxisChange();
            Invalidate();
        }

        public void ClearWMA()
        {
            deltaWMA.Clear();

            AxisChange();
            Invalidate();
        }

        private void SetTheme()
        {
            GraphPane pane = GraphPane;
            pane.Legend.Fill.Type = FillType.Solid;
            pane.Legend.Fill.Color = Color.Black;
            pane.Legend.FontSpec.FontColor = Color.White;

            pane.Border.IsVisible = true;
            //pane.Border.Color = Color.DarkGray;

            pane.Fill.Type = FillType.Solid;
            pane.Fill.Color = Color.Black;

            pane.Chart.Fill.Type = FillType.Solid;
            pane.Chart.Fill.Color = Color.Black;

            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;

            pane.XAxis.Color = Color.LightGray;
            pane.YAxis.Color = Color.LightGray;

            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            pane.XAxis.MajorGrid.Color = Color.FromArgb(50, 50, 50);
            pane.YAxis.MajorGrid.Color = Color.FromArgb(45, 45, 45);

            pane.XAxis.Title.FontSpec.FontColor = Color.Gray;
            pane.YAxis.Title.FontSpec.FontColor = Color.Gray;

            pane.XAxis.Scale.FontSpec.FontColor = Color.Gray;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Gray;

            pane.Title.FontSpec.FontColor = Color.White;

            AxisChange();
            Invalidate();
        }
    }
}
