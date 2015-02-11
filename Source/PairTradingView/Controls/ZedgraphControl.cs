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

        PointPairList deltas, deltaSMA, deltaWMA;
        LineItem deltasCurve, deltaSMACurve, deltaWMACurve;

        public MyZedgraphControl()
        {

            MasterPane mp = MasterPane;
            mp.Border.IsVisible = true;
            mp.Border.Color = Color.Yellow;


            Init();

            deltas = new PointPairList();
            deltaSMA = new PointPairList();
            deltaWMA = new PointPairList();

            deltasCurve = GraphPane.AddCurve("Δ", deltas, Color.FromArgb(0, 204, 0), SymbolType.None);
            deltaSMACurve = GraphPane.AddCurve("sma", deltaSMA, Color.FromArgb(255, 0, 0), SymbolType.None);
            deltaWMACurve = GraphPane.AddCurve("wma", deltaWMA, Color.Yellow, SymbolType.None);
           
        }


        public void SetDeltas(double[] values)
        {
            deltas.Clear();
           GraphPane.XAxis.Scale.Max = values.Length;

            for (int i = 0; i < values.Length; i++)
            {
                deltas.Add(i, values[i]);
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


            //    pane.XAxis.Scale.Min = 0;
            //    pane.XAxis.Type = AxisType.DateAsOrdinal;

            //    zedGraphControl.IsShowHScrollBar = true;
            //    zedGraphControl.ScrollMinX = 0;
            //    zedGraphControl.IsAutoScrollRange = false;
            //    zedGraphControl.IsEnableHPan = true;
            //    zedGraphControl.IsEnableHZoom = true;
            //    zedGraphControl.IsEnableVPan = false;
            //    zedGraphControl.IsEnableVZoom = false;
            //    zedGraphControl.AutoScaleMode = AutoScaleMode.None;
            //    zedGraphControl.GraphPane.XAxis.Scale.Min = 0;
            //    zedGraphControl.GraphPane.YAxis.Scale.MaxAuto = true;
            //    zedGraphControl.GraphPane.YAxis.Scale.MinAuto = true;
            //    zedGraphControl.GraphPane.IsBoundedRanges = true;
        }

        public void BlackTheme()
        {
            GraphPane pane = GraphPane;
            pane.Legend.Fill.Type = FillType.Solid;
            pane.Legend.Fill.Color = Color.Black;
            pane.Legend.FontSpec.FontColor = Color.White;

            pane.Border.IsVisible = true;
            // pane.Border.Color = Color.DarkGray;

            // Закрасим фон всего компонента ZedGraph
            // Заливка будет сплошная
            pane.Fill.Type = FillType.Solid;
            pane.Fill.Color = Color.Black;

            // Закрасим область графика (его фон) в черный цвет
            pane.Chart.Fill.Type = FillType.Solid;
            pane.Chart.Fill.Color = Color.Black;

            // Включим показ оси на уровне X = 0 и Y = 0, чтобы видеть цвет осей
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;
            // Установим цвет осей
            pane.XAxis.Color = Color.LightGray;
            pane.YAxis.Color = Color.LightGray;

            // Включим сетку
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            //// Установим цвет для сетки
            pane.XAxis.MajorGrid.Color = Color.FromArgb(35, 35, 35);
            pane.YAxis.MajorGrid.Color = Color.FromArgb(35, 35, 35);

            // Установим цвет для подписей рядом с осями
            pane.XAxis.Title.FontSpec.FontColor = Color.Gray;
            pane.YAxis.Title.FontSpec.FontColor = Color.Gray;

            // Установим цвет подписей под метками
            pane.XAxis.Scale.FontSpec.FontColor = Color.Gray;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Gray;

            // Установим цвет заголовка над графиком
            pane.Title.FontSpec.FontColor = Color.White;

            AxisChange();
            Invalidate();
        }
    }
}
