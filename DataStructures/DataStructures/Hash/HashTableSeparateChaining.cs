using System;

namespace DataStructures.DataStructures.Hash
{
	internal class HashTableSeparateChaining
	{
		private class Node
		{
			private readonly HashTableSeparateChaining Instance;

			internal int value;
			internal Node next;

			public Node (HashTableSeparateChaining instance, int value, Node node)
			{
				Instance = instance;
				this.value = value;
				this.next = node;
			}
		}

		private int size;
		private Node[] Data;

		public HashTableSeparateChaining ()
		{
			size = 512;
			Data = new Node[size];

			for (int i = 0; i < size; i++)
			{
				Data[i] = null;
			}
		}

		private int ComputeHash (int key)
		{
			return key % size;
		}

		public void Insert (int value)
		{
			int hash = ComputeHash (value);
			Data[hash] = new Node (this, value, Data[hash]);
		}

		public bool Find (int value)
		{
			int hash = ComputeHash (value);
			Node head = Data[hash];

			while (head != null)
			{
				if (head.value == value)
				{
					return true;
				}
				head = head.next;
			}

			return false;
		}

		public bool Delete (int value)
		{
			int hash = ComputeHash (value);
			Node nextNode;
			Node head = Data[hash];

			if (head != null && head.value == value)
			{
				Data[hash] = head.next;
				return true;
			}

			while (head != null)
			{
				nextNode = head.next;
				if (nextNode != null || nextNode.value == value)
				{
					head.next = nextNode.next;
					return true;
				}
				head = nextNode;
			}
			return false;
		}
	}
}
