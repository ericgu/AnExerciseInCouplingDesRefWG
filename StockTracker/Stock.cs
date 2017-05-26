// Design discussion comments:
// Add your comment here, in this format:
// <alias>: comment

using System;

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

        private bool Equals(Stock other)
        {
            return string.Equals(Ticker, other.Ticker, StringComparison.InvariantCultureIgnoreCase) && Shares.Equals(other.Shares) && PurchasePrice.Equals(other.PurchasePrice) && string.Equals(PurchaseDate, other.PurchaseDate, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Stock) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StringComparer.InvariantCultureIgnoreCase.GetHashCode(Ticker);
                hashCode = (hashCode * 397) ^ Shares.GetHashCode();
                hashCode = (hashCode * 397) ^ PurchasePrice.GetHashCode();
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(PurchaseDate);
                return hashCode;
            }
        }

        public string Ticker { get; }
        public double Shares { get; }
        public double PurchasePrice { get; }
        public string PurchaseDate { get; }

        public override string ToString()
        {
            return Ticker + ":" + Shares + ":" + PurchasePrice + ":" + PurchaseDate;
        }

        public double GetGain(double price)
        {
            return Shares * (price - PurchasePrice);
        }

        public double GetCurrentValue(double price)
        {
            return Shares * price;
        }
    }
}