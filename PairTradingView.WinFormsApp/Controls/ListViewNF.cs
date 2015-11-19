using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
