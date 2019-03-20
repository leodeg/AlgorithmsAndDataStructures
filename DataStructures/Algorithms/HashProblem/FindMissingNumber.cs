using System;
using System.Collections.Generic;

namespace DataStructures.Algorithms.HashProblem
{
	static class FindMissingNumber
	{
		public static int Find (int[] array, int startIndex, int endIndex)
		{
			HashSet<int> hashSet = new HashSet<int> ();

			foreach (int item in array)
			{
				hashSet.Add (item);
			}

			for (int current = startIndex; current <= endIndex; current++)
			{
				if (!hashSet.Contains(current))
				{
					return current;
				}
			}

			return int.MaxValue;
		}
	}
}
