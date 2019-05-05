using DA.List;
using NUnit.Framework;

namespace DA.UnitTests.DataStructures
{
    [TestFixture]
    public class SortedLinkedListTest
    {
        [Test]
        public void Insert_WhenCalled_InsertElementAtListInSortedOrder ()
        {
            SortedLinkedList<int> list = new SortedLinkedList<int> ();
            list.Insert (4);
            list.Insert (3);
            list.Insert (2);
            list.Insert (1);
            list.Insert (41);

            Assert.AreEqual (5, list.Count);
            Assert.AreEqual (1, list[0]);
            Assert.AreEqual (2, list[1]);
            Assert.AreEqual (3, list[2]);
            Assert.AreEqual (4, list[3]);
            Assert.AreEqual (41, list[4]);
        }

        [Test]
        public void Remove_WhenCalled_RemoveElementFromList ()
        {
            SortedLinkedList<int> list = new SortedLinkedList<int> ();
            list.Insert (4);
            list.Insert (3);

            Assert.AreEqual (2, list.Count);
            Assert.AreEqual (3, list[0]);
            Assert.AreEqual (4, list[1]);

            list.Remove (3);
            Assert.AreEqual (1, list.Count);
            Assert.AreEqual (4, list[0]);
        }
    }
}
