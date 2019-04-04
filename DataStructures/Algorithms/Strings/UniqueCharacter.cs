using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Strings
{
    public static class UniqueCharacter
    {
        public static bool isLettersUnique (string source)
        {
            int[] bitArray = new int[26];
            for (int i = 0; i < 26; i++)
                bitArray[i] = 0;

            for (int i = 0; i < source.Length; i++)
            {
                char character = source[i];

                if ('A' <= character && 'Z' >= character)
                {
                    character = (char)(character - 'A');
                }
                else if ('a' <= character && 'z' >= character)
                {
                    character = (char)(character - 'a');
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException ("Unknown Letter: [" + character + "]");
                }

                if (bitArray[character] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
