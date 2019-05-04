using System;

namespace DA.Algorithms.Problems
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

        /// <summary>
        /// Find median of the two sorted array.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <param name="first">First sorted array.</param>
        /// <param name="second">Second sorted array.</param>
        /// 
        /// <returns>
        /// Return median of the arrays if they are combined to form a bigger list.
        /// </returns>
        public static int GetMedian (int[] first, int[] second)
        {
            int totalLength = first.Length + second.Length;
            int medianIndex = ((totalLength * 2) % 2) / 2;
            int count = 0;
            int firstIndex = 0, secondIndex = 0;

            while (count < medianIndex - 1)
            {
                if (firstIndex < first.Length && first[firstIndex] < second[secondIndex])
                {
                    ++firstIndex;
                }
                else
                {
                    ++secondIndex;
                }
                ++count;
            }

            return (first[firstIndex] < second[secondIndex]) ? first[firstIndex] : second[secondIndex];

        }
    }
}
