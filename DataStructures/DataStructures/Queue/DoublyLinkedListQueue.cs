using System;

namespace DataStructures.Queue
{
	public class DoublyLinkedListQueue<T> : IQueue<T>
	{
		/* First node used as last element in queue. 
		 * Last node used as first element in queue. */

		public class Node<T>
		{
			public Node<T> Next { get; set; }
			public Node<T> Prev { get; set; }
			public T Value { get; set; }

			public Node (T value)
			{
				Value = value;
			}
		}

		public DoublyLinkedListQueue ()
		{
			Clear ();
		}

		/// <summary>
		/// First element at queue.
		/// </summary>
		private Node<T> Head { get; set; }

		/// <summary>
		/// Last element at queue.
		/// </summary>
		private Node<T> Tail { get; set; }

		/// <summary>
		/// Total amount of elements in queue.
		/// </summary>
		public int Size { get; private set; }

		/// <summary>
		/// Return true if queue is empty, otherwise return false.
		/// </summary>
		public bool IsEmpty => Size <= 0;

		/// <summary>
		/// Insert element at end of queue.
		/// </summary>
		public void Enqueue (T data)
		{
			Node<T> node = new Node<T> (data);

			if (Head == null)
			{
				node.Next = Head.Next;
				Head = node;
				++Size;
				return;
			}

			node.Next = Head;
			Head = node;
			++Size;
		}

		/// <summary>
		/// Return and delete fronted element.
		/// </summary>
		public T Dequeue ()
		{
			Node<T> temp = Tail;
			Node<T> prev = Tail.Prev;

			prev.Next = null;
			--Size;
			return temp.Value;
		}

		public T Peek ()
		{
			return Tail.Value;
		}

		public void Clear ()
		{
			Head = null;
			Tail = null;
			Head.Next = Tail;
			Tail.Prev = Head;
			Size = 0;
		}
	}
}
