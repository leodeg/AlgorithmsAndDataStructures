#pragma once

namespace DataStructures
{
	template <typename T>
	class ArrayDeque
	{
	private:
		int m_Length;
		Array<T> m_Array;
		int m_CurrentIndex;

	public:
		T Get (int index);
		T Remove (int index);
		T Set (int index, T data);

		void Add (int index, T data);
		void Resize ();
	};
}