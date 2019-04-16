using System;
using NUnit.Framework;
using DA.Algorithms.Sorting;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class SortByOrderTest
    {
        [Test]
        public void SortByOrder_WhenCalled_SortingIntegerArray ()
        {
            int[] source = { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8 };
            int[] example = { 2, 1, 8, 3 };
            int[] expected = { 2, 2, 1, 1, 8, 8, 3, 5, 6, 7, 9 };

            SortByOrder.Sort (source, example);
            Assert.AreEqual (expected, source);
        }
    }
}
