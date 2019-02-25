#include "ArrayDeque.h"

namespace DataStructures
{
	template <typename T>
	void DataStructures::ArrayDeque<T>::Resize ()
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
	T DataStructures::ArrayDeque<T>::Remove (int index)
	{
		T temp = m_Array[( m_CurrentIndex + index ) % m_Array.length ()];

		if (index < m_Length / 2)
		{
			for (int i = index; i > 0; i--)
			{
				m_Array[( m_CurrentIndex + i ) % m_Array.length ()] = m_Array[( m_CurrentIndex + i - 1 ) % m_Array.length ()]
			}
			m_CurrentIndex = ( m_CurrentIndex + 1 ) % m_Array.length ();
		}
		else
		{
			for (int i = index; i < m_Length - 1; i++)
			{
				m_Array[( m_CurrentIndex + i ) % m_Array.length ()] = m_Array[( m_CurrentIndex + i + 1 ) % m_Array.length ()]
			}
		}
		m_Length--;

		if (3 * m_Length < m_Array.length ()) Resize ();
		return temp;
	}

	template <typename T>
	void DataStructures::ArrayDeque<T>::Add (int index, T data)
	{
		if (m_Length + 1 > m_Array.length ())
		{
			Resize ();
		}

		if (index < m_Length / 2)
		{
			m_CurrentIndex = ( m_CurrentIndex == 0 ) ? m_Array.length () - 1 : m_CurrentIndex - 1;
			for (int i = 0; i < m_CurrentIndex - 1; i++)
			{
				m_Array[( m_CurrentIndex + i ) % m_Array.length ()] = m_Array[( m_CurrentIndex + i + 1 ) % m_Array.length ()];
			}
		}
		else
		{
			for (int i = m_Length; i > m_CurrentIndex; i--)
			{
				m_Array[( m_CurrentIndex + i ) % m_Array.length ()] = m_Array[( m_CurrentIndex + i - 1 ) % m_Array.length ()];
			}
		}

		m_Array[( m_CurrentIndex + index ) % m_Array.length ()] = data;
		m_Length++;
	}

	template <typename T>
	T DataStructures::ArrayDeque<T>::Set (int index, T data)
	{
		int wantedIndex = ( m_CurrentIndex + index ) % m_Array.length ();
		T temp = m_Array[wantedIndex];
		m_Array[wantedIndex] = data;
		return temp;
	}

	template <typename T>
	T DataStructures::ArrayDeque<T>::Get (int index)
	{
		return m_Array[( m_CurrentIndex + index ) % m_Array.length ()];
	}
}