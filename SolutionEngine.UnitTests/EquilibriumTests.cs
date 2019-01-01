using System;
using NUnit.Framework;
using SolutionEngine;

namespace SolutionEngine.UnitTests
{
	[TestFixture]
	class EquilibriumTests
	{
		#region EquilibriumIndex

		[Test]
		[TestCase (new int[] { 1 }, 0)]
		[TestCase (new int[] { 5, 5, 3, 5, 5 }, 2)]
		[TestCase (new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
		[TestCase (new int[] { -1, -1, -1, 0, 1, 1 }, 0)]
		public void EquilibriumIndex_ArrayHasEquilibriumIndex_ReturnPivotIndex (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndex (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		[Test]
		[TestCase (new int[] { 1, 2, 3 }, -1)]
		[TestCase (new int[] { 1, 7, 3 }, -1)]
		[TestCase (new int[] { 1, 7, 3, 5, 10, 15, 20 }, -1)]
		public void EquilibriumIndex_ArrayHasNotEquilibriumIndex_ReturnMinusOne (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndex (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		[Test]
		[TestCase (new int[] { }, -1)]
		public void EquilibriumIndex_ArraySizeIsZero_ReturnMinusOne (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndex (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		#endregion

		#region EquilibriumIndexOptimized

		[Test]
		[TestCase (new int[] { 1 }, 0)]
		[TestCase (new int[] { 5, 5, 3, 5, 5 }, 2)]
		[TestCase (new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
		[TestCase (new int[] { -1, -1, -1, 0, 1, 1 }, 0)]
		public void EquilibriumIndexOptimized_ArrayHasEquilibriumIndex_ReturnPivotIndex (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndexOptimized (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		[Test]
		[TestCase (new int[] { 1, 2, 3 }, -1)]
		[TestCase (new int[] { 1, 7, 3 }, -1)]
		[TestCase (new int[] { 1, 7, 3, 5, 10, 15, 20 }, -1)]
		public void EquilibriumIndexOptimized_ArrayHasNotEquilibriumIndex_ReturnMinusOne (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndexOptimized (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		[Test]
		[TestCase (new int[] { }, -1)]
		public void EquilibriumIndexOptimized_ArraySizeIsZero_ReturnMinusOne (int[] n, int expectedIndex)
		{
			int result = FindPivotIndex.EquilibriumIndexOptimized (n);
			Assert.That (result, Is.EqualTo (expectedIndex));
		}

		#endregion
	}
}
