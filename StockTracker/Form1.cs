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
                string ticker = _textBoxTicker.Text.TrimEnd('\n');
                _stocks.Add(ticker);
            }
        }

    }
}
