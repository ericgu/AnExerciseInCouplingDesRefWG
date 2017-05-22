using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    internal class LineInfo
    {
        public LineInfo(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; }
    }

    internal static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks)
        {
            var lineInfos = GetLineInfos(stockCollection, gainModel);
            var listViewItems = lineInfos.Select(CreateListViewItem).ToArray();
            listViewStocks.Items.AddRange(listViewItems);
        }

        private static List<LineInfo> GetLineInfos(StockCollection stockCollection, GainModel gainModel)
        {
            var lineInfos = new List<LineInfo>();

            var stockPriceStockTotalPriceStockGains = gainModel.GetModel(stockCollection.EnumerateStocks()).ToList();
            foreach (var s in stockPriceStockTotalPriceStockGains)
            {
                var stock = s.Stock;
                lineInfos.Add(new LineInfo(stock.Ticker, s.Price, stock.Shares, s.StockTotalPrice, s.StockGain));
            }

            lineInfos.Add(new LineInfo("------", "-", "-", "-"));

            lineInfos.Add(new LineInfo("Total", "-", "-", stockPriceStockTotalPriceStockGains.Sum(s => s.StockTotalPrice),
                    stockPriceStockTotalPriceStockGains.Sum(s => s.StockGain)));

            return lineInfos;
        }

        public static ListViewItem CreateListViewItem(LineInfo lineInfo)
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