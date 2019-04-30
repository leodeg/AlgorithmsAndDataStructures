using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class ListPermutation
    {
        /// <summary>
        /// Check whether the two arrays are permutation of each other.
        /// </summary>
        public static bool CheckPermutation<T> (T[] first, T[] second) where T : IComparable<T>
        {
            if (first == null && second == null) return true;
            if (first.Length != second.Length) return false;

            Array.Sort (first);
            Array.Sort (second);

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i].CompareTo (second[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
