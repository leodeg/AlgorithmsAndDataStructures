using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Sorting
{
    public static class InsertionSorting
    {
        /// <summary>
        /// Insertion sort is a simple sorting algorithm that works the way we sort playing cards in our hands.
        /// <para> Time Complexity - O(n^2) </para>
        /// </summary>
        /// 
        /// <typeparam name="T">type of elements in an array</typeparam>
        /// <param name="array">collection with an elements</param>
        public static void Sort<T> (T[] array) where T : IComparable<T>
        {
            int j;
            T temp;
            for (int i = 0; i < array.Length; i++)
            {
                temp = array[i];
                for (j = i; j > 0; j--)
                {
                    if (array[j - 1].CompareTo (temp) > 0)
                    {
                        array[j] = array[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                array[j] = temp;
            }
        }
    }
}
