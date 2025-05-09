using System.Collections.Generic;
using UnityEngine;

namespace Feature.FlipWall
{
	public sealed class FlipWallSystem : MonoBehaviour, IFlipWallSystem
	{
		WallKey _currentAvailableKey;
		Dictionary<WallKey, HashSet<IWall>> _walls = new();

		public void Registry(IWall wall, WallKey key)
		{
			if (_walls.ContainsKey(key) == false)
				_walls.Add(key, new HashSet<IWall>());

			_walls[key].Add(wall);
		}

		public void Flip()
		{
			foreach (var wall in _walls[_currentAvailableKey])
				wall.Block(true);

			_currentAvailableKey = _currentAvailableKey.Flip();

			foreach (var wall in _walls[_currentAvailableKey])
				wall.Block(false);
		}
	}
}