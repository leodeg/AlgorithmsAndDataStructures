namespace DA.Algorithms.Strings
{
    public static class KnuthMorrisPrattSearch
    {
        public static int KnuthMorrisPratt_Search (string text, string pattern)
        {
            return KnuthMorrisPratt_Search (text.ToCharArray (), pattern.ToCharArray ());
        }

        public static int KnuthMorrisPratt_Search (char[] text, char[] pattern)
        {
            int index = 0;
            int charCounter = 0;

            int[] shiftArray = new int[pattern.Length + 1];
            KnuthMorrisPratt_Preprocess (pattern, shiftArray);

            while (index < text.Length)
            {
                while (charCounter >= 0 && text[index] != pattern[index])
                {
                    charCounter = shiftArray[index];
                }

                ++index;
                ++charCounter;
                if (charCounter == pattern.Length)
                    return index - pattern.Length;
            }
            return -1;
        }

        public static int KnuthMorrisPratt_PatternCount (string text, string pattern)
        {
            return KnuthMorrisPratt_PatternCount (text.ToCharArray (), pattern.ToCharArray ());
        }

        public static int KnuthMorrisPratt_PatternCount (char[] text, char[] pattern)
        {
            int index = 0;
            int charCounter = 0;
            int patternCounter = 0;

            int[] shiftArray = new int[pattern.Length + 1];
            KnuthMorrisPratt_Preprocess (pattern, shiftArray);

            while (index < text.Length)
            {
                while (charCounter >= 0 && text[index] != pattern[index])
                {
                    charCounter = shiftArray[index];
                }

                ++index;
                ++charCounter;
                if (charCounter == pattern.Length)
                {
                    ++patternCounter;
                    charCounter = shiftArray[charCounter];
                }
            }
            return patternCounter;
        }

        private static void KnuthMorrisPratt_Preprocess (char[] pattern, int[] shiftArray)
        {
            int index = 0;
            int charCounter = 0;
            shiftArray[index] = -1;

            while (index < charCounter)
            {
                while (charCounter >= 0 && pattern[index] != pattern[charCounter])
                {
                    charCounter = shiftArray[charCounter];
                }
                ++index;
                ++charCounter;
                shiftArray[index] = charCounter;
            }
        }
    }
}
