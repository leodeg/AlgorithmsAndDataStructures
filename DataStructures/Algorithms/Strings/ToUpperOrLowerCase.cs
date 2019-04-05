namespace DA.Algorithms.Strings
{
    public static class ToUpperOrLowerCase
    {
        /// <summary>
        /// Convert character to uppercase.
        /// </summary>
        /// <returns>
        /// Return a new character in uppercase.
        /// </returns>
        public static char ToUpper (char character)
        {
            if (character >= 97 && character <= (97 + 25))
                character = (char)(character - 32);
            return character;
        }

        /// <summary>
        /// Convert full string to uppercase.
        /// </summary>
        /// <param name="source">string reference</param>
        /// <returns>
        /// Return a new string in uppercase.
        /// </returns>
        public static string ToUpper (string source)
        {
            if (string.IsNullOrWhiteSpace (source))
                throw new System.ArgumentNullException ();

            char[] result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = ToUpper (source[i]);
            return result.ToString ();
        }

        /// <summary>
        /// Convert character to lowercase.
        /// </summary>
        /// <returns>
        /// Return a new character in lowercase.
        /// </returns>
        public static char ToLower (char character)
        {
            if (character >= 65 && character <= (65 + 25))
                character = (char)(character + 32);
            return character;
        }

        /// <summary>
        /// Convert full string to lowercase.
        /// </summary>
        /// <param name="source">string reference</param>
        /// <returns>
        /// Return a new string in lowercase.
        /// </returns>
        public static string ToLower (string source)
        {
            if (string.IsNullOrWhiteSpace (source))
                throw new System.ArgumentNullException ();

            char[] result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = ToLower (source[i]);
            return result.ToString ();
        }

        /// <summary>
        /// Reverse a character case.
        /// </summary>
        /// <returns>
        /// Return a new character in opposite uppercase/lowercase.
        /// </returns>
        public static char ReverseCases (char character)
        {
            if (character >= 97 && character <= (97 + 25))
                character = (char)(character - 32);
            else if (character >= 65 && character <= (65 + 25))
                character = (char)(character + 32);
            return character;
        }

        /// <summary>
        /// Reverse all the characters case of a string.
        /// </summary>
        /// <returns>
        /// Return a new string where all characters case is reversed.
        /// </returns>
        public static string ReverseCases (string source)
        {
            char[] result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = ReverseCases (source[i]);
            return result.ToString ();
        }
    }
}
