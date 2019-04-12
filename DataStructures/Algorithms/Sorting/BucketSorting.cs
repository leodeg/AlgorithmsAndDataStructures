namespace DA.Algorithms.Sorting
{
    public static class BucketSorting
    {
        /// <summary>
        /// Bucket sort has a strict requirement of a predefined range of data.
        /// <para>Time Complexity - O(n+k). Where 'n' is number of elements and 'k' is the possible range.</para>
        /// </summary>
        /// <param name="array">A collection with an elements</param>
        /// <param name="lowerRange">Minimum value range of elements in the collection</param>
        /// <param name="upperRange">Maximum value range of elements in the collection</param>
        public static void Sort (int[] array, int lowerRange, int upperRange)
        {
            int range = upperRange - lowerRange;
            int[] count = new int[range];

            for (int i = 0; i < array.Length; i++)
                count[array[i] - lowerRange]++;

            int j = 0;
            for (int i = 0; i < range; i++)
                for (; count[i] > 0; count[i]--)
                    array[j++] = i + lowerRange;
        }
    }
}
