namespace DA.Algorithms.Strings
{
    public static class ToUpperOrLowerCase
    {
        public static char ToUpper (char character)
        {
            if (character >= 97 && character <= (97 + 25))
                character = (char)(character - 32);
            return character;
        }

        public static string ToUpper (string source)
        {
            if (string.IsNullOrWhiteSpace (source))
                throw new System.ArgumentNullException ();

            char[] result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = ToUpper (source[i]);
            return result.ToString ();
        }

        public static char ToLower (char character)
        {
            if (character >= 65 && character <= (65 + 25))
                character = (char)(character + 32);
            return character;
        }

        public static string ToLower (string source)
        {
            if (string.IsNullOrWhiteSpace (source))
                throw new System.ArgumentNullException ();

            char[] result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = ToLower (source[i]);
            return result.ToString ();
        }
    }
}
