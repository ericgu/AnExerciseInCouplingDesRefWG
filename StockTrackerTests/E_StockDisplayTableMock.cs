using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using StockTracker;

namespace StockTrackerTests
{
    // ReSharper disable once InconsistentNaming
    public class E_StockDisplayTableMock : E_IStockDisplayTable
    {
        List<string[]> _items = new List<string[]>();

        public List<string[]> Items
        {
            get { return _items; }
        }

        public void AddItemToList(params object[] parameters)
        {
            var strings = parameters.Select(param => param.ToString()).ToArray();
            Items.Add(strings);
        }

        public void ClearList()
        {
            Items.Clear();
        }

        public void ValidateLine(int lineNumber, params string[] parameters)
        {
            var line = Items.Skip(lineNumber).First();

            for (int i = 0; i < parameters.Length; i++)
            {
                line[i].Should().Be(parameters[i], i.ToString());
            }
        }
    }
}