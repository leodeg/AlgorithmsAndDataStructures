using System;
using System.Collections.Generic;
using System.Linq;

namespace DA.Algorithms.Sorting
{
    public static class SelectionSort
    {
        /// <summary>
        /// The sorting of an array by finding the smallest element 
        /// of the collection and exchange it with front elements.
        /// </summary>
        /// <typeparam name="T">type of an array</typeparam>
        /// <param name="array">reference to the array</param>
        public static void SelectionSorting<T> (T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                int minValueIndex = i;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo (array[minValueIndex]) < 0)
                    {
                        minValueIndex = j;
                    }
                }
                Swap (ref array[i], ref array[minValueIndex]);
            }
        }

        public static void Swap<T> (ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
