using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start)
        {
            Queue<string> frontier = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            List<String> result = new List<string>();

            frontier.Enqueue(start);
            visited.Add(start);


            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();

                result.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            return result;
        }

        public static IReadOnlyList<string> DepthFirstOrder(AdjacencyGraph graph, string start)
        {
            Stack<String> frontier = new Stack<string>();
            HashSet<String> vistied = new HashSet<string>();

            List<String> result = new List<string>();

            frontier.Push(start);
            vistied.Add(start);

            while(frontier.Count > 0)
            {
                string current = frontier.Pop();
                result.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current).Reverse())
                {
                    if (!vistied.Contains(neighbor))
                    {
                        frontier.Push(neighbor);
                        vistied.Add(neighbor);
                    }
                }
            }

            return result;
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start, string target)
        {
            Queue<string> frontier = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            frontier.Enqueue(start);
            visited.Add(start);

            while(frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                if (current == target) return true;

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            return false;
        }
    }
}
