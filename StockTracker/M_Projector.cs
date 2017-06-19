using System;
using System.Collections.Generic;
using System.Linq;

namespace StockTracker
{
    // ReSharper disable once InconsistentNaming
    public static class M_Projector
    {
        public static IEnumerable<U> Project<T, U>(IEnumerable<T> inputCollection, Func<T, U> projection)
        {
            return inputCollection.Select(projection);
        }
    }
}