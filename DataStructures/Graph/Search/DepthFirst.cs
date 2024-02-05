using System.Collections.Generic;

namespace DataStructures.Graph.Search
{
    public class DepthFirst<T>
    {

        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return dfs(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
        }

        private bool dfs(IGraphVertex<T> current, HashSet<T> visited, T searchVertexKey)
        {
            visited.Add(current.Key);
            if (current.Key.Equals(searchVertexKey))
                return true;

            foreach (var edge in current.Edges)
            {
                if (visited.Contains(edge.TargetVertexKey))
                    continue;

                if (dfs(edge.TargetVertex, visited, searchVertexKey))
                    return true;
            }
            return false;
        }


    }
}
