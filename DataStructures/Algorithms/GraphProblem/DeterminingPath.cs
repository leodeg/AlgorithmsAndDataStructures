using DA.Algorithms.Searching;

namespace DA.Algorithms.GraphProblem
{
	static class DeterminingPath
	{
		public static int PathExist (Graphs.Graph graph, int source, int destination)
		{
			int count = graph.Count;
			int[] visited = new int[count];

			for (int i = 0; i < count; i++)
			{
				visited[i] = 0;
			}

			visited[source] = 1;
			DepthFirstTraversal.DFS_Recursion (graph, source, visited);
			return visited[destination];
		}
	}
}
