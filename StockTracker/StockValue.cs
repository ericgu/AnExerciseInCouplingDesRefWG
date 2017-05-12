namespace StockTracker
{
    public class StockValue
    {
        public StockValue(Stock stock, double price)
        {
            Stock = stock;
            Price = price;
        }

        private Stock Stock { get; }
        private double Price { get; }

        public static double GetStockGain(StockValue stockValue)
        {
            return stockValue.Stock.Shares*(stockValue.Price - stockValue.Stock.PurchasePrice);
        }

        public static double GetStockTotalPrice(StockValue stockValue)
        {
            return stockValue.Stock.Shares*stockValue.Price;
        }
    }
}