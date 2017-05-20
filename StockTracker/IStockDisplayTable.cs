namespace StockTracker
{
    public interface IStockDisplayTable
    {
        void AddItemToList(params object[] parameters);
        void ClearList();
    }
}