using System;

namespace DataStructures.Queue
{
	public class Queue_DoublyLinkedList<T>
	{
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

		private Node<T> Head { get; set; }
		private Node<T> Tail { get; set; }
		public int Count { get; private set; }

		public void Enqueue (T value)
		{
			Node<T> node = new Node<T> (value);

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

		public T Dequeue ()
		{
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
