using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
    public class GainModel
    {
        private readonly StockPriceLoader _stockPriceLoader;

        public GainModel(StockPriceLoader stockPriceLoader)
        {
            _stockPriceLoader = stockPriceLoader;
        }

        public IEnumerable<StockPriceStockTotalPriceStockGain> GetModel(
            IEnumerable<Stock> enumerateStocks)
        {
            return from stock in enumerateStocks
                let price = _stockPriceLoader.Load(stock.Ticker)
                let stockTotalPrice = stock.GetTotalPrice(price)
                let stockGain = stock.GetGain(price)
                select new StockPriceStockTotalPriceStockGain(stock, price, stockTotalPrice, stockGain);
        }
    }
}