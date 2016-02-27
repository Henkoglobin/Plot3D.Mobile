using System;
using System.Collections.Generic;

namespace StandardLibrary.PatternHelpers
{
    public class StrategyComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> compare;
        private readonly Func<T, int> getHashCode;

        public bool Equals(T x, T y)
        {
            return this.compare(x, y);
        }

        public int GetHashCode(T obj)
        {
            return this.getHashCode(obj);
        }

        public StrategyComparer(Func<T, T, bool> compare)
            : this(compare, x => x.GetHashCode())
        { }

        public StrategyComparer(Func<T, T, bool> compare, Func<T, int> getHashCode)
        {
            this.compare = compare;
            this.getHashCode = getHashCode;
        }
    }
}
