using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
    public static class M_StockProcessor
    {
        public static void RefreshTable(E_IStocksStore stocksStore, E_IStockDisplayTable stockDisplayTable)
        {
            var stockCollection = LoadStocks(stocksStore);

            var stocksWithPrice = AddPriceToStock(stockCollection);

            var stocksWithPriceAndValue = CalculateGainAndCurrentValue(stocksWithPrice);

            var total = CalculateTotalCurrentValueAndGain(stocksWithPriceAndValue);

            SendDataToUi(stockDisplayTable, stocksWithPriceAndValue, total);
        }

        private static void SendDataToUi(E_IStockDisplayTable stockDisplayTable, IEnumerable<M_StockWithPriceAndValue> stocksWithPriceAndValue,
            M_StockWithPriceAndValue total)
        {
            stockDisplayTable.ClearList();

            foreach (var stockWithPriceAndValue in stocksWithPriceAndValue)
            {
                stockDisplayTable.AddItemToList(
                    stockWithPriceAndValue.Stock.Ticker,
                    stockWithPriceAndValue.Price,
                    stockWithPriceAndValue.Stock.Shares,
                    stockWithPriceAndValue.CurrentValue,
                    stockWithPriceAndValue.Gain);
            }

            stockDisplayTable.AddItemToList("------", "-", "-", "-");

            stockDisplayTable.AddItemToList("Total", "-", "-",
                total.CurrentValue, total.Gain);
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

        private static StockCollection LoadStocks(E_IStocksStore stocksStore)
        {
            return new StockCollection(stocksStore.LoadStocks());
        }
    }
}