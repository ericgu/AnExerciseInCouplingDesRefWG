using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void when_I_create_a_stock__the_properties_are_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            Assert.AreEqual("MSFT", stock.Ticker);
            Assert.AreEqual(11, stock.Shares);
            Assert.AreEqual("12/12/2012", stock.PurchaseDate);
            Assert.AreEqual(25, stock.PurchasePrice);
        }

        [TestMethod]
        public void when_I_call_ToString__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            Assert.AreEqual("MSFT:11:25:12/12/2012", stock.ToString());
        }


        [TestMethod]
        public void when_I_call_GetCurrentValue__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            Assert.AreEqual(1100, stock.GetCurrentValue(100));
        }

        [TestMethod]
        public void when_I_call_GetGain__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            Assert.AreEqual(825, stock.GetGain(100));
        }
    }
}
