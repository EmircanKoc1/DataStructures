using DataStructures.Heap;
using System;
using System.Collections.Generic;

namespace DataStructures.Graph.MinimumSpanningTree
{
    public class Prim<T, TW>
        where T : IComparable
        where TW : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinumumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, TW>>();

            dfs(graph, graph.ReferenceVertex, new BinaryHeap<MSTEdge<T, TW>>(), new HashSet<T>(), edges);

            return edges;
        }

        private void dfs(
            IGraph<T> graph,
            IGraphVertex<T> currentVertex,
            BinaryHeap<MSTEdge<T, TW>> spNeighours,
            HashSet<T> spVertices,
            List<MSTEdge<T, TW>> spEdges)
        {
            while (true)
            {
                foreach (var edge in currentVertex.Edges)
                {
                    spNeighours.Add(new MSTEdge<T, TW>(
                        currentVertex.Key,
                        edge.TargetVertexKey,
                        edge.Weight<TW>()));
                }

                var minEdge = spNeighours.DeleteMinMax();
                while (spVertices.Contains(minEdge.Source)
                    && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeighours.DeleteMinMax();
                    if (spNeighours.Count is 0)
                        return;
                }

                if (!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }
                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);
                currentVertex = graph.GetVertex(minEdge.Destination);
            }
        }
    }
}
