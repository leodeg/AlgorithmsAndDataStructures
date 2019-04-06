using System;
namespace Algorithms.Sorting
{
    public static class BubbleSort
    {
        public static void BubbleSorting (ref int[] arr)
        {
            int i, j;
            int length = arr.Length - 1;
            for (i = 0; i < length; i++)
            {
                for (j = 0; j < length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap (ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        public static void BubbleSorting_Optimized (ref int[] arr)
        {
            int i, j;
            int length = arr.Length - 1;
            bool swapped;

            for (i = 0; i < length; i++)
            {
                swapped = false;

                for (j = 0; j < length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap (ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }

        public static void Swap (ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}