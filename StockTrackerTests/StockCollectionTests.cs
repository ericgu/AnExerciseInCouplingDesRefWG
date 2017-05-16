using System.Collections.Generic;
using System.Linq;
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

            Assert.AreEqual("MSFT", stockCollection.EnumerateStocks().First().Ticker);
            Assert.AreEqual("F", stockCollection.EnumerateStocks().Skip(1).First().Ticker);
        }

        [TestMethod]
        public void when_I_add_a_stock__the_stock_is_added_and_the_changed_event_is_fired()
        {
            bool changedCalled = false;
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.Changed += (s, e) => { changedCalled = true; };

            stockCollection.Add("MSFT", 11, 25, "12/12/2012");
            Assert.AreEqual("MSFT", stockCollection.EnumerateStocks().First().Ticker);
            Assert.IsTrue(changedCalled);
        }

        [TestMethod]
        public void when_I_remove_a_stock__the_stock_is_removed_and_the_changed_event_is_fired()
        {
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.Add("MSFT", 11, 25, "12/12/2012");
            stockCollection.Add("GOOG", 12, 26, "10/10/2013");

            bool changedCalled = false;
            stockCollection.Changed += (s, e) => { changedCalled = true; };

            stockCollection.RemoveAt(0);

            Assert.AreEqual(1, stockCollection.EnumerateStocks().Count());
            Assert.IsTrue(changedCalled);
        }

        [TestMethod]
        public void when_I_remove_all_stocks__the_stocks_are_removed_and_the_changed_event_is_fired()
        {
            List<Stock> stocks = new List<Stock>();
            StockCollection stockCollection = new StockCollection(stocks);
            stockCollection.Add("MSFT", 11, 25, "12/12/2012");
            stockCollection.Add("GOOG", 12, 26, "10/10/2013");

            bool changedCalled = false;
            stockCollection.Changed += (s, e) => { changedCalled = true; };

            stockCollection.RemoveAll();

            Assert.AreEqual(0, stockCollection.EnumerateStocks().Count());
            Assert.IsTrue(changedCalled);
        }
    }
}
