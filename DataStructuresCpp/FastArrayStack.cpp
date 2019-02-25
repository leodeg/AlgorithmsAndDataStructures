#include "FastArrayStack.h"

namespace DataStructures
{
	template <typename T>
	int DataStructures::FastArrayStack<T>::Size ()
	{
		return m_Length;
	}

	template <typename T>
	T DataStructures::FastArrayStack<T>::Get (int index)
	{
		return m_Array[index];
	}

	template <typename T>
	T DataStructures::FastArrayStack<T>::Set (int index, T data)
	{
		T temp = m_Array[index];
		m_Array[index] = data;
		return temp;
	}

	template <typename T>
	void DataStructures::FastArrayStack<T>::Add (int index, T data)
	{
		if (m_Length + 1 > m_Array.m_Length) Resize ();
		std::copy_backward (m_Array + index, m_Array + m_Length, m_Array + m_Length + 1);
		m_Array[index] = data;
		m_Length++;
	}

	template <typename T>
	T DataStructures::FastArrayStack<T>::Remove (int index)
	{
		T temp = m_Array[index];

		for (int j = 0; j < m_Length - 1; j++)
		{
			m_Array[j] = m_Array[j + 1];
		}
		m_Length--;

		if (m_Array.m_Length >= 3 * n) Resize ();

		return temp;
	}

	template <typename T>
	void DataStructures::FastArrayStack<T>::Resize ()
	{
		Array<T> temp (max (1, 2 * m_Length));
		std::copy (m_Array + 0, m_Array + m_Length, temp + 0);
		m_Array = temp;
	}
}