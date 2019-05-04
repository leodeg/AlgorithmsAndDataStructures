using System;

namespace DA.Algorithms.Problems
{
    public static class MinimumSumPair
    {
        /// <summary>
        /// Find a two elements such that their sum is closest to zero.
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentException" />
        /// <exception cref="System.ArgumentNullException" />
        public static int[] MinSumPair (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            if (array.Length < 2)
            {
                throw new System.ArgumentException ("Array must have at least two elements.");
            }

            int[] result = new int[2];
            int absSum = 0;
            int minSum = Math.Abs (array[0] + array[1]);
            int front = 0;
            int end = 0;

            for (front = 0; front < array.Length - 1; front++)
            {
                for (end = front + 1; end < array.Length; end++)
                {
                    absSum = Math.Abs (array[front] + array[end]);
                    if (absSum < minSum)
                    {
                        minSum = absSum;
                        result[0] = array[front];
                        result[1] = array[end];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Find a two elements such that their sum is closest to zero.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentException" />
        /// <exception cref="System.ArgumentNullException" />
        public static int[] MinSumPairUsingSorting (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            if (array.Length < 2)
            {
                throw new System.ArgumentException ("Array must have at least two elements.");
            }

            Array.Sort (array);
            int[] result = new int[2];
            int absSum = 0;
            int minSum = Math.Abs (array[0] + array[1]);
            int front = 0;
            int end = array.Length - 1;

            while (front < end)
            {
                absSum = Math.Abs (array[front] + array[end]);
                if (absSum < minSum)
                {
                    minSum = absSum;
                    result[0] = array[front];
                    result[1] = array[end];
                }

                if (absSum < 0) ++front;
                else if (absSum > 0) --end;
                else break;
            }
            return result;
        }
    }
}
