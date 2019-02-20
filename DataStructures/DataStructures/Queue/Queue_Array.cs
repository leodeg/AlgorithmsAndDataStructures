using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
	public class Queue_Array<T> : IEnumerable<T>
	{
		private T[] queue;
		private int frontIndex;
		private int backIndex;
		private int size;

		public Queue_Array ()
		{
			frontIndex = 0;
			backIndex = 0;
			size = 4;
			queue = new T[size];
		}

		public Queue_Array (int size)
		{
			frontIndex = 0;
			backIndex = 0;
			this.size = size;
			queue = new T[size];
		}

		#region Properties

		/// <summary>
		/// Return size of the queue.
		/// </summary>
		public int Length => size;

		/// <summary>
		/// Return total amount of elements in the queue.
		/// </summary>
		public int Count => backIndex;

		#endregion

		#region Base Methods

		/// <summary>
		/// Insert data at back of queue.
		/// </summary>
		public void Enqueue (T data)
		{
			// 1. Check if back is equal to size of the queue
			// 2. If it's true then resize queue
			// 3. Else insert element to back of the queue
			// 4. Increment back index

			if (backIndex == size)
			{
				Resize ();
			}

			queue[backIndex] = data;
			backIndex++;
		}

		/// <summary>
		/// Return fronted element and delete it from queue.
		/// </summary>
		public T Dequeue ()
		{
			// 1. Check if front index is equal to back index
			// 2. If it's true throw new exception
			// 3. Else save first element and shift queue's elements at left
			// 4. Decrement back index.
			// 5. Return the saved first element.

			if (frontIndex == backIndex)
			{
				throw new ArgumentOutOfRangeException ();
			}

			T firstElement = queue[frontIndex];

			for (int i = 0; i < backIndex - 1; i++)
			{
				queue[i] = queue[i + 1];
			}

			if (backIndex < size)
			{
				queue[backIndex] = default (T);
			}

			backIndex--;
			return firstElement;
		}

		/// <summary>
		/// Return fronted element.
		/// </summary>
		/// <returns></returns>
		public T Peek ()
		{
			if (frontIndex == backIndex)
			{
				throw new ArgumentOutOfRangeException ();
			}
			return queue[frontIndex];
		}

		/// <summary>
		/// Delete all elements from queue.
		/// </summary>
		public void Clear ()
		{
			size = 4;
			backIndex = 0;
			frontIndex = 0;
			queue = new T[size];
		}

		#endregion

		#region Helper Methods

		/// <summary>	
		/// Resize array formula:
		/// size = (size == 0) ? 4 : size * 2
		/// </summary>
		public void Resize ()
		{
			// 1. Calculate a new size for the queue
			// 2. Create a new array
			// 3. Copy all elements from the queue in the new created array
			// 4. Assign the new array with copied elements to the queue

			int oldSize = size;
			size *= 2;

			T[] newQueue = new T[size];
			for (int i = 0; i < oldSize; i++)
			{
				newQueue[i] = queue[i];
			}
			queue = newQueue;
		}

		public void Print ()
		{
			if (frontIndex == backIndex)
			{
				throw new ArgumentOutOfRangeException ();
			}

			Console.WriteLine ("[");
			foreach (T item in queue)
			{
				Console.WriteLine (item + " ");
			}
			Console.WriteLine ("]");
		}

		public override string ToString ()
		{
			if (frontIndex == backIndex)
			{
				throw new ArgumentOutOfRangeException ();
			}

			StringBuilder queueString = new StringBuilder ();
			queueString.Append ("[");
			for (int i = 0; i < Length; i++)
			{
				queueString.Append (i);
				if (i < Length - 2)
				{
					queueString.Append (", ");
				}
			}
			queueString.Append ("]");
			return queueString.ToString();
		}

		#endregion

		#region Enumerators

		public IEnumerator<T> GetEnumerator ()
		{
			return queue.Take(Length).GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return queue.Take(Length).GetEnumerator ();
		}

		#endregion
	}
}
