using System;
using System.Collections.Generic;

namespace DA.Algorithms.Problems
{
    public static class SearchIn2DList
    {
        /// <summary>
        /// Find value in 2 dimensional list. 
        /// Each row and column are sorted in ascending order.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <param name="array">Two dimensional array</param>
        /// <param name="row">Row count</param>
        /// <param name="column">Column count</param>
        /// <param name="value">Value to find</param>
        /// 
        /// <returns>
        /// true - if value is exists, otherwise return false.
        /// </returns>
        public static bool Search (int[,] array, int row, int column, int value)
        {
            int rowIndex = 0;
            int columnIndex = column - 1;

            while (rowIndex < row && columnIndex >= 0)
            {
                if (array[rowIndex, columnIndex] == value)
                {
                    return true;
                }
                else if (array[rowIndex, columnIndex] > value)
                {
                    --columnIndex;
                }
                else
                {
                    ++rowIndex;
                }
            }

            return false;
        }
    }
}
