using System;
using System.Collections.Generic;
using System.Linq;
using StockTracker;

internal class Foo2Foo2
{
    private readonly StockPriceLoader _stockPriceLoader;

    public Foo2Foo2(StockPriceLoader stockPriceLoader)
    {
        _stockPriceLoader = stockPriceLoader;
    }

    public IEnumerable<StockPriceStockTotalPriceStockGain> Foo2(
        IEnumerable<Stock> enumerateStocks)
    {
        return from stock in enumerateStocks
            let price = _stockPriceLoader.Load(stock.Ticker)
            let stockTotalPrice = stock.GetTotalPrice(price)
            let stockGain = stock.GetGain(price)
            select new StockPriceStockTotalPriceStockGain(stock, price, stockTotalPrice, stockGain);
    }

    public class StockPriceStockTotalPriceStockGain
    {
        public StockPriceStockTotalPriceStockGain(
            Stock stock,
            double price,
            double stockTotalPrice,
            double stockGain)
        {
            this.Stock = stock;
            this.Price = price;
            this.StockTotalPrice = stockTotalPrice;
            this.StockGain = stockGain;
        }

        public Stock Stock { get; }
        public double Price { get;  }
        public double StockTotalPrice { get; }
        public double StockGain { get; }
    }
}