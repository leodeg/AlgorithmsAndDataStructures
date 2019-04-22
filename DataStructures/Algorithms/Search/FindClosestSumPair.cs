using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class FindClosestSumPair
    {
        /// <summary>
        /// Find a pair in array whose sum is closest to given value
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        /// 
        /// <param name="array">Collection with positive integers</param>
        /// <param name="value">Target value</param>
        /// 
        /// <returns>
        /// Return a collection with two numbers that can give closest sum to the value
        /// </returns>
        public static int[] ClosestPair (int[] array, int value)
        {
            int difference = int.MaxValue;
            int first = -1;
            int second = -1;
            int current;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    current = Math.Abs (value - (array[i] + array[j]));

                    if (current < difference)
                    {
                        difference = current;
                        first = array[i];
                        second = array[j];
                    }
                }
            }

            return new int[] { first, second };
        }

        /// <summary>
        /// Find a pair in array whose sum is closest to given value
        /// <para>Time Complexity - O(n.logn)</para>
        /// </summary>
        /// 
        /// <param name="array">Collection with positive integers</param>
        /// <param name="value">Target value</param>
        /// 
        /// <returns>
        /// Return a collection with two numbers that can give closest sum to the value
        /// </returns>
        public static void ClosestPairUsingSorting (int[] array, int value)
        {
            int first = 0;
            int second = 0;
            int start = 0;
            int stop = array.Length - 1;

            Array.Sort (array);

            int difference = int.MaxValue;
            int current = 0;

            while (start < stop)
            {
                current = (value - (array[start] + array[stop]));
                if (Math.Abs (current) < difference)
                {
                    difference = Math.Abs (current);
                    first = array[start];
                    second = array[stop];
                }

                if (current == 0) break;
                else if (current > 0) ++start;
                else --stop;
            }
        }
    }
}
