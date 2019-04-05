using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Strings
{
    public static class StringReverse
    {
        /// <summary>
        /// Reverse all characters of the source array.
        /// </summary>
        /// <param name="source">string reference</param>
        public static void Reverse (char[] source)
        {
            int start = 0;
            int end = source.Length - 1;
            char temp;

            while (start < end)
            {
                temp = source[start];
                source[start] = source[end];
                source[end] = temp;

                ++start;
                --end;
            }
        }

        /// <summary>
        /// Reverse all characters of the source array.
        /// </summary>
        /// <param name="source">string reference</param>
        /// <param name="start">start index of a reverse range</param>
        /// <param name="end">end index of a reverse range</param>
        public static void Reverse (char[] source, int start, int end)
        {
            char temp;

            while (start < end)
            {
                temp = source[start];
                source[start] = source[end];
                source[end] = temp;

                ++start;
                --end;
            }
        }

        /// <summary>
        /// Reverse order of words in a string sentence.
        /// </summary>
        /// <param name="source">reference to array of a characters</param>
        public static void ReverseWords (char[] source)
        {
            int lower = 0;
            int upper = -1;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == ' ' || source[i] == '\0')
                {
                    Reverse (source, lower, upper);
                    lower = i + 1;
                    upper = i;
                }
                else
                {
                    ++upper;
                }
            }
            Reverse (source, 0, source.Length - 1);
        }
    }
}
