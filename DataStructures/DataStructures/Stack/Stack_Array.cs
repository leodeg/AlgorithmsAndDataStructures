using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
	class Stack_Array <T>
	{
		private T[] stack;

		public Stack_Array ()
		{
			Clear ();
		}

		public int Count { get; set; }

		public void Push (T value)
		{
			++Count;
			T[] arr = new T[Count];

			arr[0] = value;
			for (int i = 1; i < Count; i++)
			{
				arr[i] = stack[i];
			}
		}

		public T Pop ()
		{
			T temp = stack[Count - 1];
			--Count;
			T[] arr = new T[Count];

			for (int i = 0; i < Count; i++)
			{
				arr[i] = stack[i];
			}

			return temp;
		}

		public T Peek ()
		{
			return stack[Count - 1];
		}

		public void Clear ()
		{
			stack = new T[0];
			Count = 0;
		}
	}
}
