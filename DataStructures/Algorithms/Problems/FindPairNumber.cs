using System;
using System.Collections.Generic;

namespace DA.Algorithms.Problems
{
    public static class FindPairNumber
    {
        /// <summary>
        /// Given an array of n numbers, find two elements 
        /// such that their sum is equal to “value”.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        public static bool FindPair (int[] array, int value)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if ((array[i] + array[j]) == value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Given an array of n numbers, find two elements 
        /// such that their sum is equal to “targetValue”.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="targetValue">Value that need to find</param>
        /// <param name="firstValue">First value of a pair sum</param>
        /// <param name="secondValue">Second value of a pair sum</param>
        public static bool FindPair (int[] array, int targetValue, out int firstValue, out int secondValue)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if ((array[i] + array[j]) == targetValue)
                    {
                        firstValue = array[i];
                        secondValue = array[j];
                        return true;
                    }
                }
            }

            firstValue = int.MinValue;
            secondValue = int.MinValue;
            return false;
        }

        /// <summary>
        /// Given an array of n numbers, find two elements 
        /// such that their sum is equal to “value”.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="value">Value that need to find</param>
        public static bool FindPairUsingSorting (int[] array, int value)
        {
            int first = 0;
            int second = array.Length - 1;
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (first >= second) break;
                currentSum = array[first] + array[second];

                if (currentSum == value) return true;
                else if (currentSum < value) ++first;
                else --second;
            }

            return false;
        }

        /// <summary>
        /// Given an array of n numbers, find two elements 
        /// such that their sum is equal to “value”.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="value">Value that need to find</param>
        /// <param name="first">First value of a pair sum</param>
        /// <param name="second">Second value of a pair sum</param>
        public static bool FindPairUsingSorting (int[] array, int value, out int first, out int second)
        {
            int firstIndex = 0;
            int secondIndex = array.Length - 1;
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (firstIndex >= secondIndex) break;
                currentSum = array[firstIndex] + array[secondIndex];

                if (currentSum == value)
                {
                    first = array[firstIndex];
                    second = array[secondIndex];
                    return true;
                }
                else if (currentSum < value)
                {
                    ++firstIndex;
                }
                else
                {
                    --secondIndex;
                }
            }

            first = int.MinValue;
            second = int.MinValue;
            return false;
        }

        /// <summary>
        /// Given an array of n numbers, find two elements 
        /// such that their sum is equal to “value”.
        /// </summary>
        public static bool FindPairUsingHashTable (int[] array, int value)
        {
            HashSet<int> hashSet = new HashSet<int> ();

            for (int i = 0; i < array.Length; i++)
            {
                if (hashSet.Contains (value - array[i]))
                {
                    return true;
                }
                hashSet.Add (array[i]);
            }
            return false;
        }
    }
}