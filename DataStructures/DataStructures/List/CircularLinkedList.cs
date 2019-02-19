using System;

namespace DataStructures.List
{
	public class CircularLinkedList<T>
	{
		public class Node<T>
		{
			public Node<T> Next { get; set; }
			public T Value { get; set; }

			public Node (T value)
			{
				Next = null;
				Value = value;
			}

			public Node (T value, Node<T> next)
			{
				Next = next;
				Value = value;
			}
		}

		public CircularLinkedList ()
		{
			Head = null;
			Count = 0;
		}

		#region Properties

		public T this[int index]
		{
			get { return GetNodeAt (index).Value; }
			set { GetNodeAt (index).Value = value; }
		}

		private Node<T> Head { get; set; }

		public int Count { get; private set; }

		public Node<T> First { get { return Head; } }

		public Node<T> Last { get { return GetLastNode (); } }

		#endregion

		#region Add Methods

		public void AddFront (T value)
		{
			Node<T> node = new Node<T> (value);

			if (Head == null || Count == 0)
			{
				node.Next = Head;
				Head = node;
				++Count;
			}
			else
			{
				node.Next = Head.Next;
				Head = node;
				++Count;
			}
		}

		public void AddBack (T value)
		{
			Node<T> node = new Node<T> (value);

			if (Head == null || Count == 0)
			{
				node.Next = Head;
				Head = node;
				++Count;
				return;
			}

			Node<T> last = GetLastNode ();
			node.Next = last.Next;
			last.Next = node;
			++Count;
		}

		#endregion

		#region Remove Methods

		public void RemoveFront ()
		{
			if (Head == null || Count == 0) throw new ArgumentNullException ();
			Head = Head.Next;
			--Count;
		}

		public void RemoveLast ()
		{
			if (Head == null) throw new ArgumentNullException ();

			if (Count == 1)
			{
				Head = null;
			}

			if (Count == 2)
			{
				Head.Next = null;
			}

			Node<T> prevLast = GetNodeAt (Count - 2);
			prevLast.Next = prevLast.Next.Next;
			--Count;
		}

		public void RemoveAt (int index)
		{
			if (Head == null) throw new ArgumentNullException ();

			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException ();
			}

			Node<T> temp = GetNodeAt (index - 1);
			temp.Next = temp.Next.Next;
			--Count;
		}

		public void Clear ()
		{
			Head.Next = null;
			Head = null;
		}

		#endregion

		#region Get Node Methods

		public Node<T> GetNodeAt (int index)
		{
			if (Head == null)
			{
				throw new ArgumentNullException ();
			}

			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException ();
			}

			Node<T> temp = Head;

			for (int i = 0; i < index; i++)
			{
				temp = temp.Next;
			}

			return temp;
		}

		public Node<T> GetLastNode ()
		{
			Node<T> temp = Head;

			for (int i = 0; i < Count - 1; i++)
			{
				temp = temp.Next;
			}

			return temp;
		}

		#endregion
	}
}
