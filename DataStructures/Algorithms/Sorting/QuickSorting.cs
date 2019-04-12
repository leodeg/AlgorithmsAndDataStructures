using System;
using System.Collections.Generic;

namespace DA.Algorithms.Sorting
{
    public static class QuickSorting
    {
        /// <summary>
        /// Quicksort is a recursive algorithm that each step selects a pivot 
        /// and then partition the array into the smallest parts.
        /// <para>Time Complexity - O(n log n)</para>
        /// </summary>
        /// <param name="array">a collection with an elements</param>
        public static void Sort<T> (T[] array) where T : IComparable<T>
        {
            QuickSort (array, 0, array.Length - 1);
        }

        /// <summary>
        /// Quicksort is a recursive algorithm that each step selects a pivot 
        /// and then partition the array into the smallest parts.
        /// <para>Time Complexity - O(n log n)</para>
        /// </summary>
        /// <typeparam name="T">type of an array</typeparam>
        /// <param name="array">a collection with an elements</param>
        private static void QuickSort<T> (T[] array, int lower, int upper) where T : IComparable<T>
        {
            if (upper <= lower) return;

            T pivot = array[lower];
            int startIndex = lower;
            int stopIndex = upper;

            while (lower < upper)
            {
                while (array[lower].CompareTo (pivot) <= 0 && lower < upper)
                {
                    ++lower;
                }

                while (array[upper].CompareTo (pivot) > 0 && lower <= upper)
                {
                    --upper;
                }

                if (lower < upper)
                {
                    Swap (array, lower, upper);
                }
            }

            Swap (array, upper, startIndex);
            QuickSort (array, startIndex, upper - 1);
            QuickSort (array, upper + 1, stopIndex);
        }

        /// <summary>
        /// Swap two elements of an array.
        /// </summary>
        private static void Swap<T> (T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
