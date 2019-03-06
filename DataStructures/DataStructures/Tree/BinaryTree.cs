using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BinaryNode
	{
		public BinaryNode Left { get; set; }
		public BinaryNode Right { get; set; }
		public int Value { get; set; }

		public BinaryNode (int value) : this (value, null, null) { }

		public BinaryNode (BinaryNode left, BinaryNode right) : this (default (int), left, right) { }

		public BinaryNode (int value, BinaryNode left, BinaryNode right)
		{
			Left = left;
			Right = right;
			Value = value;
		}

		public void PrintValue ()
		{
			System.Console.Write ("[{0}]", Value.ToString ());
		}

		public override string ToString ()
		{
			return String.Format ("[{0}]", Value.ToString ());
		}
	}

	public class BinaryTree
	{
		public enum TraversalType { Preorder, Inorder, Postorder, BreadthFirst }
		public enum PrintType { Preorder, Inorder, Postorder, BreadthFirst, DepthFirst }

		private delegate BinaryNode TraversalScheme (BinaryNode node);

		/// <summary>
		/// The most base node of tree.
		/// </summary>
		private BinaryNode Root { get; set; }

		#region Constructors

		/// <summary>
		/// Create empty tree with one empty node.
		/// </summary>
		public BinaryTree ()
		{
			Root = null;
			Count = 0;
		}

		/// <summary>
		/// Create tree with one node that hold the value.
		/// </summary>
		public BinaryTree (int value)
		{
			Root = new BinaryNode (value);
			Count++;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Length of the binary tree.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Return first node.
		/// </summary>
		public BinaryNode First => Root;

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
		public BinaryNode FindNode (int value)
		{
			BinaryNode root = Root;
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
		public BinaryNode FindNode (BinaryNode root, int value)
		{
			if (root == null) return null;

			int current = root.Value;
			if (current.Equals (value)) return root;
			if (current < value) return FindNode (root.Right, value);
			else return FindNode (root.Left, value);
		}

		#endregion

		#region Traversal

		/// <summary>
		/// Calculate height of tree.
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		/// <param name="node">first node of tree</param>
		public static int TreeHeight (BinaryNode node)
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
		public void PreorderTraversal (BinaryNode node)
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
		public void InorderTraversal (BinaryNode node)
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
		public void PostorderTraversal (BinaryNode node)
		{
			if (node == null) return;
			InorderTraversal (node.Left);
			InorderTraversal (node.Right);
			node.PrintValue ();
		}

		#endregion

		#region Print Methods

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

		private void PrintPreorder (BinaryNode node)
		{
			if (node == null) return;
			Console.Write (" " + node.Value);
			PrintPreorder (node.Left);
			PrintPreorder (node.Right);
		}

		private void PrintInorder (BinaryNode node)
		{
			if (node == null) return;
			PrintInorder (node.Left);
			Console.Write (" " + node.Value);
			PrintInorder (node.Right);
		}

		private void PrintPostorder (BinaryNode node)
		{
			if (node == null) return;
			PrintPostorder (node.Left);
			PrintPostorder (node.Right);
			Console.Write (" " + node.Value);
		}

		private void PrintBreadthFirst (BinaryNode node)
		{
			if (node == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Queue<BinaryNode> queue = new Queue<BinaryNode> ();
			BinaryNode temp;

			if (node != null)
			{
				queue.Enqueue (node);
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

		private void PrintDepthFirst (BinaryNode node)
		{
			if (node == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Stack<BinaryNode> stack = new Stack<BinaryNode> ();
			BinaryNode temp;

			if (node != null)
			{
				stack.Push (node);
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

		#region Tree Depth

		public int TreeDepth ()
		{
			return TreeDepth (Root);
		}

		private int TreeDepth (BinaryNode node)
		{
			if (node == null)
			{
				return 0;
			}

			int leftDepth = TreeDepth (node.Left);
			int rightDepth = TreeDepth (node.Right);

			return (leftDepth > rightDepth) ? leftDepth + 1 : rightDepth + 1;
		}

		#endregion

		#region Rotate

		public static BinaryNode RotateRight (BinaryNode oldRoot)
		{
			BinaryNode newRoot = oldRoot.Left;
			oldRoot.Left = newRoot.Right;
			newRoot.Right = oldRoot;
			return newRoot;
		}

		/// <summary>
		/// <para>Time Complexity - BigO(n)</para>
		/// </summary>
		public BinaryNode RotateRight ()
		{
			BinaryNode node = Root.Left;
			Root.Left = node.Right;
			node.Right = Root;
			return node;
		}

		#endregion

		#region Add Methods

		public void LevelOrderBinaryTree (int[] arr)
		{
			Root = LevelOrderBinaryTree (arr, 0);
		}

		private BinaryNode LevelOrderBinaryTree (int[] dataArray, int start)
		{
			int size = dataArray.Length;
			BinaryNode currentNode = new BinaryNode (dataArray[start]);

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
	}
}
