using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
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

        public IEnumerable<string> Items { get { return _items; } } 
    }
}