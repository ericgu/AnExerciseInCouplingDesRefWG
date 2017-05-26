using System.Collections.Generic;

namespace StockTracker
{
    public interface E_IStocksStore
    {
        void SaveStocks(IEnumerable<Stock> stocks);
        List<Stock> LoadStocks();
    }
}