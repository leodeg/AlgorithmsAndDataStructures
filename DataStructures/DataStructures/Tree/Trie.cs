namespace DA.DataStructures.Tree
{
    public class Trie
    {
        private class Node
        {
            public bool isLast;
            public char character;
            public Node [] childs;

            public Node (char character)
            {
                isLast = false;
                this.character = character;

                childs = new Node [CharCount];
                for (int i = 0; i < CharCount; i++)
                    childs [i] = null;
            }
        }

        private const int CharCount = 26;
        private Node root = null;


        public Trie ()
        {
            root = new Node (' ');
        }

        public void Insert (string text)
        {
            if (string.ReferenceEquals (text, null))
                throw new System.ArgumentNullException ();

            Insert (root, text.ToLower (), 0);
        }

        private Node Insert (Node currentNode, string text, int index)
        {
            if (currentNode == null)
            {
                currentNode = new Node (text [index - 1]);
            }

            if (text.Length == index)
            {
                currentNode.isLast = true;
            }
            else
            {
                int currentIndex = text [index] - 'a';
                currentNode.childs [currentIndex] = Insert (currentNode.childs [currentIndex], text, index + 1);
            }

            return currentNode;
        }

        public bool Find (string text)
        {
            if (string.ReferenceEquals (text, null))
                throw new System.ArgumentNullException ();

            text = text.ToLower ();
            return Find (root, text, 0);
        }

        private bool Find (Node current, string text, int index)
        {
            if (current == null) return false;
            if (text.Length == index) return current.isLast;
            return Find (current.childs [text [index] - 'a'], text, index + 1);
        }

        public void Remove (string text)
        {
            if (string.ReferenceEquals (text, null))
                throw new System.ArgumentNullException ();

            text = text.ToLower ();
            Remove (root, text, 0);
        }

        private void Remove (Node current, string text, int index)
        {
            if (current == null) return;
            if (text.Length == index)
            {
                if (current.isLast)
                    current.isLast = false;
                return;
            }
            Remove (current.childs [text [index] - 'a'], text, index + 1);
        }
    }
}
