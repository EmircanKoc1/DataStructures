using System;
using System.Collections.Generic;

namespace DataStructures.Graph
{
    public interface IGraph<T>
    {
        bool isWeightedGraph { get; }
        int Count { get; }
        IGraphVertex<T> ReferenceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumerable { get; }
        IEnumerable<T> Edges(T value);
        IGraph<T> Clone();
        bool ContainsVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        bool HasEdge(T source, T dest);
        void AddVertex(T key);
        void RemoveVertex(T key);
        void RemoveEdge(T source, T dest);
    }
    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }
        IEnumerable<IEdge<T>> Edges { get; }
        IEdge<T> GetEdge(IGraphVertex<T> targetVertex);
    }
    public interface IEdge<T>
    {
        T TargetVertexKey { get; }
        IGraphVertex<T> TargetVertex { get; }
        W Weight<W>() where W : IComparable;
    }

    public interface IDiGraphVertex<T> : IGraphVertex<T>
    {
        IDiEdge<T> GetOutEdge(IDiGraphVertex<T> vertex);
        IEnumerable<IDiEdge<T>> OutEdges { get; }
        IEnumerable<IDiEdge<T>> InEdges { get; }
        int OutEdgesCount { get; }
        int InEdgesCount { get; }

    }
    public interface IDiEdge<T> : IEdge<T>
    {
        new IDiGraphVertex<T> TargetVertex { get; }
    }
    public interface IDiGraph<T> : IGraph<T> , IEnumerable<T>
    {
        new IDiGraphVertex<T> ReferenceVertex { get; }
        new IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable { get; }
        new IDiGraphVertex<T> GetVertex(T key);
    }




}
