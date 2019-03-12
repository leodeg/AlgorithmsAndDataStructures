using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.DataStructures.Tree
{
	internal class PriorityQueue<T> : ICollection<T> where T : IComparable<T>
	{
		private const int CAPACITY = 16;
		private int m_Size;
		private T[] m_Data;
		private bool m_IsMinHeap;

		private PriorityQueue (bool minHeap = true)
		{
			m_Data = new T[CAPACITY];
			m_Size = 0;
			m_IsMinHeap = minHeap;
		}

		private PriorityQueue (T[] arr, bool minHeap = true)
		{
			m_Data = new T[arr.Length + 1];
			m_Size = arr.Length;
			m_IsMinHeap = minHeap;
			Array.Copy (arr, 1, m_Data, 1, arr.Length);

			for (int i = ( m_Size / 2 ); i > 0; i--)
			{

			}
		}

		public int Count => m_Size;

		public bool IsReadOnly => false;

		public bool IsEmpty => m_Size <= 0;

		private int Compare (int first, int second)
		{
			if (m_IsMinHeap)
			{
				return m_Data[first].CompareTo (m_Data[second]);
			}
			else
			{
				return m_Data[second].CompareTo (m_Data[first]);
			}
		}

		private void PullDown (int position)
		{
			int left = 2 * position;
			int right = left + 1;
			int small = -1;
			T temp;

			if (left <= m_Size)
			{
				small = left;
			}

			if (right <= m_Size && this.Compare (right, left) < 0)
			{
				small = right;
			}

			if (small != -1 && this.Compare (small, position) < 0)
			{
				temp = m_Data[position];
				m_Data[position] = m_Data[small];
				m_Data[small] = temp;

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
				temp = m_Data[position];
				m_Data[position] = m_Data[parent];
				m_Data[parent] = temp;

				LiftUp (parent);
			}
		}

		private void ExtendSize ()
		{
			T[] old = m_Data;
			m_Data = new T[m_Data.Length * 2];
			Array.Copy (old, 1, m_Data, 1, m_Size);
		}

		public virtual void Enqueue (T value)
		{
			if (m_Size == m_Data.Length - 1)
			{
				this.ExtendSize ();
			}

			m_Data[++m_Size] = value;
			LiftUp (m_Size);
		}

		public virtual T Dequeue ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			T value = m_Data[1];
			m_Data[1] = m_Data[m_Size];
			m_Size--;

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
			return m_Data[position];
		}

		public T GetValue (T value)
		{
			for (int i = 1; i <= m_Size; i++)
			{
				if (m_Data[i].Equals (value))
				{

					return m_Data[i];
				}
			}

			return default(T);
		}

		public void Print ()
		{
			for (int i = 1; i <= m_Size + 1; i++)
			{
				Console.Write ("[0]", m_Data[i]);
			}
		}

		public void Add (T item)
		{
			Enqueue (item);
		}

		public bool Remove (T item)
		{
			for (int i = 1; i <= m_Size; i++)
			{
				if (m_Data[i].Equals (item))
				{
					m_Data[i] = m_Data[m_Size];
					m_Size--;

					PullDown (i);
					LiftUp (i);

					return true;
				}
			}

			return false;
		}

		public void Clear ()
		{
			m_Size = 0;
		}

		public bool Contains (T item)
		{
			for (int i = 1; i <= m_Size; i++)
			{
				if (m_Data[i].Equals (item))
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

			for (int i = arrayIndex, j = 1; i < m_Data.Length; i++, j++)
			{
				array[i] = m_Data[j];
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
