using System;

namespace DA.Algorithms.Problems
{
    public static class GetMajorityElementInArray
    {
        /// <summary>
        /// Find the majority element, which appears more than (array.Length/2) times
        /// <para>Time Complexity - O(n^2)</para>
        /// </summary>
        /// 
        /// <returns>
        /// Returns majority element if so exists, otherwise return int.MinValue
        /// </returns>
        public static int GetMajorityElement (int[] array)
        {
            int majorityElement = 0, count = 0, maxCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        ++count;
                    }
                }

                if (count > maxCount)
                {
                    majorityElement = array[i];
                    maxCount = count;
                }
            }

            return (maxCount > (array.Length / 2)) ? majorityElement : int.MinValue;
        }

        /// <summary>
        /// Find the majority element, which appears more than (array.Length/2) times using array sorting algorithm
        /// <para>Time Complexity - O(n.logn)</para>
        /// </summary>
        /// 
        /// <returns>
        /// Returns majority element if so exists, otherwise return int.MinValue
        /// </returns>
        public static int GetMajorityElementUsingSorting (int[] array)
        {
            int count = 0;
            int candidate = 0;
            int majorityIndex = array.Length / 2;

            Array.Sort (array);
            candidate = array[majorityIndex];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == candidate)
                {
                    ++count;
                }
            }

            return (count > (array.Length / 2)) ? array[majorityIndex] : int.MinValue;
        }

        /// <summary>
        /// Find the majority element, which appears more than (array.Length/2) times using Moore's Voting Algorithm
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <returns>
        /// Returns majority element if so exists, otherwise return int.MinValue
        /// </returns>
        public static int GetMajorityElementMoores (int[] array)
        {
            int majorityIndex = 0;
            int count = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[majorityIndex] == array[i])
                {
                    ++count;
                }
                else
                {
                    --count;
                }

                if (count == 0)
                {
                    majorityIndex = i;
                    count = 1;
                }
            }

            int candidate = array[majorityIndex];
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == candidate)
                {
                    ++count;
                }
            }
            return (count > (array.Length / 2)) ? array[majorityIndex] : int.MinValue;
        }

        /// <summary>
        /// Find if the array has a majority element and find the majority element.
        /// </summary>
        public static bool IsMajority (int[] array)
        {
            int halfSize = array.Length / 2;
            int majority = array[halfSize];

            int firstIndex = FirstIndex (array, 0, array.Length - 1, majority);
            bool isIndexInRange = (firstIndex + halfSize) <= (array.Length - 1);
            bool isEqualToMajority = array[firstIndex + halfSize] == majority;

            return isIndexInRange && isEqualToMajority;
        }

        /// <summary>
        /// Find if the array has a majority element and find the majority element.
        /// </summary>
        public static bool IsMajority (int[] array, out int majorityElement)
        {
            int halfSize = array.Length / 2;
            int majority = array[halfSize];

            int firstIndex = FirstIndex (array, 0, array.Length - 1, majority);
            bool isIndexInRange = (firstIndex + halfSize) <= (array.Length - 1);
            bool isEqualToMajority = array[firstIndex + halfSize] == majority;

            majorityElement = majority;
            return isIndexInRange && isEqualToMajority;
        }

        public static int FirstIndex (int[] array, int value, int low, int high)
        {
            int middle = 0;
            if (high >= low)
            {
                middle = (low + high) / 2;
            }

            if ((middle == 0 || array[middle - 1] < value) && array[middle] == value)
            {
                return middle;
            }
            else if (array[middle] < value)
            {
                return FirstIndex (array, value, middle + 1, high);
            }
            else
            {
                return FirstIndex (array, value, low, middle - 1);
            }
        }
    }
}
