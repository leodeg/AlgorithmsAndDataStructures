using NUnit.Framework;
using DA.Algorithms.Problems;

namespace DA.UnitTests.Algorithms
{
    [TestFixture]
    public class PartitionZeroOneTest
    {
        [Test]
        public void Partition01_WhenCalled_ReturnNumberOfSwaps ()
        {
            int[] array = { 0, 1, 1, 0, 1, 0, 1 };
            int actual = PartitionZeroOne.Partition01 (array);
            Assert.AreEqual (2, actual);
        }

        [Test]
        public void Partition012_WhenCalled_SortIntegerArray ()
        {
            int[] array = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int[] expected = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2 };
            PartitionZeroOne.Partition012 (array);
            Assert.AreEqual (expected, array);
        }

        [Test]
        public void PartitionRange_WhenCalled_SortIntegersInArrayByRange ()
        {
            int[] array = { 1, 14, 5, 20, 4, 2, 54, 20, 87, 98, 3, 1, 32 };
            int[] expected = { 1, 5, 4, 2, 1, 3, 14, 20, 20, 98, 87, 32, 54 };

            PartitionZeroOne.PartitionRange (array, 10, 20);
            Assert.AreEqual (array, expected);
        }
    }
}
