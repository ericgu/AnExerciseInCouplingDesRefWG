using System;
using System.Collections.Generic;
using System.Windows.Forms;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable StringIndexOfIsCultureSpecific.1

// Design discussion comments:
// Add your comment here, in this format:
// <alias>: comment

namespace StockTracker
{
    public partial class Form1 : Form
    {
        readonly StocksLocalCache _stocksCache;
        private readonly StockModel _stockModel;

        public Form1()
        {
            InitializeComponent();

            _stocksCache = new StocksFileCache();
            var stocks = LoadStocks();

            _stockModel = new StockModel(stocks);
            _stockModel.Changed += _stockModel_Changed;
            RefreshValues(null, null);
        }

        private void _stockModel_Changed(object sender, EventArgs e)
        {
            RefreshValues(null, null);
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            _listViewStocks.Items.Clear();

            double total = 0;
            double gain = 0;
            foreach (Stock stock in _stockModel.EnumerateStocks())
            {
                var price = new StockPriceLoader().Load(stock.Ticker);

                var listViewItem = CreateListViewItem(stock.Ticker, price, stock.Shares, (stock.Shares*price), (stock.Shares*(price - stock.PurchasePrice)));
                _listViewStocks.Items.Add(listViewItem);

                    total += stock.Shares*price;
                    gain += stock.Shares*(price - stock.PurchasePrice);
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
            listViewItemTotal.SubItems.Add(gain.ToString());
            _listViewStocks.Items.Add(listViewItemTotal);
        }

        private static ListViewItem CreateListViewItem(string param1, double param2, double param3, double param4, double param5)
        {
            var listViewItem = new ListViewItem(param1);
            listViewItem.SubItems.Add(param2.ToString());
            listViewItem.SubItems.Add(param3.ToString());
            listViewItem.SubItems.Add(param4.ToString());
            listViewItem.SubItems.Add(param5.ToString());
            return listViewItem;
        }

        private void AddTicker(object sender, EventArgs e)
        {
            string ticker = _textBoxTicker.Text.TrimEnd('\n').ToUpper();
            double shares = Double.Parse(_textBoxShares.Text);
            double purchasePrice = Double.Parse(_textBoxPurchasePrice.Text);
            string purchaseDate = _textBoxPurchaseDate.Text;

            _stockModel.Add(ticker, shares, purchasePrice, purchaseDate);
            _textBoxTicker.Text = String.Empty;
            _textBoxShares.Text = String.Empty;
            _textBoxPurchaseDate.Text = String.Empty;
            _textBoxPurchasePrice.Text = String.Empty;

            SaveStocks();
        }

        private void SaveStocks()
        {
            _stocksCache.SaveStocks(_stockModel.EnumerateStocks());
        }

        private List<Stock> LoadStocks()
        {
            return _stocksCache.LoadStocks();
        }

        private void DeleteStock(object sender, EventArgs e)
        {
            int index = _listViewStocks.SelectedIndices[0];
            if (index != -1)
            {
                _stockModel.RemoveAt(index);
            }
        }

        private void ClearAllData(object sender, EventArgs e)
        {
            _stocksCache.Refresh();
        }
    }
}
