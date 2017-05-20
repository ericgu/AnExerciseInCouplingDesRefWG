using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class E_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks)
        {
            ClearList(listViewStocks);

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                AddItemToList(listViewStocks, stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain);
            }

            AddItemToList(listViewStocks, "------", "-", "-", "-");

            AddItemToList(listViewStocks, "Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
        }

        private static void AddItemToList(ListView listViewStocks, params object[] parameters)
        {
            var listViewItem = new ListViewItem(parameters[0].ToString());

            for (int i = 1; i < new[] {parameters}.Length; i++)
            {
                listViewItem.SubItems.Add(new[] {parameters}[i].ToString());
            }
            listViewStocks.Items.Add(listViewItem);
        }

        private static void ClearList(ListView listViewStocks)
        {
            listViewStocks.Items.Clear();
        }
    }
}