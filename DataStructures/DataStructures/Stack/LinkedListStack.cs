using System;
namespace DA.Stack
{
	public class LinkedListStack<T>
	{
		private class Node<T>
		{
			public Node<T> Next { get; set; }
			public T Value { get; set; }

			public Node (T value, Node<T> next)
			{
				Value = value;
				Next = next;
			}

			public Node (T value)
			{
				Value = value;
				Next = null;
			}

			public Node () : this (default (T)) { }
		}

		private Node<T> Top { get; set; }

		public LinkedListStack ()
		{
			Top = new Node<T> ();
			Count = 0;
		}

		/// <summary>
		/// Total number of elements in stack.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Return true if stack is empty. Otherwise return false.
		/// </summary>
		public bool IsEmpty { get { return Count == 0; } }

		/// <summary>
		/// Insert element at the top of stack.
		/// </summary>
		public void Push (T value)
		{
			Top = new Node<T> (value, Top);
			Count++;
		}

		/// <summary>
		/// Return top and delete top element in the stack.
		/// </summary>
		public T Pop ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("LinkedListStack:: stack is empty");
			}

			T temp = Top.Value;
			Top = Top.Next;
			Count--;
			return temp;
		}

		/// <summary>
		/// Just return top element of the stack.
		/// </summary>
		public T Peek ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("LinkedListStack:: stack is empty");
			}

			return Top.Value;
		}

		public void Print ()
		{
			Node<T> head = Top;

			Console.Write ("[");
			while (head != null)
			{
				Console.Write (head.Value + " ");
			}
			Console.Write ("]");
		}

		/// <summary>
		/// Delete all elements from the stack.
		/// </summary>
		public void Clear ()
		{
			Top.Next = null;
			Top = null;
			Count = 0;
		}
	}
}
