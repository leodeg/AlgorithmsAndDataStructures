using System;
using NUnit.Framework;
using DA.Algorithms.Sorting;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class InsertionSortingTest
    {
        [Test]
        public void InsertionSort_WhenCalled_SortingIntegerArray ()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            InsertionSorting.Sort (array);
            Assert.AreEqual (expected, array);
        }
    }
}
