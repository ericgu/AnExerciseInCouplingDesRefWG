﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker;

namespace StockTrackerTests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class E_StockProcessorTests
    {
        [TestMethod]
        public void when_I_call_RefreshTable_with_one_stock__the_stock_line_is_correct()
        {
            E_IStocksStore stocksStore= new E_StocksStoreMock(
                new Stock("MSFT", 100, 100, "5/10/2020")
                );

            E_StockDisplayTableMock stockDisplay = new E_StockDisplayTableMock();
            E_GainModelMock gainModel = new E_GainModelMock();

            E_StockProcessor.RefreshTable(stocksStore, gainModel, stockDisplay);

            stockDisplay.Items.Count.Should().Be(3);
            stockDisplay.ValidateLine(0, "MSFT", "15", "100", "25", "33");
        }

        [TestMethod]
        public void when_I_call_RefreshTable_with_two_stocks__the_stock_lines_and_total_are_correct()
        {
            E_IStocksStore stocksStore = new E_StocksStoreMock(
                new Stock("MSFT", 100, 100, "5/10/2020"),
                new Stock("GOOG", 300, 400, "6/10/2020")
                );

            E_StockDisplayTableMock stockDisplay = new E_StockDisplayTableMock();
            E_GainModelMock gainModel = new E_GainModelMock();

            E_StockProcessor.RefreshTable(stocksStore, gainModel, stockDisplay);

            stockDisplay.Items.Count.Should().Be(4);
            stockDisplay.ValidateLine(0, "MSFT", "15", "100", "25", "33");
            stockDisplay.ValidateLine(1, "GOOG", "15", "300", "25", "33");
            stockDisplay.ValidateLine(3, "Total", "-", "-", "50", "66");
        }
    }
}
