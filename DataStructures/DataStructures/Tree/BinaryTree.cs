using System;
using System.Collections.Generic;

namespace DA.Tree
{
	public class BinaryTree
	{
		#region Enumerators

		public enum TraversalType
		{
			Preorder,
			Inorder,
			Postorder
		}

		public enum PrintType
		{
			Preorder,
			Inorder,
			Postorder,
			BreadthFirst,
			DepthFirst
		}

		public enum PrintAtType
		{
			Preorder,
			Postorder,
			Inorder
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Create empty tree with one empty node.
		/// </summary>
		public BinaryTree ()
		{
			Root = null;
		}

		/// <summary>
		/// Create tree with one node that hold the value.
		/// </summary>
		public BinaryTree (int value)
		{
			Root = new BNode (value);
		}

		#endregion

		#region Properties

		private BNode Root { get; set; }

		/// <summary>
		/// Return first node.
		/// </summary>
		public BNode First => Root;

		/// <summary>
		/// Return value of the first node.
		/// </summary>
		public int FirstValue => Root.Value;

		#endregion

		#region Find Node

		/// <summary>
		/// Find node by value.
		/// </summary>
		/// <param name="value">value that need to find</param>
		public BNode FindNode (int value)
		{
			BNode root = Root;
			while (root != null)
			{
				int current = root.Value;
				if (current.Equals (value)) break;
				if (current < value) root = root.Right;
				else root = root.Left;
			}
			return root;
		}

		/// <summary>
		/// Find node by value. Required a root (first) node of the current tree.
		/// </summary>
		/// <param name="root">first node of the current tree</param>
		/// <param name="value">value that need to find</param>
		public BNode FindNode (BNode root, int value)
		{
			if (root == null) return null;

			int current = root.Value;
			if (current.Equals (value)) return root;
			if (current < value) return FindNode (root.Right, value);
			else return FindNode (root.Left, value);
		}

		#endregion

		#region Search

		public bool Search (int value)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty.");
			}

			return Search (Root, value);
		}

		private bool Search (BNode root, int value)
		{
			int max;
			bool left;
			bool right;

			if (root == null) return false;
			if (root.Value == value) return true;

			left = Search (root.Left, value);
			if (left) return true;

			right = Search (root.Right, value);
			if (right) return true;

			return false;
		}

		#endregion

		#region Find max value and total sum of BT

