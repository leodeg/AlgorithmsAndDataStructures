using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Problems
{
    public static class PrintRepeating
    {
        /// <summary>
        /// Print duplicates in array. Time Complexity is O(n^2)
        /// </summary>
        /// <param name="array">collection of integer elements</param>
        public static void BruteForce (int[] array)
        {
            Console.WriteLine ("Repeating elements are: [");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        Console.Write (array[i] + " ");
                }
            }
            Console.Write ("]");
        }

        /// <summary>
        /// Print duplicates in array. Time Complexity is O(n.logn)
        /// </summary>
        /// <param name="array">collection of integer elements</param>
        public static void UsingSorting (int[] array)
        {
            Array.Sort (array);

            Console.WriteLine ("Repeating elements are: [");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                    Console.Write (array[i] + " ");
            }
            Console.Write ("]");
        }

        /// <summary>
        /// Print duplicates in array. Time Complexity is O(n)
        /// </summary>
        /// <param name="array">collection of integer elements</param>
        public static void UsingHashTable (int[] array)
        {
            HashSet<int> hashSet = new HashSet<int> ();

            Console.WriteLine ("Repeating elements are: [");
            for (int i = 0; i < array.Length; i++)
            {
                if (hashSet.Contains (array[i]))
                {
                    Console.Write (array[i] + " ");
                }
                else
                {
                    hashSet.Add (array[i]);
                }
            }
            Console.Write ("]");
        }
    }
}
