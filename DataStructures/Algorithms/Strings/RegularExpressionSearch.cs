namespace DA.Algorithms.Strings
{
    public static class RegularExpressionSearch
    {
        /// <summary>
        /// "?" - matches any single character. 
        /// "*" - matches zero or more of the preceding element.
        /// </summary>
        public static bool MatchExpression (char[] expression, char[] text)
        {
            return MatchExpression (expression, text, 0, 0);
        }

        private static bool MatchExpression (char[] expression, char[] text, int i, int j)
        {
            if (i == expression.Length && j == text.Length)
            {
                return true;
            }

            if ((i == expression.Length && j != text.Length)
                || (i != expression.Length && j == text.Length))
            {
                return false;
            }

            if (expression[i] == '?' || expression[i] == expression[j])
            {
                return MatchExpression (expression, text, i + 1, j + 1);
            }

            if (expression[i] == '*')
            {
                return MatchExpression (expression, text, i + 1, j)
                    || MatchExpression (expression, text, i, j + 1)
                    || MatchExpression (expression, text, i + 1, j + 1);
            }

            return false;
        }
    }
}
