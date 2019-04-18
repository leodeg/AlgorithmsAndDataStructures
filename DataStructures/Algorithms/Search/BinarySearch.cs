using System;

namespace DA.Algorithms.Search
{
    public static class BinarySearch
    {
        /// <summary>
        /// Find value in a sorted collection 
        /// and return true if a value exists, otherwise return false.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// 
        /// <typeparam name="T">base type of elements in an array</typeparam>
        /// <param name="array">collection of an elements.</param>
        /// <param name="value">target value to find</param>
        /// 
        /// <returns>
        /// true - if the value exists.
        /// false - if the value doesn't exist.
        /// </returns>
        public static bool Search<T> (T[] array, T value) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException ();
            }

            int low = 0;
            int high = array.Length - 1;
            int middle;

            while (low <= high)
            {
                middle = low + (high - low) / 2;

                if (array[middle].CompareTo (value) == 0)
                {
                    return true;
                }
                else if (array[middle].CompareTo (value) < 0)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }

            return false;
        }

        /// <summary>
        /// Recursively find value in a sorted collection 
        /// and return true if a value exists, otherwise return false.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// 
        /// <typeparam name="T">base type of elements in an array</typeparam>
        /// <param name="array">collection of an elements.</param>
        /// <param name="value">target value to find</param>
        /// 
        /// <returns>
        /// true - if the value exists.
        /// false - if the value doesn't exist.
        /// </returns>
        public static bool Search<T> (T[] array, T value, int lowIndex, int highIndex) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException ();
            }

            if (lowIndex > highIndex)
            {
                return false;
            }

            int middle = lowIndex + (highIndex - lowIndex) / 2;
            if (array[middle].CompareTo (value) == 0)
            {
                return true;
            }
            else if (array[middle].CompareTo (value) < 0)
            {
                return Search (array, value, middle + 1, highIndex);
            }
            else
            {
                return Search (array, value, lowIndex, middle - 1);
            }
        }
    }
}
