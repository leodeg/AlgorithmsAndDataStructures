using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Search
{
    public static class BinarySearch
    {
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
        public static bool BinarySearching<T> (T[] array, T value) where T : IComparable<T>
        {
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
        public static bool BinarySearching<T> (T[] array, T value, int lowIndex, int highIndex) where T : IComparable<T>
        {
            if (lowIndex > highIndex) return false;
            int middle = lowIndex + (highIndex - lowIndex) / 2;

            if (array[middle].CompareTo (value) == 0)
            {
                return true;
            }
            else if (array[middle].CompareTo (value) < 0)
            {
                return BinarySearching (array, value, middle + 1, highIndex);
            }
            else
            {
                return BinarySearching (array, value, lowIndex, middle - 1);
            }
        }
    }
}
