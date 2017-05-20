using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks)
        {
            listViewStocks.Items.Clear();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                var listViewItem = CreateListViewItem(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice,
                    s.StockGain);
                listViewStocks.Items.Add(listViewItem);
            }

            var listViewItemLine = CreateListViewItem("------", "-", "-", "-");
            listViewStocks.Items.Add(listViewItemLine);

            var listViewItemTotal = CreateListViewItem("Total", "-", "-",
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain));
            listViewStocks.Items.Add(listViewItemTotal);
        }

        public static ListViewItem CreateListViewItem(params object[] parameters)
        {
            var listViewItem = new ListViewItem(parameters[0].ToString());

            for (int i = 1; i < parameters.Length; i++)
            {
                listViewItem.SubItems.Add(parameters[i].ToString());
            }
            return listViewItem;
        }
    }
}