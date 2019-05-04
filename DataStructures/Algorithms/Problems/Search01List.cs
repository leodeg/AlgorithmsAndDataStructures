using System;
using System.Collections.Generic;

namespace DA.Algorithms.Problems
{
    public static class Search01List
    {
        /// <summary>
        /// Find the index of the first 1 in given list of 0's and 1's in which all the 0's come before 1's.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException"/>
        /// 
        /// <returns>
        /// Return index of the first 1 in given list is so exists, otherwise return -1.
        /// </returns>
        public static int BinarySearch01 (int[] array)
        {
            if (array == null) throw new System.ArgumentNullException ();
            if (array.Length == 1 && array[0] == 1) return 0;
            if (array.Length == 1 && array[0] != 1) return -1;

            return BinarySearch01 (array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursively find the index of the first 1 in given list of 0's and 1's in which all the 0's come before 1's.
        /// </summary>
        private static int BinarySearch01 (int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int middle = (start + end) / 2;
            if (array[middle] == 1 && array[middle - 1] == 0)
            {
                return middle;
            }

            if (array[middle] == 0)
            {
                return BinarySearch01 (array, middle + 1, end);
            }
            else
            {
                return BinarySearch01 (array, start, middle - 1);
            }
        }
    }
}
