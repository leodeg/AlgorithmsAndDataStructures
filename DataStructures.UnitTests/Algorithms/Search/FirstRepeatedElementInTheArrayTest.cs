using System;
using NUnit.Framework;
using DA.Algorithms.Search;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class FirstRepeatedElementInTheArrayTest
    {
        [Test]
        [TestCase (new int[] { 0, 1, 2, 3, 4, 1 }, 1)]
        [TestCase (new int[] { 0, 1, 2, 1, 2, 1 }, 1)]
        public void FindRepeatedElement_FindValue_ReturnRepeatedValue (int[] array, int repeatedValue)
        {
            Assert.AreEqual (repeatedValue, FirstRepeatedElementInTheArray.FindRepeatedValue (array));
        }

        [Test]
        public void FindRepeatedElement_DoesntFindValue_ReturnIntMinValue ()
        {
            int[] source = { 0, 1, 2, 3, 4, 5 };
            Assert.AreEqual (int.MinValue, FirstRepeatedElementInTheArray.FindRepeatedValue (source));
        }

        [Test]
        public void FindRepeatedElement_ArrayIsNull_ThrowException ()
        {
            Assert.Throws<ArgumentNullException> (() => FirstRepeatedElementInTheArray.FindRepeatedValue(null));
        }
    }
}
