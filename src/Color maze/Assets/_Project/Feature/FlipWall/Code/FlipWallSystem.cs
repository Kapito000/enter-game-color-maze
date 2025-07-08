using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Feature.FlipWall
{
	public sealed class FlipWallSystem : MonoBehaviour, IFlipWallSystem,
		IDisposable
	{
		[SerializeField] WallKey _startAvailableWallKey;
		[SerializeField] WallKeyReactiveProperty _currentAvailableKey;

		Dictionary<WallKey, HashSet<IWall>> _walls = new();

		readonly Subject<Unit> _wallTurned = new();

		public IObservable<Unit> WallTurned => _wallTurned;

		public IReadOnlyReactiveProperty<WallKey> CurrentAvailableKey =>
			_currentAvailableKey;

		void Awake()
		{
			_currentAvailableKey.Value = _startAvailableWallKey;
		}

		void Start()
		{
			foreach (var wall in _walls[_startAvailableWallKey])
				wall.Block(false);
		}

		public void Registry(IWall wall, WallKey key)
		{
			if (_walls.ContainsKey(key) == false)
				_walls.Add(key, new HashSet<IWall>());

			_walls[key].Add(wall);
		}

		public void Flip()
		{
			foreach (var wall in _walls[_currentAvailableKey.Value])
				wall.Block(true);

			_currentAvailableKey.Value = _currentAvailableKey.Value.Flip();

			foreach (var wall in _walls[_currentAvailableKey.Value])
				wall.Block(false);

			WallFlipped();
		}

		void WallFlipped() =>
			_wallTurned.OnNext(Unit.Default);

		void OnDestroy()
		{
			Dispose();
		}

		public void Dispose()
		{
			_wallTurned.OnCompleted();
			_wallTurned.Dispose();
		}
	}
}