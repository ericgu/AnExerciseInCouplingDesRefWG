using System.Collections.Generic;
using System.Linq;
using StockTracker;

namespace StockTrackerTests
{
    // ReSharper disable once InconsistentNaming
    public class E_StocksStoreMock : E_IStocksStore
    {
        private List<Stock> _stocks;

        public E_StocksStoreMock(params Stock[] stocks)
        {
            _stocks = stocks.ToList();
        }

        public void SaveStocks(IEnumerable<Stock> stocks)
        {
        }

        public StockCollection LoadStocks()
        {
            return new StockCollection(_stocks);
        }
    }
}