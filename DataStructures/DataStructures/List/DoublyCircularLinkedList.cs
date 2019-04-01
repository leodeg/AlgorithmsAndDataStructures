using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.List
{
	public class DoublyCircularLinkedList<T>
	{
		public class Node<T>
		{
			public Node<T> Next { get; set; }
			public Node<T> Prev { get; set; }
			public T Value { get; set; }

			public Node (T value)
			{
				Next = null;
				Prev = null;
				Value = value;
			}
		}

		public DoublyCircularLinkedList ()
		{
			Head = null;
			Tail = null;

			Head.Next = Tail;
			Head.Prev = Tail;

			Tail.Next = Head;
			Tail.Prev = Head;

			Count = 0;
		}

		#region Properties

		private Node<T> Head { get; set; }
		private Node<T> Tail { get; set; }
		public int Count { get; private set; } = 0;

		public Node<T> First { get { return Head; } }
		public Node<T> Last { get { return Tail; } }

		#endregion

		#region Add Methods

		public void AddFront (T value)
		{
			Node<T> node = new Node<T> (value);

			if (Head == null)
			{
				node.Prev = Head.Prev;
				node.Next = Head.Next;
				Head = node;
				++Count;
				return;
			}

			node.Prev = Head.Prev;
			Head.Prev = node;
			node.Next = Head;
			Head = node;
			++Count;
		}

		public void AddBack (T value)
		{
			Node<T> node = new Node<T> (value);
			node.Prev = Tail;
			node.Next = Tail.Next;
			Tail.Next = node;
			Tail = node;
			++Count;
		}

		#endregion

		#region Remove Methods

		public void RemoveFront ()
		{
			if (Head == null) throw new ArgumentNullException ();

			Node<T> nextTemp = Head.Next;
			nextTemp.Prev = Head.Prev;
			Head = nextTemp;
			Tail.Next = Head;
			--Count;
		}

		public void RemoveBack ()
		{
			if (Tail == null) throw new ArgumentNullException ();

			Node<T> prevTemp = Tail.Prev;
			prevTemp.Next = Tail.Next;
			Tail = prevTemp;
			Head.Prev = Tail;
			--Count;
		}

		public void RemoveAt (int index)
		{
			if (index < 0 || index > Count) throw new ArgumentOutOfRangeException ();

			if (index == 0)
			{
				RemoveFront ();
				return;
			}
			else if (index == Count - 1)
			{
				RemoveBack ();
				return;
			}

			Node<T> current = GetNode (index);
			Node<T> prev = current.Prev;
			Node<T> next = current.Next;

			prev.Next = current.Next;
			next.Prev = current.Prev;
			--Count;
		}

		#endregion

		#region Helper Methods

		public Node<T> GetNode (int index)
		{
			if (index < 0 || index > Count) throw new ArgumentOutOfRangeException ();
			if (index == 0) return Head;
			if (index == Count - 1) return Tail;

			Node<T> current = Head;

			for (int i = 0; i < index - 1; i++)
			{
				current = current.Next;
			}

			return current;
		}

		public bool GetNode (T value, out T temp)
		{
			if (value.Equals (null)) throw new ArgumentNullException ();

			if (Head.Value.Equals(value))
			{
				temp = Head.Value;
				return true;
			}
			else if (Tail.Value.Equals(value))
			{
				temp = Tail.Value;
				return true;
			}

			Node<T> current = Head;

			for (int i = 0; i < Count - 1; i++)
			{
				if (current.Value.Equals (value))
				{
					temp = current.Value;
					return true;
				}
				current = current.Next;
			}

			temp = default (T);
			return false;
		}

		#endregion
	}
}
