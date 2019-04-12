using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Sorting
{
    public static class QuickSelection
    {
        /// <summary>
        /// Find the element, which will be at the K-th position without actually sorting the whole collection.
        /// <para>Time Complexity - O(log n)</para>
        /// </summary>
        /// <typeparam name="T">Type of an array</typeparam>
        /// <param name="array">A collection with an elements</param>
        /// <param name="position">Index of the requested element.</param>
        public static T GetElement<T> (T[] array, int position) where T : IComparable<T>
        {
            QuickSelect (array, 0, array.Length - 1, position);
            return array[position];
        }

        /// <summary>
        /// Quick select is used to find the element, which will be at the K-th position without actually sorting the whole collection.
        /// <para>Time Complexity - O(log n)</para>
        /// </summary>
        /// <typeparam name="T">Type of an array</typeparam>
        /// <param name="array">A collection with an elements</param>
        /// <param name="k">Index of the requested element.</param>
        public static void QuickSelect<T> (T[] array, int lower, int upper, int k) where T : IComparable<T>
        {
            if (upper <= lower) return;

            T pivot = array[lower];
            int startIndex = lower;
            int stopIndex = upper;

            while (lower < upper)
            {
                while (array[lower].CompareTo(pivot) <= 0 && lower < upper)
                {
                    ++lower;
                }

                while (array[upper].CompareTo(pivot) > 0 && lower <= upper)
                {
                    --upper;
                }

                if (lower < upper)
                {
                    Swap (array, lower, upper);
                }

                Swap (array, upper, startIndex);

                if (k < upper)
                {
                    QuickSelect (array, startIndex, upper - 1, k);
                }

                if (k > upper)
                {
                    QuickSelect (array, upper + 1, stopIndex, k);
                }
            }
        }

        /// <summary>
        /// Swap two elements of an array.
        /// </summary>
        private static void Swap<T> (T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
