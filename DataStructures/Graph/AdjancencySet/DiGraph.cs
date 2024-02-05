using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Graph.AdjancencySet
{
    public class DiGraph<T> : IDiGraph<T>
    {
        private Dictionary<T, DiGraphVertex<T>> vertices;

        public IDiGraphVertex<T> ReferenceVertex =>
            vertices.First().Value;

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable =>
            vertices.Select(x => x.Value);


        public DiGraph()
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
        }

        public DiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
            foreach (var item in collection)
                AddVertex(item);
        }
        public bool isWeightedGraph => false;
        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex => ReferenceVertex;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public void AddVertex(T key) =>
            vertices.Add(key, new DiGraphVertex<T>(key));


        public void AddEdge(T source, T dest)
        {
            vertices[source].OutEdges.Add(vertices[dest]);
            vertices[dest].InEdges.Add(vertices[source]);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }
        public IGraph<T> Clone()
        {
            var graph = new DiGraph<T>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.OutEdges)
                {
                    graph.AddEdge(vertex.Value.Key, edge.Key);
                }
            }

            return graph;
        }

        public bool ContainsVertex(T key) =>
            vertices.ContainsKey(key);

        public IEnumerable<T> Edges(T key) =>
            vertices[key].OutEdges.Select(x => x.Key);

        public IEnumerator<T> GetEnumerator() =>
            vertices.Select(x => x.Key).GetEnumerator();

        public IDiGraphVertex<T> GetVertex(T key) =>
            vertices[key];


        public bool HasEdge(T source, T dest) =>
            vertices[source].OutEdges.Contains(vertices[dest]) &&
            vertices[dest].InEdges.Contains(vertices[source]);



        public void RemoveEdge(T source, T dest)
        {
            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);

        }

        public void RemoveVertex(T key)
        {
            foreach (var vertex in vertices[key].InEdges)
                vertex.InEdges.Remove(vertices[key]);

            foreach (var vertex in vertices[key].OutEdges)
                vertex.OutEdges.Remove(vertices[key]);

            vertices.Remove(key);

        }
        IEnumerator IEnumerable.GetEnumerator() =>
             GetEnumerator();

        IGraphVertex<T> IGraph<T>.GetVertex(T key) =>
            vertices[key];


        private class DiGraphVertex<T> : IDiGraphVertex<T>
        {
            public HashSet<DiGraphVertex<T>> OutEdges { get; set; }
            public HashSet<DiGraphVertex<T>> InEdges { get; set; }
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges =>
                OutEdges.Select(x => new DiEdge<T, int>(x, 1));
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges =>
                InEdges.Select(x => new DiEdge<T, int>(x, 1));

            public int OutEdgesCount => OutEdges.Count;
            public int InEdgesCount => InEdges.Count;
            public T Key { get; set; }

            public DiGraphVertex(T key)
            {
                Key = key;
                OutEdges = new HashSet<DiGraphVertex<T>>();
                InEdges = new HashSet<DiGraphVertex<T>>();
            }
            public IEnumerable<IEdge<T>> Edges =>
                OutEdges.Select(x => new Edge<T, int>(x, 1));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex) =>
                new Edge<T, int>(targetVertex, 1);

            public IEnumerator<T> GetEnumerator() =>
                OutEdges.Select(x => x.Key).GetEnumerator();

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> vertex) =>
                 new DiEdge<T, int>(vertex, 1);

            IEnumerator IEnumerable.GetEnumerator() =>
                GetEnumerator();


        }
    }
}
