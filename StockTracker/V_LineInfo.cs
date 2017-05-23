namespace StockTracker
{
    internal class V_LineInfo
    {
        public V_LineInfo(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; }
    }
}