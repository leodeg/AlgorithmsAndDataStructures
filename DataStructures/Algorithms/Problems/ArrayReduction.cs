using System;

namespace DA.Algorithms.Problems
{
    public static class ArrayReduction
    {
        /// <summary>
        /// Given an array of positive elements.
        /// You need to perform reduction operation.In each reduction operation
        /// smallest positive element value is picked and all the elements are
        /// subtracted by that value. You need to print the number
        /// of elements left after each reduction process.
        /// </summary>
        /// Example:
        /// Input:
        /// [5, 1, 1, 1, 2, 3, 5]
        /// Output:
        /// 4 corresponds to [4, 1, 2, 4]
        /// 3 corresponds to [3, 1, 3]
        /// 2 corresponds to [2, 2]
        /// 0 corresponds to [0]
        public static void Reduction (int[] source)
        {
            Array.Sort (source);
            int count = 1;
            int reduction = source[0];

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] - reduction > 0)
                {
                    Console.WriteLine (source.Length - i);
                    reduction = source[i];
                    ++count;
                }
            }

            Console.WriteLine ("Total number of reductions: {0}", count);
        }
    }
}
