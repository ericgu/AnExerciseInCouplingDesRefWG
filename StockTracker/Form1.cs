using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace StockTracker
{
    public partial class Form1 : Form
    {
        List<string> _stocks = new List<string>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void TickerKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                AddStockToList();
            }
        }

        private void AddStockToList()
        {
            string ticker = _textBoxTicker.Text.TrimEnd('\n').ToUpper();
            _stocks.Add(new Stock(ticker).Ticker);
            RefreshValues(null, null);
            _textBoxTicker.Text = String.Empty;
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            _listViewStocks.Items.Clear();

            foreach (string stock in _stocks)
            {
                string url = String.Format("http://dev.markitondemand.com/MODApis/Api/v2/Quote/jsonp?symbol={0}", stock);

                WebClient webClient = new WebClient();
                string result = webClient.DownloadString(url);
                if (!result.Contains("No symbol matches found"))
                {
                    string lastPrice = result.Substring(result.IndexOf("LastPrice"));
                    string pricePlus = lastPrice.Substring(lastPrice.IndexOf(":") + 1);
                    string priceString = pricePlus.Substring(0, pricePlus.IndexOf(","));
                    double price = Double.Parse(priceString);

                    var listViewItem = new ListViewItem(stock);
                    listViewItem.SubItems.Add(priceString);
                    listViewItem.SubItems.Add("b");
                    _listViewStocks.Items.Add(listViewItem);
                }
            }
        }

        private void AddTicker(object sender, EventArgs e)
        {
            AddStockToList();
        }
    }
}
