using System;
using System.Collections.Generic;

namespace StockTracker
{
    public class StockModel
    {
        private readonly List<Stock> _stocks;
        public event EventHandler Changed;

        public StockModel(List<Stock> stocks)
        {
            _stocks = stocks;
        }

        public void Add(string ticker, double shares, double purchasePrice, string purchaseDate)
        {
            this._stocks.Add(new Stock(ticker, shares, purchasePrice, purchaseDate));
            OnChanged();
        }

        public void RemoveAt(int index)
        {
            this._stocks.RemoveAt(index);
            OnChanged();
        }

        public void RemoveAll()
        {
            this._stocks.Clear();
            OnChanged();
        }

        public IEnumerable<Stock> EnumerateStocks()
        {
            return this._stocks;
        }

        private void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}