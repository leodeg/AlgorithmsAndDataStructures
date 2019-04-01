using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.TreeAlgorithms
{
    internal static class BellmanFordShortestPath
    {
        public static void FindShortestPath (Graphs.Graph graph, int source)
        {
            int count = graph.Count;
            int [] distance = new int [count];
            int [] path = new int [count];

            for (int i = 0; i < count; i++)
                distance [i] = int.MaxValue;

            distance [source] = 0;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Graphs.Graph.Node currentNode = graph.GetNode (j);
                    while (currentNode != null)
                    {
                        int newDistance = distance [j] + currentNode.cost;
                        if (distance[currentNode.destination] > newDistance)
                        {
                            distance [currentNode.destination] = newDistance;
                            path [currentNode.destination] = j;
                        }
                        currentNode = currentNode.next;
                    }
                }
            }
        }
    }
}
