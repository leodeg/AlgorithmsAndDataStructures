using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
	internal class Queue_Array<T>
	{
		private T[] queue;

		public Queue_Array ()
		{
			Count = 0;
			LastIndex = 0;
			queue = new T[0];
		}

		#region Properties

		public int Count { get; private set; }
		public int LastIndex { get; private set; }

		#endregion

		#region Queue Methods

		public void Enqueue (T value)
		{
			++Count;
			T[] newQueue = new T[Count];

			newQueue[0] = value;
			for (int i = 1; i < queue.Length; i++)
			{
				newQueue[i] = queue[i];
				LastIndex = i;
			}

			queue = newQueue;
		}

		public T Dequeue ()
		{
			--Count;
			T temp = queue[LastIndex];
			T[] newQueue = new T[Count];

			for (int i = 0; i < queue.Length - 1; i++)
			{
				newQueue[i] = queue[i];
				LastIndex = i;
			}

			return temp;
		}

		public void Resize (int wantedSize)
		{
			T[] arr = new T[wantedSize];

			for (int i = 0; i < queue.Length; i++)
			{
				arr[i] = queue[i];
			}

			queue = arr;
		}

		public void Clear ()
		{
			queue = new T[0];
			Count = 0;
		}

		#endregion
	}
}
