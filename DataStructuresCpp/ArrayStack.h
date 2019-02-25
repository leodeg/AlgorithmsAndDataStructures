#pragma once

namespace DataStructures
{
	template <typename T>
	class ArrayStack
	{
	public:
		int Size ();
		void Resize ();
		T Get (int index);
		T Remove (int index);
		T Set (int index, T data);
		void Add (int index, T data);

	private:
		Array<T> m_Array;
		int m_Length;
	};
}
