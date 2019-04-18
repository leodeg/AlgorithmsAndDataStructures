using System;
using System.Collections.Generic;

namespace DA.Algorithms
{
    public static class FindMissingNumber
    {
        /// <summary>
        /// Find missing number in the array.
        /// </summary>
        /// <param name="array">An array with integers, which are in the range of 1 to n.</param>
        /// <returns>
        /// Return a missed number.
        /// </returns>
        public static int Find (int[] array)
        {
            if (array[0] == 0)
            {
                throw new System.InvalidOperationException ("The array must be starting with value 1.");
            }

            int found = 0;

            for (int i = 1; i <= array.Length; i++)
            {
                found = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == i)
                    {
                        found = 1;
                        break;
                    }
                }
                if (found == 0)
                {
                    return i;
                }
            }

            return int.MaxValue;
        }
    }
}
