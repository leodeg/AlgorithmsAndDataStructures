#include "ArrayStack.h"

namespace DataStructures
{
	template <typename T>
	T DataStructures::ArrayStack<T>::Set (int index, T data)
	{
		T temp = m_Array[index];
		m_Array[index] = data;
		return temp;
	}

	template <typename T>
	void DataStructures::ArrayStack<T>::Add (int index, T data)
	{
		if (m_Length + 1 > m_Array.length) Resize ();

		for (int i = m_Length; i > index; i--)
		{
			m_Array[i] = m_Array[i - 1];
		}

		m_Array[index] = data;
		m_Length++;
	}

	template <typename T>
	T DataStructures::ArrayStack<T>::Remove (int index)
	{
		T temp = m_Array[index];

		for (int j = 0; j < m_Length - 1; j++)
		{
			m_Array[j] = m_Array[j + 1];
		}

		m_Length--;

		if (m_Array.length >= 3 * n) Resize ();

		return temp;
	}

	template <typename T>
	void DataStructures::ArrayStack<T>::Resize ()
	{
		Array<T> temp (max (2 * m_Length, 1));
		for (int i = 0; i < m_Length; i++)
		{
			temp[i] = m_Array[i];
		}
		m_Array = temp;
	}

	template <typename T>
	int DataStructures::ArrayStack<T>::Size ()
	{
		return m_Length;
	}

	template <typename T>
	T DataStructures::ArrayStack<T>::Get (int index)
	{
		return m_Array[index];
	}
}