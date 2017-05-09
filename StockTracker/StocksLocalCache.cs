using System.Collections.Generic;

namespace StockTracker
{
    internal interface StocksLocalCache
    {
        List<Stock> LoadStocks();
        void Refresh();
        void SaveStocks(IEnumerable<Stock> stocks);
    }
}