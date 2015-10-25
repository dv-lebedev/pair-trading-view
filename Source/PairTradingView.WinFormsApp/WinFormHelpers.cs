using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PairTradingView.Helpers
{
    public static class WinFormHelpers
    {
        public static void DoInvoke(this Form form, Action func)
        {
            IAsyncResult result = form.BeginInvoke(func);

            form.EndInvoke(result);
        }
    }
}
