using System;

namespace DA.Algorithms.Problems
{
    public static class KLargestElement
    {
        public static int GetKLargestElement (int[] array, int range)
        {
            int[] temp = new int[array.Length];

            Array.Copy (array, temp, array.Length);
            Array.Sort (temp);

            for (int i = 0; i < array.Length; i++)
            {
                if (temp[i] >= array[array.Length - range])
                {
                    return temp[i];
                }
            }

            return int.MinValue;
        }
    }
}
