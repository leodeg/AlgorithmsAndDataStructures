using System;
using System.Collections.Generic;

namespace DA.DataStructures.Tree
{
    public class TernarySearchTrie
    {
        private class Node
        {
            public char data;
            public bool isLast;

            public Node left;
            public Node equal;
            public Node right;
            private TernarySearchTrie trie;

            public Node (char data)
            {
                this.data = data;
                isLast = false;
                left = equal = right = null;
            }

            public Node (TernarySearchTrie trie, char data)
            {
                this.trie = trie;
                this.data = data;
            }
        }

        private Node root;

        public TernarySearchTrie ()
        {
            root = null;
        }

        public virtual void Insert (string word)
        {
            root = Insert (root, word, 0);
        }

        private Node Insert (Node current, string word, int index)
        {
            if (current == null)
                current = new Node (this, word [index]);

            if (word [index] < current.data)
                current.left = Insert (current.left, word, index);

            else if (word [index] > current.data)
                current.right = Insert (current.right, word, index);

            else if (index < word.Length - 1)
                current.equal = Insert (current.equal, word, index + 1);

            else current.isLast = true;

            return current;
        }



        public virtual bool Find (string word)
        {
            return Find (root, word, 0);
        }

        private bool Find (Node current, string word, int index)
        {
            if (current == null) return false;

            if (word [index] < current.data)
                return Find (current.left, word, index);

            if (word [index] > current.data)
                return Find (current.right, word, index);

            if (index == word.Length - 1)
                return current.isLast;

            return Find (current.equal, word, word.Length + 1);
        }
    }
}
