using DA.Algorithms.Search;
using NUnit.Framework;


namespace DA.UnitTests
{
    [TestFixture]
    public class LinearSearchTest
    {
        [Test]
        public void SearchInUnsorted_ValueExists_ReturnTrue ()
        {
            int[] integers = { 5, 2, 11, 15, 2 };
            Assert.IsTrue (LinearSearch.SearchInUnsorted (integers, 2));
            Assert.IsTrue (LinearSearch.SearchInUnsorted (integers, 15));
        }

        [Test]
        public void SearchInUnsorted_ValueDoesntExists_ReturnFalse ()
        {
            int[] integers = { 5, 2, 11, 15, 2 };
            Assert.IsFalse (LinearSearch.SearchInUnsorted (integers, 0));
            Assert.IsFalse (LinearSearch.SearchInUnsorted (integers, 10));
        }

        [Test]
        public void SearchInSorted_ValueExists_ReturnTrue ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsTrue (LinearSearch.SearchInUnsorted (integers, 1));
            Assert.IsTrue (LinearSearch.SearchInUnsorted (integers, 5));
        }

        [Test]
        public void SearchInSorted_ValueDoesntExists_ReturnFalse ()
        {
            int[] integers = { 1, 2, 3, 4, 5 };
            Assert.IsFalse (LinearSearch.SearchInUnsorted (integers, 0));
            Assert.IsFalse (LinearSearch.SearchInUnsorted (integers, 10));
        }
    }
}
