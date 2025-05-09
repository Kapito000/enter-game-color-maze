using UnityEngine;

namespace Feature.FlipWall
{
	public static class WallKeyExtensions
	{
		public static WallKey Flip(this WallKey wallKey)
		{
			switch (wallKey)
			{
				case WallKey.Firs:
					return WallKey.Second;
				case WallKey.Second:
					return WallKey.Firs;

				default:
					var result = (WallKey)0;
					Debug.LogError($"Unknown wall key: {wallKey}." +
					               $"Returned \"{result}\".");
					return result;
			}
		}
	}
}