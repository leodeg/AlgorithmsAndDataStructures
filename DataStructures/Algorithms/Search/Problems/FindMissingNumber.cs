using System;
using System.Collections.Generic;

namespace DA.Algorithms
{
    public static class FindMissingNumber
    {
        /// <summary>
        /// Find missing number in the array, which are in the range of 1 to n.
        /// </summary>
        /// 
        /// <exception cref="System.InvalidOperationException" />
        /// 
        /// <param name="array">An array with integers, which are in the range of 1 to n.</param>
        /// 
        /// <returns>
        /// Return a missed number.
        /// </returns>
        public static int Find (int[] array)
        {
            if (array[0] == 0)
            {
                throw new System.InvalidOperationException ("The array must be starting with value 1.");
            }

            bool isFound = false;
            for (int i = 1; i <= array.Length; i++)
            {
                isFound = false;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == i)
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    return i;
                }
            }

            return int.MaxValue;
        }

        /// <summary>
        /// Get missing numbers in the array, which are in the range of 0 to n-1.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// 
        /// <param name="array">An array with integers, which are in the range of 0 to n-1.</param>
        /// 
        /// <returns>
        /// Return a List with missed numbers.
        /// </returns>
        public static List<int> FindNumbers (int[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException ();
            }

            bool isFound = false;
            int maxValue = FindMax(array);
            List<int> result = new List<int> ();

            for (int currentNumber = 0; currentNumber <= maxValue; currentNumber++)
            {
                isFound = false;
                for (int currentIndex = 0; currentIndex < array.Length; currentIndex++)
                {
                    if (currentNumber == array[currentIndex])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    result.Add (currentNumber);
                }
            }
            return result;
        }

        /// <summary>
        /// Find max value in the array.
        /// </summary>
        public static int FindMax (int[] array)
        {
            int maxValue = int.MinValue;
            foreach (int number in array)
            {
                if (number > maxValue)
                {
                    maxValue = number;
                }
            }
            return maxValue;
        }
    }
}
