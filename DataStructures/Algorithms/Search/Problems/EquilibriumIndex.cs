using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class EquilibriumIndex
    {
        /// <summary>
        /// Find balance point index. 
        /// An index is balanced if the elements in the left of it 
        /// and elements in the right of it have same sum.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="array"></param>
        public static int FindBalancedPoint (int[] array)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            if (array.Length == 1)
                return 0;

            int first = 0;
            int second = 0;

            for (int i = 0; i < array.Length; i++)
                second += array[i];

            for (int index = 0; index < array.Length; index++)
            {
                if (first == second)
                    return index;
                if (index < array.Length - 1)
                    first += array[index];
                second -= array[index + 1];
            }

            return -1;
        }
    }
}
