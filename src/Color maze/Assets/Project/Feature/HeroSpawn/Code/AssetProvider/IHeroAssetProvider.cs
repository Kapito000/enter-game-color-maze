using CapLib.Common;
using UnityEngine;

namespace Feature.HeroSpawn.AssetProvider
{
	public interface IHeroAssetProvider : IAssetProvider
	{
		GameObject HeroPrefab();
	}
}