using System;
using System.Collections.Generic;
using DataStructures.Graphs;

namespace DataStructures.Algorithms.TreeAlgorithms
{
	static class ShortestPath
	{
		public static void FindShortestPath (Graph graph, int source)
		{
			int current;
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
				current = queue.Dequeue ();
				Graph.Node head = graph.GetNode (current);

				while (head != null)
				{
					if (distance[head.destination] == -1)
					{
						distance[head.destination] = distance[current] + 1;
						path[head.destination] = current;
						queue.Enqueue (head.destination);
					}
					head = head.next;
				}
			}
		}
	}
}
