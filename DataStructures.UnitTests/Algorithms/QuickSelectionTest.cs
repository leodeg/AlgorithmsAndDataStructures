using System;
using NUnit.Framework;
using DA.Algorithms.Sorting;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class QuickSelectionTest
    {
        [Test]
        public void QuickSelect_WhenCalled_ReturnIntegerValueAtPosition ()
        {
            int[] array = { 5, 4, 3, 2, 1 };

            int actual = QuickSelection.GetElement (array, 3);
            Assert.AreEqual (4, actual);

            actual = QuickSelection.GetElement (array, 2);
            Assert.AreEqual (3, actual);

            actual = QuickSelection.GetElement (array, 1);
            Assert.AreEqual (2, actual);

            actual = QuickSelection.GetElement (array, 0);
            Assert.AreEqual (1, actual);
        }
    }
}
