using Feature.FlipWall;
using UnityEngine;

namespace Feature.FlipWallColors
{
	public sealed class WallColorSystem : ScriptableObject, IWallColorSystem
	{
		[SerializeField] WallKeyColorsDictionary _wallColors = new();

		public bool TryGetColor(WallKey key, out Color color) =>
			_wallColors.TryGetValue(key, out color);
	}
}