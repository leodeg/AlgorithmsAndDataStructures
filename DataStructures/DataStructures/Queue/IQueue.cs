using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
	internal interface IQueue<T>
	{
		void Enqueue (T data);
		T Dequeue ();
		T Peek ();

		bool IsEmpty { get; }
		int Size { get; }
	}
}
