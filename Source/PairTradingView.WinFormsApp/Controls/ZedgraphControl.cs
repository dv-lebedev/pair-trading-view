using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace PairTradingView.Controls
{
    public class MyZedgraphControl : ZedGraphControl
    {

        PointPairList deltas, deltaSMA, deltaWMA, deltaCurrent;
        LineItem deltasCurve, deltaSMACurve, deltaWMACurve, deltaCurrentCurve;

        public MyZedgraphControl()
        {
            MasterPane mp = MasterPane;
            mp.Border.IsVisible = true;
            mp.Border.Color = Color.Yellow;

            Init();

            deltas = new PointPairList();
            deltaSMA = new PointPairList();
            deltaWMA = new PointPairList();
            deltaCurrent = new PointPairList();

            deltasCurve = GraphPane.AddCurve("Δ", deltas, Color.FromArgb(0, 204, 0), SymbolType.None);
            deltaSMACurve = GraphPane.AddCurve("sma", deltaSMA, Color.FromArgb(255, 0, 0), SymbolType.None);
            deltaWMACurve = GraphPane.AddCurve("wma", deltaWMA, Color.Yellow, SymbolType.None);
            deltaCurrentCurve = GraphPane.AddCurve("now", deltaCurrent, Color.Gray, SymbolType.None);

            BlackTheme();

        }


        public void SetDeltas(double[] values)
        {
            deltas.Clear();
            GraphPane.XAxis.Scale.Max = values.Length - 1;

            for (int i = 0; i < values.Length; i++)
            {
                deltas.Add(i, values[i]);
            }

            AxisChange();
            Invalidate();
        }

        public void SetDeltaCurrent(double currentDelta)
        {
            deltaCurrent.Clear();

            for (int i = 0; i < deltas.Count; i++)
            {
                deltaCurrent.Add(i, currentDelta);
            }

            AxisChange();
            Invalidate();
        }

        public void SetSMA(double[] values, int interval)
        {
            deltaSMA.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                deltaSMA.Add(i + interval, values[i]);
            }

            AxisChange();
            Invalidate();
        }

        public void SetWMA(double[] values, int interval)
        {
            deltaWMA.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                deltaWMA.Add(i + interval, values[i]);
            }

            AxisChange();
            Invalidate();
        }


        private void Init()
        {
            ZedGraph.GraphPane pane = GraphPane;

            pane.Title.Text = "/";
            pane.Title.FontSpec.FontColor = Color.Gray;
            pane.IsFontsScaled = false;
            pane.XAxis.Title.Text = "t ";
            pane.YAxis.Title.Text = "Δ";


            //pane.XAxis.Scale.Min = 0;
            ////pane.XAxis.Type = AxisType.DateAsOrdinal;
            //IsShowHScrollBar = true;
            //ScrollMinX = 0;
            //IsAutoScrollRange = false;
            //IsEnableHPan = true;
            //IsEnableHZoom = true;
            //IsEnableVPan = false;
            //IsEnableVZoom = false;
            //AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //GraphPane.XAxis.Scale.Min = 0;
            //GraphPane.YAxis.Scale.MaxAuto = true;
            //GraphPane.YAxis.Scale.MinAuto = true;
            //GraphPane.IsBoundedRanges = true;
        }

        public void BlackTheme()
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

            pane.XAxis.MajorGrid.Color = Color.FromArgb(35, 35, 35);
            pane.YAxis.MajorGrid.Color = Color.FromArgb(35, 35, 35);

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
