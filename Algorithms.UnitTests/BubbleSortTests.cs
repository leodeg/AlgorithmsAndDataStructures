using System;
using Algorithms;
using NUnit.Framework;

namespace Algorithms.UnitTests
{
	[TestFixture]
	class BubbleSortTests
	{
		[Test]
		[TestCase (new int[] { }, new int[] { })]
		[TestCase (new int[] { 1 }, new int[] { 1 })]
		[TestCase (new int[] { 2, 1 }, new int[] { 1, 2 })]
		[TestCase (new int[] { 2, 4, 5, 1, 10 }, new int[] { 1, 2, 4, 5, 10 })]
		[TestCase (new int[] { 3, 4, 100, 11, 10, 55, 67 }, new int[] { 3, 4, 10, 11, 55, 67, 100 })]
		public void BubbleSort_WhenCalled_SortArray (int[] arr, int[] expected)
		{
			BubbleSort.bubbleSort (ref arr);
			Assert.That (arr, Is.EqualTo (expected));
		}

		[Test]
		[TestCase (new int[] { }, new int[] { })]
		[TestCase (new int[] { 1 }, new int[] { 1 })]
		[TestCase (new int[] { 2, 1 }, new int[] { 1, 2 })]
		[TestCase (new int[] { 1, 2, 1, 5, 10 }, new int[] { 1, 1, 2, 5, 10 })]
		[TestCase (new int[] { 2, 4, 5, 1, 10 }, new int[] { 1, 2, 4, 5, 10 })]
		[TestCase (new int[] { 3, 4, 100, 11, 10, 55, 67 }, new int[] { 3, 4, 10, 11, 55, 67, 100 })]
		public void BubbleSortOptimized_WhenCalled_SortArray (int[] arr, int[] expected)
		{
			BubbleSort.bubbleSortOptimized (ref arr);
			Assert.That (arr, Is.EqualTo (expected));
		}
	}
}
