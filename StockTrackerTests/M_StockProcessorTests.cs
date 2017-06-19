using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class M_StockProcessorTests
    {
        [TestMethod]
        public void when_I_call_CalculateGainAndCurrentValue_with_one_stock__the_calculated_values_are_correct()
        {
            M_StockWithPrice stockWithPrice = new M_StockWithPrice
            {
                Stock = new Stock("TEST", 5, 5, "12/12/2012"),
                Price = 15
            };

            var result = CalculateGainAndCurrentValue(stockWithPrice);

            result.CurrentValue.Should().Be(75);
            result.Gain.Should().Be(50);
        }

        private static M_StockWithPriceAndValue CalculateGainAndCurrentValue(M_StockWithPrice stockWithPrice)
        {
            var result = M_StockProcessor.CalculateGainAndCurrentValue(new[] {stockWithPrice});
            return result.First();
        }

        [TestMethod]
        public void when_I_call_CalculateTotalGainAndCurrentValue_with_two_stocks__the_calculated_values_are_correct()
        {
            M_StockWithPriceAndValue[] stocksWithPrice = new M_StockWithPriceAndValue[]
            {
                new M_StockWithPriceAndValue
                {
                    Stock = new Stock("TEST", 5, 5, "12/12/2012"),
                    Price = 15,
                    CurrentValue = 75,
                    Gain = 50
                },
                new M_StockWithPriceAndValue
                {
                    Stock = new Stock("BEST", 5, 5, "12/12/2012"),
                    Price = 20,
                    CurrentValue = 150,
                    Gain = 70
                }
            };

            var result = M_StockProcessor.CalculateTotalCurrentValueAndGain(stocksWithPrice);
            result.CurrentValue.Should().Be(225);
            result.Gain.Should().Be(120);
        }

        [TestMethod]
        public void when_I_call_FormatDataForDisplay_with_two_stocks__the_line_values_are_correct()
        {
            M_StockWithPriceAndValue[] stocksWithPrice = new M_StockWithPriceAndValue[]
            {
                new M_StockWithPriceAndValue
                {
                    Stock = new Stock("TEST", 5, 5, "12/12/2012"),
                    Price = 15,
                    CurrentValue = 75,
                    Gain = 50
                },
                new M_StockWithPriceAndValue
                {
                    Stock = new Stock("BEST", 5, 5, "12/12/2012"),
                    Price = 20,
                    CurrentValue = 150,
                    Gain = 70
                }
            };

            var totalCurrentValueAndGain = M_StockProcessor.CalculateTotalCurrentValueAndGain(stocksWithPrice);

            var result = M_StockProcessor.FormatDataForDisplay(stocksWithPrice, totalCurrentValueAndGain);
            result.Count.Should().Be(4);
            result.First().Items[0].Should().Be("TEST");
            result.Skip(1).First().Items[1].Should().Be("20");
            result.Skip(2).First().Items[2].Should().Be("-");
            result.Skip(3).First().Items[3].Should().Be("225");
        }
    }
}
