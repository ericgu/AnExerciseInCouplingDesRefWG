using System.Collections;
using System.Collections.Generic;

namespace StockTracker
{
    public class V_LineInfo
    {
        public V_LineInfo(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; }

        private bool Equals(V_LineInfo other)
        {
            return (Parameters as IStructuralEquatable).Equals(other.Parameters, EqualityComparer<object>.Default);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((V_LineInfo)obj);
        }

        public override int GetHashCode()
        {
            return Parameters?.GetHashCode() ?? 0;
        }
    }
}