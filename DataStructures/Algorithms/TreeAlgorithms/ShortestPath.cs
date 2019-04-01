using System;
using System.Collections.Generic;
using DA.Graphs;

namespace DA.Algorithms.TreeAlgorithms
{
	static class ShortestPath
	{
		public static void FindShortestPath (Graph graph, int source)
		{
			int currentIndex;
			int count = graph.Count;
			int[] distance = new int[count];
			int[] path = new int[count];

			Queue<int> queue = new Queue<int> ();
			for (int i = 0; i < count; i++)
			{
				distance[i] = -1;
			}

			queue.Enqueue (source);
			distance[source] = 0;
			while (queue.Count > 0)
			{
				currentIndex = queue.Dequeue ();
				Graph.Node currentNode = graph.GetNode (currentIndex);

				while (currentNode != null)
				{
					if (distance[currentNode.destination] == -1)
					{
						distance[currentNode.destination] = distance[currentIndex] + 1;
						path[currentNode.destination] = currentIndex;
						queue.Enqueue (currentNode.destination);
					}
					currentNode = currentNode.next;
				}
			}
		}
	}
}
