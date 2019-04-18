using System;
using NUnit.Framework;
using DA.Algorithms;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class FindMissingNumberTest
    {
        [Test]
        [TestCase (new int[] { 1, 2, 3, 5 }, 4)]
        [TestCase (new int[] { 1, 3, 5, 6  }, 2)]
        [TestCase (new int[] { 1, 2, 3, 5, 6 }, 4)]
        public void FindMissingNumber_FindMissedNumber_ReturnMissedNumber (int[] array, int missedNumber)
        {
            Assert.AreEqual (missedNumber, FindMissingNumber.Find (array));
        }

        [Test]
        public void FindMissingNumber_DoesntFindNumber_ReturnIntMaxValue ()
        {
            int[] source = { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual (int.MaxValue, FindMissingNumber.Find (source));
        }

        [Test]
        public void FindMissingNumber_GetArrayThatStartedWithZero_ThrowException ()
        {
            int[] source = { 0, 2, 3, 4, 5, 6 };
            Assert.Throws<System.InvalidOperationException> (() => FindMissingNumber.Find (source));
        }
    }
}
