using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graph.AdjacencyList;

namespace DataStructures.Algorithms.Searching
{
	internal class DepthFirstTraversal
	{
		public static void DFS_Stack (Graph.AdjacencyList.Graph graph)
		{
			int count = graph.Count;
			int[] visited = new int[count];
			int current;

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

				Graph.AdjacencyList.Graph.ANode head = graph.GetNode (current);
				while (head != null)
				{
					if (visited[head.destination] == 0)
					{
						visited[head.destination] = 1;
						stack.Push (head.destination);
					}
					head = head.next;
				}
			}
		}

		public static void DFS_Recursion (Graph.AdjacencyList.Graph graph, int index, int[] visited)
		{
			Graph.AdjacencyList.Graph.ANode head = graph.GetNode (index);

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
