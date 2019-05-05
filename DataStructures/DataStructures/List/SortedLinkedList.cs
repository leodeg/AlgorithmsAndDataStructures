using System;

namespace DA.List
{
    public class SortedLinkedList<T> where T : IComparable<T>
    {
        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }

            public Node (T value)
            {
                Value = value;
                Next = null;
            }

            public Node (T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        Node<T> head;
        int count;

        public SortedLinkedList ()
        {
            head = null;
            count = 0;
        }

        public T this[int index]
        {
            get { return GetNode (index).Value; }
            set { GetNode (index).Value = value; }
        }

        /// <summary>
        /// Total amount of elements in list.
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Return node at index position.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.InvalidOperationException" />
        private Node<T> GetNode (int index)
        {
            if (index < 0 || index > count - 1)
            {
                throw new System.ArgumentOutOfRangeException ();
            }

            if (head == null)
            {
                throw new System.InvalidOperationException ("List is empty");
            }

            Node<T> current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex.Equals (index))
                {
                    return current;
                }
                current = current.Next;
                ++currentIndex;
            }

            return null;
        }

        /// <summary>
        /// Insert value in sorted order.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="value">Value to insert to list.</param>
        public void Insert (T value)
        {
            if (value.Equals (null))
            {
                throw new System.ArgumentNullException ();
            }

            Node<T> node = new Node<T> (value);
            Node<T> current = head;

            if (current == null || current.Value.CompareTo (value) > 0)
            {
                node.Next = head;
                head = node;
                ++count;
                return;
            }

            while (current.Next != null && current.Next.Value.CompareTo (value) < 0)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;
            ++count;
        }

        /// <summary>
        /// Remove element from list.
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.InvalidOperationException" />
        /// <param name="value">Element that need to remove from list</param>
        /// 
        /// <returns>
        /// If value was deleted return true, otherwise return false.
        /// </returns>
        public bool Remove (T value)
        {
            if (value.Equals (null))
            {
                throw new System.ArgumentNullException ();
            }

            if (head == null)
            {
                throw new System.InvalidOperationException ("List is empty");
            }

            if (head.Value.Equals (value))
            {
                head = head.Next;
                --count;
                return true;
            }

            Node<T> current = head;
            Node<T> previous = null;

            while (current.Next != null && !current.Next.Value.Equals (value))
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = current.Next;
            --count;
            return true;
        }
    }
}
