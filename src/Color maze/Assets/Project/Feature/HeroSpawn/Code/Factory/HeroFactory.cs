
using Feature.HeroSpawn.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.HeroSpawn.Factory
{
	public sealed class HeroFactory : IHeroFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] IHeroAssetProvider _heroAssetProvider;

		public GameObject Create(Vector3 pos, Quaternion rot)
		{
			var prefab = _heroAssetProvider.HeroPrefab();
			var instance = _instantiator.InstantiatePrefab(prefab, pos, rot, null);
			return instance;
		}
	}
}