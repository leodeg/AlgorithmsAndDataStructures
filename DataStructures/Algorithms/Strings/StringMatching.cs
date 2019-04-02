using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Algorithms.Strings
{
    public static class StringMatching
    {
        #region Brute Force Search Algorithm

        public static int BruteForceSearch (string text, string pattern)
        {
            return BruteForceSearch (text.ToCharArray (), pattern.ToCharArray ());
        }

        private static int BruteForceSearch (char [] text, char [] pattern)
        {
            int index = 0;
            int charCounter = 0;
            int textLength = text.Length;
            int patternLength = pattern.Length;

            while (index <= (textLength - patternLength))
            {
                charCounter = 0;

                while (charCounter < patternLength
                    && pattern [charCounter] == text [index + charCounter])
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

        #endregion

        #region Robin Karp Search Algorithm

        public static int RobinKarpSearch (string text, string pattern)
        {
            return RobinKarpSearch (text.ToCharArray (), pattern.ToCharArray ());
        }

        public static int RobinKarpSearch (char [] text, char [] pattern)
        {
            int charCounter = 0;
            int patternLength = pattern.Length;

            int primeNumber = 101;
            int powerNumber = 1;
            int textHash = 0;
            int patternHash = 0;

            for (int i = 0; i < patternLength - 1; i++)
                powerNumber = (powerNumber << 1) % primeNumber;

            for (int i = 0; i < patternLength; i++)
            {
                patternHash = ((patternHash << 1) + pattern [i]) % primeNumber;
                textHash = ((textHash << 1) + text [i]) % primeNumber;
            }

            for (int i = 0; i <= (text.Length - patternLength); i++)
            {
                if (textHash == patternHash)
                {
                    for (charCounter = 0; charCounter < patternLength; charCounter++)
                        if (text [i + charCounter] != pattern [charCounter])
                            break;

                    if (charCounter == patternLength)
                        return i;
                }

                textHash = (((textHash - text [i] * powerNumber) << 1) + text [i + charCounter]) % primeNumber;

                if (textHash < 0)
                    textHash += primeNumber;
            }
            return -1;
        }

        #endregion

        #region Knuth-Morris-Pratt Search Algorithm

        public static int KnuthMorrisPratt_Search (string text, string pattern)
        {
            return KnuthMorrisPratt_Search (text.ToCharArray (), pattern.ToCharArray ());
        }

        public static int KnuthMorrisPratt_Search (char [] text, char [] pattern)
        {
            int index = 0;
            int charCounter = 0;

            int [] shiftArray = new int [pattern.Length + 1];
            KnuthMorrisPratt_Preprocess (pattern, shiftArray);

            while (index < text.Length)
            {
                while (charCounter >= 0 && text [index] != pattern [index])
                {
                    charCounter = shiftArray [index];
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

        public static int KnuthMorrisPratt_PatternCount (char [] text, char [] pattern)
        {
            int index = 0;
            int charCounter = 0;
            int patternCounter = 0;

            int [] shiftArray = new int [pattern.Length + 1];
            KnuthMorrisPratt_Preprocess (pattern, shiftArray);

            while (index < text.Length)
            {
                while (charCounter >= 0 && text [index] != pattern [index])
                {
                    charCounter = shiftArray [index];
                }

                ++index;
                ++charCounter;
                if (charCounter == pattern.Length)
                {
                    ++patternCounter;
                    charCounter = shiftArray [charCounter];
                }
            }
            return patternCounter;
        }

        private static void KnuthMorrisPratt_Preprocess (char [] pattern, int [] shiftArray)
        {
            int index = 0;
            int charCounter = 0;
            shiftArray [index] = -1;

            while (index < charCounter)
            {
                while (charCounter >= 0 && pattern [index] != pattern [charCounter])
                {
                    charCounter = shiftArray [charCounter];
                }
                ++index;
                ++charCounter;
                shiftArray [index] = charCounter;
            }
        }

        #endregion
    }
}
