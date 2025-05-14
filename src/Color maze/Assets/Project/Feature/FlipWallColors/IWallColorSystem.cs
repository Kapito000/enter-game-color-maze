using CapLib.Common;
using Feature.FlipWall;
using UnityEngine;

namespace Feature.FlipWallColors
{
	public interface IWallColorSystem : ISystem
	{
		bool TryGetColor(WallKey key, out Color color);
	}
}