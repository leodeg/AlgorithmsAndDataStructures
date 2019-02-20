using System;

namespace DataStructures.Queue
{
	public class Queue_LinkedList<T>
	{
		/* First node used as last element in queue. 
		 * Last node used as first element in queue. */

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
			Last = null;
		}

		/// <summary>
		/// First element of queue.
		/// </summary>
		private Node<T> Head { get; set; }

		/// <summary>
		/// Link to last element in queue. 
		/// </summary>
		private	Node<T> Last { get; set; }

		/// <summary>
		/// Total amount of elements in queue.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Insert element at the end of queue.
		/// </summary>
		public void Enqueue (T value)
		{
			// 1. Check value on null
			// 2. Create a new node
			// 3. If Head equal to null
			//		1. Assign the new node to Head
			//		2. Increment Count
			// 4. Else 
			//		2. Save Head
			//		3. Assign the new node to Head
			//		4. Increment Count

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

		/// <summary>
		/// Return and delete fronted element in queue.
		/// </summary>
		public T Dequeue ()
		{
			// 1. Check is Head equal to null
			// 2. If Head is one element in queue
			//		1. Save Head value
			//		2. Delete element
			//		3. Decrement count
			//		4. Return saved value
			// 3. Find last node and node before last node
			// 4. Save value of the last node
			// 5. Delete last node
			// 6. Decrement count
			// 7. Return saved value

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
			T value = last.Value;
			prevLast.Next = null;
			--Count;
			return value;
		}

		/// <summary>
		/// Delete all elements from queue.
		/// </summary>
		public void Clear ()
		{
			Head.Next = null;
			Head = null;
			Count = 0;
		}

		/// <summary>
		/// Return node before last node in queue.
		/// </summary>
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
