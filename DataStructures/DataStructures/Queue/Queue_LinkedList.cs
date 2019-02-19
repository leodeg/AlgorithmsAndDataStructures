using System;

namespace DataStructures.Queue
{
	public class Queue_LinkedList<T>
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
		}

		public Queue_LinkedList ()
		{
			Count = 0;
			Head = null;
		}

		private Node<T> Head { get; set; }
		public int Count { get; set; }

		public void Enqueue (T value)
		{
			if (value.Equals (null)) throw new ArgumentNullException ();

			Node<T> node = new Node<T> (value);

			if (Head == null)
			{
				Head = node;
				++Count;
				return;
			}

			node.Next = Head;
			Head = node;
			++Count;
		}

		public T Dequeue ()
		{
			if (Head == null) throw new ArgumentOutOfRangeException ();

			if (Head.Next == null && Head != null)
			{
				Node<T> temp = Head;
				Head = null;
				--Count;
				return temp.Value;
			}

			Node<T> prevLast = GetPrevLastNode ();
			Node<T> last = prevLast.Next;

			prevLast.Next = null;
			--Count;
			return last.Value;
		}

		public void Clear ()
		{
			Head.Next = null;
			Head = null;
			Count = 0;
		}

		private Node<T> GetPrevLastNode ()
		{
			if (Head == null) throw new ArgumentOutOfRangeException ();

			Node<T> current = Head;

			while (current.Next.Next != null)
			{
				current = current.Next;
			}

			return current;
		}
	}
}
