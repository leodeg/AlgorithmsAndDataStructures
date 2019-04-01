using System;
using System.Collections.Generic;

namespace DA.Algorithms.HashProblem
{
	internal static class PrintRepeatingInteger
	{
		public static void Print (int[] array)
		{
			HashSet<int> hashSet = new HashSet<int> ();

			foreach (int item in array)
			{
				if (hashSet.Contains (item))
				{
					Console.WriteLine (" " + item);
				}
				else
				{
					hashSet.Add (item);
				}
			}
		}
	}
}
