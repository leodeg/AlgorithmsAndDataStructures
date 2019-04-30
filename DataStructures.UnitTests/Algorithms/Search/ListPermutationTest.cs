using NUnit.Framework;
using DA.Algorithms.Search;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class ListPermutationTest
    {
        [Test]
        public void CheckPermutation_ListsIsPermutationOfEachOther_ReturnTrue ()
        {
            int[] first = { 1, 2, 3, 4, 5, 6, };
            int[] second = { 2, 1, 3, 4, 6, 5, };

            bool actual = ListPermutation.CheckPermutation (first, second);
            Assert.AreEqual (true, actual);
        }

        [Test]
        public void CheckPermutation_ListsIsNotPermutationOfEachOther_ReturnFalse ()
        {
            int[] first = { 1, 2, 3, 4, 5, 6, };
            int[] second = { 2, 1, 10, 4, 6, 5, };

            bool actual = ListPermutation.CheckPermutation (first, second);
            Assert.AreEqual (false, actual);
        }

        [Test]
        public void CheckPermutationUsingHash_ListsIsPermutationOfEachOther_ReturnTrue ()
        {
            int[] first = { 1, 2, 3, 4, 5, 6, };
            int[] second = { 2, 1, 3, 4, 6, 5, };

            bool actual = ListPermutation.CheckPermutationUsingHash (first, second);
            Assert.AreEqual (true, actual);
        }

        [Test]
        public void CheckPermutationUsingHash_ListsIsNotPermutationOfEachOther_ReturnFalse ()
        {
            int[] first = { 1, 2, 3, 4, 5, 6, };
            int[] second = { 2, 1, 10, 4, 6, 5, };

            bool actual = ListPermutation.CheckPermutationUsingHash (first, second);
            Assert.AreEqual (false, actual);
        }
    }
}
