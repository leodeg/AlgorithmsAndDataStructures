using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.DataStructures.Tree
{
	internal class PriorityQueue<T> : ICollection<T> where T : IComparable<T>
	{
		private const int Capacity = 16;
		private int size;
		private T[] data;
		private bool isMinHeap;

		public PriorityQueue (bool minHeap = true)
		{
			data = new T[Capacity];
			size = 0;
			isMinHeap = minHeap;
		}

		public PriorityQueue (T[] arr, bool minHeap = true)
		{
			data = new T[arr.Length + 1];
			size = arr.Length;
			isMinHeap = minHeap;
			Array.Copy (arr, 1, data, 1, arr.Length);

			for (int i = ( size / 2 ); i > 0; i--)
			{

			}
		}

		public int Count => size;

		public bool IsReadOnly => false;

		public bool IsEmpty => size <= 0;

		private int Compare (int first, int second)
		{
			if (isMinHeap)
			{
				return data[first].CompareTo (data[second]);
			}
			else
			{
				return data[second].CompareTo (data[first]);
			}
		}

		private void PullDown (int position)
		{
			int left = 2 * position;
			int right = left + 1;
			int small = -1;
			T temp;

			if (left <= size)
			{
				small = left;
			}

			if (right <= size && this.Compare (right, left) < 0)
			{
				small = right;
			}

			if (small != -1 && this.Compare (small, position) < 0)
			{
				temp = data[position];
				data[position] = data[small];
				data[small] = temp;

				PullDown (small);
			}
		}

		private void LiftUp (int position)
		{
			int parent = position / 2;
			T temp;

			if (parent == 0) return;

			if (this.Compare (parent, position) > 0)
			{
				temp = data[position];
				data[position] = data[parent];
				data[parent] = temp;

				LiftUp (parent);
			}
		}

		private void ExtendSize ()
		{
			T[] old = data;
			data = new T[data.Length * 2];
			Array.Copy (old, 1, data, 1, size);
		}

		public virtual void Enqueue (T value)
		{
			if (size == data.Length - 1)
			{
				this.ExtendSize ();
			}

			data[++size] = value;
			LiftUp (size);
		}

		public virtual T Dequeue ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			T value = data[1];
			data[1] = data[size];
			size--;

			PullDown (1);
			return value;
		}

		public static void Sort (T[] arr)
		{
			PriorityQueue<T> heap = new PriorityQueue<T> (arr);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = heap.Dequeue ();
			}
		}

		public T GetValueAt (int position)
		{
			return data[position];
		}

		public T GetValue (T value)
		{
			for (int i = 1; i <= size; i++)
			{
				if (data[i].Equals (value))
				{

					return data[i];
				}
			}

			return default(T);
		}

		public T Peek ()
		{
			return data[0];
		}

		public void Print ()
		{
			for (int i = 1; i <= size + 1; i++)
			{
				Console.Write ("[0]", data[i]);
			}
		}

		public void Add (T item)
		{
			Enqueue (item);
		}

		public bool Remove (T item)
		{
			for (int i = 1; i <= size; i++)
			{
				if (data[i].Equals (item))
				{
					data[i] = data[size];
					size--;

					PullDown (i);
					LiftUp (i);

					return true;
				}
			}

			return false;
		}

		public void Clear ()
		{
			size = 0;
		}

		public bool Contains (T item)
		{
			for (int i = 1; i <= size; i++)
			{
				if (data[i].Equals (item))
				{
					return true;
				}
			}

			return false;
		}

		public IEnumerator<T> GetEnumerator ()
		{
			return new PriorityQueueEnumerator<T> (this);
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		public void CopyTo (T[] array, int arrayIndex)
		{
			if (array.Equals(null))
			{
				throw new System.ArgumentNullException ();
			}

			if (arrayIndex < 1)
			{
				throw new System.ArgumentOutOfRangeException ();
			}

			for (int i = arrayIndex, j = 1; i < data.Length; i++, j++)
			{
				array[i] = data[j];
			}
		}

		internal class PriorityQueueEnumerator<T> : IEnumerator<T> where T : IComparable<T>
		{
			private PriorityQueue<T> m_Queue;
			private int m_Index;
			private T m_Current;

			public PriorityQueueEnumerator (PriorityQueue<T> queue)
			{
				m_Queue = queue;
				m_Current = default (T);
				m_Index = 1;
			}

			public T Current { get { return m_Current; } }

			object IEnumerator.Current { get { return this.Current; } }

			public void Dispose ()
			{
				m_Queue = null;
				m_Current = default (T);
				m_Index = 1;
			}

			public bool MoveNext ()
			{
				if (m_Index <= m_Queue.Count)
				{
					m_Current = m_Queue.GetValueAt (m_Index);
					m_Index++;
					return true;
				}
				return false;
			}

			public void Reset ()
			{
				m_Current = default (T);
				m_Index = 1;
			}
		}
	}
}
