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
            int textLength = text.Length;
            int patternLength = pattern.Length;

            while (index <= (textLength - patternLength))
            {
                charCounter = 0;

                while (charCounter < patternLength
                    && pattern[charCounter] == text[index + charCounter])
                {
                    charCounter++;
                }

                if (charCounter == patternLength)
                {
                    return index;
                }

                index++;
            }
            return -1;
        }
    }
}
