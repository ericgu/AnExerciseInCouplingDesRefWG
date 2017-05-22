using System.Collections.Generic;
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
            var foos = GetFoos(stockCollection, gainModel);
            var listViewItems = foos.Select(CreateListViewItem).ToArray();
            listViewStocks.Items.AddRange(listViewItems);
        }

        private static List<Foo> GetFoos(StockCollection stockCollection, GainModel gainModel)
        {
            var foos = new List<Foo>();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                foos.Add(new Foo(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain));
            }

            foos.Add(new Foo("------", "-", "-", "-"));

            foos.Add(new Foo("Total", "-", "-", stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                    stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain)));

            return foos;
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