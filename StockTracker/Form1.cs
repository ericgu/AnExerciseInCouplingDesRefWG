using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace StockTracker
{
    public partial class Form1 : Form
    {
        List<Stock> _stocks = new List<Stock>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            _listViewStocks.Items.Clear();

            double total = 0;
            foreach (Stock stock in _stocks)
            {
                string url = String.Format("http://dev.markitondemand.com/MODApis/Api/v2/Quote/jsonp?symbol={0}", stock.Ticker);

                WebClient webClient = new WebClient();
                string result = webClient.DownloadString(url);
                if (!result.Contains("No symbol matches found"))
                {
                    string lastPrice = result.Substring(result.IndexOf("LastPrice"));
                    string pricePlus = lastPrice.Substring(lastPrice.IndexOf(":") + 1);
                    string priceString = pricePlus.Substring(0, pricePlus.IndexOf(","));
                    double price = Double.Parse(priceString);

                    var listViewItem = new ListViewItem(stock.Ticker);
                    listViewItem.SubItems.Add(priceString);
                    listViewItem.SubItems.Add(stock.Shares.ToString());
                    listViewItem.SubItems.Add((stock.Shares * price).ToString());
                    _listViewStocks.Items.Add(listViewItem);

                    total += stock.Shares * price;
                }
            }

            var listViewItemLine = new ListViewItem("------");
            listViewItemLine.SubItems.Add("-");
            listViewItemLine.SubItems.Add("-");
            listViewItemLine.SubItems.Add("-");
            _listViewStocks.Items.Add(listViewItemLine);

            var listViewItemTotal = new ListViewItem("Total");
            listViewItemTotal.SubItems.Add("-");
            listViewItemTotal.SubItems.Add("-");
            listViewItemTotal.SubItems.Add(total.ToString());
            _listViewStocks.Items.Add(listViewItemTotal);
        }

        private void AddTicker(object sender, EventArgs e)
        {
            string ticker = _textBoxTicker.Text.TrimEnd('\n').ToUpper();
            double shares = Double.Parse(_textBoxShares.Text);

            _stocks.Add(new Stock(ticker, shares));
            RefreshValues(null, null);
            _textBoxTicker.Text = String.Empty;
            _textBoxShares.Text = String.Empty;

            SaveStocks();
        }

        private void SaveStocks()
        {
            throw new NotImplementedException();
        }
    }
}
