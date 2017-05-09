using System.Collections.Generic;

namespace StockTracker
{
    public class StockModel
    {
        private readonly List<Stock> _stocks;

        public StockModel(List<Stock> stocks)
        {
            _stocks = stocks;
        }

        public void Add(string ticker, double shares, double purchasePrice, string purchaseDate)
        {
            this._stocks.Add(new Stock(ticker, shares, purchasePrice, purchaseDate));
        }

        public void RemoveAt(int index)
        {
            this._stocks.RemoveAt(index);
        }

        public IEnumerable<Stock> EnumerateStocks()
        {
            return this._stocks;
        }
    }
}