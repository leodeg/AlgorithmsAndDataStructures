
namespace DA.Algorithms.Strings
{
    public static class RobinKarpStringSearch
    {
        public static int RobinKarpSearch (string text, string pattern)
        {
            return RobinKarpSearch (text.ToCharArray (), pattern.ToCharArray ());
        }

        public static int RobinKarpSearch (char[] text, char[] pattern)
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
                patternHash = ((patternHash << 1) + pattern[i]) % primeNumber;
                textHash = ((textHash << 1) + text[i]) % primeNumber;
            }

            for (int i = 0; i <= (text.Length - patternLength); i++)
            {
                if (textHash == patternHash)
                {
                    for (charCounter = 0; charCounter < patternLength; charCounter++)
                        if (text[i + charCounter] != pattern[charCounter])
                            break;

                    if (charCounter == patternLength)
                        return i;
                }

                textHash = (((textHash - text[i] * powerNumber) << 1) + text[i + charCounter]) % primeNumber;

                if (textHash < 0)
                    textHash += primeNumber;
            }
            return -1;
        }
    }
}
