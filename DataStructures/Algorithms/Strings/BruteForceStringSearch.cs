namespace DA.Algorithms.Strings
{
    public static class BruteForceStringSearch
    {
        public static int BruteForceSearch (string text, string pattern)
        {
            return BruteForceSearch (text.ToCharArray (), pattern.ToCharArray ());
        }

        private static int BruteForceSearch (char[] text, char[] pattern)
        {
            int index = 0;
            int charCounter = 0;
            while (index <= (text.Length - pattern.Length))
            {
                charCounter = 0;

                while (charCounter < pattern.Length
                    && pattern[charCounter] == text[index + charCounter])
                {
                    charCounter++;
                }

                if (charCounter == pattern.Length)
                {
                    return index;
                }

                index++;
            }
            return -1;
        }
    }
}
