using System;

namespace DataStructures.Queue
{
	public class Queue_DoublyLinkedList<T>
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

		public Queue_DoublyLinkedList ()
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
		public int Count { get; private set; }

		/// <summary>
		/// Insert element at end of queue.
		/// </summary>
		public void Enqueue (T data)
		{
			// 1. Create a new node
			// 2. If head == null
			//		1. Save link to the tail
			//		2. Assign the new node to Head
			//		3. Increment count
			// 3. Else
			//		1. Save Head
			//		2. Assign the new node to Head
			//		3. Increment count

			Node<T> node = new Node<T> (data);

			if (Head == null)
			{
				node.Next = Head.Next;
				Head = node;
				++Count;
				return;
			}

			node.Next = Head;
			Head = node;
			++Count;
		}

		/// <summary>
		/// Return and delete fronted element.
		/// </summary>
		public T Dequeue ()
		{
			// 1. Save last element to temp variable
			// 2. Save previous element before last element
			// 3. Delete last element
			// 4. Decrement count
			// 5. Return saved last element

			Node<T> temp = Tail;
			Node<T> prev = Tail.Prev;

			prev.Next = null;
			--Count;
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
			Count = 0;
		}
	}
}
