using System;

namespace DA.Algorithms.Sorting
{
    public static class SelectionSorting
    {
        /// <summary>
        /// The sorting of an array by finding the smallest element 
        /// of the collection and exchange it with front elements.
        /// </summary>
        /// 
        /// <typeparam name="T">type of an array</typeparam>
        /// <param name="array">reference to the array</param>
        public static void Sort<T> (T[] array) where T : IComparable<T>
        {
            int size = array.Length;

            for (int i = 0; i < size - 1; i++)
            {
                int minValueIndex = i;
                for (int current = i + 1; current < size; current++)
                {
                    if (array[current].CompareTo (array[minValueIndex]) < 0)
                    {
                        minValueIndex = current;
                    }
                }
                Swap (ref array[minValueIndex], ref array[i]);
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
