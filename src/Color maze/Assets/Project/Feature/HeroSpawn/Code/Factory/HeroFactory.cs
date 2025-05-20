using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.HeroSpawn.Factory
{
	public sealed class HeroFactory : IHeroFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] IAssetProvider _assetProvider;

		public async UniTask<GameObject> Create(Vector3 pos, Quaternion rot)
		{
			var prefab = await _assetProvider.Load<GameObject>(AssetAddresses.Hero);
			if (prefab == null)
				return null;
			
			var instance = _instantiator.InstantiatePrefab(prefab, pos, rot, null);
			return instance;
		}
	}
}