using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms
{
	static class RemoveDuplicates
	{
		public static void ClearDuplicates<T>(T[] array)
		{
			int index = 0;
			HashSet<T> hashSet = new HashSet<T> ();

			foreach (T value in array)
			{
				if (!hashSet.Contains(value))
				{
					array[index++] = value;
					hashSet.Add (value);
				}
			}
		}
	}
}
