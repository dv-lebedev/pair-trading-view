using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PairTradingView.Data.Csv;
using PairTradingView.Data.DataProviders;
using PairTradingView.Forms;
using PairTradingView.Helpers;

namespace PairTradingView.WinFormsApp.Forms
{
    public partial class CsvToStorageWindow : Form
    {

        private MainWindow mWindow;

        private static Dictionary<string, CsvFormat> csvFormats;
        private static Dictionary<string, char> csvSeparators;


        public CsvToStorageWindow(MainWindow mainWindow)
        {
            if (mainWindow == null) throw new NullReferenceException();

            this.mWindow = mainWindow;

            InitializeComponent();
        }

        static CsvToStorageWindow()
        {
            csvFormats = new Dictionary<string, CsvFormat>();
            csvFormats.Add("DATE, TIME, OPEN, HIGH, LOW, CLOSE, VOL",
                new CsvFormat { DateIndex = 0, TimeIndex = 1, PriceIndex = 5, VolumeIndex = 6 });

            csvFormats.Add("DATETIME, OPEN, HIGH, LOW, CLOSE, VOL",
                new CsvFormat { DateIndex = 0, TimeIndex = 0, PriceIndex = 4, VolumeIndex = 5 });

            csvFormats.Add("TICKER, PER, DATE, TIME, OPEN, HIGH, LOW, CLOSE, VOL",
                new CsvFormat { DateIndex = 2, TimeIndex = 3, PriceIndex = 7, VolumeIndex = 8 });

            csvFormats.Add("TICKER, PER, DATETIME, OPEN, HIGH, LOW, CLOSE, VOL",
                new CsvFormat { DateIndex = 2, TimeIndex = 2, PriceIndex = 6, VolumeIndex = 7 });


            csvSeparators = new Dictionary<string, char>();
            csvSeparators.Add("Comma", ',');
            csvSeparators.Add("Semicolon", ';');
            csvSeparators.Add("BlankSpace", ' ');
        }


        private void CsvToDbWindow_Load(object sender, EventArgs e)
        {
            try
            {
                progressBar1.MarqueeAnimationSpeed = 0;

                formatComboBox.Items.AddRange(csvFormats.Keys.ToArray());
                formatComboBox.Text = formatComboBox.Items[0].ToString();

                separatorBox.Items.AddRange(csvSeparators.Keys.ToArray());
                separatorBox.Text = separatorBox.Items[0].ToString();

                dtFormat.Text = "yyyyMMdd HHmmss";


                IMarketDataProvider p = mWindow.SessionConfig.GetMarketDataProvider();

                string[] codes = p.GetStocks().Select(i => i.Code).ToArray();

                foreach (var file in Directory.EnumerateFiles("csv-files")
                    .Where(i => i.EndsWith(".txt") || i.EndsWith(".csv")))
                {
                    int index = listView1.Items.Add(file, file, 0).Index;

                    string code = file
                        .Replace("csv-files", "")
                        .Replace("\\", "")
                        .Replace(".csv", "")
                        .Replace(".txt", "").ToUpper();


                    if (codes.Contains(code))
                    {
                        listView1.Items[index].SubItems.Add(code);
                        listView1.Items[index].SubItems.Add("not loaded");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadToDb_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.MarqueeAnimationSpeed = 4;


                IHistoryDataProvider p = mWindow.SessionConfig.GetHistoryDataProvider();

                List<Tuple<string, string>> pathAndCode = new List<Tuple<string, string>>();

                foreach (var item in listView1.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)item;

                    if (listViewItem.Checked && listViewItem.SubItems[1].Text != "")
                    {
                        var path = listViewItem.SubItems[0].Text;
                        var code = listViewItem.SubItems[1].Text;
                        pathAndCode.Add(new Tuple<string, string>(path, code));
                    }
                }

                var csvFormat = csvFormats[formatComboBox.Text];
                csvFormat.ContainsHeader = containsHeader.Checked;
                csvFormat.Separator = csvSeparators[separatorBox.Text];
                csvFormat.DateTimeFormat = dtFormat.Text;

                new Task(() =>
                    {
                        foreach (var item in pathAndCode)
                        {                 
                            var data = CsvFile.Read(item.Item1, csvFormat);

                            p.Save(item.Item2, data);

                            this.DoInvoke(() =>
                                {
                                    var lvitem = listView1.Items.Find(item.Item1, false).First();
                                    lvitem.BackColor = Color.SpringGreen;
                                    lvitem.SubItems[2].Text = "loaded";
                                });
                        }

                        this.DoInvoke(() => 
                        { 
                            progressBar1.MarqueeAnimationSpeed = 0;
                            progressBar1.Value = 0;
                            MessageBox.Show("Data loaded.");
                        });

                    }).Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
