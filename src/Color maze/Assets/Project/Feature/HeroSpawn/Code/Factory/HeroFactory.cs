using CapLib.Instantiate;
using Feature.HeroSpawn.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.HeroSpawn.Factory
{
	public sealed class HeroFactory : IHeroFactory
	{
		[Inject] IInstantiateService _instantiate;
		[Inject] IHeroAssetProvider _heroAssetProvider;

		public GameObject Create(Vector3 pos, Quaternion rot)
		{
			var prefab = _heroAssetProvider.HeroPrefab();
			var instance = _instantiate.Instantiate(prefab, pos, rot);
			return instance;
		}
	}
}