using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Algorithms.Searching;

namespace DataStructures.Algorithms.GraphProblem
{
	static class IsGraphConnected
	{
		public static bool IsConnected (Graphs.Graph graph)
		{
			int count = graph.Count;
			int[] visited = new int[count];

			for (int i = 0; i < count; i++)
			{
				visited[i] = 0;
			}

			visited[0] = 1;
			DepthFirstTraversal.DFS_Recursion (graph, 0, visited);

			for (int i = 0; i < count; i++)
			{
				if (visited[0] == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
