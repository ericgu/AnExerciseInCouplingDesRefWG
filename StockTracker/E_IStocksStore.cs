using System.Collections.Generic;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public interface E_IStocksStore
    {
        void SaveStocks(IEnumerable<Stock> stocks);
        StockCollection LoadStocks();
    }
}