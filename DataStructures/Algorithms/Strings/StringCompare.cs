using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Strings
{
    public static class StringCompare
    {
        /// <summary>
        /// Compare two strings. 
        /// </summary>
        /// 
        /// <param name="source">first string</param>
        /// <param name="other">second string</param>
        /// 
        /// <returns>
        /// <para> 0 - the both first and second strings are equal. </para>
        /// <para> negative value - the first string is less then the second. </para>
        /// <para> positive value - the first string is greater than the second. </para>
        /// </returns>
        public static int Compare (string source, string other)
        {
            int index = 0;
            int minLength = source.Length;

            if (source.Length > other.Length)
            {
                minLength = other.Length;
            }

            while (index < minLength && source[index] == other[index])
            {
                ++index;
            }

            if (index == source.Length && index == other.Length)
            {
                return 0;
            }
            else if (index == source.Length)
            {
                return -1;
            }
            else if (index == other.Length)
            {
                return 1;
            }
            else
            {
                return source[index] - other[index];
            }
        }
    }
}
