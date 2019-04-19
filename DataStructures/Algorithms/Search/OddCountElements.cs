using System;
using System.Collections.Generic;

namespace DA.Algorithms.Search
{
    public static class OddCountElements
    {
        public static void FindOddCountElements (int[] array)
        {
            int xorSum = 0;
            int first = 0;
            int second = 0;
            int setBit;

            for (int i = 0; i < array.Length; i++)
            {
                xorSum ^= array[i];
            }

            setBit = xorSum & ~(xorSum - 1);

            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] & setBit) != 0)
                {
                    first ^= array[i];
                }
                else
                {
                    second ^= array[i];
                }
            }
        }
    }
}
