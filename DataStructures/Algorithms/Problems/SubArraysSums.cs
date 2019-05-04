namespace DA.Algorithms.Problems
{
    public static class SubArraysSums
    {
        /// <summary>
        /// Find of there is some range in array that 
        /// if we add all the elements in that range 
        /// then it became equal to given value.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="array">Collection with positive numbers</param>
        /// <param name="value">Value to find</param>
        public static int GetSubArraySum (int[] array, int value)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            int first = 0;
            int second = 0;
            int sum = array[first];

            while (first < array.Length && second < array.Length)
            {
                if (sum == value)
                    return sum;

                if (sum < value)
                {
                    ++second;
                    if (second < array.Length)
                        sum += array[second];
                }
                else
                {
                    sum -= array[first];
                    ++first;
                }
            }

            return sum;
        }
    }
}
