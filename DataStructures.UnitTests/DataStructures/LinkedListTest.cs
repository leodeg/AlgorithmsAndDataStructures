using DA.List;
using NUnit.Framework;

namespace DA.UnitTests.DataStructures
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void AddFront_WhenCalled_InsertElementAtFrontOfList ()
        {
            LinkedList<int> list = new LinkedList<int> ();
            list.AddFront (1);
            list.AddFront (2);
            list.AddFront (3);
            list.AddFront (4);

            Assert.AreEqual (4, list[0]);
        }

        [Test]
        public void AddLast_WhenCalled_InsertElementAtEndOfList ()
        {
            LinkedList<int> list = new LinkedList<int> ();
            list.AddLast (1);
            list.AddLast (2);
            list.AddLast (3);
            list.AddLast (4);

            Assert.AreEqual (4, list[3]);
        }

        [Test]
        public void AddAfter_WhenCalled_InsertElementAtEndOfList ()
        {
            LinkedList<int> list = new LinkedList<int> ();
            list.AddFront (2);
            list.AddFront (1);
            list.AddAfter (3, 0);

            Assert.AreEqual (3, list[1]);
        }

        [Test]
        public void Remove_WhenCalled_RemoveElementAtIndexFromList ()
        {
            LinkedList<int> list = new LinkedList<int> ();
            list.AddFront (2);
            list.AddFront (1);

            Assert.IsTrue (list.Remove (1));
            Assert.AreEqual (1, list.Count);
            Assert.AreEqual (1, list[0]);
        }

        [Test]
        public void Remove_WhenCalled_RemoveElementByValueFromList ()
        {
            LinkedList<string> list = new LinkedList<string> ();
            list.AddFront ("John");
            list.AddFront ("Jeki");
            list.AddFront ("Judi");

            Assert.IsTrue (list.Remove ("Jeki"));
            Assert.AreEqual (2, list.Count);
            Assert.AreEqual ("Judi", list[0]);
        }
    }
}
