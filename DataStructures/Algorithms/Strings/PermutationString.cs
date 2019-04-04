namespace DA.Algorithms.Strings
{
    public static class PermutationString
    {
        /// <summary>
        /// Check if two strings are permutation of each other.
        /// </summary>
        public static bool isPermutation (string source, string assumptionSource)
        {
            int[] counter = new int[256];

            if (assumptionSource.Length != source.Length)
                return false;

            for (int i = 0; i < 256; i++)
                counter[i] = 0;

            for (int i = 0; i < source.Length; i++)
            {
                char character = source[i];
                ++counter[character];
                character = assumptionSource[i];
                --counter[character];
            }

            for (int i = 0; i < source.Length; i++)
                if (counter[i] != 0)
                    return false;

            return true;
        }
    }
}
