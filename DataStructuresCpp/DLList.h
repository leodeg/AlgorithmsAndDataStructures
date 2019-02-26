#pragma once

namespace DataStructures
{
	template <typename T>
	class DNode
	{
	public:
		T Value;
		DNode<T> *Prev;
		DNode<T> *Next;

		DNode (T value)
		{
			Value = value;
			Prev = nullptr;
			Next = nullptr;
		}
	};

	template <typename T>
	class DLList
	{
	private:
		DNode<T> m_Head;
		int length;
		DNode<T>* GetNode (int index);
		DNode<T>* AddBefore (DNode<T>* node, T data);
		DNode<T>* AddAfter (DNode<T>* node, T data);
		bool Remove (DNode<T>* node);

	public:
		DLList ();
		int Count ();
		T Get (int index);
		T Set (int index, T data);
		void AddBefore (int index, T data);
		void AddAfter (int index, T data);
		bool Remove (int index);
	};
}