using System.Collections.Generic;
using DA.Graphs;

namespace DA.Algorithms.Searching
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
				Graph.Node currentNode = graph.GetNode(current);
				while (currentNode != null)
				{
					if (visited[currentNode.destination] == 0)
					{
						visited[currentNode.destination] = 1;
						queue.Enqueue (currentNode.destination);
					}
					currentNode = currentNode.next;
				}
			}
		}
	}
}
