﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Graph.AdjancencySet
{
    public class WeightedGraph<T, TW> : IGraph<T>
        where TW : IComparable
    {
        private Dictionary<T, WeightedGraphVertex<T, TW>> vertices;
        public WeightedGraph()
        {
            vertices = new Dictionary<T, WeightedGraphVertex<T, TW>>();
        }
        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferenceVertex => vertices[this.vertices.Keys.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public void AddVertex(T key)
        {
            if (key is null)
                throw new ArgumentNullException();

            var newVertex = new WeightedGraphVertex<T, TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }
        public WeightedGraph<T, TW> Clone()
        {
            var graph = new WeightedGraph<T, TW>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);

            }

            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            return vertices[key].Edges.Select(x => x.Key.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }


        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            return vertices[source].Edges.ContainsKey(vertices[dest]) && vertices[dest].Edges.ContainsKey(vertices[source]);
        }
        public void AddEdge(T source, T dest, TW weight)
        {
            vertices[source].Edges.Add(vertices[dest], weight);
            vertices[dest].Edges.Add(vertices[source], weight);
        }
        public void RemoveEdge(T source, T dest)
        {
            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key is null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(key))
                throw new ArgumentException();

            foreach (var vertex in vertices[key].Edges)
            {
                vertex.Key.Edges.Remove(vertices[key]);
            }

            vertices.Remove(key);
        }

        private class WeightedGraphVertex<T, TW> : IGraphVertex<T>
            where TW : IComparable
        {

            public Dictionary<WeightedGraphVertex<T, TW>, TW> Edges;

            public WeightedGraphVertex(T key)
            {
                Key = key;
                Edges = new Dictionary<WeightedGraphVertex<T, TW>, TW>();
            }

            public T Key { get; set; }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>
                Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, TW>(targetVertex, Edges[targetVertex as WeightedGraphVertex<T, TW>]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
