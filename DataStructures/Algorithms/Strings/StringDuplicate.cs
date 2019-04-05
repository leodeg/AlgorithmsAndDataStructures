using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Strings
{
    public static class StringDuplicate
    {
        /// <summary>
        /// Get a new duplicate of the original array.
        /// </summary>
        /// 
        /// <param name="source">reference to original array</param>
        ///
        /// <returns>
        /// Return a new copy of the original characters array.
        /// </returns>
        public static char[] GetDuplicate (char[] source)
        {
            int index = 0;
            char[] duplicate = new char[source.Length];
            foreach (char item in source)
                duplicate[index++] = item;
            return duplicate;
        }
    }
}
