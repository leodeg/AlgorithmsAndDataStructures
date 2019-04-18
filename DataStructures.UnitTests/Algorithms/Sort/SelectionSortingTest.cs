using System;
using NUnit.Framework;
using DA.Algorithms.Sorting;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class SelectionSortingTest
    {
        [Test]
        public void SelectionSort_WhenCalled_SortingIntegerArray ()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            SelectionSorting.Sort (array);
            Assert.AreEqual (expected, array);
        }

        [Test]
        public void SelectionSort_WhenCalled_SortingStringArray ()
        {
            string[] array = { "d", "c", "b", "a" };
            string[] expected = { "a", "b", "c", "d" };

            SelectionSorting.Sort (array);
            Assert.AreEqual (expected, array);
        }
    }
}
