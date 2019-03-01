#include "ChainedHashTable.h"

namespace DataStructures
{
	template <typename T>
	T DataStructures::ChainedDataStructures<T>::Find (T value)
	{
		int index = hash (value);
		for (int i = 0; i < m_HashTable[index].size (); i++)
		{
			if (value == m_HashTable[index].get (i))
			{
				return m_HashTable ([index].get (i);
			}
		}
		return nullptr;
	}

	template <typename T>
	T DataStructures::ChainedDataStructures<T>::Remove (T value)
	{
		int index = hash (value);
		for (int i = 0; i < m_HashTable[index].size (); i++)
		{
			T temp = m_HashTable[index].get (i);
			if (value == temp)
			{
				m_HashTable[index].remove (i);
				m_Count--;
				return temp;
			}
		}
		return nullptr;
	}

	template <typename T>
	bool DataStructures::ChainedDataStructures<T>::Add (T data)
	{
		if (Find (data) != NULL) return false;
		if (m_Count + 1 > m_HashTable.length) resize ();
		m_HashTable[hash (data)].add (data);
		m_Count++;
		return true;
	}

	template <typename T>
	int DataStructures::ChainedDataStructures<T>::Count ()
	{
		return m_Count;
	}

	template <typename T>
	int DataStructures::ChainedDataStructures<T>::Length ()
	{
		return sizeof (m_HashTable) / sizeof (*m_HashTable))
	}
}
