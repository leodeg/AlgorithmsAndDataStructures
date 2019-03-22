using System;
using System.Collections.Generic;
using DataStructures.DataStructures.Tree;
using DataStructures.Graphs;

namespace DataStructures.Algorithms.TreeAlgorithms
{
	internal static class MinimumSpanningTree
	{
		public static void Prims (Graph graph)
		{
			int[] previous = new int[graph.Count];
			int[] destination = new int[graph.Count];
			int source = -1;

			for (int i = 0; i < graph.Count; i++)
			{
				previous[i] = i;
				destination[i] = int.MaxValue;
			}

			destination[source] = 0;
			previous[source] = -1;
			PriorityQueue<Graph.Node> queue = new PriorityQueue<Graph.Node> ();
			Graph.Node node = new Graph.Node (source, source, 0);
			queue.Enqueue (node);

			while (queue.Count != 0)
			{
				node = queue.Peek ();
				queue.Dequeue ();

				Graph.List list = graph.GetList (node.destination);
				Graph.Node currentNode = list.head;

				while (currentNode != null)
				{
					int currentCost = currentNode.cost;
					if (currentCost < destination[currentNode.destination])
					{
						destination[currentNode.destination] = currentCost;
						previous[currentNode.destination] = currentNode.source;
						node = new Graph.Node (currentNode.source, currentNode.destination, currentCost);
						queue.Enqueue (node);
					}
					currentNode = currentNode.next;
				}
			}
		}
	}
}
