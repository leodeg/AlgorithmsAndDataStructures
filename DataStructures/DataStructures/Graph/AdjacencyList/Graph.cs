using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjacencyList
{
	class Graph
	{
		public class ANode : IComparable<ANode>
		{
			internal int source;
			internal int destination;
			internal int cost;

			internal ANode next;

			public ANode (int source, int destination, int cost)
			{
				this.source = source;
				this.destination = destination;
				this.cost = cost;
			}

			public int CompareTo (ANode other)
			{
				return cost - other.cost;
			}
		}

		private class AList
		{
			internal ANode head;
		}

		private int count;
		private AList[] nodes;

		public Graph (int count)
		{
			this.count = count;
			nodes = new AList[count];

			for (int i = 0; i < count; i++)
			{
				nodes[i] = new AList ();
				nodes[i].head = null;
			}
		}

		public int Count { get { return count; } }

		public virtual void AddEdge (int source, int destination, int cost)
		{
			ANode node = new ANode (source, destination, cost);
			node.next = nodes[source].head;
			nodes[source].head = node;
		}

		public virtual void AddEdge (int source, int destination)
		{
			AddEdge (source, destination, 1);
		}

		public virtual void AddBiEdge (int source, int destination, int cost)
		{
			AddEdge (source, destination, cost);
			AddEdge (destination, source, cost);
		}

		public virtual void AddBiEdge (int source, int destination)
		{
			AddEdge (source, destination, 1);
		}

		public ANode GetNode (int index)
		{
			return nodes[index].head;
		} 

		public virtual void Print ()
		{
			ANode node;

			for (int i = 0; i < count; i++)
			{
				node = nodes[i].head;
				if (node != null)
				{
					Console.WriteLine ("Vertex: {0} is connected to: ", i);
					while (node != null)
					{
						Console.WriteLine (node.destination + " ");
						node = node.next;
					}
					Console.WriteLine ("");
				}
			}
		}
	}
}
