using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Algorithms.Sorting
{
    public static class MergeSorting
    {
        public static void Sort<T> (T[] array) where T : IComparable<T>
        {
            int size = array.Length;
            T[] tempArray = new T[size];
            MergeSort (array, tempArray, 0, size - 1);
        }

        private static void MergeSort<T> (T[] array, T[] tempArray, int lowerIndex, int upperIndex) where T : IComparable<T>
        {
            if (lowerIndex >= upperIndex)
            {
                return;
            }

            int middleIndex = (lowerIndex + upperIndex) / 2;

            MergeSort (array, tempArray, lowerIndex, middleIndex);
            MergeSort (array, tempArray, middleIndex + 1, upperIndex);
            Merge (array, tempArray, lowerIndex, middleIndex, upperIndex);
        }

        private static void Merge<T> (T[] array, T[] tempArray, int lowerIndex, int middleIndex, int upperIndex) where T : IComparable<T>
        {
            int lowerStart = lowerIndex;
            int lowerStop = middleIndex;
            int upperStart = middleIndex + 1;
            int upperStop = upperIndex;
            int count = lowerIndex;

            while (lowerStart <= lowerStop && upperStart <= upperStop)
            {
                if (array[lowerStart].CompareTo (array[upperStart]) < 0)
                {
                    tempArray[count++] = array[lowerStart++];
                }
                else
                {
                    tempArray[count++] = array[upperStart++];
                }
            }

            while (lowerStart <= lowerStop)
            {
                tempArray[count++] = array[lowerStart++];
            }

            while (upperStart <= upperStop)
            {
                tempArray[count++] = array[upperStart++];
            }

            for (int i = lowerIndex; i <= upperIndex; i++)
            {
                array[i] = tempArray[i];
            }
        }
    }
}
