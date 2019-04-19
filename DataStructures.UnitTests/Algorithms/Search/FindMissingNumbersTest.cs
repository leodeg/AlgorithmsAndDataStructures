using DA.Algorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class FindMissingNumbersTest
    {
        [Test]
        public void FindMissingNumbers_FindMissedNumbers_ReturListOfIntegersWithMissedNumbers ()
        {
            int[] source = { 0, 2, 3, 5, 7 };
            List<int> expected = new List<int> () { 1, 4, 6 };
            Assert.AreEqual (expected, FindMissingNumber.FindNumbers (source));
        }

        [Test]
        public void FindMissingNumbers_DoesntFindNumber_ReturnEmptyList ()
        {
            int[] source = { 0, 1, 2, 3, 4 };
            Assert.AreEqual (0, FindMissingNumber.FindNumbers (source).Count);
        }

        [Test]
        public void FindMissingNumbers_NullArray_ThrowException ()
        {
            Assert.Throws<System.ArgumentNullException> (() => FindMissingNumber.FindNumbers (null));
        }
    }
}
