
using System.Collections.Generic;
using DA.Graphs;

namespace DA.Algorithms.Searching
{
	internal static class DepthFirstTraversal
	{
		public static void DFS_Stack (Graph graph)
		{
			int count = graph.Count;
			int current;

			int[] visited = new int[count];
			Stack<int> stack = new Stack<int> ();

			for (int i = 0; i < count; i++)
			{
				visited[i] = 0;
			}

			visited[0] = 1;
			stack.Push (0);

			while (stack.Count > 0)
			{
				current = stack.Pop ();

				Graph.Node currentNode = graph.GetNode (current);
				while (currentNode != null)
				{
					if (visited[currentNode.destination] == 0)
					{
						visited[currentNode.destination] = 1;
						stack.Push (currentNode.destination);
					}
					currentNode = currentNode.next;
				}
			}
		}

		public static void DFS_Recursion (Graph graph, int index, int[] visited)
		{
			Graph.Node head = graph.GetNode (index);

			while (head != null)
			{
				if (visited[head.destination] == 0)
				{
					visited[head.destination] = 1;
					DFS_Recursion (graph, head.destination, visited);
				}
				head = head.next;
			}
		}
	}
}
