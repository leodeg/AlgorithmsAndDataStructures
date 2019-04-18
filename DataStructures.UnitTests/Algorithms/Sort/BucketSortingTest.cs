using System;
using NUnit.Framework;
using DA.Algorithms.Sorting;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class BucketSortingTest
    {
        [Test]
        public void BucketSort_WhenCalled_SortingIntegerArray ()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            BucketSorting.Sort (array, 1, 10);
            Assert.AreEqual (expected, array);
        }
    }
}
