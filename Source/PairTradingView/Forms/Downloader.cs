using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections;

namespace PairTradingView.Forms
{
    public partial class Downloader : Form
    {
        string folder = "";
        string interval = "";

        public Downloader()
        {
            InitializeComponent();
            folder = Directory.GetCurrentDirectory().ToString() + @"\MarketData";
            txtPath.Text = folder;
            folderBrowserDialog1.SelectedPath = folder;
            fromMonth.SelectedIndex = 0;
            toMonth.SelectedIndex = 0;
            interval = "d";
            setCurrentDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Verify folderPath
            if (Directory.Exists(txtPath.Text))
            {
                if (datesVerified())
                {
                    string tickers = textBoxTicker.Text;
                    //verifies symbols are only letters and commas
                    bool result = tickers.All((c => Char.IsLetter(c) || c == ',' || c == ' '));
                    if (result)
                    {
                        setInterval();
                        //removes white space, converts to uppercase & splits symbols
                        tickers = tickers.Replace(" ", string.Empty);
                        tickers = tickers.ToUpper();
                        string[] symbols = tickers.Split(',');
                        foreach (string symbol in symbols)
                        {
                            //Constructs Yahoo's URL to request data from
                            string path = Path.Combine(folder, symbol + ".txt");
                            string url = "http://real-chart.finance.yahoo.com/table.csv?s=" + symbol + "&a=" + fromMonth.SelectedIndex + "&b=" +
                                fromDay.Value + "&c=" + fromYear.Value + "&d=" + toMonth.SelectedIndex + "&e=" + toDay.Value + "&f" + toYear.Value + "&g=" + interval + "&ignore=.csv";
                            try
                            {
                                using (WebClient Client = new WebClient())
                                {
                                    //Download .csv file from Yahoo
                                    Client.DownloadFile(url, path);

                                    //Create temp array to hold list in order to reverse it
                                    ArrayList arrText = new ArrayList();

                                    //Create temp file
                                    string tempFile = Path.Combine(folder, symbol + "_temp.txt");
                                    using (var writer = new StreamWriter(tempFile))
                                    using (var reader = new StreamReader(File.OpenRead(path)))
                                    {
                                        //Remove Header by reading first line (Date,Open,High,Low,Close,Volume)
                                        reader.ReadLine();

                                        while (!reader.EndOfStream)
                                        {
                                            string tickerInfo = reader.ReadLine();

                                            //Remove hypens in date
                                            tickerInfo = tickerInfo.Replace("-", "");

                                            //Remove Adj Close from results                                            
                                            int index = tickerInfo.LastIndexOf(",");
                                            tickerInfo = tickerInfo.Remove(index, tickerInfo.Length - index);
                                            arrText.Add(tickerInfo);
                                        }
                                        //Reverse list so oldest dates appear first
                                        arrText.Reverse();
                                        foreach (string sOutput in arrText)
                                        {
                                            writer.WriteLine(sOutput);
                                        }
                                    }

                                    File.Copy(tempFile, path, true);
                                    File.Delete(tempFile);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Could not locate " + symbol);
                            }

                        }
                        MessageBox.Show("All tickers processed to: " + folder);
                    }
                    else
                        MessageBox.Show("Please enter only letters and commas, ex:" + Environment.NewLine + "GOOG, AMZN, MSFT");
                }
            }
            else
                MessageBox.Show("Please enter a valid folder");
        }

        private void setInterval()
        {
            if (rbDaily.Checked)
                interval = "d";
            if (rbWeekly.Checked)
                interval = "w";
            if (rbMonthly.Checked)
                interval = "m";
        }

        private bool datesVerified()
        {
            //year, month, day
            DateTime startDate = new DateTime((int)fromYear.Value, (int)fromMonth.SelectedIndex + 1, (int)fromDay.Value);
            DateTime endDate = new DateTime((int)toYear.Value, (int)toMonth.SelectedIndex + 1, (int)toDay.Value);

            if (endDate < startDate)
            {
                MessageBox.Show("End date can not be earlier than the start date");
                return false;
            }
            else if (endDate > DateTime.Now)
            {
                MessageBox.Show("End date can not be beyond today's date");
                return false;
            }
            else
                return true;
        }

        private void setCurrentDate()
        {
            DateTime asdf = DateTime.Today;
            toMonth.SelectedIndex = asdf.Month - 1;
            toDay.Value = asdf.Day;
            toYear.Value = asdf.Year;
            fromYear.Value = asdf.Year;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                folder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void dow30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Access barchart.com to get Dow 30 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/industrials.php?view=main");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf(",,");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            textBoxTicker.Text += webPageInfo;
        }

        private void sP100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Access barchart.com to get S&P 100 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/sp100.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf("\"");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            textBoxTicker.Text += webPageInfo;
        }

        private void nasdaq100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Access barchart.com to get NASDAQ 100 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/nasdaq100.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf("\"");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            textBoxTicker.Text += webPageInfo;
        }
    }
}
