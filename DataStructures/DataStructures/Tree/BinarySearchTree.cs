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

		public int Max { get { return FindMax (); } }
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
				if (node.Value.CompareTo (value) > 0)
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

		public void Delete (int value)
		{
			Root = Delete (Root, value);
		}

		private BNode Delete (BNode node, int value)
		{
			BNode temp = null;

			if (node != null)
			{
				if (node.Value.Equals (value))
				{
					if (node.Left.Equals (null)
						&& node.Right.Equals (null))
					{
						return null;
					}
					else
					{
						if (node.Left.Equals (null))
						{
							temp = node.Right;
							return temp;
						}

						if (node.Right.Equals (null))
						{
							temp = node.Left;
							return temp;
						}

						BNode maxNode = FindMax (node.Left);
						int maxValue = maxNode.Value;

						node.Value = maxValue;
						node.Left = Delete (node.Left, maxValue);
					}
				}
				else
				{
					if (node.Value.CompareTo (value) > 0)
					{
						node.Left = Delete (node.Left, value);
					}
					else
					{
						node.Right = Delete (node.Right, value);
					}
				}
			}

			return node;
		}

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
				if (current.Value.Equals (value))
				{
					return true;
				}

				if (current.Value.CompareTo (value) > 0)
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


			while (!current.Equals (null))
			{
				if (current.Value.Equals (value))
				{
					container = current.Value;
					return true;
				}

				if (current.Value.CompareTo (value) > 0)
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
			if (Root.Equals (null))
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = Root;
			while (!node.Left.Equals (null))
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
			while (!node.Right.Equals (null))
			{
				node = node.Right;
			}
			return node.Value;
		}

		private BNode FindMax (BNode root)
		{
			if (Root.Equals (null))
			{
				throw new System.InvalidOperationException ("Tree: is empty");
			}

			BNode node = root;
			while (!node.Right.Equals (null))
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
			while (!node.Left.Equals (null))
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

			if (!root.Left.Equals (null)
				&& FindMax (root.Left).Value.CompareTo (root.Value) > 0)
			{
				return false;
			}

			if (root.Right != null
				&& FindMin (root.Right).Value.CompareTo (root.Value) <= 0)
			{
				return false;
			}

			return ( IsBinarySearchTree (root.Left)
				&& IsBinarySearchTree (root.Right) );
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

			if (current.Value.CompareTo (min) < 0
				|| current.Value.CompareTo (max) > 0)
			{
				return false;
			}

			return ( IsBinarySearchTreeUtil (current.Left, min, current.Value)
				&& IsBinarySearchTreeUtil (current.Right, current.Value, max) );
		}

		#endregion

		#region Least Common Ancestor

		public int LeastCommonAcenstor (int first, int second)
		{
			return LeastCommonAcenstor (Root, first, second);
		}

		private int LeastCommonAcenstor (BNode current, int first, int second)
		{
			if (current.Equals (null))
			{
				return int.MaxValue;
			}

			if (current.Value.CompareTo (first) > 0
				&& current.Value.CompareTo (second) > 0)
			{
				return LeastCommonAcenstor (current.Left, first, second);
			}

			if (current.Value.CompareTo (first) < 0
				&& current.Value.CompareTo (second) < 0)
			{
				return LeastCommonAcenstor (current.Right, first, second);
			}

			return current.Value;
		}

		#endregion
	}
}
