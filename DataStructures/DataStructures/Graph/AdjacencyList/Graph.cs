using System;

namespace DA.Graphs
{
	internal class Graph
	{
		public class Node : IComparable<Node>
		{
			internal int source;
			internal int destination;
			internal int cost;

			internal Node next;

			public Node (int source, int destination, int cost)
			{
				this.source = source;
				this.destination = destination;
				this.cost = cost;
			}

			public int CompareTo (Node other)
			{
				return cost - other.cost;
			}
		}

		public class List
		{
			internal Node head;
		}

		private int count;
		private List[] nodes;

		public Graph (int count)
		{
			this.count = count;
			nodes = new List[count];

			for (int i = 0; i < count; i++)
			{
				nodes[i] = new List ();
				nodes[i].head = null;
			}
		}

		public int Count { get { return count; } }

		public virtual void AddEdge (int source, int destination, int cost)
		{
			Node node = new Node (source, destination, cost);
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

		public Node GetNode (int index)
		{
			return nodes[index].head;
		}

		public List GetList (int index)
		{
			return nodes[index];
		}

		public virtual void Print ()
		{
			Node node;

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
