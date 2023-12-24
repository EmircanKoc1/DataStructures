using System;

namespace DataStructures.Graph
{
    public class Edge<T, C> : IEdge<T>
        where C : IComparable
    {
        private object weight;
        public Edge(IGraphVertex<T> target, C weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }

    public class DiEdge<T, TW> : IDiEdge<T>
    {
        private object weight;
        public DiEdge(IDiGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }


        public IDiGraphVertex<T> TargetVertex { get; private set; }
        public T TargetVertexKey => TargetVertex.Key;

        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return $"{TargetVertexKey}";
        }



    }


}
