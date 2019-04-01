using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.DataStructures.Hash;

namespace DA.Algorithms.HashProblem
{
	static class PrintFirstRepeatingNumber
	{
		public static void Print (int[] array)
		{
			int size = array.Length;

			CountMap<int> countMap = new CountMap<int> ();

			for (int i = 0; i < size; i++)
			{
				countMap.Add (array[i]);
			}

			for (int i = 0; i < size; i++)
			{
				countMap.Remove (array[i]);

				if (countMap.ContainsKey (array[i]) > 0)
				{
					Console.WriteLine ("First repeating number is: {0}", array[i]);
					return;
				}
			}
		}
	}
}
