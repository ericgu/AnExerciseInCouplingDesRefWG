// Design discussion comments:
// Add your comment here, in this format:
// <alias>: comment

namespace StockTracker
{
    public class Stock
    {
        public Stock(string ticker, double shares, double purchasePrice, string purchaseDate)
        {
            Ticker = ticker;
            Shares = shares;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
        }

        public string Ticker { get; }
        public double Shares { get; }
        private double PurchasePrice { get; }
        private string PurchaseDate { get; }

        public override string ToString()
        {
            return Ticker + ":" + Shares + ":" + PurchasePrice + ":" + PurchaseDate;
        }

        public double GetStockGain(double price)
        {
            return Shares*(price - PurchasePrice);
        }

        public double GetStockTotalPrice(double price)
        {
            return Shares*price;
        }
    }
}