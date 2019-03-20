namespace DataStructures.DataStructures.Hash
{
	public class CountMap<T>
	{
		internal System.Collections.Generic.Dictionary<T, int> hashMap;

		public CountMap ()
		{
			hashMap = new System.Collections.Generic.Dictionary<T, int> ();
		}

		public virtual void Add (T key)
		{
			if (hashMap.ContainsKey (key))
			{
				int count = hashMap[key];
				hashMap[key] = count + 1;
			}
			else
			{
				hashMap[key] = 1;
			}
		}

		public virtual void Remove (T key)
		{
			if (hashMap.ContainsKey (key))
			{
				if (hashMap[key] == 1)
				{
					hashMap.Remove (key);
				}
				else
				{
					int count = hashMap[key];
					hashMap[key] = count - 1;
				}
			}
		}

		public int ContainsKey (T key)
		{
			if (hashMap.ContainsKey (key))
			{
				return hashMap[key];
			}

			return 0;
		}

		public int GetSize ()
		{
			return hashMap.Count;
		}
	}
}
