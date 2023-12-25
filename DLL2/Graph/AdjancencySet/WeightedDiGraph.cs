using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Graph.AdjancencySet
{
    public class WeightedDiGraph<T, TW> : IDiGraph<T>
        where TW : IComparable
    {
        private Dictionary<T, WeightedDiGraphVertex<T, TW>> vertices;
        public IDiGraphVertex<T> ReferenceVertex => vertices.First().Value;

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex =>
            vertices.First().Value;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public WeightedDiGraph()
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
        }
        public WeightedDiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
            foreach (var vertex in collection)
                AddVertex(vertex);
        }
        public void AddVertex(T key)
        {
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedDiGraph<T, TW> Clone()
        {
            var graph = new WeightedDiGraph<T, TW>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);
            foreach (var vertex in vertices)
            {
                foreach (var node in vertex.Value.OutEdges)
                    graph.AddEdge(vertex.Value.Key, node.Key.Key, node.Value);
            }

            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);

        }

        public IEnumerable<T> Edges(T key)
        {
            return vertices[key].OutEdges.Select(x => x.Key.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            return vertices[source].OutEdges.ContainsKey(vertices[dest]) &&
                vertices[dest].OutEdges.ContainsKey(vertices[source]);
        }

        public void RemoveEdge(T source, T dest)
        {
            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);

        }
        public void AddEdge(T source, T dest, TW weight)
        {
            vertices[source].OutEdges.Add(vertices[dest], weight);
            vertices[dest].InEdges.Add(vertices[source], weight);
        }


        public void RemoveVertex(T key)
        {
            foreach (var vertex in vertices[key].InEdges)
                vertex.Key.InEdges.Remove(vertices[key]);

            foreach (var vertex in vertices[key].OutEdges)
                vertex.Key.OutEdges.Remove(vertices[key]);

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return vertices[key];
        }

        private class WeightedDiGraphVertex<T, TW> : IDiGraphVertex<T>
            where TW : IComparable
        {

            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> OutEdges;
            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> InEdges;

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges =>
                OutEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges =>
               InEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;

            public T Key { get; set; }

            public WeightedDiGraphVertex(T key)
            {
                this.Key = key;
                OutEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
                InEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
            }
            public IEnumerable<IEdge<T>> Edges =>
               OutEdges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                var node = targetVertex as WeightedDiGraphVertex<T, TW>;
                return new Edge<T, TW>(targetVertex, OutEdges[node]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                var node = targetVertex as WeightedDiGraphVertex<T, TW>;
                return new DiEdge<T, TW>(targetVertex, OutEdges[node]);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


    }
}
