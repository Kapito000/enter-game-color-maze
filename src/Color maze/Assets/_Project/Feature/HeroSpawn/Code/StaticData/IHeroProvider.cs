using CapLib.Common;
using UnityEngine;

namespace Feature.HeroSpawn.StaticData
{
	public interface IHeroProvider : IAssetProvider
	{
		GameObject Hero();
	}
}