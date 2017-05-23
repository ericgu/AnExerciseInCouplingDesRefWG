using System.Collections.Generic;

namespace StockTracker
{
    public interface E_IGainModel
    {
        IEnumerable<StockValue> GetModel(
            IEnumerable<Stock> enumerateStocks);
    }
}