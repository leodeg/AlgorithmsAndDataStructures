using System;
using DA.Algorithms.Search;
using NUnit.Framework;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class SearchIn2DListTest
    {
        [Test]
        public void Search_SearchValueInSortedArray_ReturnTrue ()
        {
            int[,] array = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            bool actual = SearchIn2DList.Search (array, 4, 4, 11);
            Assert.AreEqual (true, actual);
        }

        [Test]
        public void Search_SearchValueInUnsortedArray_ReturnFalse ()
        {
            int[,] array = new int[4, 4]
            {
                { 5, 6, 7, 8 },
                { 1, 2, 3, 4 },
                { 13, 14, 15, 16 },
                { 9, 10, 11, 12 }
            };

            bool actual = SearchIn2DList.Search (array, 4, 4, 11);
            Assert.AreEqual (false, actual);
        }
    }
}
