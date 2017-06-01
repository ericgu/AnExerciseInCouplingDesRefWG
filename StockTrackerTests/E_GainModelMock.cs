using System.Collections.Generic;
using System.Linq;
using StockTracker;

namespace StockTrackerTests
{
    // ReSharper disable once InconsistentNaming
    public class E_GainModelMock : E_IGainModel
    {
        public IEnumerable<StockValue> GetModel(IEnumerable<Stock> enumerateStocks)
        {
            return enumerateStocks.Select(stock => new StockValue(stock, 15, 25, 33));
        }
    }
}