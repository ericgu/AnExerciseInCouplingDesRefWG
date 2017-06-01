using System.Collections.Generic;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public interface E_IGainModel
    {
        IEnumerable<StockValue> GetModel(
            IEnumerable<Stock> enumerateStocks);
    }
}