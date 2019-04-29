namespace DA.Algorithms.Search
{
    public static class FirstRepeatedElementInTheArray
    {
        /// <summary>
        /// Find repeated element in the array.
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException"/>
        /// 
        /// <returns>
        /// Return repeated element or int.MinValue.
        /// </returns>
        public static int FindRepeatedValue (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j]) return array[i];
                }
            }
            return int.MinValue;
        }
    }
}
