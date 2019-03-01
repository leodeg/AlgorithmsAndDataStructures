using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures.Stack
{
	internal class DynamicArrayStack<T>
	{
		private const int k_MinCapacity = 1000;
		private T[] m_Data;
		private int m_Top = -1;
		private int m_MinCapacity;
		private int m_MaxCapacity;

		public DynamicArrayStack (int capacity)
		{
			m_Data = new T[capacity];
			m_MinCapacity = m_MaxCapacity = capacity;
		}

		public DynamicArrayStack () : this (k_MinCapacity) { }

		public int Size { get { return m_Top + 1; } }
		public bool IsEmpty { get { return m_Top == -1; } }

		#region Dynamic Array Stack Methods

		public void Push (T data)
		{
			if (this.Size == m_MaxCapacity)
			{
				ExpandStack ();
			}
		}

		public T Pop ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("DynamicArrayStack:: stack is empty");
			}

			T temp = m_Data[m_Top];
			m_Top--;

			if (this.Size == m_MaxCapacity / 2 && m_MaxCapacity > m_MinCapacity)
			{
				CompressStack ();
			}

			return temp;
		}

		public T Peek ()
		{
			return m_Data[m_Top];
		}

		public void Print ()
		{
			Console.Write ("[");
			for (int i = m_Top; i > -1; i--)
			{
				if (i > 0)
				{
					Console.Write (m_Data[i] + ", ");
				}
				else if (i == 0)
				{
					Console.Write (m_Data[i]);
				}
			}
			Console.Write ("]");
		}

		#endregion

		#region Helper Methods

		public void ExpandStack ()
		{
			T[] newData = new T[m_MaxCapacity * 2];
			Array.Copy (m_Data, 0, newData, 0, m_MaxCapacity);
			m_Data = newData;
			m_MaxCapacity *= 2;
		}

		public void CompressStack ()
		{
			m_MaxCapacity /= 2;
			T[] newData = new T[m_MaxCapacity];
			Array.Copy (m_Data, 0, newData, 0, m_MaxCapacity);
			m_Data = newData;
		}

		#endregion
	}
}
