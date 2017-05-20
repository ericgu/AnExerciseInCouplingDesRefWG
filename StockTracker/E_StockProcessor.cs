using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class E_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks, IStockDisplayTable form1)
        {
            form1.ClearList();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                form1.AddItemToList(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain);
            }

            form1.AddItemToList("------", "-", "-", "-");

            form1.AddItemToList("Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
        }
    }
}