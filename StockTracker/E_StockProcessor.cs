using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class E_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks, Form1 form1)
        {
            Form1.ClearList(listViewStocks, form1);

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                Form1.AddItemToList(listViewStocks, form1, stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain);
            }

            Form1.AddItemToList(listViewStocks, form1, "------", "-", "-", "-");

            Form1.AddItemToList(listViewStocks, form1, "Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
        }
    }
}