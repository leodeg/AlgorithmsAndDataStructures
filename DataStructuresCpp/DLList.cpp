#include "DLList.h"

namespace DataStructures
{
	template <typename T>
	bool DataStructures::DLList<T>::Remove (int index)
	{
		if (index < 0 || index > length - 1) return false;
		return Remove (GetNode (index));
	}

	template <typename T>
	bool DataStructures::DLList<T>::Remove (DNode<T>* node)
	{
		if (node == nullptr) return false;

		node->Prev->Next = node->Next;
		node->Next->Prev = node->Prev;
		delete node;
		length--;
		return true;
	}

	template <typename T>
	void DataStructures::DLList<T>::AddAfter (int index, T data)
	{
		AddAfter (GetNode (index), data);
	}

	template <typename T>
	void DataStructures::DLList<T>::AddBefore (int index, T data)
	{
		AddBefore (GetNode (index), data);
	}

	template <typename T>
	DataStructures::DNode<T>* DataStructures::DLList<T>::AddAfter (DNode<T>* node, T data)
	{
		if (node == nullptr) return nullptr;

		DNode<T>* newNode = new DNode<T> (data);

		newNode->Next = node->Next;
		newNode->Prev = node;

		newNode->Next->Prev = newNode;
		newNode->Prev->Next = newNode;

		length++;
		return newNode;
	}

	template <typename T>
	DataStructures::DNode<T>* DataStructures::DLList<T>::AddBefore (DNode<T>* node, T data)
	{
		if (node == nullptr) return nullptr;

		DNode<T>* newNode = new DNode<T> (data);

		newNode->Prev = node->Prev;
		newNode->Next = node;

		newNode->Next->Prev = newNode;
		newNode->Prev->Next = newNode;

		length++;
		return node;
	}

	template <typename T>
	T DataStructures::DLList<T>::Set (int index, T data)
	{
		DNode<T>* node = GetNode (index);
		T temp = node->Value;
		node->Value = data;
		return temp;
	}

	template <typename T>
	T DataStructures::DLList<T>::Get (int index)
	{
		GetNode (index)->Value;
	}

	template <typename T>
	DataStructures::DLList<T>::DLList ()
	{
		m_Head.Next = &m_Head;
		m_Head.Prev = &m_Head;
		length = 0;
	}

	template <typename T>
	int DataStructures::DLList<T>::Count ()
	{
		return length;
	}

	template <typename T>
	DNode<T>* DataStructures::DLList<T>::GetNode (int index)
	{
		if (index < 0 || index > length - 1) return nullptr;

		DNode<T>* node;

		if (index < length / 2)
		{
			node = m_Head.Next;
			for (int i = 0; i < index; i++)
			{
				node = node->Next;
			}
		}
		else
		{
			node = &m_Head;
			for (int i = length; i > index; i--)
			{
				node = node->Prev;
			}
		}

		return node;
	}
}