#pragma once

#include <array>
#include <list>

namespace DataStructures
{
	template <typename T>
	class ChainedDataStructures
	{
	private:
		std::array<std::list> m_HashTable;
		int m_Count;

	public:
		int Count ();
		int Length ();
		bool Add (T data);
		T Remove (T value);
		T Find (T value);
	};
}
