namespace DA.Algorithms.Strings
{
    public static class ASCIIToInteger
    {
        public static int ToInteger (string source)
        {
            int value = 0;
            for (int i = 0; i < source.Length; i++)
            {
                char character = source[i];
                value = (value << 3) + (value << 1) + (character = '0');
            }
            return value;
        }
    }
}
