using System;

namespace DataStructures.Graph.MinimumSpanningTree
{
    public class MSTEdge<T, TW> : IComparable
        where TW : IComparable
    {
        public MSTEdge(T source, T destination, TW weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public T Source { get; }
        public T Destination { get; }
        public TW Weight { get; }

        public int CompareTo(object obj)
        {
            return Weight.CompareTo((obj as MSTEdge<T, TW>).Weight);
        }
        public override string ToString()
        {
            return $"{Source} - {Destination} W: {Weight}";
        }


    }
}
