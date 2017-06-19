using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public static class M_StockProcessor
    {
        public static void RefreshTable(E_IStocksStore stocksStore, M_IStockDisplayTable stockDisplayTable)
        {
            StockCollection stockCollection = stocksStore.LoadStocks();

            IEnumerable<M_StockWithPrice> stocksWithPrice = AddPriceToStock(stockCollection);

            IEnumerable<M_StockWithPriceAndValue> stocksWithPriceAndValue = CalculateGainAndCurrentValue(stocksWithPrice);

            M_StockWithPriceAndValue total = CalculateTotalCurrentValueAndGain(stocksWithPriceAndValue);

            List<M_StockDisplayData> displayLines = FormatDataForDisplay(stocksWithPriceAndValue, total);

            stockDisplayTable.Render(displayLines);
        }

        public static List<M_StockDisplayData> FormatDataForDisplay(IEnumerable<M_StockWithPriceAndValue> stocksWithPriceAndValue, M_StockWithPriceAndValue total)
        {
            var displayLines = stocksWithPriceAndValue.Select(
                s => new M_StockDisplayData(
                    s.Stock.Ticker,
                    s.Price,
                    s.Stock.Shares,
                    s.CurrentValue,
                    s.Gain)).ToList();

            displayLines.Add(new M_StockDisplayData("------", "-", "-", "-"));

            displayLines.Add(new M_StockDisplayData("Total", "-", "-", total.CurrentValue, total.Gain));

            return displayLines;
        }

        public static M_StockWithPriceAndValue CalculateTotalCurrentValueAndGain(IEnumerable<M_StockWithPriceAndValue> stocksWithPriceAndValue)
        {
            return new M_StockWithPriceAndValue()
            {
                CurrentValue = stocksWithPriceAndValue.Sum(s => s.CurrentValue),
                Gain = stocksWithPriceAndValue.Sum(s => s.Gain)
            };
        }

        public static IEnumerable<M_StockWithPriceAndValue> CalculateGainAndCurrentValue(IEnumerable<M_StockWithPrice> stocksWithPrice)
        {
            return stocksWithPrice.Select(stockWithPrice => new M_StockWithPriceAndValue()
            {
                Stock = stockWithPrice.Stock,
                Price = stockWithPrice.Price,
                CurrentValue = stockWithPrice.Stock.GetCurrentValue(stockWithPrice.Price),
                Gain = stockWithPrice.Stock.GetGain(stockWithPrice.Price)
            });
        }

        private static IEnumerable<M_StockWithPrice> AddPriceToStock(StockCollection stockCollection)
        {
            StockPriceLoader stockPriceLoader = new StockPriceLoader();

            return stockCollection.EnumerateStocks()
                .Select(stock => new M_StockWithPrice() {Stock = stock, Price = stockPriceLoader.Load(stock.Ticker)});
        }

        public static M_StockWithPriceAndValue CalculateGainAndCurrentValue(M_StockWithPrice stockWithPrice)
        {
            var result = M_StockProcessor.CalculateGainAndCurrentValue(new[] {stockWithPrice});
            return result.First();
        }
    }
}