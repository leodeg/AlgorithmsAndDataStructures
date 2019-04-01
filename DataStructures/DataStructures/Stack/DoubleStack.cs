using System;
namespace DA.DataStructures.Stack
{
	internal class DoubleStack<T>
	{
		private const int MAX_SIZE = 50;
		private readonly int m_MaxSize;
		private int m_TopFirst;
		private int m_TopSecond;
		private T[] m_Data;

		public DoubleStack (int capacity)
		{
			m_MaxSize = capacity;
			m_TopFirst = -1;
			m_TopSecond = m_MaxSize;
			m_Data = new T[m_MaxSize];
		}

		public DoubleStack () : this (MAX_SIZE) { }

		public int SizeFirst { get { return m_TopFirst - 1; } }
		public int SizeSecond { get { return m_MaxSize - m_TopSecond; } }

		public void PushAtFirst (T data)
		{
			if (m_TopFirst >= m_TopSecond - 1)
			{
				throw new System.InvalidOperationException ("DoubleStack:: first stack is full");
			}

			m_Data[++m_TopFirst] = data;
		}

		public void PushAtSecond (T data)
		{
			if (m_TopFirst >= m_TopSecond - 1)
			{
				throw new System.InvalidOperationException ("DoubleStack:: second stack is full");
			}

			m_Data[--m_TopSecond] = data;
		}

		public T PopFromFirst ()
		{
			if (m_TopFirst < 0)
			{
				throw new System.InvalidOperationException ("DoubleStack:: first stack is empty");
			}

			return m_Data[m_TopFirst--];
		}

		public T PopFromSecond ()
		{
			if (m_TopSecond >= m_MaxSize)
			{
				throw new System.InvalidOperationException ("DoubleStack:: second stack is empty");
			}

			return m_Data[m_TopSecond++];
		}

		public T PeekAtFirst ()
		{
			if (m_TopFirst == -1)
			{
				throw new System.InvalidOperationException ("DoubleStack:: first stack is empty");
			}

			return m_Data[m_TopFirst];
		}

		public T PeekAtSecond ()
		{
			if (m_TopSecond >= m_MaxSize)
			{
				throw new System.InvalidOperationException ("DoubleStack:: second stack is empty");
			}

			return m_Data[m_TopSecond];
		}

		public void PrintFirst ()
		{
			for (int i = 0; i < m_TopSecond; i++)
			{
				Console.Write (m_Data[i] + " ");
			}
		}

		public void PrintSecond ()
		{
			for (int i = m_TopSecond; i > m_TopFirst; i--)
			{
				Console.Write (m_Data[i] + " ");
			}
		}
	}
}
