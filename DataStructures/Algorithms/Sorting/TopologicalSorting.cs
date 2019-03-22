using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs;

namespace DataStructures.Algorithms.Sorting
{
	static class TopologicalSorting
	{
		public static void TopologicalSort (Graph graph)
		{
			int count = graph.Count;
			int[] visited = new int[count];
			Stack<int> stack = new Stack<int> ();

			for (int i = 0; i < count; i++)
			{
				visited[i] = 0;
			}

			for (int i = 0; i < count; i++)
			{
				if(visited[i] == 0)
				{
					visited[i] = 1;
					TopologicalSortDFS (graph, i, visited, stack);
				}
			}
		}

		private static void TopologicalSortDFS (Graph graph, int index, int[] visited, Stack<int> stack)
		{
			Graph.Node head = graph.GetNode (index);

			while (head != null)
			{
				if (visited[head.destination] == 0)
				{
					visited[head.destination] = 1;
					TopologicalSortDFS (graph, head.destination, visited, stack);
				}
				head = head.next;
			}

			stack.Push (index);
		}
	}
}
