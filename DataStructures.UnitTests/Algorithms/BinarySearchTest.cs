using DA.Algorithms.Search;
using NUnit.Framework;


namespace DA.UnitTests
{
    [TestFixture]
    public class BinarySearchTest
    {
        [Test]
        public void BinarySearch_ValueExists_ReturnTrue ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsTrue (BinarySearch.BinarySearching (integers, 2));
            Assert.IsTrue (BinarySearch.BinarySearching (integers, 5));
        }

        [Test]
        public void BinarySearch_ValueDoesntExists_ReturnFalse ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 0));
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 10));
        }

        [Test]
        public void BinarySearch_ValueExistsInUnsortedArray_ReturnFalse ()
        {
            int[] integers = { 2, 5, 1, 3, 25, 15 };
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 5));
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 2));
        }

        [Test]
        public void BinarySearchRecursive_ValueExists_ReturnTrue ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsTrue (BinarySearch.BinarySearching (integers, 1, 0, integers.Length - 1));
            Assert.IsTrue (BinarySearch.BinarySearching (integers, 5, 0, integers.Length - 1));
        }

        [Test]
        public void BinarySearchRecursive_ValueDoesntExists_ReturnFalse ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 0, 0, integers.Length - 1));
            Assert.IsFalse (BinarySearch.BinarySearching (integers, 10, 0, integers.Length - 1));
        }
    }
}
