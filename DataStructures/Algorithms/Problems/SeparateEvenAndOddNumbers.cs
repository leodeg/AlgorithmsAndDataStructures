namespace DA.Algorithms.Problems
{
    public static class SeparateEvenAndOddNumbers
    {
        /// <summary>
        /// Separate even numbers from the odd numbers in the collection.
        /// </summary>
        /// <param name="array">A collection with even and odd numbers.</param>
        public static void Separate (int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                if (array[left] % 2 == 0)
                {
                    ++left;
                }
                else if (array[right] % 2 == 1)
                {
                    --right;
                }
                else
                {
                    Swap (ref array[left], ref array[right]);
                    ++left;
                    --right;
                }
            }
        }

        /// <summary>
        /// Swap two elements.
        /// </summary>
        public static void Swap<T> (ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
