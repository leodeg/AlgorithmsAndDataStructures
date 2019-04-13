using System;
namespace DA.Algorithms.Sorting
{
    public static class PartitionZeroOne
    {
        /// <summary>
        /// Sort array so that 0s come first followed by 1s.
        /// Return the minimum number of swaps required to sort the array.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <param name="array">Collection containing 0s and 1s</param>
        public static int Partition01 (int[] array)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int swapCounter = 0;

            while (leftIndex < rightIndex)
            {
                // Finding value 1 at front of the collection
                while (array[leftIndex] == 0)
                {
                    leftIndex++;
                }
                // Finding value 0 at back of the collection
                while (array[rightIndex] == 1)
                {
                    rightIndex--;
                }
                // Swap found values
                if (leftIndex < rightIndex)
                {
                    Swap (ref array[leftIndex], ref array[rightIndex]);
                    swapCounter++;
                }
            }

            return swapCounter;
        }

        /// <summary>
        /// Sort array so that 0s come first followed by 1s and then 2s in the end.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <param name="array">Collection containing 0s and 1s</param>
        public static void Partition012 (int[] array)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int currentIndex = 0;

            while (currentIndex <= rightIndex)
            {
                // If value is 0 then swap to front of the collection
                if (array[currentIndex] == 0)
                {
                    Swap (ref array[currentIndex], ref array[leftIndex]);
                    currentIndex++;
                    leftIndex++;
                }
                // If value is 2 then swap to back of the collection
                else if (array[currentIndex] == 2)
                {
                    Swap (ref array[currentIndex], ref array[rightIndex]);
                    rightIndex--;
                }
                // If value is 1 then just go to next index
                else
                {
                    currentIndex++;
                }
            }
        }

        /// <summary>
        /// Sort array so that values smaller than range come to left, then values under the range followed with values greater than the range.
        /// <para>Time Complexity - O(n)</para>
        /// <see href="https://www.geeksforgeeks.org/three-way-partitioning-of-an-array-around-a-given-range/"/>
        /// </summary>
        /// <param name="array">Collection containing an elements</param>
        public static void PartitionRange (int[] array, int minRange, int maxRange)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;
            int currentIndex = 0;

            while (currentIndex < endIndex)
            {
                // If value is smaller than range, then swap to front of the collection
                if (array[currentIndex] < minRange)
                {
                    Swap (ref array[currentIndex], ref array[startIndex]);
                    currentIndex++;
                    startIndex++;
                }
                // If value is greater than range, then swap to back of the collection
                else if (array[currentIndex] > maxRange)
                {
                    Swap (ref array[currentIndex], ref array[endIndex]);
                    endIndex--;
                }
                // Skip current value and go to next index
                else
                {
                    currentIndex++;
                }
            }
        }

        /// <summary>
        /// Swap two elements.
        /// </summary>
        public static void Swap<T> (ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
