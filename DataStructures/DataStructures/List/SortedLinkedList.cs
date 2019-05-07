using System;
using System.Collections;
using System.Collections.Generic;

namespace DA.List
{
    public class SortedLinkedList<T> : IEnumerator<T> where T : IComparable<T>
    {
        public class Node<T>
        {
            /// <summary>
            /// Current value
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Link to next element in current list
            /// </summary>
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

        /// <summary>
        /// Link to the first element at list.
        /// </summary>
        Node<T> head;

        Node<T> current;

        public SortedLinkedList ()
        {
            head = null;
            Count = 0;
        }

        public T this[int index]
        {
            get { return GetNode (index).Value; }
            set { GetNode (index).Value = value; }
        }

        /// <summary>
        /// Total amount of elements in list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Check if list contains any element
        /// </summary>
        /// 
        /// <returns>
        /// Returns true if list is empty, otherwise return false.
        /// </returns>
        public bool IsEmpty { get { return Count <= 0; } }

        /// <summary>
        /// Return node at index position.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.InvalidOperationException" />
        private Node<T> GetNode (int index)
        {
            if (index < 0 || index > Count - 1)
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
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
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
                ++Count;
                return;
            }

            while (current.Next != null && current.Next.Value.CompareTo (value) < 0)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;
            ++Count;
        }

        /// <summary>
        /// Remove element from list.
        /// <para>Time Complexity - O(n)</para>
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
                --Count;
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
            --Count;
            return true;
        }

        /// <summary>
        /// Remove all elements that is equal to value from list.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException" />
        /// <param name="value">Values that need delete from list</param>
        public void RemoveAll (T value)
        {
            if (value.Equals (null))
            {
                throw new System.ArgumentNullException ();
            }

            if (head == null)
            {
                throw new System.InvalidOperationException ("List is empty");
            }

            Node<T> currentNode = head;
            Node<T> nextNode;

            while (currentNode != null && currentNode.Value.Equals (value))
            {
                head = currentNode.Next;
                currentNode = head;
                --Count;
            }

            while (currentNode != null)
            {
                nextNode = currentNode.Next;

                if (nextNode != null && nextNode.Value.Equals (value))
                {
                    currentNode.Next = nextNode.Next;
                    --Count;
                }
                else
                {
                    currentNode = nextNode;
                }
            }

        }

        /// <summary>
        /// Remove first element from list.
        /// <para>Time Complexity - O(1)</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException" />
        public void RemoveFirst ()
        {
            if (head == null)
            {
                throw new InvalidOperationException ("List is empty!");
            }

            head = head.Next;
            --Count;
        }

        /// <summary>
        /// Remove last element from list.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException" />
        public void RemoveLast ()
        {
            if (head == null)
            {
                throw new InvalidOperationException ("List is empty!");
            }

            Node<T> current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            --Count;
        }

        /// <summary>
        /// Remove duplicates elements from list.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException" />
        public void RemoveDuplicates ()
        {
            if (head == null)
            {
                throw new InvalidOperationException ("List is empty!");
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Next != null && current.Value.Equals (current.Next.Value))
                {
                    current.Next = current.Next.Next;
                    --Count;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Delete all elements from list.
        /// </summary>
        public void Clear ()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Check if the data exists in list.
        /// <para>Time Complexity - O(n)</para>
        /// </summary>
        /// 
        /// <exception cref="System.ArgumentNullException" />
        /// <param name="data">Value to find</param>
        /// 
        /// <returns>
        /// Returns true if the data exists, otherwise return false.
        /// </returns>
        public bool IsExist (T data)
        {
            if (data.Equals (null))
            {
                throw new System.ArgumentNullException ();
            }

            if (head.Value.Equals (data))
            {
                return true;
            }

            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.Value.Equals (data))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        #region IEnumerator

        public T Current => current.Value;

        object IEnumerator.Current => current.Value;

        public IEnumerator<T> GetEnumerator ()
        {
            return this;
        }

        public void Dispose ()
        {
            Dispose ();
        }

        public bool MoveNext ()
        {
            if (current == null)
            {
                current = head;
                return true;
            }

            current = current.Next;
            if (current.Next != null)
                return true;
            return false;
        }

        public void Reset ()
        {
            current = head;
        }

        #endregion
    }
}
