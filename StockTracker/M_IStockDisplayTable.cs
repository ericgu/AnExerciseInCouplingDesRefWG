using System.Collections.Generic;

namespace StockTracker
{
    public interface M_IStockDisplayTable
    {
        void Render(IEnumerable<M_StockDisplayData> stockDisplayData);
    }
}