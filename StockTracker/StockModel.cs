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
    }
}