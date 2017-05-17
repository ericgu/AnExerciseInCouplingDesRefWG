using System;
using System.Collections.Generic;

namespace StockTracker
{
    public class StockCollection
    {
        private readonly List<Stock> _stocks;
        public event EventHandler Changed;

        public StockCollection(List<Stock> stocks)
        {
            _stocks = stocks;
        }

        public StockCollection() : this(new List<Stock>())
        {

        }

        public void Add(string ticker, double shares, double purchasePrice, string purchaseDate)
        {
            _stocks.Add(new Stock(ticker, shares, purchasePrice, purchaseDate));
            OnChanged();
        }

        public void RemoveAt(int index)
        {
            _stocks.RemoveAt(index);
            OnChanged();
        }

        public void RemoveAll()
        {
            _stocks.Clear();
            OnChanged();
        }

        public IEnumerable<Stock> EnumerateStocks()
        {
            return _stocks;
        }

        private void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}