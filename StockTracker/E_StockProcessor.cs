using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class E_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks, E_IStockDisplayTable stockDisplayTable)
        {
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