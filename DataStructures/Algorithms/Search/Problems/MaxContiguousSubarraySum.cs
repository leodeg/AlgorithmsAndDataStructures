using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class MaxContiguousSubarraySum
    {
        /// <summary>
        /// Find maximum contiguous subarray in the array.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="array">
        /// Collection with positive and negative integers values
        /// </param>
        public static int GetSumKadaneAlgorithm (int[] array)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            int currentMax = 0;
            int maximum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentMax = Math.Max (array[i], currentMax + array[i]);
                if (currentMax < 0)
                    currentMax = 0;
                if (maximum < currentMax)
                    maximum = currentMax;
            }

            return maximum;
        }

        /// <summary>
        /// Find maximum contiguous subarray in the first array. 
        /// Such it does not contains elements from the second array.
        /// <para>Time Complexity - O(m+n)</para>
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public static int MaxConSubArray (int[] first, int[] second)
        {
            if (first == null)
                throw new System.ArgumentNullException ("The first array is null!");
            if (second == null)
                throw new System.ArgumentNullException ("The second array is null!");

            int maximum = 0;

            HashSet<int> hashSet = new HashSet<int> ();
            for (int i = 0; i < second.Length; i++)
                hashSet.Add (second[i]);

            for (int i = 0; i < first.Length; i++)
            {
                if (hashSet.Contains (first[i]))
                    maximum = 0;
                else maximum = Math.Max (first[i], maximum + first[i]);
            }

            return (maximum < 0) ? 0 : maximum;
        }

        /// <summary>
        /// Find maximum contiguous subarray in the first array. 
        /// Such it does not contains elements from the second array.
        /// <para>Time Complexity - O(m.logm + n.logn) for sorting and then for search each element</para>
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public static int MaxConSubArrayUsingBinarySearch (int[] first, int[] second)
        {
            if (first == null)
                throw new System.ArgumentNullException ("The first array is null!");
            if (second == null)
                throw new System.ArgumentNullException ("The second array is null!");

            int currentMax = 0;
            int maximum = 0;

            Array.Sort (second);
            for (int i = 0; i < first.Length; i++)
            {
                if (BinarySearch.Search (second, first[i]))
                {
                    currentMax = 0;
                }
                else
                {
                    currentMax = Math.Max (currentMax, currentMax + first[i]);
                    if (currentMax < 0)
                        currentMax = 0;
                    if (maximum < currentMax)
                        maximum = currentMax;
                }
            }

            return maximum;
        }
    }
}
