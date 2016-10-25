
/*
Copyright(c) 2015-2016 Denis Lebedev

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

using PairTradingView.Infrastructure;
using Statistics;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PairTradingView.Controls
{
    public class ListViewNF : ListView
    {
        public ListViewNF()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            this.HideSelection = false;
            this.OwnerDraw = true;

            this.DrawItem += ListViewNF_DrawItem;
            this.DrawColumnHeader += ListViewNF_DrawColumnHeader;
        }

        void ListViewNF_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds);
            e.DrawText();
        }

        void ListViewNF_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        public void Update(List<FinancialPair> pairs)
        {
            foreach (var pair in pairs)
            {
                var xSymbol = pair.X.Name;
                var ySymbol = pair.Y.Name;

                int index = Items.Add(pair.Name.ToString(), xSymbol, 0).Index;

                Items[index].SubItems.Add(ySymbol);

                var regression = pair.Regression as LinearRegression;

                Items[index].SubItems.Add(Math.Round(pair.X.Deviation, 6).ToString());
                Items[index].SubItems.Add(Math.Round(pair.Y.Deviation, 6).ToString());
                Items[index].SubItems.Add(Math.Round(regression.Alpha, 6).ToString());
                Items[index].SubItems.Add(Math.Round(regression.Beta, 6).ToString());
                Items[index].SubItems.Add(Math.Round(regression.RValue, 6).ToString());
                Items[index].SubItems.Add(Math.Round(regression.RSquared, 6).ToString());

                var deltaAverage = pair.DeltaValues.Average();
                var deltaSD = MathUtils.GetStandardDeviation(pair.DeltaValues);

                Items[index].SubItems.Add(Math.Round(deltaAverage, 6).ToString());
                Items[index].SubItems.Add(Math.Round(pair.DeltaValues.Min(), 6).ToString());
                Items[index].SubItems.Add(Math.Round(pair.DeltaValues.Max(), 6).ToString());
                Items[index].SubItems.Add(Math.Round(deltaSD, 6).ToString());
                Items[index].SubItems.Add(Math.Round(deltaAverage - (3 * deltaSD), 6).ToString());
                Items[index].SubItems.Add(Math.Round(deltaAverage + (3 * deltaSD), 6).ToString());

                if (regression.RValue >= 0.7M && regression.RValue <= 1)
                {
                    Items[index].BackColor = Color.FromArgb(38, 153, 38);
                }

                if (regression.RValue <= -0.7M && regression.RValue >= -1)
                {
                    Items[index].BackColor = Color.FromArgb(191, 48, 48);
                }
            }
        }
    }
}
