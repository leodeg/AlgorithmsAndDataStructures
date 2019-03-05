namespace DataStructures.Queue
{
	public class LinkedListQueue<T> : IQueue<T>
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

		public LinkedListQueue ()
		{
			Size = 0;
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// First element of queue.
		/// </summary>
		private Node<T> Head { get; set; }

		/// <summary>
		/// Link to last element in queue. 
		/// </summary>
		private	Node<T> Tail { get; set; }

		/// <summary>
		/// Total amount of elements in queue.
		/// </summary>
		public int Size { get; set; }

		/// <summary>
		/// Return true if queue is empty, otherwise return false.
		/// </summary>
		public bool IsEmpty { get { return Size == 0; } }

		/// <summary>
		/// Insert element at end.
		/// </summary>
		public void Enqueue (T value)
		{
			if (value.Equals (null)) throw new System.ArgumentNullException ();

			Node<T> node = new Node<T> (value);

			if (Head == null)
			{
				Head = Tail = node;
			}
			else
			{
				Tail.Next = node;
				Tail = node;
			}

			++Size;
		}

		/// <summary>
		/// Return and delete fronted element.
		/// </summary>
		public T Dequeue ()
		{
			if (IsEmpty)
			{
				throw new System.InvalidOperationException ("Queue: is empty");
			}

			T temp = Head.Value;
			Head = Head.Next;
			--Size;
			return temp;
		}

		/// <summary>
		/// Return fronted value.
		/// </summary>
		public T Peek ()
		{
			if (IsEmpty)
			{
				throw new System.InvalidOperationException ("Queue: is empty");
			}

			return Head.Value;
		}

		/// <summary>
		/// Delete all elements from queue.
		/// </summary>
		public void Clear ()
		{
			Head.Next = null;
			Head = null;
			Size = 0;
		}

		public void Print ()
		{
			Node<T> node = Head;
			while (node != null)
			{
				System.Console.Write (node.Value + " ");
				node = node.Next;
			}
		}
	}
}