		public int FindMax ()
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty.");
			}

			return FindMax (Root);
		}

		private int FindMax (BNode current)
		{
			int left;
			int right;

			if (current == null) return int.MinValue;
			int max = current.Value;

			left = FindMax (current.Left);
			right = FindMax (current.Right);

			if (left > max) max = left;
			if (right > max) max = right;
			return max;
		}

		public int MaxPath ()
		{
			return MaxPath (Root);
		}

		private int MaxPath (BNode current)
		{
			int max;
			int leftPath, rightPath;
			int leftMax, rightMax;

			if (current == null) return 0;

			leftPath = TreeDepth (current.Left);
			rightPath = TreeDepth (current.Right);

			max = leftPath + rightPath + 1;

			leftMax = MaxPath (current.Left);
			rightMax = MaxPath (current.Right);

			if (leftMax > max) return leftMax;
			if (rightMax > max) return rightMax;
			return max;
		}

		public int TotalSum ()
		{
			return TotalSum (Root);
		}

		private int TotalSum (BNode current)
		{
			int sum;
			int leftSum;
			int rightSum;

			if (current == null) return 0;
			leftSum = TotalSum (current.Left);
			rightSum = TotalSum (current.Right);

			sum = rightSum + leftSum + current.Value;
			return sum;
		}

		#endregion

		#region Least Common Ancestor

		public int LeastCommonAcestor (int first, int second)
		{
			BNode ancestor = LeastCommonAcestor (Root, first, second);

			if (ancestor != null)
				return ancestor.Value;

			return int.MinValue;
		}

		private BNode LeastCommonAcestor (BNode current, int first, int second)
		{
			BNode left;
			BNode right;

			if (current == null)
			{
				return null;
			}

			if (current.Value == first || current.Value == second)
			{
				return current;
			}

			left = LeastCommonAcestor (current.Left, first, second);
			right = LeastCommonAcestor (current.Right, first, second);

			if (left != null && right != null)
			{
				return current;
			}
			else if (left != null)
			{
				return left;
			}
			else
			{
				return right;
			}
		}

		#endregion

		#region Add

		public void LevelOrderBinaryTree (int[] arr)
		{
			Root = LevelOrderBinaryTree (arr, 0);
		}

		private BNode LevelOrderBinaryTree (int[] dataArray, int start)
		{
			int size = dataArray.Length;
			BNode currentNode = new BNode (dataArray[start]);

			int leftIndex = 2 * start + 1;
			int rightIndex = 2 * start + 2;

			if (leftIndex < size)
			{
				currentNode.Left = LevelOrderBinaryTree (dataArray, leftIndex);
			}
			if (rightIndex < size)
			{
				currentNode.Right = LevelOrderBinaryTree (dataArray, rightIndex);
			}

			return currentNode;
		}

		#endregion

		#region Traversal

		/// <summary>
		/// Calculate height of tree.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="node">first node of tree</param>
		public static int TreeHeight (BNode node)
		{
			if (node == null) return 0;
			return 1 + Math.Max (TreeHeight (node.Left), TreeHeight (node.Right));
		}

		/// <summary>
		/// Traverse through the tree and print values of each node.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="type">type of traversal method</param>
		public void Traversal (TraversalType type)
		{
			switch (type)
			{
				case TraversalType.Preorder:
					PreorderTraversal (Root);
					break;

				case TraversalType.Inorder:
					InorderTraversal (Root);
					break;

				case TraversalType.Postorder:
					PostorderTraversal (Root);
					break;

				default:
					throw new System.ArgumentOutOfRangeException ();
			}
		}

		/// <summary>
		/// Traverse through the tree in preorder way and print all values.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="node">root of tree</param>
		public void PreorderTraversal (BNode node)
		{
			if (node == null) return;
			node.PrintValue ();
			PreorderTraversal (node.Left);
			PreorderTraversal (node.Right);
		}

		/// <summary>
		/// Traverse through the tree in inorder way and print all values.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="node">root of tree</param>
		public void InorderTraversal (BNode node)
		{
			if (node == null) return;
			InorderTraversal (node.Left);
			node.PrintValue ();
			InorderTraversal (node.Right);
		}

		/// <summary>
		/// Traverse through the tree in postorder way and print all values.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="node">root of tree</param>
		public void PostorderTraversal (BNode node)
		{
			if (node == null) return;
			InorderTraversal (node.Left);
			InorderTraversal (node.Right);
			node.PrintValue ();
		}

		#endregion

		#region Tree Depth

		public int TreeDepth ()
		{
			return TreeDepth (Root);
		}

		private int TreeDepth (BNode root)
		{
			if (root == null)
			{
				return 0;
			}

			int leftDepth = TreeDepth (root.Left);
			int rightDepth = TreeDepth (root.Right);

			return ( leftDepth > rightDepth ) ? leftDepth + 1 : rightDepth + 1;
		}

		#endregion

		#region Print Tree

		public void Print (PrintType type)
		{
			switch (type)
			{
				case PrintType.Preorder:
					PrintPreorder (Root);
					break;

				case PrintType.Inorder:
					PrintInorder (Root);
					break;

				case PrintType.Postorder:
					PrintPostorder (Root);
					break;

				case PrintType.BreadthFirst:
					PrintBreadthFirst (Root);
					break;

				case PrintType.DepthFirst:
					PrintDepthFirst (Root);
					break;

				default:
					throw new System.ArgumentOutOfRangeException ();
			}
		}

		private void PrintPreorder (BNode root)
		{
			if (root == null) return;
			Console.Write (" " + root.Value);
			PrintPreorder (root.Left);
			PrintPreorder (root.Right);
		}

		private void PrintInorder (BNode root)
		{
			if (root == null) return;
			PrintInorder (root.Left);
			Console.Write (" " + root.Value);
			PrintInorder (root.Right);
		}

		private void PrintPostorder (BNode root)
		{
			if (root == null) return;
			PrintPostorder (root.Left);
			PrintPostorder (root.Right);
			Console.Write (" " + root.Value);
		}

		private void PrintBreadthFirst (BNode root)
		{
			if (root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Queue<BNode> queue = new Queue<BNode> ();
			BNode temp;

			if (root != null)
			{
				queue.Enqueue (root);
			}

			while (queue.Count != 0)
			{
				temp = queue.Dequeue ();
				Console.Write (" " + temp.Value);

				if (temp.Left != null)
				{
					queue.Enqueue (temp.Left);
				}
				if (temp.Right != null)
				{
					queue.Enqueue (temp.Right);
				}
			}
		}

		private void PrintDepthFirst (BNode root)
		{
			if (root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Stack<BNode> stack = new Stack<BNode> ();
			BNode temp;

			if (root != null)
			{
				stack.Push (root);
			}

			while (stack.Count != 0)
			{
				temp = stack.Pop ();
				Console.Write (" " + temp.Value);

				if (temp.Left != null)
				{
					stack.Push (temp.Left);
				}
				if (temp.Right != null)
				{
					stack.Push (temp.Right);
				}
			}
		}

		#endregion

		#region Print element at index

		public void PrintAt (int index, PrintAtType type)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty.");
			}

			int[] counter = { 0 };
			switch (type)
			{
				case PrintAtType.Preorder:
					PrintAtIndexPreOrder (index, Root, counter);
					break;

				case PrintAtType.Postorder:
					PrintAtIndexPostOrder (index, Root, counter);
					break;

				case PrintAtType.Inorder:
					PrintAtIndexInOrder (index, Root, counter);
					break;

				default: throw new System.ArgumentOutOfRangeException ();
			}
		}

		private void PrintAtIndexPreOrder (int index, BNode node, int[] counter)
		{
			if (node == null) return;

			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write (" " + node.Value);
			}

			PrintAtIndexPreOrder (index, node.Left, counter);
			PrintAtIndexPreOrder (index, node.Right, counter);
		}

		private void PrintAtIndexPostOrder (int index, BNode node, int[] counter)
		{
			if (node == null) return;
			PrintAtIndexPostOrder (index, node.Left, counter);
			PrintAtIndexPostOrder (index, node.Right, counter);

			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write (" " + node.Value);
			}
		}

		private void PrintAtIndexInOrder (int index, BNode node, int[] counter)
		{
			if (node == null) return;
			PrintAtIndexInOrder (index, node.Left, counter);
			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write (" " + node.Value);
			}
			PrintAtIndexInOrder (index, node.Right, counter);
		}

		#endregion

		#region Print path

		public void PrintPath ()
		{
			Stack<int> stack = new Stack<int> ();
			PrintPath (Root, stack);
		}

		private void PrintPath (BNode current, Stack<int> stack)
		{
			if (current == null) return;

			stack.Push (current.Value);
			if (current.Left == null && current.Right == null)
			{
				Console.WriteLine (stack.ToString());
				stack.Pop ();
				return;
			}

			PrintPath (current.Left, stack);
			PrintPath (current.Right, stack);
			stack.Pop ();
		}

		#endregion

		#region Copy

		public BinaryTree Copy ()
		{
			BinaryTree tree = new BinaryTree ();
			tree.Root = Copy (Root);
			return tree;
		}

		private BNode Copy (BNode current)
		{
			if (current == null) return null;

			BNode temp = new BNode (current.Value);
			temp.Left = Copy (current.Left);
			temp.Right = Copy (current.Right);
			return temp;

		}

		public BinaryTree CopyMirror ()
		{
			BinaryTree tree = new BinaryTree ();
			tree.Root = CopyMirror (Root);
			return tree;
		}

		private BNode CopyMirror (BNode current)
		{
			if (current == null) return null;

			BNode temp = new BNode (current.Value);
			temp.Right = CopyMirror (current.Left);
			temp.Left = CopyMirror (current.Right);
			return temp;

		}

		#endregion

		#region Count elements

		public int CountElements ()
		{
			return CountElements (Root);
		}

		private int CountElements (BNode current)
		{
			if (current == null) return 0;
			return 1 + CountElements (current.Left) + CountElements (current.Right);
		}

		public int CountFullNodes ()
		{
			return CountFullNodes (Root);
		}

		private int CountFullNodes (BNode current)
		{
			int count;
			if (current == null) return 0;

			count = CountFullNodes (current.Left);
			count += CountFullNodes (current.Right);

			if (current.Left != null && current.Right != null)
			{
				count++;
			}

			return count;
		}

		public int CountLeafs ()
		{
			return CountLeafs (Root);
		}

		private int CountLeafs (BNode current)
		{
			if (current == null) return 0;
			if (current.Left == null && current.Right == null) return 1;
			return CountLeafs (current.Left) + CountLeafs (current.Right);
		}

		#endregion

		#region Equal

		public bool IsEqual (BinaryTree other)
		{
			return IsEqual (Root, other.Root);
		}

		private bool IsEqual (BNode current, BNode other)
		{
			if (current == null && other == null) return true;
			if (current == null || other == null) return false;

			return current.Value == other.Value
				&& IsEqual (current.Left, other.Left)
				&& IsEqual (current.Right, other.Right);
		}

		#endregion

		#region Rotate

		public static BNode RotateRight (BNode oldRoot)
		{
			BNode newRoot = oldRoot.Left;
			oldRoot.Left = newRoot.Right;
			newRoot.Right = oldRoot;
			return newRoot;
		}

		/// <summary>
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		public BNode RotateRight ()
		{
			BNode node = Root.Left;
			Root.Left = node.Right;
			node.Right = Root;
			return node;
		}

		#endregion

		#region Convert

		//TODO: add converter method from tree to list 

		#endregion

		#region Clear

		public void Clear ()
		{
			Root = null;
		}

		#endregion
	}
}
