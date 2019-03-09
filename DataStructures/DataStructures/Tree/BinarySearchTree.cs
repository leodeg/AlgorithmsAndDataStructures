using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
	internal class BinarySearchTree
	{
		#region Constructors

		public BinarySearchTree ()
		{
			Root = null;
		}

		public BinarySearchTree (int value)
		{
			Root = new BNode (value);
		}

		private BNode Root
		{
			get { return Root; }
			set { Root = value; }
		}

		#endregion

		#region Properties

		public int Max { get { return FindMax(); } }
		public int Min { get { return FindMin (); } }
		public bool IsBST { get { return IsBinarySearchTreeUtil (); } }

		#endregion

		#region Add

		public void Create (int[] arr)
		{
			Root = Create (arr, 0, arr.Length - 1);
		}

		public BNode Create (int[] arr, int start, int end)
		{
			BNode current = null;

			if (start > end)
				return null;

			int middle = ( start + end ) / 2;
			current = new BNode (arr[middle]);
			current.Left = Create (arr, start, middle - 1);
			current.Right = Create (arr, middle + 1, end);
			return current;
		}

		public void Insert (int value)
		{
			Root = Insert (value, Root);
		}

		private BNode Insert (int value, BNode node)
		{
			if (node == null)
			{
				node = new BNode (value);
			}
			else
			{
				if (node.Value > value)
				{
					node.Left = Insert (value, node.Left);
				}
				else
				{
					node.Right = Insert (value, node.Right);
				}
			}
			return node;
		}

		#endregion

		#region Delete



		#endregion

		#region Find

		public bool Find (int value)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode current = Root;

			while (current != null)
			{
				if (current.Value == value)
				{
					return true;
				}

				if (current.Value > value)
				{
					current = current.Left;
				}
				else
				{
					current = current.Right;
				}
			}
			return false;
		}

		public bool Find (int value, out int container)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode current = Root;


			while (current != null)
			{
				if (current.Value == value)
				{
					container = current.Value;
					return true;
				}

				if (current.Value > value)
				{
					current = current.Left;
				}
				else
				{
					current = current.Right;
				}
			}

			container = int.MinValue;
			return false;
		}

		public int FindMin ()
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = Root;
			while (node.Left != null)
			{
				node = node.Left;
			}
			return node.Value;
		}

		public int FindMax ()
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = Root;
			while (node.Right != null)
			{
				node = node.Right;
			}
			return node.Value;
		}

		private BNode FindMax (BNode root)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = root;
			while (node.Right != null)
			{
				node = node.Right;
			}
			return node;
		}

		private BNode FindMin (BNode root)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = root;
			while (node.Left != null)
			{
				node = node.Left;
			}
			return node;
		}

		#endregion

		#region Is Binary Search Tree

		private bool IsBinarySearchTree (BNode root)
		{
			if (root == null)
			{
				return true;
			}

			if (root.Left != null && FindMax(root.Left).Value > root.Value)
			{
				return false;
			}

			if (root.Right != null && FindMin(root.Right).Value <= root.Value)
			{
				return false;
			}

			return ( IsBinarySearchTree (root.Left) && IsBinarySearchTree (root.Right) );
		}

		private bool IsBinarySearchTreeUtil ()
		{
			return IsBinarySearchTreeUtil (Root, int.MinValue, int.MaxValue);
		}

		private bool IsBinarySearchTreeUtil (BNode current, int min, int max)
		{
			if (current == null)
			{
				return true;
			}

			if (current.Value < min || current.Value > max)
			{
				return false;
			}

			return ( IsBinarySearchTreeUtil (current.Left, min, current.Value) && IsBinarySearchTreeUtil (current.Right, current.Value, max) );
		}

		#endregion
	}
}
