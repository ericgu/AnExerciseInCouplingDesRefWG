using System.Collections.Generic;
using System.Linq;
using StockTracker;

public static class V_Formatter
{
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
}