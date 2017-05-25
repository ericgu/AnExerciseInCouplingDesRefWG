namespace StockTracker
{
    public class StockValue
    {
        protected bool Equals(StockValue other)
        {
            return Stock.Equals(other.Stock) && Price.Equals(other.Price) && StockTotalPrice.Equals(other.StockTotalPrice) && StockGain.Equals(other.StockGain);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StockValue) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Stock.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ StockTotalPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ StockGain.GetHashCode();
                return hashCode;
            }
        }

        public StockValue(
            Stock stock,
            double price,
            double stockTotalPrice,
            double stockGain)
        {
            Stock = stock;
            Price = price;
            StockTotalPrice = stockTotalPrice;
            StockGain = stockGain;
        }

        public Stock Stock { get; }
        public double Price { get;  }
        public double StockTotalPrice { get; }
        public double StockGain { get; }
    }
}