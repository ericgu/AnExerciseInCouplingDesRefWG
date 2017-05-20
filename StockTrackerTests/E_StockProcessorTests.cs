using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
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
    }

    public class E_GainModelMock : E_IGainModel
    {
        public IEnumerable<StockValue> GetModel(IEnumerable<Stock> enumerateStocks)
        {
            return enumerateStocks.Select(stock => new StockValue(stock, 15, 25, 33));
        }
    }

    [TestClass]
    public class E_StockProcessorTests
    {
        [TestMethod]
        public void when_I_call_RefreshTable_with_one_stock__the_stock_line_is_correct()
        {
            StockCollection stocks = new StockCollection();
            stocks.Add("MSFT", 100, 100, "5/10/2020");

            E_StockDisplayTableMock stockDisplay = new E_StockDisplayTableMock();
            E_GainModelMock gainModel = new E_GainModelMock();

            E_StockProcessor.RefreshTable(stocks, gainModel, stockDisplay);

            stockDisplay.Items.Count.Should().Be(3);
            ValidateLine(stockDisplay, "MSFT", "15", "100", "25", "33");
        }

        private static void ValidateLine(E_StockDisplayTableMock stockDisplay, params string[] parameters)
        {
            var line = stockDisplay.Items.First();

            for (int i = 0; i < parameters.Length; i++)
            {
                line[i].Should().Be(parameters[i], i.ToString());
            }
        }
    }
}
