using NUnit.Framework;
using DA.Algorithms.Problems;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class ShuffleListTest
    {
        [Test]
        public void ShuffleList_WhenCalled_SortArray ()
        {
            char[] actual = { '1', '2', '3', '4', '5', '6', '7', '8' };
            char[] expected = { '1', '5', '2', '6', '3', '7', '4', '8' };

            ShuffleList.ShuffleArray (actual);
            Assert.AreEqual (expected, actual);
        }
    }
}
