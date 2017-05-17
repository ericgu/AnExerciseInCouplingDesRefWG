using FluentAssertions;
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

            stock.Ticker.Should().Be("MSFT");
            stock.Shares.Should().Be(11);
            stock.PurchaseDate.Should().Be("12/12/2012");
            stock.PurchasePrice.Should().Be(25);
        }

        [TestMethod]
        public void when_I_call_ToString__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            stock.ToString().Should().Be("MSFT:11:25:12/12/2012");
        }


        [TestMethod]
        public void when_I_call_GetCurrentValue__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            stock.GetCurrentValue(100).Should().Be(1100);
        }

        [TestMethod]
        public void when_I_call_GetGain__the_value_is_correct()
        {
            Stock stock = new Stock("MSFT", 11, 25, "12/12/2012");

            stock.GetGain(100).Should().Be(825);
        }
    }
}
