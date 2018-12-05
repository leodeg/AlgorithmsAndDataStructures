namespace DataStructures
{
	class LinkedListNode<T>
	{
		/// <summary>
		/// Value of the current node
		/// </summary>
		public T Value { get; private set; }

		/// <summary>
		/// The current node constructor
		/// </summary>
		/// <param name="value"></param>
		public LinkedListNode (T value) { Value = value; }

		/// <summary>
		/// Reference to a next element
		/// </summary>
		public LinkedListNode<T> Next { get; internal set; }
	}
}
