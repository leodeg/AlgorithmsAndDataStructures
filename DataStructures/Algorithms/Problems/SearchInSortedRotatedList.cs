using System;
using System.Collections.Generic;

namespace DA.Algorithms.Problems
{
    public static class SearchInSortedRotatedList
    {
        /// <summary>
        /// Find an element in rotated array.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="array">Rotated sorted array</param>
        /// <param name="key">Value to find</param>
        /// 
        /// <returns>
        /// Return index of found value
        /// </returns>
        public static int Find (int[] array, int key)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            return Find (array, 0, array.Length - 1, key);
        }

        /// <summary>
        /// Recursively find an element in rotated array.
        /// </summary>
        /// 
        /// <param name="array">Rotated sorted array</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        /// <param name="key">Value to find</param>
        private static int Find (int[] array, int start, int end, int key)
        {
            if (end < start) return -1;

            int middle = (start + end) / 2;

            if (key == array[middle])
            {
                return middle;
            }

            if (array[middle] > array[start])
            {
                if (array[start] <= key && key < array[middle])
                {
                    return Find (array, start, middle - 1, key);
                }
                else
                {
                    return Find (array, middle + 1, end, key);
                }
            }
            else
            {
                if (array[middle] < key && key <= array[end])
                {
                    return Find (array, middle + 1, end, key);
                }
                else
                {
                    return Find (array, start, middle - 1, key);
                }
            }
        }
    }
}
