using System.Linq;
using System.Windows.Forms;

namespace StockTracker
{
    public static class V_StockProcessor
    {
        public static void RefreshTable(StockCollection stockCollection, V_GetStockPriceDelegate getStockPrice, ListView listViewStocks)
        {
            var stockValues = V_StockValuator.GetStockValues(stockCollection, getStockPrice);
            var lineInfos = V_Formatter.GetLineInfos(stockValues);
            var listViewItems = lineInfos.Select(CreateListViewItem).ToArray();

            listViewStocks.Items.Clear();
            listViewStocks.Items.AddRange(listViewItems);
        }

        private static ListViewItem CreateListViewItem(V_LineInfo lineInfo)
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