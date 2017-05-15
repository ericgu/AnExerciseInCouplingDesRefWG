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

        public IEnumerable<StockValue> GetModel(
            IEnumerable<Stock> enumerateStocks)
        {
            return enumerateStocks
                .Select(stock => 
                    new
                    {
                        Stock = stock,
                        Price = _stockPriceLoader.Load(stock.Ticker)
                    })
                .Select(t => new StockValue(t.Stock, t.Price, t.Stock.GetTotalPrice(t.Price), t.Stock.GetGain(t.Price))); 
       }
    }
}