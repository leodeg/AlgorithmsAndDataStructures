using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionEngine
{
	public static class FindPivotIndex
	{
		/* We define the pivot index as the index where the sum of the numbers 
		 * to the left of the index is equal to the sum of the numbers to the right of the index.
		 * If no such index exists, we should return -1. 
		 * If there are multiple pivot indexes, you should return the left-most pivot index.
		 * 
		 * Input: integers in the range [0, 1000]
		 * Input: nums[i] in the range [-1000, 1000]
		 * Output: -1 if a pivot is not found, else return number that is a pivot.
		 */
		public static int EquilibriumIndex (int[] nums)
		{
			int pivot, j;
			int sumLeft;
			int sumRight;

			for (pivot = 0; pivot < nums.Length; pivot++)
			{
				sumLeft = 0;
				sumRight = 0;

				for (j = 0; j < pivot; j++)
				{
					sumLeft += nums[j];
				}

				for (j = pivot + 1; j < nums.Length; j++)
				{
					sumRight += nums[j];
				}

				if (sumLeft == sumRight)
				{
					return pivot;
				}
			}
			return -1;
		}

		public static int EquilibriumIndexOptimized (int[] nums)
		{
			int pivot;
			int sumRight = nums.Sum();
			int sumLeft = 0;

			for (pivot = 0; pivot < nums.Length; pivot++)
			{
				sumRight -= nums[pivot];
				if (sumLeft == sumRight)
				{
					return pivot;
				}
				sumLeft += nums[pivot];
			}

			return -1;
		}
	}
}
