using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class FindSumOfPairEqualToRestArray
    {
        /// <summary>
        /// Find sum pair of numbers that equal to rest of the elements of the array.
        /// </summary>
        public static int[] Find (int[] array)
        {
            int total = 0;
            int current = 0;
            int low = 0;
            int high = array.Length - 1;

            Array.Sort (array);

            foreach (int number in array)
                total += number;
            int value = total / 2;

            while (low < high)
            {
                current = array[low] + array[high];
                if (current == value) return new int[] { array[low], array[high] };
                else if (current < value) ++low;
                else --high;
            }

            return null;
        }
    }
}
