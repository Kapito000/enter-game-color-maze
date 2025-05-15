using CapLib.Common;
using Feature.HeroSpawn.Factory;
using UnityEngine;
using Zenject;

namespace Feature.HeroSpawn
{
	public sealed class HeroSpawnSystem : MonoBehaviour, IHeroSpawnSystem
	{
		[Inject] IHeroFactory _factory;
		[Inject] IHeroSpawnPoint _spawnPoint;

		void Start()
		{
			Spawn();
		}

		void Spawn()
		{
			if (CanSpawn() == false)
				return;

			var pos = _spawnPoint.Pos();
			var rot = _spawnPoint.Rot();
			var heroObj = _factory.Create(pos, rot);
		}

		bool CanSpawn() =>
			DebugAssert.IsNotNull(_spawnPoint) &&
			DebugAssert.IsNotNull(_factory);
	}
}