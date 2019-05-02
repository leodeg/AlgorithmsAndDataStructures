namespace DA.Algorithms.Search
{
    public static class FindFixPoint
    {
        /// <summary>
        /// Find fix point in array. 
        /// Fix point is an index of array in which index and value is the same.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <returns>
        /// Return fix point value/index of the array
        /// </returns>
        public static int GetFixPoint (int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == i)
                    return i;
            return -1;
        }

        /// <summary>
        /// Find fix point in sorted array. 
        /// Fix point is an index of array in which index and value is the same.
        /// <para>Time Complexity - O(logn)</para>
        /// </summary>
        /// 
        /// <param name="array">Sorted array</param>
        /// 
        /// <returns>
        /// Return fix point value/index of the array
        /// </returns>
        public static int GetFixPointBinarySearch (int[] array, bool isSorted = false)
        {
            if (!isSorted)
            {
                System.Array.Sort (array);
            }

            int low = 0;
            int high = array.Length - 1;
            int middle;

            while (low <= high)
            {
                middle = (low + high) / 2;

                if (array[middle] == middle)
                    return middle;

                if (array[middle] < middle)
                    low = middle + 1;
                else high = middle - 1;
            }

            return -1;
        }
    }
}
