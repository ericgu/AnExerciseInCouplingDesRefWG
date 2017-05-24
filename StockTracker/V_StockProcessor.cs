using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    public static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, GainModel gainModel, ListView listViewStocks)
        {
            var lineInfos = GetLineInfos(((E_IGainModel) gainModel).GetModel(stockCollection.EnumerateStocks()).ToList());
            var listViewItems = lineInfos.Select(CreateListViewItem).ToArray();

            listViewStocks.Items.Clear();
            listViewStocks.Items.AddRange(listViewItems);
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