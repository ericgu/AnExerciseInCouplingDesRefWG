using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public class M_StockDisplayData
    {
        readonly List<string> _items = new List<string>();

        public M_StockDisplayData(params object[] parameters)
        {
            foreach (object parameter in parameters)
            {
                _items.Add(parameter.ToString());
            }
        }

        public IList<string> Items { get { return _items; } } 
    }
}