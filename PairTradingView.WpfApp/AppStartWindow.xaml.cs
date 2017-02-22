using PairTradingView.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PairTradingView.WpfApp
{
    /// <summary>
    /// Interaction logic for AppStartWindow.xaml
    /// </summary>
    public partial class AppStartWindow : Window
    {
        private string csvFilesDirectory = "csv-files";
        public AppData AppData { get; private set; }

        public AppStartWindow()
        {
            InitializeComponent();
            InitDeltaTypeBox();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitDeltaTypeBox()
        {
            foreach (var item in Enum.GetNames(typeof(DeltaType)))
            {
                deltaTypeBox.Items.Add(item);
            }

            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int priceIndex = Utils.TextBoxValueToInt32(priceCol) - 1;

                bool header = containsHeader.IsChecked.Value;

                AppData = new AppData();

                AppData.InputData = CsvUtils.ReadAllDataFrom(csvFilesDirectory, priceIndex, header);
                AppData.DeltaTypeName = deltaTypeBox.Text;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Start => {ex.Message}");
            }
        }
    }
}
