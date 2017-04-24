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
        public double PurchasePrice { get; }
        public string PurchaseDate { get; }

        public override string ToString()
        {
            return Ticker + ":" + Shares + ":" + PurchasePrice + ":" + PurchaseDate;
        }
    }
}