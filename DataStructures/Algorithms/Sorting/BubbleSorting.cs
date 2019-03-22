namespace Algorithms.Sorting
{
	public static class BubbleSort
	{
		public static void bubbleSort (ref int[] arr)
		{
			int i, j;
			int length = arr.Length - 1;

			for (i = 0; i < length; i++)
			{
				for (j = 0; j < length - i; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}

		public static void bubbleSortOptimized (ref int[] arr)
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
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
						swapped = true;
					}
				}

				if (!swapped) break;
			}
		}
	}
}