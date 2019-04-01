using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DataStructures.Stack
{
	internal class ArrayStack<T>
	{
		private const int k_Capacity = 1000;
		private T[] m_Data;
		private int m_Top = -1;

		public ArrayStack (int capacity)
		{
			m_Data = new T[capacity];
		}

		public ArrayStack () : this (k_Capacity) { }

		public int Size { get { return m_Top + 1; } }
		public bool IsEmpty { get { return m_Top == -1; } }

		public void Push (T data)
		{
			if (this.Size == m_Data.Length)
			{
				throw new System.InvalidOperationException ("ArrayStack:: overflow exception");
			}

			m_Top++;
			m_Data[m_Top] = data;
		}

		public T Pop ()
		{
			T temp = m_Data[m_Top];
			m_Top--;
			return temp;
		}

		public T Peek ()
		{
			if (this.IsEmpty)
			{
				throw new System.InvalidOperationException ("ArrayStack:: stack is empty");
			}

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
	}
}
