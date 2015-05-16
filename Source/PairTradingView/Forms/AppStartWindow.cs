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
        public DeltaType DeltaType { get; private set; }

        public AppStartWindow()
        {
            InitializeComponent();

            CsvFormat = new CsvFormat();

            priceIndexUpDown.Minimum = 5;
            volumeIndexUpDown.Minimum = 6;

            deltaTypeBox.Items.Add("Ratio");
            deltaTypeBox.Items.Add("RatioIncludingBeta");

            deltaTypeBox.Items.Add("Spread");
            deltaTypeBox.Items.Add("SpreadIncludingBeta");

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
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
            if (CsvFormat.PriceIndex == CsvFormat.VolumeIndex)
            {
                MessageBox.Show("Price and Volume indeces should have a different values!");
                return;
            }

            this.Close();
        }

        private void ContainsHeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CsvFormat.ContainsHeader = ContainsHeaderCheckBox.Checked;
        }

        private void openDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Downloader DlForm = new Downloader();
            DlForm.Show();
        }

        private void deltaTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (deltaTypeBox.Text)
            {
                case "Ratio":
                    DeltaType = DataProcessing.DeltaType.Ratio;
                    explanationLabel.Text = "if r_value >= 0: y / x \nelse: log(y) * log(x)";
                    break;

                case "RatioIncludingBeta":
                    DeltaType = DataProcessing.DeltaType.RatioIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y / (beta * x) \nelse: log(y) * (beta * log(x))";
                    break;

                case "Spread":
                    DeltaType = DataProcessing.DeltaType.Spread;
                    explanationLabel.Text = "if r_value >= 0: y - x \nelse: y + x";
                    break;

                case "SpreadIncludingBeta":
                    DeltaType = DataProcessing.DeltaType.SpreadIncludingBeta;
                    explanationLabel.Text = "if r_value >= 0: y - beta * x \nelse: y + beta * x";
                    break;
            }
        }
    }
}
