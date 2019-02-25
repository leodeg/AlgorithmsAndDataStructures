#include "Array.h"

namespace DataStructures
{
	template <typename T>
	DataStructures::Array<T>& DataStructures::Array<T>::operator=(Array<T> &b)
	{
		if (a != NULL) delegate[]a;

		a = b.Array;
		b.Array = NULL;
		m_Length = b.m_Length;

		return *this;
	}

	template <typename T>
	DataStructures::Array<T>::Array (int length)
	{
		m_Length = length;
		m_Array = new T[m_Length];
	}
}