using CapLib.Common;
using Cysharp.Threading.Tasks;
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
			Spawn().Forget();
		}

		async UniTaskVoid Spawn()
		{
			if (CanSpawn() == false)
				return;

			var pos = _spawnPoint.Pos();
			var rot = _spawnPoint.Rot();
			var hero = await _factory.Create(pos, rot);
			if (hero == null)
				return;
		}

		bool CanSpawn() =>
			DebugAssert.IsNotNull(_spawnPoint) &&
			DebugAssert.IsNotNull(_factory);
	}
}