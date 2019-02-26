#pragma once

namespace DataStructures 
{
	template <typename T>
	struct Node
	{
		T Value;
		Node *Next;
		Node (T data)
		{
			Value = data;
			Next = nullptr;
		}
	};

	template <typename T>
	class SSList
	{
	public:
		int Count ();

		T Remove ();
		void Add (T data);

		T Pop ();
		void Push (T data);

	private:
		Node<T> *head;
		Node<T> *tail;
		int length;
	};
}
