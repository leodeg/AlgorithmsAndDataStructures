using System.Collections.Generic;
using DataStructures.Graphs;

namespace DataStructures.Algorithms.Searching
{
	internal class BreadthFirstTraversal
	{
		public void BFS_Queue (Graph graph, int index, int[] visited)
		{
			if (graph.Equals (null))
			{
				throw new System.ArgumentNullException (nameof(graph));
			}

			if (index < 0)
			{
				throw new System.InvalidOperationException ("Index must be greater than zero");
			}

			int current;
			Queue<int> queue = new Queue<int> ();

			visited[index] = 1;
			queue.Enqueue (index);

			while (queue.Count > 0)
			{
				current = queue.Dequeue ();
				Graph.Node head = graph.GetNode(current);
				while (head != null)
				{
					if (visited[head.destination] == 0)
					{
						visited[head.destination] = 1;
						queue.Enqueue (head.destination);
					}
					head = head.next;
				}
			}
		}
	}
}
