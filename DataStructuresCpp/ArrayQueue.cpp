#include "ArrayQueue.h"

namespace DataStructures
{
	template <typename T>
	void DataStructures::ArrayQueue<T>::Resize ()
	{
		Array<T> temp (max (1, 2 * m_Length));

		for (int i = 0; i < m_Length; i++)
		{
			temp[i] = m_Array[( m_CurrentIndex + i ) % m_Array.m_Length];
		}

		m_Array = temp;
		m_CurrentIndex = 0;
	}

	template <typename T>
	T DataStructures::ArrayQueue<T>::Remove ()
	{
		T tempData = m_Array[m_CurrentIndex];
		m_CurrentIndex = ( m_CurrentIndex + 1 ) % m_Array.m_Length;
		m_Length--;

		if (m_Array.m_Length >= 3 * m_Length) Resize ();
		return tempData;
	}

	template <typename T>
	bool DataStructures::ArrayQueue<T>::Add (T data)
	{
		if (m_Length + 1 > m_Array.m_Length) Resize ();
		m_Array[( m_CurrentIndex + m_Length ) % m_Array->m_Length] = data;
		m_Length++;
		return true;
	}
}