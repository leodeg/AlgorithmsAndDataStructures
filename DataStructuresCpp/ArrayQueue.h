#pragma once

namespace DataStructures
{
	template <typename T>
	class ArrayQueue
	{
	private:
		int m_Length;
		Array<T> m_Array;
		int m_CurrentIndex;

	public:
		T Remove ();
		void Resize ();
		bool Add (T data);
	};
}