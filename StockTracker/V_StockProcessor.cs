using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal class Foo
    {
        public Foo(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; }
    }

    internal static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks)
        {
            listViewStocks.Items.Clear();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                var listViewItem = CreateListViewItem(new Foo(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain));
                listViewStocks.Items.Add(listViewItem);
            }

            var listViewItemLine = CreateListViewItem(new Foo("------", "-", "-", "-"));
            listViewStocks.Items.Add(listViewItemLine);

            var listViewItemTotal = CreateListViewItem(new Foo("Total", "-", "-", stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice), stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain)));
            listViewStocks.Items.Add(listViewItemTotal);
        }

        public static ListViewItem CreateListViewItem(Foo foo)
        {
            var listViewItem = new ListViewItem(foo.Parameters[0].ToString());

            for (int i = 1; i < foo.Parameters.Length; i++)
            {
                listViewItem.SubItems.Add(foo.Parameters[i].ToString());
            }
            return listViewItem;
        }
    }
}