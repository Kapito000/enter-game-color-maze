using UnityEngine;

namespace CapLib.Common
{
	public static class DebugAssert
	{
		public static bool IsNotNull<T>(T obj)
		{
			if (obj == null)
			{
				Debug.LogError("DebugAssert::IsNotNull: obj is null.");
				return false;
			}

			return true;
		}
	}
}