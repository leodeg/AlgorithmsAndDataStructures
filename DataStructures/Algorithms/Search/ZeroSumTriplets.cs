using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Search
{
    public static class ZeroSumTriplets
    {
        /// <summary>
        /// Find a triplet whose sum is zero.
        /// <para>Time Complexity - O(n^3)</para>
        /// </summary>
        public static bool BruteForce (int[] array)
        {
            for (int i = 0; i < array.Length - 2; i++)
                for (int j = i + 1; j < array.Length - 1; j++)
                    for (int k = j + 1; k < array.Length; k++)
                        if (array[i] + array[j] + array[k] == 0)
                            return true;
            return false;
        }

        /// <summary>
        /// Find a triplet whose sum is zero.
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        public static bool UseSorting (int[] array)
        {
            int start, stop, currentSum;
            Array.Sort (array);

            for (int i = 0; i < array.Length - 2; i++)
            {
                start = i + 1;
                stop = array.Length - 1;

                while (start < stop)
                {
                    currentSum = array[i] + array[start] + array[stop];

                    if (currentSum == 0) return true;
                    else if (currentSum > 0) --stop;
                    else ++start;
                }
            }

            return false;
        }

        public static void SmallerThanValue (int[] array, int value)
        {
            int start, stop;
            int count = 0;

            Array.Sort (array);

            for (int i = 0; i < array.Length - 2; i++)
            {
                start = i + 1;
                stop = array.Length - 1;

                while (start < stop)
                {
                    if (array[i] + array[start] + array[stop] >= value)
                    {
                        --stop;
                    }
                    else
                    {
                        count += stop - start;
                        ++start;
                    }
                }
            }

            Console.WriteLine (count);
        }
    }
}
