using System.Collections.Generic;

namespace StockTracker
{
    public class StockModel
    {
        public StockModel(List<Stock> stocks)
        {
            Stocks = stocks;
        }

        public List<Stock> Stocks { get; }

        public void Add(string ticker, double shares, double purchasePrice, string purchaseDate)
        {
            this.Stocks.Add(new Stock(ticker, shares, purchasePrice, purchaseDate));
        }

        public void RemoveAt(int index)
        {
            this.Stocks.RemoveAt(index);
        }

        public IEnumerable<Stock> EnumerateStocks()
        {
            return this.Stocks;
        }
    }
}