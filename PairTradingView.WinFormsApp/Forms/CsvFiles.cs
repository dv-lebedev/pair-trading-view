using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PairTradingView.Csv;
using PairTradingView.Forms;
using PairTradingView.Synthetics;

namespace PairTradingView.WinFormsApp.Forms
{
    public partial class CsvFiles : Form
    {
        private MainWindow mWindow;
        private const string CSV_FILES_DIRECTORY = "csv-files";

        public CsvFiles(MainWindow mainWindow)
        {
            if (mainWindow == null) 
                throw new ArgumentNullException();

            this.mWindow = mainWindow;
            InitializeComponent();
        }


        private void CsvToDbWindow_Load(object sender, EventArgs e)
        {
            deltaTypeBox.Items.Add("SPREAD");
            deltaTypeBox.Items.Add("RATIO");
            deltaTypeBox.Text = deltaTypeBox.Items[0].ToString();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                var quotes = GetQuotes();

                var factory = new SyntheticsFactory(quotes);

                mWindow.Synthetics = factory.CreateSynthetics(DeltaType.SPREAD).ToList();
                mWindow.UpdateListView();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load => " + ex.Message);
            }
        }


        private Dictionary<string, decimal[]> GetQuotes()
        {
            var result = new Dictionary<string, decimal[]>();

            try
            {
                foreach (var file in Directory.EnumerateFiles(CSV_FILES_DIRECTORY))
                {
                    if (file.EndsWith(".txt") || file.EndsWith(".csv"))
                    {
                        var name = Path.GetFileNameWithoutExtension(file);

                        result.Add(name, CsvFile.Read(file, (int)priceColumn.Value, header.Checked));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("GetQuotes => " + e.Message);
            }

            return result;
        }
    }
}
