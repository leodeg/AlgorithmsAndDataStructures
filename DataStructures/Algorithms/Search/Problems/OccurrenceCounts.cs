using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class OccurrenceCounts
    {
        /// <summary>
        /// Find the number of occurrences of a key in sorted list.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <returns>
        /// Return count of occurrences of a key
        /// </returns>
        public static int FindInSortedList<T> (IEnumerable<T> list, T key)
        {
            if (list.Equals (null))
                throw new System.ArgumentNullException ();

            int count = 0;
            foreach (T item in list)
                if (item.Equals (key))
                    ++count;
            return count;
        }
    }
}
