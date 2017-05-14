using System;
using System.Collections.Generic;
using StockTracker;

static internal class Foo2Foo2
{
    public static void Foo2(out double total, out double gain,
        IEnumerable<Stock> enumerateStocks,
        Action<Stock, double, double, double> foo1)
    {
        total = 0;
        gain = 0;
        foreach (Stock stock in enumerateStocks)
        {
            var price = new StockPriceLoader().Load(stock.Ticker);

            var stockTotalPrice = stock.GetTotalPrice(price);
            var stockGain = stock.GetGain(price);
            foo1(stock, price, stockTotalPrice, stockGain);

            total += stockTotalPrice;
            gain += stockGain;
        }
    }
}