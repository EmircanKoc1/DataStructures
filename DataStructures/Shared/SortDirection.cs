using System;
using System.Collections.Generic;

namespace DataStructures.Shared
{
    public enum SortDirection
    {
        Asceding = 0,
        Descending = 1,


    }

    public class CustomComparer<T> : IComparer<T>
        where T : IComparable
    {
        private readonly bool isMax;
        private readonly IComparer<T> comparer;
        public CustomComparer(SortDirection sortDirection, IComparer<T> comparer)
        {
            isMax = sortDirection == SortDirection.Descending;
            this.comparer = comparer;
        }
        public int Compare(T x, T y)
        {
            return !isMax ? compare(x, y) : compare(y, x);
        }

        private int compare(T x, T y) => comparer.Compare(x, y);

    }



}
