namespace DA.Algorithms.Strings
{
    public static class CharactersOrderInAText
    {
        /// <summary>
        /// Find if the characters of a pattern are in the same order in the source.
        /// </summary>
        public static bool PatternOrder (string source, string pattern)
        {
            return PatternOrder (source.ToCharArray (), pattern.ToCharArray ());
        }

        /// <summary>
        /// Find if the characters of a pattern are in the same order in the source.
        /// </summary>
        public static bool PatternOrder (char[] source, char[] pattern)
        {
            int counter = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == pattern[counter])
                    ++counter;
                if (counter == pattern.Length)
                    return true;
            }
            return false;
        }
    }
}
