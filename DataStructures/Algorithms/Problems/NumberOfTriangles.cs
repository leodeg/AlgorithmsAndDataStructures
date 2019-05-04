namespace DA.Algorithms.Problems
{
    public static class NumberOfTriangles
    {
        /// <summary>
        /// Find the number of triangles that can be formed from 
        /// elements of the array representing sides of triangles.
        /// <para>Time Complexity - O(n^3)</para>
        /// </summary>
        public static int GetNumberOfTriangles (int[] array)
        {
            int count = 0;

            for (int i = 0; i < array.Length - 2; i++)
                for (int j = i + 1; j < array.Length - 1; j++)
                    for (int k = j + 1; k < array.Length; k++)
                        if (array[i] + array[j] > array[k])
                            ++count;

            return count;
        }

        /// <summary>
        /// Find the number of triangles that can be formed from 
        /// elements of the array representing sides of triangles.
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        public static int GetNumberOfTrianglesUsingSorting (int[] array)
        {
            int count = 0, currentIndex = 0;

            for (int i = 0; i < array.Length - 2; i++)
            {
                currentIndex = i + 2;
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    while (currentIndex < array.Length 
                        && array[i] + array[j] > array[currentIndex])
                    {
                        ++currentIndex;
                    }
                    count += currentIndex - j - 1;
                }
            }

            return count;
        }
    }
}
