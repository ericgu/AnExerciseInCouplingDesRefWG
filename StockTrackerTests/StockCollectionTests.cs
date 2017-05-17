using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    public class StockCollectionTests
    {
        [TestMethod]
        public void when_I_create_a_stock_collection__it_contains_those_stocks()
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("MSFT", 11, 25, "12/12/2012"));
            stocks.Add(new Stock("F", 7, 12, "11/11/2011"));

            StockCollection stockCollection = new StockCollection(stocks);

            stockCollection.EnumerateStocks().Should().HaveCount(2);
            stockCollection.EnumerateStocks().First().Ticker.Should().Be("MSFT");
            stockCollection.EnumerateStocks().Skip(1).First().Ticker.Should().Be("F");
        }

        [TestMethod]
        public void when_I_add_a_stock__the_stock_is_added_and_the_changed_event_is_fired()
        {
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.MonitorEvents();

            stockCollection.Add("MSFT", 11, 25, "12/12/2012");

            stockCollection.EnumerateStocks().Should().HaveCount(1);
            stockCollection.EnumerateStocks().First().Ticker.Should().Be("MSFT");
            stockCollection.ShouldRaise(nameof(StockCollection.Changed));
        }

        [TestMethod]
        public void when_I_remove_a_stock__the_stock_is_removed_and_the_changed_event_is_fired()
        {
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.Add("MSFT", 11, 25, "12/12/2012");
            stockCollection.Add("GOOG", 12, 26, "10/10/2013");
            stockCollection.MonitorEvents();

            stockCollection.RemoveAt(0);

            stockCollection.EnumerateStocks().Should().HaveCount(1);
            stockCollection.ShouldRaise(nameof(StockCollection.Changed));
        }

        [TestMethod]
        public void when_I_remove_all_stocks__the_stocks_are_removed_and_the_changed_event_is_fired()
        {
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.Add("MSFT", 11, 25, "12/12/2012");
            stockCollection.Add("GOOG", 12, 26, "10/10/2013");
            stockCollection.MonitorEvents();

            stockCollection.RemoveAll();

            stockCollection.EnumerateStocks().Should().BeEmpty();
            stockCollection.ShouldRaise(nameof(StockCollection.Changed));
        }
    }
}
