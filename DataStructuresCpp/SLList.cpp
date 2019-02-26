#include "SLList.h"

namespace DataStructures
{
	template <typename T>
	int DataStructures::SSList<T>::Count ()
	{
		return length;
	}

	template <typename T>
	void DataStructures::SSList<T>::Add (T data)
	{
		Node* node = new Node (data);
		if (length == 0) head = node;
		else tail->Next = node;
		tail = node;
		length++;
	}

	template <typename T>
	T DataStructures::SSList<T>::Remove ()
	{
		Pop ();
	}

	template <typename T>
	T DataStructures::SSList<T>::Pop ()
	{
		if (length == 0) return nullptr;

		T data = head.Value;
		Node currentHead = head;
		head = head.Next;
		delete currentHead;

		if (--length == 0) tail == nullptr;
		return data;
	}

	template <typename T>
	void DataStructures::SSList<T>::Push (T data)
	{
		Node* node = new Node (data);
		node->Next = head;
		head = node;
		if (length == 0) tail = node;
		length++;
	}
}