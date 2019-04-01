using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DataStructures.Hash
{
	class HashTable
	{
		private static int EmptyNode = -1;
		private static int LazyDeleted = -2;
		private static int FilledNode = 0;

		private int size;
		internal int[] Data;
		internal int[] Flag;

		public HashTable (int size)
		{
			this.size = size;
			Data = new int[size + 1];
			Flag = new int[size + 1];

			for (int i = 0; i <= size; i++)
			{
				Flag[i] = EmptyNode;
			}
		}

		public int Size { get { return size; } }
		public bool IsEmpty { get { return size <= 0; } }

		internal virtual int ComputeHash (int key)
		{
			return key % size;
		}

		internal virtual int ResolveCollision (int index)
		{
			return index;
		}

		internal virtual bool InsertNode (int value)
		{
			int hash = ComputeHash (value);

			for (int i = 0; i < size; i++)
			{
				if (Flag[hash] == EmptyNode || Flag[hash] == LazyDeleted)
				{
					Data[hash] = value;
					Flag[hash] = FilledNode;
					return true;
				}

				hash += ResolveCollision (i);
				hash %= size;
			}

			return false;
		}

		internal virtual bool FindNode (int value)
		{
			int hash = ComputeHash (value);

			for (int i = 0; i < size; i++)
			{
				if (Flag[hash] == EmptyNode)
					return false;

				if (Flag[hash] == FilledNode && Data[hash] == value)
					return true;

				hash += ResolveCollision (i);
				hash %= size;
			}

			return false;
		}

		internal virtual bool DeleteNode (int value)
		{
			int hash = ComputeHash (value);

			for (int i = 0; i < size; i++)
			{
				if (Flag[hash] == EmptyNode)
					return false;

				if (Flag[hash] == FilledNode && Data[hash] == value)
				{
					Flag[hash] = LazyDeleted;
					return true;
				}

				hash += ResolveCollision (i);
				hash %= size;
			}

			return false;
		}

		internal virtual void Print ()
		{
			for (int i = 0; i < size; i++)
			{
				if (Flag[i] == FilledNode)
				{
					Console.WriteLine ("[{0} : {1}]", i, Data[i]);
				}
			}
		}

		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();

			for (int i = 0; i < size; i++)
			{
				if (Flag[i] == FilledNode)
				{
					builder.Append ($"[{i} : {Data[i]}]");
				}
			}

			return builder.ToString ();
		}
	}
}
