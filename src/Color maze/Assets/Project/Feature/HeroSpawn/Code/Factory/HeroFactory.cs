using Feature.HeroSpawn.StaticData;
using UnityEngine;
using Zenject;

namespace Feature.HeroSpawn.Factory
{
	public sealed class HeroFactory : IHeroFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] IHeroProvider _heroProvider;

		public GameObject Create(Vector3 pos, Quaternion rot)
		{
			var prefab = _heroProvider.Hero();
			if (prefab == null)
				return null;

			var instance = _instantiator.InstantiatePrefab(prefab, pos, rot, null);
			return instance;
		}
	}
}