using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        readonly List<Stock> _stocks;

        public Form1()
        {
            InitializeComponent();

            _stocks = LoadStocks();
            RefreshValues(null, null);
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            _listViewStocks.Items.Clear();

            double total = 0;
            double gain = 0;
            foreach (Stock stock in _stocks)
            {
                var price = new StockPriceLoader().Load(stock);

                var listViewItem = new ListViewItem(stock.Ticker);
                    listViewItem.SubItems.Add(price.ToString());
                    listViewItem.SubItems.Add(stock.Shares.ToString());
                    listViewItem.SubItems.Add((stock.Shares*price).ToString());
                    listViewItem.SubItems.Add((stock.Shares * (price - stock.PurchasePrice)).ToString());
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

        private void AddTicker(object sender, EventArgs e)
        {
            string ticker = _textBoxTicker.Text.TrimEnd('\n').ToUpper();
            double shares = Double.Parse(_textBoxShares.Text);
            double purchasePrice = Double.Parse(_textBoxPurchasePrice.Text);
            string purchaseDate = _textBoxPurchaseDate.Text;

            _stocks.Add(new Stock(ticker, shares, purchasePrice, purchaseDate));
            RefreshValues(null, null);
            _textBoxTicker.Text = String.Empty;
            _textBoxShares.Text = String.Empty;
            _textBoxPurchaseDate.Text = String.Empty;
            _textBoxPurchasePrice.Text = String.Empty;

            SaveStocks();
        }

        private void SaveStocks()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string filename = Path.Combine(folderPath, "stocks.dat");

            var contents = String.Join(",", _stocks.Select(stock => stock.ToString()));

            File.WriteAllText(filename, contents);
        }

        private List<Stock> LoadStocks()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string filename = Path.Combine(folderPath, "stocks.dat");

            if (File.Exists(filename))
            {
                var contents = File.ReadAllText(filename);

                try
                {
                    return contents.Split(',')
                        .Select(s =>
                            new Stock(s.Split(':').First(),
                                Double.Parse(s.Split(':').Skip(1).First()),
                                Double.Parse(s.Split(':').Skip(2).First()),
                                s.Split(':').Skip(3).First()))
                        .ToList();
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch (Exception)
                {
                    
                }
            }

            return new List<Stock>();
        }

        private void DeleteStock(object sender, EventArgs e)
        {
            int index = _listViewStocks.SelectedIndices[0];
            if (index != -1)
            {
                _stocks.RemoveAt(index);
                RefreshValues(null, null);
            }
        }

        private void ClearAllData(object sender, EventArgs e)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string filename = Path.Combine(folderPath, "stocks.dat");

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            LoadStocks();
        }
    }
}
