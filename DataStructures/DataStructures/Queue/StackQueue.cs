using System;
using System.Collections.Generic;

namespace DataStructures.Queue
{
	internal class StackQueue<T> : IQueue<T>
	{
		private Stack<T> m_Stack1;
		private Stack<T> m_Stack2;

		public StackQueue ()
		{
			m_Stack1 = new Stack<T> ();
			m_Stack2 = new Stack<T> ();
		}

		public bool IsEmpty => m_Stack1.Count == 0 && m_Stack2.Count == 0;
		public int Size => m_Stack1.Count + m_Stack2.Count;

		public T Dequeue ()
		{
			if (IsEmpty)
			{
				throw new System.InvalidOperationException ("Queue: is empty");
			}

			if (m_Stack2.Count != 0)
			{
				return m_Stack2.Pop ();
			}

			MoveElementsToSecondStack ();

			return m_Stack2.Pop ();
		}

		public void Enqueue (T data)
		{
			m_Stack1.Push (data);
		}

		public T Peek ()
		{
			if (IsEmpty)
			{
				throw new System.InvalidOperationException ("Queue: is empty");
			}

			if (m_Stack2.Count != 0)
			{
				return m_Stack2.Peek ();
			}

			MoveElementsToSecondStack ();

			return m_Stack2.Peek ();
		}

		private void MoveElementsToSecondStack ()
		{
			T temp;
			while (m_Stack1.Count != 0)
			{
				temp = m_Stack1.Pop ();
				m_Stack2.Push (temp);
			}
		}
	}
}
