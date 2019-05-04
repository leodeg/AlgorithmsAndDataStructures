using System;

namespace DA.Algorithms.Problems
{
    public static class RemoveDuplicates
    {
        /// <summary>
        /// Return array with unique elements.
        /// <para>Time Complexity - O(n.logn)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <returns>
        /// Return array of the integers with unique elements.
        /// </returns>
        public static int[] Remove (int[] array)
        {
            if (array == null) throw new System.ArgumentNullException ();

            Array.Sort (array);
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array[j])
                {
                    j++;
                    array[j] = array[i];
                }
            }

            int[] result = new int[j + 1];
            Array.Copy (array, result, j + 1);
            return result;
        }
    }
}
