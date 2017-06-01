using System.Collections.Generic;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public interface M_IStockDisplayTable
    {
        void Render(IEnumerable<M_StockDisplayData> stockDisplayData);
    }
}