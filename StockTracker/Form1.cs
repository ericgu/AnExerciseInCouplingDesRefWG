using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string ticker = _textBoxTicker.Text.TrimEnd('\n');
            _stocks.Add(ticker);
            RefreshValues(null, null);
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            _listViewStocks.Items.Clear();

            foreach (string stock in _stocks)
            {
                //http://dev.markitondemand.com/MODApis/Api/v2/Quote/jsonp?symbol=AAPL


                var listViewItem = new ListViewItem(stock);
                listViewItem.SubItems.Add("a");
                listViewItem.SubItems.Add("b");
                _listViewStocks.Items.Add(listViewItem);
            }
        }

        private void AddTicker(object sender, EventArgs e)
        {
            AddStockToList();
        }
    }
}
