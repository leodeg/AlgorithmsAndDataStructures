using System;

namespace DA.Algorithms.Search
{
    public static class FindAMedianOfAnArray
    {
        /// <summary>
        /// Time Complexity - O(n.logn)
        /// </summary>
        public static int GetMedian (int[] array)
        {
            Array.Sort (array);
            return array[array.Length / 2];
        }
    }
}
