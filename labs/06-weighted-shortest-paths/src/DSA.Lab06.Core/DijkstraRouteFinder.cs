using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    public sealed class DijkstraRouteFinder
    {
        public RouteResult FindRoute(WeightedGraph graph, string start, string goal)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0); //if you WIN
            }

            Dictionary<string, int> bestCost = new();
            Dictionary<string, string> cameFrom = new();
            MinFrontier<string> frontier = new();

            bestCost[start] = 0; //sets the cost of arriving to this node, to zero duh
            
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;
#region instructions
            // TODO Lab 6A:
            // 1. Repeatedly remove the smallest-priority frontier candidate.
            // 2. Ignore stale entries when a cheaper cost is already known.
            // 3. Finalize/expand the current node.
            // 4. If it is the goal, reconstruct the route using cameFrom.
            // 5. Relax each outgoing edge:
            //      candidate = bestCost[current] + edge.Cost
            //    If candidate improves the known cost, update both bestCost and cameFrom,
            //    then enqueue the neighbor with the improved total cost.
            //
            // Implement one small piece at a time and run the relevant tests.

            //The weightedNode is a custom class containing a string (likely its name) and 2 int values (likely its xy position)
            //The weightedEdge is a custom class containing 2 strings (name of nodes it came from and to) and an int value (its weight)

            //start is the name for the starting node, and goal is the name for the goal you are looking for
            //bestCost is a dictionary containing a string (name of node) and an int (cost of arrivig at the node from start)
            //cameFrom is a dictionary containing 2 strings (name of node and name of the node it came from)
           
            //frontier is a minFrontier which is a binary min-heap that contains a bunch of Entries, which in themselves contain a TValue (a string in this case) and an int (priority) 
            //therefore, frontier include 2 public functions, Enqueue and Dequeue

            //weightedGraph is a 

            // I need to find all the neighbors of a node
#endregion

            while (frontier.Count > 0)
            {
                Entry<string> current = frontier.Dequeue();

                if (current.Priority > bestCost[current.Value])
                {
                    continue;
                }

                expandedNodes++;

                if (current.Value == goal) return RouteResult.Success(Path(), bestCost[goal], expandedNodes);

                foreach (WeightedEdge edge in graph.GetOutgoing(current.Value))
                {
                    if (!bestCost.ContainsKey(edge.To) || bestCost[edge.To] > bestCost[edge.From] + edge.Cost)
                    {
                        bestCost[edge.To] = bestCost[edge.From] + edge.Cost;
                        frontier.Enqueue(edge.To, bestCost[edge.To]);

                        cameFrom[edge.To] = edge.From;
                    }
                }
            }

            IReadOnlyList<string> Path()
            {
                List<string> path = new();
                string current = goal;

                while (true)
                {
                    path.Add(current);
                    if (current == start) break;
                    current = cameFrom[current];
                }
                path.Reverse();

                return path;
            }


            return RouteResult.NotFound(expandedNodes);
        }
    }
}
