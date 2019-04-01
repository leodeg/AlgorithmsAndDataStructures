using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Queue
{
	internal class ArrayQueue<T> : IQueue<T>
	{
		private int m_Count = 0;
		private int m_Capacity = 100;
		private T[] m_Data;
		private int m_FrontIndex = 0;
		private int m_BackIndex = 0;

		public ArrayQueue ()
		{
			m_Count = 0;
			m_Data = new T[m_Capacity];
		}

		public ArrayQueue (int capacity)
		{
			m_Capacity = capacity;
			m_Data = new T[m_Capacity];
			m_Count = 0;
		}

		public bool IsEmpty => m_Count == 0;
		public int Size => m_Count;

		public void Enqueue (T data)
		{
			if (m_Count >= m_Capacity)
			{
				throw new System.InvalidOperationException ("Queue: is full");
			}

			m_Count++;
			m_Data[m_BackIndex] = data;
			m_BackIndex = ( ++m_BackIndex ) % ( m_Capacity - 1 );
		}

		public T Dequeue ()
		{
			if (m_Count <= 0)
			{
				throw new System.InvalidOperationException ("Queue: is empty");
			}

			m_Count--;
			T temp = m_Data[m_FrontIndex];
			m_FrontIndex = ( ++m_FrontIndex ) % ( m_Capacity - 1 );
			return temp;
		}

		public T Peek ()
		{
			return m_Data[m_FrontIndex];
		}
	}
}
