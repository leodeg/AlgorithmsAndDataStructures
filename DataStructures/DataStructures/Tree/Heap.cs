using System;
namespace DataStructures.Tree
{
	internal class Heap
	{
		private const int CAPACITY = 16;
		private int m_Size;
		private int[] m_Data;

		public Heap ()
		{
			m_Data = new int[CAPACITY];
			m_Size = 0;
		}

		public Heap (int[] arr)
		{
			m_Size = arr.Length;
			m_Data = new int[arr.Length + 1];
			System.Array.Copy (arr, 0, m_Data, 1, arr.Length);

			for (int i = ( m_Size / 2 ); i > 0; i--)
			{
				PullDown (i);
			}
		}

		public virtual void Add (int value)
		{
			if (m_Size == m_Data.Length)
			{
				ExtendHeapSize ();
			}

			m_Data[++m_Size] = value;
			LiftUp (m_Size);
		}

		public virtual int Delete ()
		{
			if (IsEmpty())
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			int value = m_Data[1];
			m_Data[1] = m_Data[m_Size];
			m_Size--;

			PullDown (1);
			return value;
		}

		private void PullDown (int position)
		{
			int left = 2 * position;
			int right = left + 1;
			int small = -1;
			int temp;

			if (left <= m_Size)
			{
				small = left;
			}

			if (right <= m_Size && ( m_Data[right] - m_Data[left] < 0 ))
			{
				small = right;
			}

			if (small != -1 && ( m_Data[small] - m_Data[position] < 0 ))
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
			int temp;

			if (parent == 0)
			{
				return;
			}

			if ((m_Data[parent] - m_Data[position]) > 0)
			{
				temp = m_Data[position];
				m_Data[position] = m_Data[parent];
				m_Data[parent] = temp;

				LiftUp (parent);
			}
		}

		public static void HeapSort (int[] arr)
		{
			Heap heap = new Heap (arr);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = heap.Delete ();
			}
		}

		private void ExtendHeapSize ()
		{
			int[] old = m_Data;
			m_Data = new int[m_Data.Length * 2];
			Array.Copy (old, 1, m_Data, 1, m_Size);
		}

		public virtual void Print ()
		{
			for (int i = 0; i <= m_Size; i++)
			{
				System.Console.WriteLine ("value is: {0}", m_Data[i]);
			}
		}

		public virtual bool IsEmpty ()
		{
			return m_Size <= 0;
		}

		public virtual int Peek ()
		{
			if (IsEmpty())
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			return m_Data[1];
		}
	}
}
