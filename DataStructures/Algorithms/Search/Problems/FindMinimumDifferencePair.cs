using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class FindMinimumDifferencePair
    {
        /// <summary>
        /// Find the element pair with minimum difference
        /// </summary>
        /// <param name="array">Collection with integers</param>
        /// <param name="value">Target value to find</param>
        /// <returns></returns>
        public static int[] FindUsingSorting (int[] array, int value)
        {
            int front = 0;
            int end = 0;
            int difference = int.MaxValue;

            Array.Sort (array);

            while (front < array.Length && end < array.Length)
            {
                difference = Math.Abs (array[front] - array[end]);

                if (difference == value) return new int[] { array[front], array[end] };
                else if (difference > value) ++front;
                else --end;
            }

            return null;
        }
    }
}
