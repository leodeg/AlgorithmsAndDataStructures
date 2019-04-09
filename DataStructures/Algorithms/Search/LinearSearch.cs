using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Search
{
    public static class LinearSearch
    {
        /// <summary>
        /// Find value in an unsorted collection and return true if a value exists, otherwise return false.
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
        public static bool SearchInUnsorted<T> (T[] array, T value) where T : IEquatable<T>
        {
            for (int i = 0; i < array.Length; i++)
                if (value.Equals (array[i]))
                    return true;
            return false;
        }

        /// <summary>
        /// Find value in a sorted collection and return true if a value exists, otherwise return false.
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
        public static bool SearchInSorted<T> (T[] array, T value) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (value.CompareTo (array[i]) == 0)
                {
                    return true;
                }
                else if (value.CompareTo (array[i]) < 0)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
