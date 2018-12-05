using System;
using DataStructures;

namespace DataStructures
{
	class Program
	{
		static void Main (string[] args)
		{
			LinkedList_MethodsTesting ();
		}

		#region My LinkedList Test

		static void LinkedList_MethodsTesting ()
		{
			DataStructures.LinkedList<int> linkedList = new DataStructures.LinkedList<int> ();

			#region Add Method
			linkedList.Add (10);
			linkedList.Add (15);
			linkedList.Add (20);
			linkedList.Add (25);
			linkedList.Add (30);
			linkedList.Add (35);

			DisplayList (ref linkedList, "Add Method");
			#endregion

			#region Remove Method
			linkedList.Remove (20);
			linkedList.Remove (25);
			linkedList.Remove (35);

			DisplayList (ref linkedList, "Remove Method");
			#endregion

			#region CopyTo Array Method
			int[] arr = new int[3];

			linkedList.CopyTo (arr, 0);

			DisplayList (ref linkedList, "CopyTo Method Display List");
			DisplayArray (ref arr, "CopyTo Method Display Array");
			#endregion

			#region Clear Method
			linkedList.Clear ();

			if (linkedList.Count == 0)
			{
				Console.WriteLine ("Clear Method");
				Console.WriteLine ("LinkedList is empty");
			}
			Console.WriteLine ("\n");
			#endregion
		}

		static void DisplayList(ref LinkedList<int> list, string testName)
		{
			Console.WriteLine (testName);

			foreach (var item in list)
			{
				Console.Write (item + " | ");
			}
			Console.WriteLine ("\n");
		}

		static void DisplayArray<T>(ref T[] arr, string testName)
		{
			Console.WriteLine (testName);

			foreach (var item in arr)
			{
				Console.Write (item + " | ");
			}
			Console.WriteLine ("\n");
		}

		#endregion
	}
}
