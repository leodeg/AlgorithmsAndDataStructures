using System;

namespace DA.List
{
    public class LinkedList<T>
    {
        /// <summary>
        /// Handle a value and a link to the next element in list of type T.
        /// </summary>
        public class Node<T>
        {
            /// <summary>
            /// Value of the current node.
            /// </summary>
            internal T Value { get; set; }

            /// <summary>
            /// Link to next node.
            /// </summary>
            internal Node<T> Next { get; set; }

            public Node (T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }

            public Node (T value)
            {
                Value = value;
                Next = null;
            }

            public Node () : this (default (T)) { }
        }


        public LinkedList ()
        {
            Head = new Node<T> (default (T));
        }

        #region Properties

        private Node<T> Head { get; set; }

        /// <summary>
        /// Return total number of elements in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Check if the list is empty of not.
        /// </summary>
        public bool IsEmpty { get { return Count == 0; } }

        /// <summary>
        /// Return copy of the first element in the list.
        /// </summary>
        public Node<T> FirstElement { get { return Head; } }

        /// <summary>
        /// Return copy of the last element in the list.
        /// </summary>
        public Node<T> LastElement { get { return GetLast (); } }

        /// <summary>
        /// Allows to use array syntax to work with list values.
        /// </summary>
        public T this[int index]
        {
            get { return GetNodeAt (index).Value; }
            set { GetNodeAt (index).Value = value; }
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Get the last node of a list.
        /// </summary>
        private Node<T> GetLast ()
        {
            if (Head == null)
                return null;

            Node<T> temp = Head;
            while (temp.Next != null)
                temp = temp.Next;
            return temp;
        }

        /// <summary>
        /// Return element from index position.
        /// </summary>
        private Node<T> GetNodeAt (int index)
        {
            if (index < 0 || index > Count - 1)
                throw new ArgumentOutOfRangeException ();

            if (index == 0)
                return Head;

            Node<T> temp = Head;
            int count = 0;

            while (temp != null && count <= index)
            {
                temp = temp.Next;
                ++count;
            }

            return temp;
        }

        /// <summary>
        /// Return a first node that has the particular value.
        /// </summary>
        private Node<T> GetNode (T value)
        {
            if (Head.Value.Equals (value))
                return Head;

            Node<T> temp = Head;
            while (!temp.Value.Equals (value) && temp != null)
            {
                temp = temp.Next;
            }

            return temp;
        }

        #endregion

        #region Add Methods

        /// <summary>
        /// Insert value at front of list.
        /// </summary>
        public void AddFront (T value)
        {
            Node<T> node = new Node<T> (value);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }

            ++Count;
        }

        /// <summary>
        /// Add value to end of list.
        /// </summary>
        public void AddLast (T value)
        {
            Node<T> node = new Node<T> (value);
            if (Head == null) Head = node;
            else GetLast ().Next = node;
            ++Count;
        }

        /// <summary>
        /// Insert an element after index element.
        /// </summary>
        public void AddAfter (T value, int index)
        {
            if (index < 0 || index > Count - 1)
                throw new ArgumentOutOfRangeException ();

            Node<T> node = new Node<T> (value);

            Node<T> temp = Head;
            int counter = 0;
            while (temp != null && counter <= index)
            {
                temp = temp.Next;
                ++counter;
            }

            node.Next = temp.Next;
            temp.Next = node;

            ++Count;
        }

        #endregion

        #region Remove Methods

        /// <summary>
        /// Remove value from the list.
        /// </summary>
        public bool Remove (T value)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            if (current != null && current.Value.Equals (value))
            {
                Head = Head.Next;
                --Count;
                return true;
            }

            while (current.Next != null && !current.Value.Equals (value))
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }

            previous.Next = current.Next;
            --Count;
            return true;
        }

        /// <summary>
        /// Remove element in the list at the index position.
        /// </summary>
        public bool Remove (int index)
        {
            if (index < 0 || index > Count - 1)
                throw new ArgumentOutOfRangeException ();

            Node<T> temp = GetNodeAt (index - 1);

            if (temp == null)
                return false;

            temp.Next = temp.Next.Next;
            --Count;
            return true;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Reverse the list.
        /// </summary>
        public void Reverse ()
        {
            Node<T> previous = null;
            Node<T> current = Head;
            Node<T> temp = null;

            while (current != null)
            {
                temp = current.Next; // Save to move one
                current.Next = previous; // Save and link previous value
                previous = current; // Save current value
                current = temp; // Move to next value
            }

            Head = previous; // Change head to last element
        }

        /// <summary>
        /// If list is cycled return true, otherwise return false.
        /// <para>Time Complexity - BigO(n)</para>
        /// </summary>
        public bool IsCycled ()
        {
            Node<T> slow = Head;
            Node<T> fast = Head.Next;

            while (true)
            {
                if (fast == null || fast.Next == null)
                {
                    return false;
                }
                else if (fast == slow || fast.Next == slow)
                {
                    return true;
                }
                else
                {
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }
            }
        }

        #endregion
    }
}
