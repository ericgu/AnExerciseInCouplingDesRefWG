using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class M_ProjectorTests
    {
        [TestMethod]
        public void when_I_call_Project_with_two_items__it_calls_the_process_function_on_both()
        {
            double[] items = {3.14159, 44.33};

            var result = M_Projector.Project(items, d => (int) d);

            result.First().Should().Be(3);
            result.Skip(1).First().Should().Be(44);
        }
    }
}
