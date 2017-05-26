using System.Collections.Generic;
using System.Linq;
using StockTracker;

public static class V_StockValuator
{
    public static List<StockValue> GetStockValues(StockCollection stockCollection, V_GetStockPriceDelegate getStockPrice)
    {
        return stockCollection.EnumerateStocks()
            .Select(stock =>
                new
                {
                    Stock = stock,
                    Price = getStockPrice(stock.Ticker)
                })
            .Select(t => new StockValue(t.Stock, t.Price, t.Stock.GetCurrentValue(t.Price), t.Stock.GetGain(t.Price)))
            .ToList();
    }
}