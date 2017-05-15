using System;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace StockTracker
{
    public partial class Form1 : Form
    {
        private readonly StocksFileRepository _stocksRepository;
        private readonly StockModel _stockModel;
        private readonly GainModel _gainModel;

        public Form1(StocksFileRepository stocksFileRepository, GainModel gainModel)
        {
            InitializeComponent();

            _stocksRepository = stocksFileRepository;
            _gainModel = gainModel;
            _stockModel = new StockModel(stocksFileRepository.LoadStocks());
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

            var stockPriceStockTotalPriceStockGains = _gainModel.GetModel(_stockModel.EnumerateStocks());
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                var listViewItem = CreateListViewItem(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice,
                    s.StockGain);
                _listViewStocks.Items.Add(listViewItem);
            }

            var listViewItemLine = CreateListViewItem("------", "-", "-", "-");
            _listViewStocks.Items.Add(listViewItemLine);

            var listViewItemTotal = CreateListViewItem("Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
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
