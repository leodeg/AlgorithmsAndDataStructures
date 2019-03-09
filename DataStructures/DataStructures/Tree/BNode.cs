using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
	public class BNode
	{
		public BNode Left { get; set; }
		public BNode Right { get; set; }
		public int Value { get; set; }

		public BNode (int value) 
			: this (value, null, null) { }

		public BNode (BNode left, BNode right) 
			: this (default (int), left, right) { }

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
}
