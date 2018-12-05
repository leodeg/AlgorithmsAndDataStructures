namespace DataStructures
{
	// -=-=-=-=-=-=-=- Notes -=-=-=-=-=-=-=-
	//
	// The most confusing part of the Linked List implementation was a fact 
	// that need to just delete a reference to the node, 
	// and then the Garbage Collector will destroy this node from the computer memory.
	//
	// -=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-

	public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
	{
		private LinkedListNode<T> first; // first node
		private LinkedListNode<T> last; // latest node

		public int Count { get; private set; }

		public void Add (T value)
		{
			// Create a new node
			LinkedListNode<T> node = new LinkedListNode<T> (value);

			// Find the last node
			if (first == null)
			{
				// Add first element
				first = node;
				last = node;
			}
			else
			{
				last.Next = node; // Add a new node to the list
				last = node; // Get a reference to the new added last element in the list
			}
			Count++; // change length value of the list
		}

		public bool Remove (T item)
		{
			LinkedListNode<T> previous = null;
			LinkedListNode<T> current = first;

			while (current != null)
			{
				// If element is found
				if (current.Value.Equals (item))
				{
					if (previous != null)
					{
						// Delete reference to the current node by change the references of the previous element to the next node after current.
						previous.Next = current.Next;

						// If we don't have anything in the list after current node then set the reference to the last element from the previous node
						if (current.Next == null)
						{
							last = previous; // get reference of the last element in the list
						}
					}
					else
					{
						// Delete the first element
						first = first.Next;

						// If a list had the one element then delete last reference to this element from the tail of the list
						if (first == null)
						{
							last = null; // clear the last reference to the item
						}
					}

					Count--; // change length value of the list
					return true;
				}

				previous = current; // get reference to the current element
				current = current.Next; // get reference to the next element
										// Move on >>>>>
			}
			return false;
		}

		public bool Contains (T item)
		{
			LinkedListNode<T> current = first; // Get a reference to the first element in the list

			while (current != null)
			{
				if (current.Value.Equals (item))
				{
					return true;
				}
				current = current.Next; // move on to a next node
			}
			return false;
		}

		/// <summary>
		/// Copy a list to an array by start from arrayIndex position.
		/// </summary>
		/// <param name="array">An array where the list will be added</param>
		/// <param name="arrayIndex">The start position where the list will be added</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			LinkedListNode<T> current = first;

			while (current != null)
			{
				array[arrayIndex++] = current.Value;
				current = current.Next;
			}
		}

		public System.Collections.Generic.IEnumerator<T> GetEnumerator ()
		{
			LinkedListNode<T> current = first;

			while (current != null)
			{
				yield return current.Value; // return current value
				current = current.Next; // move to a next node
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}

		public void Clear ()
		{
			first = null;
			last = null;
			Count = 0;
		}
	}
}
