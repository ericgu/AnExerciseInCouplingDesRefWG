using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    public static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GetStockPriceDelegate getStockPrice, ListView listViewStocks)
        {
            var stockValues = GetStockValues(stockCollection, getStockPrice);
            var lineInfos = GetLineInfos(stockValues);
            var listViewItems = lineInfos.Select(CreateListViewItem).ToArray();

            listViewStocks.Items.Clear();
            listViewStocks.Items.AddRange(listViewItems);
        }

        public static List<StockValue> GetStockValues(StockCollection stockCollection, GetStockPriceDelegate getStockPrice)
        {
            return stockCollection.EnumerateStocks()
                .Select(stock =>
                    new
                    {
                        Stock = stock,
                        Price = getStockPrice(stock.Ticker)
                    })
                .Select(t => new StockValue(t.Stock, t.Price, t.Stock.GetCurrentValue(t.Price), t.Stock.GetGain(t.Price)))
                .ToList();
        }

        public static List<V_LineInfo> GetLineInfos(List<StockValue> stockValues)
        {
            var lineInfos = new List<V_LineInfo>();

            foreach (var s in stockValues)
            {
                var stock = s.Stock;
                lineInfos.Add(new V_LineInfo(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain));
            }

            lineInfos.Add(new V_LineInfo("------", "-", "-", "-"));

            lineInfos.Add(new V_LineInfo("Total", "-", "-", stockValues.Sum(s => s.StockTotalPrice),
                    stockValues.Sum(s => s.StockGain)));

            return lineInfos;
        }

        public static ListViewItem CreateListViewItem(V_LineInfo lineInfo)
        {
            var listViewItem = new ListViewItem(lineInfo.Parameters[0].ToString());

            for (int i = 1; i < lineInfo.Parameters.Length; i++)
            {
                listViewItem.SubItems.Add(lineInfo.Parameters[i].ToString());
            }
            return listViewItem;
        }
    }
}