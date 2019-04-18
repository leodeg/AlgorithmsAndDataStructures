using System;

namespace DA.Algorithms.Search
{
    public static class LinearSearch
    {
        /// <summary>
        /// Find value in an unsorted collection 
        /// and return true if the value exists, otherwise return false.
        /// <para>Time Complexity - O(n). No extra memory is used to allocate the array.</para>
        /// </summary>
        /// 
        /// <typeparam name="T">base type of elements in an array</typeparam>
        /// <param name="array">collection of an elements.</param>
        /// <param name="value">target value to find</param>
        /// 
        /// <returns>
        /// true - if the value exists.
        /// false - if the value doesn't exist.
        /// </returns>
        public static bool SearchUnsortedInput<T> (T[] array, T value) where T : IEquatable<T>
        {
            for (int current = 0; current < array.Length; current++)
            {
                if (value.Equals (array[current]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find value in a sorted collection 
        /// and return true if the value exists, otherwise return false.
        /// <para>Time Complexity - O(n). No extra memory is used to allocate the array.</para>
        /// </summary>
        /// 
        /// <typeparam name="T">base type of elements in an array</typeparam>
        /// <param name="array">collection of an elements.</param>
        /// <param name="value">target value to find</param>
        /// 
        /// <returns>
        /// true - if the value exists.
        /// false - if the value doesn't exist.
        /// </returns>
        public static bool SearchSortedInput<T> (T[] array, T value) where T : IComparable<T>
        {
            for (int current = 0; current < array.Length; current++)
            {
                if (value.CompareTo (array[current]) == 0)
                {
                    return true;
                }
                else if (value.CompareTo (array[current]) < 0)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
