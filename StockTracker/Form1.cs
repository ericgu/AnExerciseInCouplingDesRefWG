using System;
using System.Collections.Generic;
using System.Windows.Forms;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace StockTracker
{
    public partial class Form1 : Form
    {
        readonly StocksFileRepository _stocksRepository;
        private readonly StockModel _stockModel;

        public Form1()
        {
            InitializeComponent();

            _stocksRepository = new StocksFileRepository();
            var stocks = LoadStocks();

            _stockModel = new StockModel(stocks);
            _stockModel.Changed += (sender, e) => RefreshTable();
            _stockModel.Changed += (sender, e) => SaveStocks();

            RefreshTable();
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            _listViewStocks.Items.Clear();

            double total = 0;
            double gain = 0;
            foreach (Stock stock in _stockModel.EnumerateStocks())
            {
                var price = new StockPriceLoader().Load(stock.Ticker);

                var stockTotalPrice = stock.GetTotalPrice(price);
                var stockGain = stock.GetGain(price);
                var listViewItem = CreateListViewItem(stock.Ticker, price, stock.Shares, stockTotalPrice,
                    stockGain);
                _listViewStocks.Items.Add(listViewItem);

                total += stockTotalPrice;
                gain += stockGain;
            }


            var listViewItemLine = CreateListViewItem("------", "-", "-", "-");
            _listViewStocks.Items.Add(listViewItemLine);

            var listViewItemTotal = CreateListViewItem("Total", "-", "-", total, gain);
            _listViewStocks.Items.Add(listViewItemTotal);
        }

        private static ListViewItem CreateListViewItem(params object[] parameters)
        {
            var listViewItem = new ListViewItem(parameters[0].ToString());

            for (int i = 1; i < parameters.Length; i++)
            {
                listViewItem.SubItems.Add(parameters[i].ToString());
            }
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
        }

        private void SaveStocks()
        {
            _stocksRepository.SaveStocks(_stockModel.EnumerateStocks());
        }

        private List<Stock> LoadStocks()
        {
            return _stocksRepository.LoadStocks();
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
            _stockModel.RemoveAll();
        }
    }
}
