#pragma once

namespace DataStructures
{
	template <typename T>
	struct Array
	{
	private:
		T *m_Array;
		int m_Length;

	public:

		int length () { return m_Length; }
		Array (int length);

		T& operator[](int index)
		{
			assert (index >= 0 && index < m_Length);
			return a[i];
		}

		Array<T>& operator=(Array<T> &b);
	};
}
