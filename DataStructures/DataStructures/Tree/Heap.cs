using System;
namespace DA.Tree
{
	internal class Heap
	{
		private const int Capacity = 16;
		private int size;
		private int[] data;

		public Heap ()
		{
			data = new int[Capacity];
			size = 0;
		}

		public Heap (int[] arr)
		{
			size = arr.Length;
			data = new int[arr.Length + 1];
			System.Array.Copy (arr, 0, data, 1, arr.Length);

			for (int i = ( size / 2 ); i > 0; i--)
			{
				PullDown (i);
			}
		}

		public virtual void Add (int value)
		{
			if (size == data.Length)
			{
				ExtendHeapSize ();
			}

			data[++size] = value;
			LiftUp (size);
		}

		public virtual int Delete ()
		{
			if (IsEmpty())
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			int value = data[1];
			data[1] = data[size];
			size--;

			PullDown (1);
			return value;
		}

		private void PullDown (int position)
		{
			int left = 2 * position;
			int right = left + 1;
			int small = -1;
			int temp;

			if (left <= size)
			{
				small = left;
			}

			if (right <= size && ( data[right] - data[left] < 0 ))
			{
				small = right;
			}

			if (small != -1 && ( data[small] - data[position] < 0 ))
			{
				temp = data[position];
				data[position] = data[small];
				data[small] = temp;

				PullDown (small);
			}
		}

		private void LiftUp (int position)
		{
			int parent = position / 2;
			int temp;

			if (parent == 0)
			{
				return;
			}

			if ((data[parent] - data[position]) > 0)
			{
				temp = data[position];
				data[position] = data[parent];
				data[parent] = temp;

				LiftUp (parent);
			}
		}

		public static void HeapSort (int[] arr)
		{
			Heap heap = new Heap (arr);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = heap.Delete ();
			}
		}

		private void ExtendHeapSize ()
		{
			int[] oldData = data;
			data = new int[data.Length * 2];
			Array.Copy (oldData, 1, data, 1, size);
		}

		public virtual void Print ()
		{
			for (int i = 0; i <= size; i++)
			{
				System.Console.WriteLine ("value is: {0}", data[i]);
			}
		}

		public static bool IsMinHeap (int[] array, int size)
		{
			for (int current = 0; current <= (size - 2) / 2; current++)
			{
				int leftIndex = 2 * current + 1;
				if (leftIndex < size && array[current] > array[leftIndex])
				{
					return false;
				}

				int rightIndex = 2 * current + 2;
				if (rightIndex < size && array[current] > array[rightIndex])
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsMaxHeap (int[] array, int size)
		{
			for (int current = 0; current <= ( size - 2 ) / 2; current++)
			{
				int leftIndex = 2 * current + 1;
				if (leftIndex < size && array[current] < array[leftIndex])
				{
					return false;
				}

				int rightIndex = 2 * current + 2;
				if (rightIndex  < size && array[current] < array[rightIndex])
				{
					return false;
				}
			}
			return true;
		}

		public virtual bool IsEmpty ()
		{
			return size <= 0;
		}

		public virtual int Peek ()
		{
			if (IsEmpty())
			{
				throw new System.InvalidOperationException ("Heap:: is empty.");
			}

			return data[1];
		}
	}
}
