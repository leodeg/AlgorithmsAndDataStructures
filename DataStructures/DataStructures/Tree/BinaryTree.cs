using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BNode
	{
		public BNode Left { get; set; }
		public BNode Right { get; set; }
		public int Value { get; set; }

		public BNode (int value) : this (value, null, null) { }

		public BNode (BNode left, BNode right) : this (default (int), left, right) { }

		public BNode (int value, BNode left, BNode right)
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
		public enum TraversalType { Preorder, Inorder, Postorder }
		public enum PrintType { Preorder, Inorder, Postorder, BreadthFirst, DepthFirst }
		public enum GetType { Preorder, Postorder, Inorder }

		private delegate BNode TraversalScheme (BNode node);

		private BNode Root { get; set; }

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

		private void PrintPreorder (BNode node)
		{
			if (node == null) return;
			Console.Write (" " + node.Value);
			PrintPreorder (node.Left);
			PrintPreorder (node.Right);
		}

		private void PrintInorder (BNode node)
		{
			if (node == null) return;
			PrintInorder (node.Left);
			Console.Write (" " + node.Value);
			PrintInorder (node.Right);
		}

		private void PrintPostorder (BNode node)
		{
			if (node == null) return;
			PrintPostorder (node.Left);
			PrintPostorder (node.Right);
			Console.Write (" " + node.Value);
		}

		private void PrintBreadthFirst (BNode node)
		{
			if (node == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Queue<BNode> queue = new Queue<BNode> ();
			BNode temp;

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

		private void PrintDepthFirst (BNode node)
		{
			if (node == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty");
			}

			Stack<BNode> stack = new Stack<BNode> ();
			BNode temp;

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

		#region Print Element At index

		public void PrintAt (int index, GetType type)
		{
			if (Root == null)
			{
				throw new System.InvalidOperationException ("BinaryTree: is empty.");
			}

			int[] counter = { 0 };
			switch (type)
			{
				case GetType.Preorder:
					PrintAtIndexPreOrder (index, Root, counter);
					break;

				case GetType.Postorder:
					PrintAtIndexPostOrder (index, Root, counter);
					break;

				case GetType.Inorder:
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

		#region Tree Depth

		public int TreeDepth ()
		{
			return TreeDepth (Root);
		}

		private int TreeDepth (BNode node)
		{
			if (node == null)
			{
				return 0;
			}

			int leftDepth = TreeDepth (node.Left);
			int rightDepth = TreeDepth (node.Right);

			return ( leftDepth > rightDepth ) ? leftDepth + 1 : rightDepth + 1;
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

		#region Number of elements

		public int CountElements ()
		{
			return CountElements (Root);
		}

		private int CountElements (BNode current)
		{
			if (current == null) return 0;
			return 1 + CountElements (current.Left) + CountElements (current.Right);
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

		#region Add Methods

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
	}
}
