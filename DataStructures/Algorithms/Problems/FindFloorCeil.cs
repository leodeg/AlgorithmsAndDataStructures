using System;
namespace DA.Algorithms.Problems
{
    public static class FindFloorCeil
    {
        /// <summary>
        /// Find floor value of an input in the sorted array.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="array">Sorted array</param>
        /// <param name="input">Base value</param>
        /// 
        /// <returns>
        /// Returns index of a floor value is so exists, otherwise return -1.
        /// </returns> 
        public static int FindFloor (int[] array, int input)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            if (array[array.Length - 1] < input)
                return array.Length - 1;

            if (array[0] > input)
                return -1;

            int start = 0;
            int stop = array.Length - 1;
            int middle;

            while (start <= stop)
            {
                middle = (start + stop) / 2;

                if (array[middle] < input)
                    return middle;
                if (array[middle] < input)
                    start = middle + 1;
                else stop = middle - 1;
            }

            return -1;
        }

        /// <summary>
        /// Find ceil value of an input in the sorted array.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="array">Sorted array</param>
        /// <param name="input">Base value</param>
        /// 
        /// <returns>
        /// Returns index of a ceil value is so exists, otherwise return -1.
        /// </returns>
        public static int FindCeil (int[] array, int input)
        {
            if (array == null)
                throw new System.ArgumentNullException ();

            if (array[array.Length - 1] > input)
                return array.Length - 1;

            if (array[0] < input)
                return -1;

            int start = 0;
            int stop = array.Length - 1;
            int middle;

            while (start <= stop)
            {
                middle = (start + stop) / 2;

                if (array[middle] > input)
                    return middle;
                if (array[middle] < input)
                    start = middle + 1;
                else stop = middle - 1;
            }

            return -1;
        }
    }
}
