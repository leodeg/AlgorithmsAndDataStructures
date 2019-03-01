#pragma once

namespace DataStructures
{
	template <typename T>
	struct SNode
	{
	public:
		T Value;
		int Height;
		SNode<T>* Next[];
	};

	template <typename T>
	class SkiplistSSet
	{
	private:
		SNode<T>* m_Sential;
		int m_Length;
		SNode<T>* FindPredNode (T value);
	public:
		T Find (T value);
	};

	template <typename T>
	T DataStructures::SkiplistSSet<T>::Find (T value)
	{
		SNode<T>* node = FindPredNode (value);
		return node->Next[0] == nullptr ? nullptr : node->Next[0]->Value;
	}

	template <typename T>
	SNode<T>* DataStructures::SkiplistSSet<T>::FindPredNode (T value)
	{
		SNode<T>* node = m_Sential;
		int listIndex = m_Length;

		while (listIndex >= 0)
		{
			while (node->Next[listIndex] != nullptr && compare (node->Next[listIndex]->Value, value) < 0)
			{
				// Go right in list listIndex
				node = node->Next[listIndex];
			}
			// Go down into list listIndex - 1
			listIndex--;
		}

		return node;
	}

}
