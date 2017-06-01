using System.Linq;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public static class E_StockProcessor
    {
        public static void RefreshTable(E_IStocksStore stocksStore, E_IGainModel gainModel, E_IStockDisplayTable stockDisplayTable)
        {
            var stockCollection = stocksStore.LoadStocks();

            stockDisplayTable.ClearList();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                stockDisplayTable.AddItemToList(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain);
            }

            stockDisplayTable.AddItemToList("------", "-", "-", "-");

            stockDisplayTable.AddItemToList("Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
        }
    }
}