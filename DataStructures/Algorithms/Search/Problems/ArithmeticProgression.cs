using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Search.Problems
{
    public static class ArithmeticProgression
    {
        /// <summary>
        /// Find if array elements can form an Arithmetic progression.
        /// <para>Time Complexity - O(n.logn)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        public static bool IsArithmeticProgression (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            if (array.Length <= 1)
            {
                return true;
            }

            Array.Sort (array);
            int difference = array[1] - array[0];

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] - array[i - 1] != difference)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Find if array elements can form an Arithmetic progression.
        /// <para>Time Complexity - O(n.logn)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        public static bool IsArithmeticProgressionUsingHash (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            int first = int.MaxValue;
            int second = int.MaxValue;
            int value = 0;

            HashSet<int> hashSet = new HashSet<int> ();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < first)
                {
                    second = first;
                    first = array[i];
                }
                else if (array[i] < second)
                {
                    second = array[i];
                }
            }

            int difference = second - first;

            for (int i = 0; i < array.Length; i++)
            {
                // If value is duplicate return false
                if (hashSet.Contains (array[i]))
                {
                    return false;
                }

                hashSet.Add (array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
                value = first + i * difference;

                if (!hashSet.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
