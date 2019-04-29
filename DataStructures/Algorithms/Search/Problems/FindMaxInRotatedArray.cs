using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class FindMaxInRotatedArray
    {
        /// <summary>
        /// Find maximum value element in the array.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <param name="array">Sorted array.</param>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <returns>
        /// Return an index of the maximum value element in the array.
        /// </returns>
        public static int FindValue (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            return FindValue (array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursively find maximum value element in the array.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        private static int FindValue (int[] array, int start, int end)
        {
            if (end <= start)
            {
                return array[start];
            }

            int middle = (start + end) / 2;

            if (array[middle] > array[middle + 1])
            {
                return array[middle];
            }

            if (array[start] <= array[middle])
            {
                return FindValue (array, middle + 1, end);
            }
            else
            {
                return FindValue (array, start, middle - 1);
            }
        }

        /// <summary>
        /// Find maximum value index in the array.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <param name="array">Sorted array.</param>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <returns>
        /// Return an index of the maximum value element in the array.
        /// </returns>
        public static int FindIndex (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            return FindIndex (array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursively find maximum value index in the array.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        private static int FindIndex (int[] array, int start, int end)
        {
            if (end <= start)
            {
                return start;
            }

            int middle = (start + end) / 2;

            if (array[middle] > array[middle + 1])
            {
                return middle;
            }

            if (array[start] <= array[middle])
            {
                return FindIndex (array, middle + 1, end);
            }
            else
            {
                return FindIndex (array, start, middle - 1);
            }
        }
    }
}
