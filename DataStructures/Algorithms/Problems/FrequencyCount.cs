using System;
using System.Collections.Generic;

namespace DA.Algorithms.Problems
{
    public static class FrequencyCount
    {
        public static void GetFrequencyCount (int[] array)
        {
            int index;

            for (int i = 0; i < array.Length; i++)
            {
                while (array[i] > 0)
                {
                    index = array[i] - 1;
                    if (array[index] > 0)
                    {
                        array[i] = array[index];
                        array[index] = -1;
                    }
                    else
                    {
                        array[index]--;
                        array[i] = 0;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine ("{0}", i + 1 + Math.Abs (array[i]));
            }
        }
    }
}
