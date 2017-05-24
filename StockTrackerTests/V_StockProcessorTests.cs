using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    public class V_StockProcessorTests
    {
        [TestMethod]
        public void when_I_call_GetLineInfos_with_two_stocks__the_line_infos_are_correct()
        {
            var stockValues = new List<StockValue>()
            {
                new StockValue(new Stock("MSFT", 100, 100, "5/10/2020"), 15.0, 25.0, 33.0),
                new StockValue(new Stock("GOOG", 300, 400, "6/10/2020"), 15.0, 25.0, 33.0)
            };

            var lineInfos = V_StockProcessor.GetLineInfos(stockValues);

            lineInfos.Should().Equal(
                new V_LineInfo("MSFT", 15.0, 100.0, 25.0, 33.0),
                new V_LineInfo("GOOG", 15.0, 300.0, 25.0, 33.0),
                new V_LineInfo("------", "-", "-", "-"),
                new V_LineInfo("Total", "-", "-", 50.0, 66.0)
            );
        }
    }
}
