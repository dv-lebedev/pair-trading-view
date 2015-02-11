using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PairTradingView.DataProcessing;

namespace PairTradingView.Forms
{
    public partial class AppStartWindow : Form
    {
        public CsvFormat CsvFormat { get; private set; }

        public AppStartWindow()
        {
            InitializeComponent();

            CsvFormat = new CsvFormat();

            priceIndexUpDown.Minimum = 1;
            volumeIndexUpDown.Minimum = 1;
        }

        private void AppStartWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void priceIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            CsvFormat.PriceIndex = (int)priceIndexUpDown.Value - 1;
        }

        private void volumeIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            CsvFormat.VolumeIndex = (int)volumeIndexUpDown.Value -1;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContainsHeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CsvFormat.ContainsHeader = ContainsHeaderCheckBox.Checked;
        }
    }
}
