using Feature.HeroSpawn.Factory;
using UnityEngine;
using Zenject;
using Debug = UnityEngine.Debug;

namespace Feature.HeroSpawn
{
	public sealed class HeroSpawnSystem : IHeroSpawnSystem
	{
		[Inject] IHeroFactory _factory;
		[Inject] IHeroSpawnPoint _spawnPoint;

		public bool TrySpawn(out GameObject hero)
		{
			var pos = _spawnPoint.Pos();
			var rot = _spawnPoint.Rot();
			hero = _factory.Create(pos, rot);
			if (hero == null)
			{
				Debug.LogError($"Can't spawn hero.");
				return false;
			}

			return true;
		}
	}
}