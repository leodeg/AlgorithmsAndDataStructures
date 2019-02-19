using System;

namespace DataStructures.List
{
	internal class DoublyNode<T>
	{
		/// <summary>
		/// Contain value of the current node.
		/// </summary>
		public T Value { get; set; }

		/// <summary>
		/// Contain link to previous node.
		/// </summary>
		public DoublyNode<T> Prev { get; set; }

		/// <summary>
		/// Contain link to next node.
		/// </summary>
		public DoublyNode<T> Next { get; set; }

		public DoublyNode (T value)
		{
			Value = value;
			Prev = null;
			Next = null;
		}
	}

	internal class DoublyLinkedList<T>
	{
		/// <summary>
		/// Handle first element in list.
		/// </summary>
		private DoublyNode<T> Head { get; set; }

		/// <summary>
		/// Handle last element in list.
		/// </summary>
		private DoublyNode<T> Tail { get; set; }

		public DoublyLinkedList ()
		{
			Head = new DoublyNode<T> (default (T));
			Tail = new DoublyNode<T> (default (T));
			Head.Next = Tail;
			Tail.Prev = Head;
		}

		/// <summary>
		/// Total number of the elements in the list.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Return a first element in the list.
		/// </summary>
		public DoublyNode<T> FirstElement { get { return Head; } }

		/// <summary>
		/// Return a last element in the list.
		/// </summary>
		public DoublyNode<T> LastElement { get { return Tail; } }

		/// <summary>
		/// Allow to use list by using array syntax.
		/// </summary>
		public T this[int index]
		{
			get { return GetNode (index).Value; }
			set { GetNode (index).Value = value; }
		}

		#region Get Methods

		/// <summary>
		/// Return first element int the list.
		/// </summary>
		public DoublyNode<T> GetFirst ()
		{
			return FirstElement;
		}

		/// <summary>
		/// Return last element int the list.
		/// </summary>
		public DoublyNode<T> GetLast ()
		{
			return LastElement;
		}

		/// <summary>
		/// Return node, otherwise return null.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public DoublyNode<T> GetNode (int index)
		{
			if (index < 0 && index >= Count) throw new ArgumentOutOfRangeException ();
			if (Head.Next == null) return null;
			if (index == 0) return Head;
			if (index == Count - 1) return Tail;

			DoublyNode<T> current = Head;
			int count = 0;

			while (current != null && count < Count)
			{
				if (count == index)
				{
					return current;
				}
				current = current.Next;
			}

			return null;
		}

		/// <summary>
		/// Return a node if the node exist, otherwise return null.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public DoublyNode<T> GetNode (T value)
		{
			if (Head == null) return null;
			if (Head.Next == null) return null;
			if (value.Equals (Head.Value)) return Head;
			if (value.Equals (Tail.Value)) return Tail;

			DoublyNode<T> current = Head;

			while (current != null)
			{
				if (current.Value.Equals (value))
				{
					return current;
				}
				current = current.Next;
			}

			return null;
		}

		#endregion

		#region Insert Methods

		/// <summary>
		/// Insert element at front of the list.
		/// <para>Time Complexity = BigO(1)</para>
		/// </summary>
		public void AddFront (T value)
		{
			DoublyNode<T> node = new DoublyNode<T> (value);

			if (Head == null)
			{
				node.Next = Head.Next; // Save link to tail
				Head = node;
			}
			else
			{
				node.Next = Head.Next;
				node.Prev = Head.Prev;
				Head = node;
			}

			Count++;
		}

		/// <summary>
		/// Insert element at back of the list.
		/// <para>Time Complexity = BigO(1)</para>
		/// </summary>
		public void AddLast (T value)
		{
			DoublyNode<T> node = new DoublyNode<T> (value);

			if (Head == null)
			{
				node.Next = Head.Next; // Save link to tail
				Head = node;
			}
			else if (Tail == null)
			{
				node.Prev = Tail.Prev; // Save link to head
				Tail = node;
			}
			else
			{
				node.Prev = Tail;
				node.Next = null;
				Tail = node;
			}

			Count++;
		}

		/// <summary>
		/// Insert element after index position of the list.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public void AddAfter (T value, int index)
		{
			if (index < 0 && index >= Count)
			{
				throw new ArgumentOutOfRangeException ();
			}

			DoublyNode<T> node = new DoublyNode<T> (value);
			DoublyNode<T> temp = GetNode (index);
			node.Next = temp.Next;
			temp.Next = node;
			Count++;
		}

		/// <summary>
		/// Insert element before index position of the list.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public void AddBefore (T value, int index)
		{
			if (index >= 0 && index <= Count)
			{
				DoublyNode<T> node = new DoublyNode<T> (value);
				DoublyNode<T> temp = GetNode (index);
				node.Prev = temp.Prev;
				temp.Prev = node;
				Count++;
			}
			else
			{
				throw new ArgumentOutOfRangeException ();
			}
		}

		#endregion

		#region Remove Methods

		/// <summary>
		/// Remove first suitable element in the list that equal to value.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public bool Remove (T value)
		{
			DoublyNode<T> temp = GetNode (value);

			if (temp == null)
			{
				return false;
			}

			DoublyNode<T> previous = temp.Prev;
			previous = temp.Next;
			Count--;
			return true;
		}

		/// <summary>
		/// Remove element at the index position.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public bool Remove (int index)
		{
			if (index < 0 && index >= Count) throw new ArgumentOutOfRangeException ();

			DoublyNode<T> temp = GetNode (index);

			if (temp == null)
			{
				return false;
			}

			DoublyNode<T> previous = temp.Prev;
			previous = temp.Next;
			Count--;
			return true;
		}

		#endregion

		#region Helper Methods

		public void Reverse ()
		{
			// TODO: Make Reverse methods for the Doubly Linked List
			throw new System.NotImplementedException ();

		}

		/// <summary>
		/// Return true if item exist in the list, otherwise return false.
		/// <para>Time Complexity = BigO(n)</para>
		/// </summary>
		public bool Contains (T item)
		{
			if (Head.Value.Equals (item)) return true;
			if (Tail.Value.Equals (item)) return true;

			DoublyNode<T> current = GetNode (item);
			return current != null;
		}

		#endregion
	}
}
