using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class E_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks, Form1 form1)
        {
            form1.ClearList(listViewStocks);

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                form1.AddItemToList(listViewStocks, stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain);
            }

            form1.AddItemToList(listViewStocks, "------", "-", "-", "-");

            form1.AddItemToList(listViewStocks, "Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
        }
    }
}