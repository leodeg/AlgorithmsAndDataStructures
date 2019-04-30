using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class ShuffleList
    {
        /// <summary>
        /// An array [a1, a2, a3, a4, b1, b2, b3, b4] 
        /// to convert into [a1, b1, a2, b2, a3, b3, a4, b4]
        /// </summary>
        /// <param name="array"></param>
        public static void ShuffleArray (char[] array)
        {
            int halfLength = array.Length / 2;
            for (int i = 1; i < halfLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int index = halfLength - i + 2 * j;
                    Swap (ref array[index], ref array[index + 1]);
                }
            }
        }

        /// <summary>
        /// Swap two elements.
        /// </summary>
        public static void Swap<T> (ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
