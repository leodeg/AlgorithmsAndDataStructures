using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Search
{
    public static class DuplicateKDistance
    {
        /// <summary>
        /// Find if duplicate values exist in the range.
        /// </summary>
        /// <returns></returns>
        public static bool FindDuplicate (int[] array, int range)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            Dictionary<int, int> dictionary = new Dictionary<int, int> ();

            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey (array[i]) 
                    && i - dictionary[array[i]] <= range)
                {
                    return true;
                }
                else
                {
                    dictionary[array[i]] = i;
                }
            }

            return false;
        }
    }
}
