using System;
using System.Collections.Generic;
using DA.DataStructures.Tree;
using DA.Graphs;

namespace DA.Algorithms.TreeAlgorithms
{
	static class DijkstraAlgorithm
	{
		public static void FindShortestPath (Graph graph, int source)
		{
			int[] previous = new int[graph.Count];
			int[] distance = new int[graph.Count];

			for (int i = 0; i < graph.Count; i++)
			{
				previous[i] = -1;
				distance[i] = int.MaxValue;
			}

			previous[source] = -1;
			distance[source] = 0;

			PriorityQueue<Graph.Node> queue = new PriorityQueue<Graph.Node> ();
			Graph.Node node = new Graph.Node (source, source, 0);

			while (queue.Count != 0)
			{
				node = queue.Peek ();
				queue.Dequeue ();

				Graph.Node currentNode = graph.GetNode(node.destination);

				while (currentNode != null)
				{
					int cost = currentNode.cost + distance[currentNode.source];
					if (cost < distance[currentNode.destination])
					{
						distance[currentNode.destination] = cost;
						previous[currentNode.destination] = currentNode.source;
						node = new Graph.Node (currentNode.source, currentNode.destination, cost);
						queue.Enqueue (node);
					}
					currentNode = currentNode.next;
				}
			}
		}
	}
}
